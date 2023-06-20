using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HK_Database.Data;
using HK_Database.Models;

namespace HK_Database.Controllers
{
    public class ChatsController : Controller
    {
        private readonly HKContext _context;

        public ChatsController(HKContext context)
        {
            _context = context;
        }

        // GET: Chats
        public async Task<IActionResult> Index()
        {
            var hKContext = _context.Chats.Include(c => c.Users);
            return View(await hKContext.ToListAsync());
        }

        // GET: Chats/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var chats = await _context.Chats
                .Include(c => c.Users)
                .FirstOrDefaultAsync(m => m.ChatId == id);
            if (chats == null)
            {
                return NotFound();
            }

            return View(chats);
        }

        // GET: Chats/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: Chats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChatId,ChatData,ChatName,UserId")] Chats chats)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chats);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", chats.UserId);
            return View(chats);
        }

        // GET: Chats/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chats = await _context.Chats.FindAsync(id);
            if (chats == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", chats.UserId);
            return View(chats);
        }

        // POST: Chats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ChatId,ChatData,ChatName,UserId")] Chats chats)
        {
            if (id != chats.ChatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chats);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatsExists(chats.ChatId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", chats.UserId);
            return View(chats);
        }

        // GET: Chats/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chats = await _context.Chats
                .Include(c => c.Users)
                .FirstOrDefaultAsync(m => m.ChatId == id);
            if (chats == null)
            {
                return NotFound();
            }

            return View(chats);
        }

        // POST: Chats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var chats = await _context.Chats.FindAsync(id);
            _context.Chats.Remove(chats);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatsExists(string id)
        {
            return _context.Chats.Any(e => e.ChatId == id);
        }
    }
}
