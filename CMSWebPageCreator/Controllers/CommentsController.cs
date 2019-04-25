using CMSWebPageCreator.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSWebPageCreator.Controllers
{
    public class CommentsController : Controller
    {

        private readonly DBContext _context;

        public CommentsController(DBContext context)
        {
            _context = context;
        }
        public async Task<List<Comment>> getComments()
        {
            return await _context.Comment.ToListAsync();
        }

        public async Task<List<Comment>> getComments(string postId, int? parentComment)
        {
            return await _context.Comment.Where(c => c.ParentId == parentComment && c.PostId == postId).ToListAsync();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,UserId,Time,ParentId,Content,PostId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = comment.PostId });
            }
            return View(comment);
        }
    }
}
