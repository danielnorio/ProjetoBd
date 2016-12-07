using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoDeBancoDeDados.Data;
using ProjetoDeBancoDeDados.Models;

namespace ProjetoDeBancoDeDados.Controllers
{
    public class SeguradorasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeguradorasController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Seguradoras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Seguradora.ToListAsync());
        }

        // GET: Seguradoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seguradora = await _context.Seguradora.SingleOrDefaultAsync(m => m.ID == id);
            if (seguradora == null)
            {
                return NotFound();
            }

            return View(seguradora);
        }

        // GET: Seguradoras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seguradoras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CNPJ,Email,Endereco,Nome,Telefone")] Seguradora seguradora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seguradora);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(seguradora);
        }

        // GET: Seguradoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seguradora = await _context.Seguradora.SingleOrDefaultAsync(m => m.ID == id);
            if (seguradora == null)
            {
                return NotFound();
            }
            return View(seguradora);
        }

        // POST: Seguradoras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CNPJ,Email,Endereco,Nome,Telefone")] Seguradora seguradora)
        {
            if (id != seguradora.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seguradora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeguradoraExists(seguradora.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(seguradora);
        }

        // GET: Seguradoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seguradora = await _context.Seguradora.SingleOrDefaultAsync(m => m.ID == id);
            if (seguradora == null)
            {
                return NotFound();
            }

            return View(seguradora);
        }

        // POST: Seguradoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seguradora = await _context.Seguradora.SingleOrDefaultAsync(m => m.ID == id);
            _context.Seguradora.Remove(seguradora);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SeguradoraExists(int id)
        {
            return _context.Seguradora.Any(e => e.ID == id);
        }
    }
}
