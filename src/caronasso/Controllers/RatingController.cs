using caronasso.Data;
using caronasso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace caronasso.Controllers;
public class RatingController : Controller
{
    private readonly AppDbContext _context;

    public RatingController(AppDbContext context)
    {
        _context = context;
    }

    //public IActionResult Index()
    //{
    //    return View();
    //}

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Rate(int idRatedUser, int ratingValue, string descricao)
    {
        var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

        //var carona = await _context.Caronas.FirstOrDefaultAsync(c => c.MotoristaId == idRatedUser);

        var caronaP = await _context.CaronaPassageiros.FirstOrDefaultAsync(cp => cp.UsuarioId == currentUserId && cp.Carona.MotoristaId == idRatedUser);

        var rating = await _context.AvaliacoesUsuarios.FirstOrDefaultAsync(au => au.UsuarioAvaliadorId == currentUserId && au.UsuarioAvaliadoId == idRatedUser);

        if (caronaP == null || ratingValue < 1 || ratingValue > 5)
        {
            TempData["Alerta"] = "Erro ao avaliar usuario";
            return RedirectToAction("Index", "Home");
        }

        if (ModelState.IsValid)
        {
            if(rating != null)
            {
                rating.Nota = ratingValue;
                rating.Comentario = descricao;
                rating.DataAvaliacao = DateTime.Now;
            }
            else
            {
                rating = new AvaliacaoUsuario
                {
                    UsuarioAvaliadorId = currentUserId,
                    UsuarioAvaliadoId = idRatedUser,
                    Comentario = descricao,
                    Nota = ratingValue
                };

                _context.AvaliacoesUsuarios.Add(rating);
            }
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index", "Home");
    }

}
