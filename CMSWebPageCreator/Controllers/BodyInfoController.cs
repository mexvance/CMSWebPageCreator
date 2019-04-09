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
    public class BodyInfoController : Controller
    {
        private readonly DBContext _context;

        public BodyInfoController(DBContext context)
        {
            _context = context;
        }

        // GET: BodyInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.BodyInfo.ToListAsync());
        }

        // GET: BodyInfo/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyInfo = await _context.BodyInfo
                .FirstOrDefaultAsync(m => m.BodyItem == id);
            if (bodyInfo == null)
            {
                return NotFound();
            }

            return View(bodyInfo);
        }

        // GET: BodyInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BodyInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PageCreateParentId,BodyItem,BodyContent,ContentType")] BodyInfo bodyInfo)
        {
            if (ModelState.IsValid)
            {
                bodyInfo.BodyItem = Guid.NewGuid();
                _context.Add(bodyInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bodyInfo);
        }

        // GET: BodyInfo/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyInfo = await _context.BodyInfo.FindAsync(id);
            if (bodyInfo == null)
            {
                return NotFound();
            }
            return View(bodyInfo);
        }

        // POST: BodyInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PageCreateParentId,BodyItem,BodyContent,ContentType")] BodyInfo bodyInfo)
        {
            if (id != bodyInfo.BodyItem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodyInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BodyInfoExists(bodyInfo.BodyItem))
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
            return View(bodyInfo);
        }

        // GET: BodyInfo/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyInfo = await _context.BodyInfo
                .FirstOrDefaultAsync(m => m.BodyItem == id);
            if (bodyInfo == null)
            {
                return NotFound();
            }

            return View(bodyInfo);
        }

        // POST: BodyInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bodyInfo = await _context.BodyInfo.FindAsync(id);
            _context.BodyInfo.Remove(bodyInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BodyInfoExists(Guid id)
        {
            return _context.BodyInfo.Any(e => e.BodyItem == id);
        }
    }
}
