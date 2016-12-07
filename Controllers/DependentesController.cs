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
    public class DependentesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DependentesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Dependentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dependente.ToListAsync());
        }

        // GET: Dependentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependente = await _context.Dependente.SingleOrDefaultAsync(m => m.ID == id);
            if (dependente == null)
            {
                return NotFound();
            }

            return View(dependente);
        }

        // GET: Dependentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dependentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CPF,Email,Nome,RG,Telefone")] Dependente dependente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dependente);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dependente);
        }

        // GET: Dependentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependente = await _context.Dependente.SingleOrDefaultAsync(m => m.ID == id);
            if (dependente == null)
            {
                return NotFound();
            }
            return View(dependente);
        }

        // POST: Dependentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CPF,Email,Nome,RG,Telefone")] Dependente dependente)
        {
            if (id != dependente.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dependente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DependenteExists(dependente.ID))
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
            return View(dependente);
        }

        // GET: Dependentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependente = await _context.Dependente.SingleOrDefaultAsync(m => m.ID == id);
            if (dependente == null)
            {
                return NotFound();
            }

            return View(dependente);
        }

        // POST: Dependentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dependente = await _context.Dependente.SingleOrDefaultAsync(m => m.ID == id);
            _context.Dependente.Remove(dependente);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DependenteExists(int id)
        {
            return _context.Dependente.Any(e => e.ID == id);
        }
    }
}
