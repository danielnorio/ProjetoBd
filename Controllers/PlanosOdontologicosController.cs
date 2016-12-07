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
    public class PlanosOdontologicosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlanosOdontologicosController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: PlanoOdontologicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlanoOdontologico.ToListAsync());
        }

        // GET: PlanoOdontologicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoOdontologico = await _context.PlanoOdontologico.SingleOrDefaultAsync(m => m.ID == id);
            if (planoOdontologico == null)
            {
                return NotFound();
            }

            return View(planoOdontologico);
        }

        // GET: PlanoOdontologicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlanoOdontologicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Numero,Tipo,Titular,Validade,Valor")] PlanoOdontologico planoOdontologico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planoOdontologico);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(planoOdontologico);
        }

        // GET: PlanoOdontologicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoOdontologico = await _context.PlanoOdontologico.SingleOrDefaultAsync(m => m.ID == id);
            if (planoOdontologico == null)
            {
                return NotFound();
            }
            return View(planoOdontologico);
        }

        // POST: PlanoOdontologicoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Numero,Tipo,Titular,Validade,Valor")] PlanoOdontologico planoOdontologico)
        {
            if (id != planoOdontologico.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planoOdontologico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanoOdontologicoExists(planoOdontologico.ID))
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
            return View(planoOdontologico);
        }

        // GET: PlanoOdontologicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoOdontologico = await _context.PlanoOdontologico.SingleOrDefaultAsync(m => m.ID == id);
            if (planoOdontologico == null)
            {
                return NotFound();
            }

            return View(planoOdontologico);
        }

        // POST: PlanoOdontologicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planoOdontologico = await _context.PlanoOdontologico.SingleOrDefaultAsync(m => m.ID == id);
            _context.PlanoOdontologico.Remove(planoOdontologico);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PlanoOdontologicoExists(int id)
        {
            return _context.PlanoOdontologico.Any(e => e.ID == id);
        }
    }
}
