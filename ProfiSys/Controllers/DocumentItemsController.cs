using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProfiSys.Data;
using ProfiSys.Models;

namespace ProfiSys.Controllers
{
    public class DocumentItemsController : Controller
    {
        private readonly DocumentContext _context;

        public DocumentItemsController(DocumentContext context)
        {
            _context = context;
        }

        // GET: DocumentItems
        public async Task<IActionResult> Index()
        {
              return _context.DocumentItem != null ? 
                          View(await _context.DocumentItem.ToListAsync()) :
                          Problem("Entity set 'DocumentContext.DocumentItem'  is null.");
        }

        // GET: DocumentItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DocumentItem == null)
            {
                return NotFound();
            }

            var documentItem = await _context.DocumentItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentItem == null)
            {
                return NotFound();
            }

            return View(documentItem);
        }

        // GET: DocumentItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DocumentItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ordinal,Product,Quantity,Price,TaxRate")] DocumentItem documentItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(documentItem);
        }

        // GET: DocumentItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DocumentItem == null)
            {
                return NotFound();
            }

            var documentItem = await _context.DocumentItem.FindAsync(id);
            if (documentItem == null)
            {
                return NotFound();
            }
            return View(documentItem);
        }

        // POST: DocumentItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ordinal,Product,Quantity,Price,TaxRate")] DocumentItem documentItem)
        {
            if (id != documentItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentItemExists(documentItem.Id))
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
            return View(documentItem);
        }

        // GET: DocumentItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DocumentItem == null)
            {
                return NotFound();
            }

            var documentItem = await _context.DocumentItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentItem == null)
            {
                return NotFound();
            }

            return View(documentItem);
        }

        // POST: DocumentItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DocumentItem == null)
            {
                return Problem("Entity set 'DocumentContext.DocumentItem'  is null.");
            }
            var documentItem = await _context.DocumentItem.FindAsync(id);
            if (documentItem != null)
            {
                _context.DocumentItem.Remove(documentItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentItemExists(int id)
        {
          return (_context.DocumentItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
