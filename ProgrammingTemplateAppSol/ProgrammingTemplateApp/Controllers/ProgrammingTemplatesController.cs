using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgrammingTemplateApp.Data;
using ProgrammingTemplateApp.Models;

namespace ProgrammingTemplateApp.Controllers
{
    public class ProgrammingTemplatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProgrammingTemplatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProgrammingTemplates
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProgrammingTemplates.ToListAsync());
        }

        // GET: ProgrammingTemplates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programmingTemplate = await _context.ProgrammingTemplates
                .FirstOrDefaultAsync(m => m.ProgrammingTemplateId == id);
            if (programmingTemplate == null)
            {
                return NotFound();
            }

            return View(programmingTemplate);
        }

        // GET: ProgrammingTemplates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProgrammingTemplates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgrammingTemplateId,Title,Description,Price,ProgrammingLanguage,CreatedDate")] ProgrammingTemplate programmingTemplate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programmingTemplate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programmingTemplate);
        }

        // GET: ProgrammingTemplates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programmingTemplate = await _context.ProgrammingTemplates.FindAsync(id);
            if (programmingTemplate == null)
            {
                return NotFound();
            }
            return View(programmingTemplate);
        }

        // POST: ProgrammingTemplates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProgrammingTemplateId,Title,Description,Price,ProgrammingLanguage,CreatedDate")] ProgrammingTemplate programmingTemplate)
        {
            if (id != programmingTemplate.ProgrammingTemplateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programmingTemplate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgrammingTemplateExists(programmingTemplate.ProgrammingTemplateId))
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
            return View(programmingTemplate);
        }

        // GET: ProgrammingTemplates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programmingTemplate = await _context.ProgrammingTemplates
                .FirstOrDefaultAsync(m => m.ProgrammingTemplateId == id);
            if (programmingTemplate == null)
            {
                return NotFound();
            }

            return View(programmingTemplate);
        }

        // POST: ProgrammingTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programmingTemplate = await _context.ProgrammingTemplates.FindAsync(id);
            if (programmingTemplate != null)
            {
                _context.ProgrammingTemplates.Remove(programmingTemplate);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgrammingTemplateExists(int id)
        {
            return _context.ProgrammingTemplates.Any(e => e.ProgrammingTemplateId == id);
        }
    }
}
