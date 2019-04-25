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
        public async Task<IActionResult> Details(string permalink)
        {
            ViewData["permalink"] = permalink;
            var currentUser = await _userManager.GetUserAsync(User);

            var pageCreate = await _context.PageCreate
                .FirstOrDefaultAsync(m => m.Title.ToLower() == permalink.ToLower());
            if (pageCreate == null)
            {
                return NotFound();
            }

            if (currentUser == null)
            {
                ViewBag.userId = null;
            }
            else
            {
                ViewBag.userId = currentUser.Id;
            }

            pageCreate.Headers = await _context.HeaderInfo.Where(c => c.PageCreateParentId == pageCreate.pageId).ToListAsync();
            pageCreate.BodyItems = await _context.BodyInfo.Where(c => c.PageCreateParentId == pageCreate.pageId).ToListAsync();
            pageCreate.FooterItems = await _context.FooterInfo.Where(c => c.PageCreateParentId == pageCreate.pageId).ToListAsync();
            ViewBag.Comments = await _context.Comment.Where(c => c.PostId == pageCreate.Title).ToListAsync();

            return View(pageCreate);
        }

        // GET: PageCreates/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: PageCreates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin,Editor")]
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

            pageCreate.Headers = await _context.HeaderInfo.Where(c => c.PageCreateParentId == id).ToListAsync();
            pageCreate.BodyItems = await _context.BodyInfo.Where(c => c.PageCreateParentId == id).ToListAsync();
            pageCreate.FooterItems = await _context.FooterInfo.Where(c => c.PageCreateParentId == id).ToListAsync();
            ViewBag.Comments = await _context.Comment.Where(c => c.PostId.ToLower() == pageCreate.Title.ToLower()).ToListAsync();

            return View(pageCreate);
        }

        // POST: PageCreates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Editor")]
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Editor")]
        public async Task<IActionResult> CreateHeaderItem(/*Guid id,*/ [Bind("PageCreateParentId,ContentType,HeaderContent")] HeaderInfo headerInfo)
        {
            //if (id != pageCreate.pageId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                headerInfo.HeaderId = Guid.NewGuid();
                _context.Add(headerInfo);
                await _context.SaveChangesAsync();

                return RedirectToAction("Edit", new { id = headerInfo.PageCreateParentId });
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Editor")]
        public async Task<IActionResult> EditHeaderItem( [Bind("PageCreateParentId,ContentType,HeaderContent,HeaderId")] HeaderInfo headerInfo,
                                                          string edit, string delete)
        {

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(delete))
                {
                    var header = _context.HeaderInfo
                        .Where(pi => pi.HeaderId == headerInfo.HeaderId)
                        .FirstOrDefault();
                    _context.Remove(header);
                    await _context.SaveChangesAsync();
                }
                else if (!string.IsNullOrEmpty(edit))
                {
                   
                    _context.Update(headerInfo);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("Edit", new { id = headerInfo.PageCreateParentId });
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Editor")]
        public async Task<IActionResult> CreateBodyItem(/*Guid id,*/ [Bind("PageCreateParentId,ContentType,BodyContent")] BodyInfo bodyInfo)
        {
            //if (id != pageCreate.pageId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                bodyInfo.BodyId = Guid.NewGuid();
                _context.Add(bodyInfo);
                await _context.SaveChangesAsync();

                return RedirectToAction("Edit", new { id = bodyInfo.PageCreateParentId });
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Editor")]
        public async Task<IActionResult> EditBodyItem([Bind("PageCreateParentId,ContentType,BodyContent,BodyId")] BodyInfo bodyInfo,
                                                          string edit, string delete)
        {

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(delete))
                {
                    var body = _context.BodyInfo
                        .Where(pi => pi.BodyId == bodyInfo.BodyId)
                        .FirstOrDefault();
                    _context.Remove(body);
                    await _context.SaveChangesAsync();
                }
                else if (!string.IsNullOrEmpty(edit))
                {

                    _context.Update(bodyInfo);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("Edit", new { id = bodyInfo.PageCreateParentId });
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Editor")]
        public async Task<IActionResult> CreateFooterItem(/*Guid id,*/ [Bind("PageCreateParentId,ContentType,FooterContent")] FooterInfo footerInfo)
        {
            //if (id != pageCreate.pageId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                footerInfo.FooterId = Guid.NewGuid();
                _context.Add(footerInfo);
                await _context.SaveChangesAsync();

                return RedirectToAction("Edit", new { id = footerInfo.PageCreateParentId });
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Editor")]
        public async Task<IActionResult> EditFooterItem([Bind("PageCreateParentId,ContentType,FooterContent,FooterId")] FooterInfo footerInfo,
                                                          string edit, string delete)
        {

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(delete))
                {
                    var footer = _context.FooterInfo
                        .Where(pi => pi.FooterId == footerInfo.FooterId)
                        .FirstOrDefault();
                    _context.Remove(footer);
                    await _context.SaveChangesAsync();
                }
                else if (!string.IsNullOrEmpty(edit))
                {

                    _context.Update(footerInfo);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("Edit", new { id = footerInfo.PageCreateParentId });
            }
            return View();
        }

        // GET: PageCreates/Delete/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePage(Guid id, [Bind("pageId,Title")] PageCreate pageCreate)
        {

            await _context.BodyInfo
                .Where(pi => pi.PageCreateParentId == id)
                .ForEachAsync(pi => _context.Remove(pi));
            await _context.SaveChangesAsync();

            await _context.HeaderInfo
                .Where(pi => pi.PageCreateParentId == id)
                .ForEachAsync(pi => _context.Remove(pi));
            await _context.SaveChangesAsync();

            await _context.FooterInfo
                .Where(pi => pi.PageCreateParentId == id)
                .ForEachAsync(pi => _context.Remove(pi));
            await _context.SaveChangesAsync();

            _context.PageCreate.Remove(_context.PageCreate.Find(id));
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        private bool PageCreateExists(Guid id)
        {
            return _context.PageCreate.Any(e => e.pageId == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> CreateComment([Bind("Id,UserId,Time,ParentId,Content,PostId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                
                var pageCreate = await _context.PageCreate.FirstOrDefaultAsync(p => p.Title.ToLower() == comment.PostId.ToLower());
                pageCreate.Headers = await _context.HeaderInfo.Where(c => c.PageCreateParentId == pageCreate.pageId).ToListAsync();
                pageCreate.BodyItems = await _context.BodyInfo.Where(c => c.PageCreateParentId == pageCreate.pageId).ToListAsync();
                pageCreate.FooterItems = await _context.FooterInfo.Where(c => c.PageCreateParentId == pageCreate.pageId).ToListAsync();
                ViewBag.Comments = await _context.Comment.Where(c => c.PostId.ToLower() == pageCreate.Title.ToLower()).ToListAsync();
                return Redirect("/"+ pageCreate.Title);
            }
            return View(comment);
        }
    }
}
