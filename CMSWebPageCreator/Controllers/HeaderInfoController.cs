using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMSWebPageCreator.Models;

namespace CMSWebPageCreator.Controllers
{
    public class HeaderInfoController : Controller
    {
        private readonly DBContext _context;

        public HeaderInfoController(DBContext context)
        {
            _context = context;
        }

        // GET: HeaderInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.HeaderInfo.ToListAsync());
        }

        // GET: HeaderInfo/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headerInfo = await _context.HeaderInfo
                .FirstOrDefaultAsync(m => m.HeaderItem == id);
            if (headerInfo == null)
            {
                return NotFound();
            }

            return View(headerInfo);
        }

        // GET: HeaderInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HeaderInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PageCreateParentId,HeaderItem,HeaderContent,ContentType")] HeaderInfo headerInfo)
        {
            if (ModelState.IsValid)
            {
                headerInfo.HeaderItem = Guid.NewGuid();
                _context.Add(headerInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(headerInfo);
        }

        // GET: HeaderInfo/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headerInfo = await _context.HeaderInfo.FindAsync(id);
            if (headerInfo == null)
            {
                return NotFound();
            }
            return View(headerInfo);
        }

        // POST: HeaderInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PageCreateParentId,HeaderItem,HeaderContent,ContentType")] HeaderInfo headerInfo)
        {
            if (id != headerInfo.HeaderItem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(headerInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeaderInfoExists(headerInfo.HeaderItem))
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
            return View(headerInfo);
        }

        // GET: HeaderInfo/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headerInfo = await _context.HeaderInfo
                .FirstOrDefaultAsync(m => m.HeaderItem == id);
            if (headerInfo == null)
            {
                return NotFound();
            }

            return View(headerInfo);
        }

        // POST: HeaderInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var headerInfo = await _context.HeaderInfo.FindAsync(id);
            _context.HeaderInfo.Remove(headerInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeaderInfoExists(Guid id)
        {
            return _context.HeaderInfo.Any(e => e.HeaderItem == id);
        }
    }
}
