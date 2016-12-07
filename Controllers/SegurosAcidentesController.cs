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
    public class SegurosAcidentesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SegurosAcidentesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: SegurosAcidentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SeguroAcidente.ToListAsync());
        }

        // GET: SegurosAcidentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seguroAcidente = await _context.SeguroAcidente.SingleOrDefaultAsync(m => m.ID == id);
            if (seguroAcidente == null)
            {
                return NotFound();
            }

            return View(seguroAcidente);
        }

        // GET: SegurosAcidentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SegurosAcidentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Numero,Tipo,Titular,Validade,Valor")] SeguroAcidente seguroAcidente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seguroAcidente);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(seguroAcidente);
        }

        // GET: SegurosAcidentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seguroAcidente = await _context.SeguroAcidente.SingleOrDefaultAsync(m => m.ID == id);
            if (seguroAcidente == null)
            {
                return NotFound();
            }
            return View(seguroAcidente);
        }

        // POST: SegurosAcidentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Numero,Tipo,Titular,Validade,Valor")] SeguroAcidente seguroAcidente)
        {
            if (id != seguroAcidente.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seguroAcidente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeguroAcidenteExists(seguroAcidente.ID))
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
            return View(seguroAcidente);
        }

        // GET: SegurosAcidentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seguroAcidente = await _context.SeguroAcidente.SingleOrDefaultAsync(m => m.ID == id);
            if (seguroAcidente == null)
            {
                return NotFound();
            }

            return View(seguroAcidente);
        }

        // POST: SegurosAcidentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seguroAcidente = await _context.SeguroAcidente.SingleOrDefaultAsync(m => m.ID == id);
            _context.SeguroAcidente.Remove(seguroAcidente);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SeguroAcidenteExists(int id)
        {
            return _context.SeguroAcidente.Any(e => e.ID == id);
        }
    }
}
