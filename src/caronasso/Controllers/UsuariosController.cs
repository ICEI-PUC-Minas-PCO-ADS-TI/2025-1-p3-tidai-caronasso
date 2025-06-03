using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using caronasso.Data;
using caronasso.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace caronasso.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Usuarios.ToListAsync());
        //}

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (id == null)
            {
                id = currentUserId;
            }

            var usuario = await _context.Usuarios
                .Include(u => u.AvaliacoesRecebidas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            ViewBag.IsOwnProfile = currentUserId == usuario.Id;

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var usuario = await _context.Usuarios.FindAsync(currentUserId);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, [Bind("Nome,Email,Senha,Curso,Endereco,Descricao,Genero")] Usuario usuario, IFormFile? fotoPerfilUpload)
        {
            //if (id != usuario.Id)
            //{
            //    return NotFound();
            //}

            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var currentUser = await _context.Usuarios.FindAsync(currentUserId);

            if (id != currentUserId || currentUser == null)
            {
                return Unauthorized();
            }

            if (fotoPerfilUpload != null && fotoPerfilUpload.Length > 0)
            {
                string[] allowedExtensions = [".jpg", ".jpeg", ".png"];

                var profilePhotosFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/uploads/profilePhotos");

                var fileExtension = Path.GetExtension(fotoPerfilUpload.FileName);

                if (String.IsNullOrEmpty(fileExtension) || !allowedExtensions.Contains(fileExtension.ToLowerInvariant()))
                {
                    return RedirectToAction("Index", "Home");
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(fotoPerfilUpload.FileName);
                var filePath = Path.Combine(profilePhotosFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await fotoPerfilUpload.CopyToAsync(stream);
                }

                if(!string.IsNullOrEmpty(currentUser.FotoPerfil))
                {
                    var oldPhotoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", currentUser.FotoPerfil.TrimStart('/'));

                    if (System.IO.File.Exists(oldPhotoPath))
                    {
                        System.IO.File.Delete(oldPhotoPath);
                    }
                }


                currentUser.FotoPerfil = "/assets/uploads/profilePhotos/" + fileName;
            }
           

            currentUser.Nome = usuario.Nome;
            currentUser.Email = usuario.Email;
            currentUser.Curso = usuario.Curso;
            currentUser.Endereco = usuario.Endereco;
            currentUser.Descricao = usuario.Descricao;
            currentUser.Genero = usuario.Genero;
            
            if(!string.IsNullOrEmpty(usuario.Senha))
            {
                currentUser.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            } else
            {
                ModelState.Remove("Senha");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currentUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details));
            }
            return View(currentUser);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
