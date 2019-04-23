using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMSWebPageCreator.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CMSWebPageCreator.Controllers
{
    public class PageCreatesController : Controller
    {
        private readonly DBContext _context;
        private UserManager<IdentityUser> _userManager;

        public PageCreatesController(DBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: PageCreates
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            return View(await _context.PageCreate.ToListAsync());

        }

        // GET: PageCreates/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageCreate = await _context.PageCreate
                .FirstOrDefaultAsync(m => m.pageId == id);
            if (pageCreate == null)
            {
                return NotFound();
            }

            //ViewBag.MyBody = await _context.BodyInfo.Where(c => c.PageCreateParentId == id).ToListAsync();
            //ViewBag.MyHeader = await _context.HeaderInfo.Where(c => c.PageCreateParentId == id).ToListAsync();
            pageCreate.Headers = await _context.HeaderInfo.Where(c => c.PageCreateParentId == id).ToListAsync();

            return View(pageCreate);
        }

        // GET: PageCreates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PageCreates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("pageId,Title")] PageCreate pageCreate)
        {
            if (ModelState.IsValid)
            {
                pageCreate.pageId = Guid.NewGuid();

                _context.Add(pageCreate);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", new { id = pageCreate.pageId });
            }
            return View(pageCreate);
        }

        // GET: PageCreates/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageCreate = await _context.PageCreate.FindAsync(id);
            if (pageCreate == null)
            {
                return NotFound();
            }
            ViewBag.MyBody = await _context.BodyInfo.Where(c => c.PageCreateParentId == id).ToListAsync();
            pageCreate.Headers = await _context.HeaderInfo.Where(c => c.PageCreateParentId == id).ToListAsync();
            pageCreate.Headers.Add(new HeaderInfo());
            ViewBag.MyFooter = await _context.FooterInfo.Where(c => c.PageCreateParentId == id).ToListAsync();
           
            return View(pageCreate);
        }

        // POST: PageCreates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("pageId,Title")] PageCreate pageCreate)
        {
            if (id != pageCreate.pageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pageCreate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageCreateExists(pageCreate.pageId))
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
            return View(pageCreate);
        }


        //Hey Add this function from here to here, that being the end of this function. Thanks
        //Also do this for Header Footer, 
        //Other things to look at (on the edit view, we should load a dropdown of the ContentType )

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MyHeaderCreate(/*Guid id,*/ [Bind("pageId,Title,MyHeader")] PageCreate pageCreate)
        {
            //if (id != pageCreate.pageId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var myHeader in pageCreate.Headers.Where(h => h.HeaderItem == null))
                    {
                        myHeader.PageCreateParentId = pageCreate.pageId;
                        myHeader.HeaderItem = Guid.NewGuid();
                        _context.HeaderInfo.Add(myHeader);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageCreateExists(pageCreate.pageId))
                    {
                        return NotFound();
}
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Edit", new { id = pageCreate.pageId });
            }
            return View(pageCreate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MyBodyCreate(/*Guid id,*/ [Bind("pageId,Title,MyBody")] PageCreate pageCreate)
        {
            //if (id != pageCreate.pageId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    var myBody = pageCreate.MyBody;
                    myBody.PageCreateParentId = pageCreate.pageId;
                    myBody.BodyItem = Guid.NewGuid();
                    _context.BodyInfo.Add(myBody);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageCreateExists(pageCreate.pageId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Edit", new { id = pageCreate.pageId });
            }
            return View(pageCreate);
        }


        //Footer added context
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MyFooterCreate(/*Guid id,*/ [Bind("pageId,Title,MyFooter")] PageCreate pageCreate)
        {
            //if (id != pageCreate.pageId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    var myFooter = pageCreate.MyFooter;
                    myFooter.PageCreateParentId = pageCreate.pageId;
                    myFooter.FooterItem = Guid.NewGuid();
                    _context.FooterInfo.Add(myFooter);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageCreateExists(pageCreate.pageId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Edit", new { id = pageCreate.pageId });
            }
            return View(pageCreate);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var headerInfo = await _context.HeaderInfo.FindAsync(id);
            _context.HeaderInfo.Remove(headerInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: PageCreates/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageCreate = await _context.PageCreate
                .FirstOrDefaultAsync(m => m.pageId == id);
            if (pageCreate == null)
            {
                return NotFound();
            }

            return View(pageCreate);
        }

        // POST: PageCreates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteHeaderItem(Guid id, [Bind("pageId,Title,MyHeader")] PageCreate pageCreate)
        {
            //var headerItem = await _context.HeaderInfo.FindAsync(pageCreate.Headers);
            //_context.HeaderInfo.Remove(headerItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Edit", new { id = pageCreate.pageId });
        }

        private bool PageCreateExists(Guid id)
        {
            return _context.PageCreate.Any(e => e.pageId == id);
        }
    }
}
