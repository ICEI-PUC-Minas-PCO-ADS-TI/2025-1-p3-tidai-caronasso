using caronasso.Data;
using caronasso.Models;
using caronasso.Models.DTOs;
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
    public class ChatsController : Controller
    {
        private readonly AppDbContext _context;

        public ChatsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Chats
        public async Task<IActionResult> Index()
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            ViewBag.currentUserId = currentUserId;

            return View(await _context.Chats
                .Include(chat => chat.Participantes)
                    .ThenInclude(chatp => chatp.Usuario)
                .Include(chat => chat.Mensagens)
                .Where(chat => chat.Participantes.Any(chatp => chatp.UsuarioId == currentUserId))
                .ToListAsync());
        }

        // GET: Chats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chat = await _context.Chats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chat == null)
            {
                return NotFound();
            }

            return View(chat);
        }

        // GET: Chats/Create
        [HttpGet]
        public async Task<IActionResult> Create(int? idUsuario)
        {
            if(idUsuario.HasValue)
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == idUsuario);
                ViewBag.DestinatarioNome = usuario.Nome;
                ViewBag.DestinatarioId = usuario.Id;
            } 
            else
            {
                return RedirectToAction("Index", "Home");
            }

                return View();
        }

        // POST: Chats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateChat(int? destinatarioId)
        {
            if(!destinatarioId.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }

            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var currentUser = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == destinatarioId);

            var existingChat = await _context.Chats
                .Where(ch => ch.Participantes.Any(p => p.UsuarioId == currentUserId) &&
                             ch.Participantes.Any(p => p.UsuarioId == destinatarioId) &&
                             ch.Participantes.Count == 2)
                .FirstOrDefaultAsync();

            if(existingChat != null)
            {
                return RedirectToAction("Index");
            }

            var existingUser = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == destinatarioId);

            if(existingUser == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var chat = new Chat
            {
                Titulo = $"{existingUser.Nome} & {currentUser.Nome}",
                UltimaMensagemData = DateTime.Now
            };

            _context.Add(chat);
            await _context.SaveChangesAsync();

            ChatParticipante pUsuario = new ChatParticipante { ChatId = chat.Id, UsuarioId = currentUserId };
            ChatParticipante pDestinatario = new ChatParticipante { ChatId = chat.Id, UsuarioId = (int)destinatarioId };

            _context.Add(pUsuario);
            _context.Add(pDestinatario);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            //return View(chat);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageDTO message)
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            // PRECISA CRIAR UMA VERIFICAÇÃO PARA VER SE O USUÁRIO QUE ESTÁ ENVIANDO A MENSAGEM ESTÁ NO CHAT
            Mensagem msgObj = new Mensagem
            {
                ChatId = message.ChatId,
                Conteudo = message.Conteudo,
                RemetenteId = currentUserId,
            };

            _context.Mensagens.Add(msgObj);
            await _context.SaveChangesAsync();

            return base.Created();
        }
        [HttpGet]
        public async Task<IActionResult> GetMessages(int chatId)
        {
            var currentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            // PRECISA CRIAR UMA VERIFICAÇÃO PARA VER SE O USUÁRIO QUE ESTÁ ACESSANDO AS MENSAGENS ESTÁ NO CHAT

            var messages = await _context.Mensagens
                .Where(m => m.ChatId == chatId)
                .Include(m => m.Remetente)
                .OrderBy(m => m.HorarioEnvio)
                .Select(m => new
                {
                    Remetente = m.Remetente.Nome,
                    m.Conteudo,
                    Horario = m.HorarioEnvio.ToString("HH:mm")
                })
                .ToListAsync();


            return Json(messages);
        }



        // GET: Chats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chat = await _context.Chats.FindAsync(id);
            if (chat == null)
            {
                return NotFound();
            }
            return View(chat);
        }

        // POST: Chats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Conteudo,HorarioEnvio")] Chat chat)
        {
            if (id != chat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatExists(chat.Id))
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
            return View(chat);
        }

        // GET: Chats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chat = await _context.Chats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chat == null)
            {
                return NotFound();
            }

            return View(chat);
        }

        // POST: Chats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chat = await _context.Chats.FindAsync(id);
            if (chat != null)
            {
                _context.Chats.Remove(chat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatExists(int id)
        {
            return _context.Chats.Any(e => e.Id == id);
        }
    }
}
