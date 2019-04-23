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
    public class FooterInfoController : Controller
    {
        private readonly DBContext _context;

        public FooterInfoController(DBContext context)
        {
            _context = context;
        }

        // GET: FooterInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.FooterInfo.ToListAsync());
        }

        // GET: FooterInfo/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footerInfo = await _context.FooterInfo
                .FirstOrDefaultAsync(m => m.FooterId == id);
            if (footerInfo == null)
            {
                return NotFound();
            }

            return View(footerInfo);
        }

        // GET: FooterInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FooterInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PageCreateParentId,FooterId,FooterContent,ContentType")] FooterInfo footerInfo)
        {
            if (ModelState.IsValid)
            {
                footerInfo.FooterId = Guid.NewGuid();
                _context.Add(footerInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(footerInfo);
        }

        // GET: FooterInfo/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footerInfo = await _context.FooterInfo.FindAsync(id);
            if (footerInfo == null)
            {
                return NotFound();
            }
            return View(footerInfo);
        }

        // POST: FooterInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PageCreateParentId,FooterId,FooterContent,ContentType")] FooterInfo footerInfo)
        {
            if (id != footerInfo.FooterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(footerInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FooterInfoExists(footerInfo.FooterId))
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
            return View(footerInfo);
        }

        // GET: FooterInfo/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footerInfo = await _context.FooterInfo
                .FirstOrDefaultAsync(m => m.FooterId == id);
            if (footerInfo == null)
            {
                return NotFound();
            }

            return View(footerInfo);
        }

        // POST: FooterInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var footerInfo = await _context.FooterInfo.FindAsync(id);
            _context.FooterInfo.Remove(footerInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FooterInfoExists(Guid id)
        {
            return _context.FooterInfo.Any(e => e.FooterId == id);
        }
    }
}
