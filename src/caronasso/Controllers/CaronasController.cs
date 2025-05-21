using caronasso.Data;
using caronasso.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace caronasso.Controllers
{
    [Authorize]
    public class CaronasController : Controller
    {
        private readonly AppDbContext _context;

        public CaronasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Caronas
        public async Task<IActionResult> Index()
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var caronas = await _context.Caronas
                .Where(c => !c.Passageiros.Any(cp => cp.UsuarioId == currentUserId) && c.MotoristaId != currentUserId)
                .Include(c => c.Motorista)
                .ToListAsync();

            return View(caronas);
        }

        public async Task<IActionResult> MinhasCaronas()
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var caronas = await _context.CaronaPassageiros
                .Where(cp => cp.UsuarioId == currentUserId)
                .Include(cp => cp.Carona)
                    .ThenInclude(c => c.Motorista)
                .Select(cp => cp.Carona)
                .ToListAsync();

            return View(caronas);
        }

        public async Task<IActionResult> CaronasMotorista()
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var caronas = await _context.Caronas
                .Where(c => c.MotoristaId == currentUserId)
                .Include(c => c.Passageiros)
                    .ThenInclude(cp => cp.Usuario)
                .ToListAsync();

            return View(caronas);
        }

        public async Task<IActionResult> RemoverPassageiro(int caronaId, int usuarioId)
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var carona = await _context.Caronas
                .FirstOrDefaultAsync(c => c.Id == caronaId);

            if (carona == null || carona.MotoristaId != currentUserId)
            {
                TempData["Alerta"] = "Não foi possível excluir a carona";
                return RedirectToAction("Index", "Home");
            }

            var caronaPassageiro = await _context.CaronaPassageiros
                .FirstOrDefaultAsync(cp => cp.CaronaId == caronaId && cp.UsuarioId == usuarioId);

            if (caronaPassageiro != null)
            {
                _context.Remove(caronaPassageiro);
                await _context.SaveChangesAsync();
                //TempData["Alerta"] = "Carona excluída com sucesso!";
            }
            else
            {
                TempData["Alerta"] = "Não foi possível excluir a carona";
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction(nameof(CaronasMotorista));
        }

        // GET: Caronas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carona = await _context.Caronas
                .Include(c => c.Motorista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carona == null)
            {
                return NotFound();
            }

            return View(carona);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Join(int id)
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            CaronaPassageiro caronaP = new CaronaPassageiro
            {
                CaronaId = id,
                UsuarioId = currentUserId
            };

            var alreadyIn = await _context.CaronaPassageiros.FirstOrDefaultAsync(cp => cp.UsuarioId == currentUserId && cp.CaronaId == caronaP.CaronaId);

            var carona = await _context.Caronas.FirstOrDefaultAsync(ca => ca.Id == id);

            if (carona == null || carona.VagasDisponiveis < 1 || alreadyIn != null || carona.MotoristaId == currentUserId)
            {
                TempData["Alerta"] = "Erro ao entrar na carona.";
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                carona.VagasDisponiveis -= 1;
                _context.Add(caronaP);
                _context.Update(carona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Leave(int id)
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var carona = await _context.Caronas.FirstOrDefaultAsync(c => c.Id == id);

            var caronaP = await _context.CaronaPassageiros.FirstOrDefaultAsync(cp => cp.UsuarioId == currentUserId && cp.CaronaId == id);

            if (caronaP == null || carona == null)
            {
                TempData["Alerta"] = "Erro ao sair da carona";
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                carona.VagasDisponiveis += 1;
                _context.Remove(caronaP);
                _context.Update(carona);
                await _context.SaveChangesAsync();
                //TempData["Alerta"] = "Você saiu da carona com sucesso.";
                return RedirectToAction(nameof(MinhasCaronas));
            }

            return RedirectToAction("Index", "Home");
        }


        // GET: Caronas/Create
        public IActionResult Create()
        {
            ViewData["MotoristaId"] = new SelectList(_context.Usuarios, "Id", "Email");
            return View();
        }

        // POST: Caronas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Origem,Destino,HorarioSaida,VagasDisponiveis")] Carona carona)
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            carona.MotoristaId = currentUserId;

            // Gambiarra para o modelstate ser válido
            ModelState.Remove("Motorista");

            if (ModelState.IsValid)
            {
                _context.Add(carona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MotoristaId"] = new SelectList(_context.Usuarios, "Id", "Email", carona.MotoristaId);
            return View(carona);
        }

        // GET: Caronas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carona = await _context.Caronas.FindAsync(id);
            if (carona == null)
            {
                return NotFound();
            }
            ViewData["MotoristaId"] = new SelectList(_context.Usuarios, "Id", "Email", carona.MotoristaId);
            return View(carona);
        }

        // POST: Caronas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Origem,Destino,HorarioSaida,VagasDisponiveis,MotoristaId")] Carona carona)
        {
            if (id != carona.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaronaExists(carona.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MotoristaId"] = new SelectList(_context.Usuarios, "Id", "Email", carona.MotoristaId);
            return View(carona);
        }

        // GET: Caronas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carona = await _context.Caronas
                .Include(c => c.Motorista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carona == null)
            {
                return NotFound();
            }

            return View(carona);
        }

        // POST: Caronas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var carona = await _context.Caronas.FindAsync(id);

            if (carona.MotoristaId != currentUserId)
            {
                return Unauthorized();
            }

            if(carona == null)
            {
                TempData["Alerta"] = "Erro ao entrar na carona.";
                return RedirectToAction("Index", "Home");
            }


            var passageiros = _context.CaronaPassageiros.Where(cp => cp.CaronaId == id);
            _context.CaronaPassageiros.RemoveRange(passageiros);
            _context.Caronas.Remove(carona);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool CaronaExists(int id)
        {
            return _context.Caronas.Any(e => e.Id == id);
        }
    }
}
