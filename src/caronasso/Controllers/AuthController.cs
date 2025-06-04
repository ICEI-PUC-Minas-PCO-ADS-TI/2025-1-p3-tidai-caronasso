using caronasso.Data;
using caronasso.Models;
using caronasso.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace caronasso.Controllers;

public class AuthController : Controller
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cadastrar(LoginCadastroViewModel model)
    {
        ModelState.Remove("Login");

        string emailPermitido = "@sga.pucminas.br";

        if(!model.Cadastro.Email.ToLower().EndsWith(emailPermitido))
        {
            ModelState.AddModelError("Cadastro.Email", "Somente e-mails da PUC são aceitos.");
            return View("Index", model);
        }

        if (ModelState.IsValid) 
        {
            Usuario? usuarioExistente = await _context.Usuarios.Where(c => c.Email == model.Cadastro.Email).FirstOrDefaultAsync();

            if(usuarioExistente == null)
            {
                Usuario usuario = new Usuario()
                {
                    Nome = model.Cadastro.Nome,
                    Email = model.Cadastro.Email,
                    Senha = BCrypt.Net.BCrypt.HashPassword(model.Cadastro.Senha),
                    Curso = model.Cadastro.Curso
                };

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.CadastroMsg = "Email já usado!";
            }
        }

        //return RedirectToAction("Index", "Home");
        return View("Index", model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginCadastroViewModel model)
    {
        ModelState.Remove("Cadastro");

        if(ModelState.IsValid)
        {
            Usuario? usuario = await _context.Usuarios.Where(c => c.Email == model.Login.Email).FirstOrDefaultAsync();

            if (usuario != null && BCrypt.Net.BCrypt.Verify(model.Login.Senha, usuario.Senha))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Email),
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Perfil.ToString())
                };

                var usuarioIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentity);

                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(principal, props);

                ViewBag.LoginMsg = "Usuário autenticado com sucesso!";

                return Redirect("/");
            } 
            else
            {
                ViewBag.LoginMsg = "Usuário e/ou senha incorretos!";
            }
        }
        //return RedirectToAction("Index", "Home");
        return View("Index", model);
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }
}
