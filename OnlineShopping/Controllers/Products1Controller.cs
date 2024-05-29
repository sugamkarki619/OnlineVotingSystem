using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers
{
    public class Products1Controller : Controller
    {
        private readonly OnlineShoppingContext _context;

        public Products1Controller(OnlineShoppingContext context)
        {
            _context = context;
        }

        // GET: Products1
        public async Task<IActionResult> Index()
        {
              return _context.Product != null ? 
                          View(await _context.Product.ToListAsync()) :
                          Problem("Entity set 'OnlineShoppingContext.Product'  is null.");
        }

        // GET: Products1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,title,description,price,Categoryid")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,title,description,price,Categoryid")] Product product)
        {
            if (id != product.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.id))
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
            return View(product);
        }

        // GET: Products1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'OnlineShoppingContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Product?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
