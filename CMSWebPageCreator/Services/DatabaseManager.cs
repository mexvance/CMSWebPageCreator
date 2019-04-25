using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSWebPageCreator.Models;
using CMSWebPageCreator.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CMSWebPageCreator.Services
{
    public class DatabaseManager : IPageManagerService
    {
        private readonly DBContext _context;
        public DatabaseManager(DBContext cmsContext)
        {
            _context = cmsContext ?? throw new ArgumentNullException(nameof(cmsContext));
        }

        public bool AddBodyItem(BodyInfo content)
        {
            _context.Add(content);
            _context.SaveChangesAsync();
            return true;
        }

        public bool AddFooterItem(FooterInfo content)
        {
            _context.Add(content);
            _context.SaveChangesAsync();
            return true;
        }

        public bool AddHeaderItem(HeaderInfo content)
        {
            _context.Add(content);
            _context.SaveChangesAsync();
            return true;
        }

        public bool AddPage(PageCreate page)
        {
            _context.Add(page);
            _context.SaveChangesAsync();
            return true;
        }

        public bool DeleteBodyItem(BodyInfo item)
        {
            var body = _context.BodyInfo
                .Where(i => i.BodyId == item.BodyId)
               .FirstOrDefault();
            _context.Remove(body);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteFooterItem(FooterInfo item)
        {
            var footer = _context.FooterInfo
               .Where(i => i.FooterId == item.FooterId)
               .FirstOrDefault();
            _context.Remove(footer);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteHeaderItem(HeaderInfo item)
        {
            var header = _context.HeaderInfo
                .Where(pi => pi.HeaderId == item.HeaderId)
                .FirstOrDefault();
            _context.Remove(header);
            _context.SaveChanges();
            return true;
        }

        //Delete all the page information that we had
        public bool DeletePage(Guid id)
        {
            DeleteBodyItems(id);
            DeleteHeaderItems(id);
            DeleteFooterItems(id);
            _context.PageCreate.Remove(_context.PageCreate.Find(id));
            _context.SaveChangesAsync();
            return true;
        }

        private void DeleteBodyItems(Guid pageId)
        {
            _context.BodyInfo
                .Where(pi => pi.PageCreateParentId == pageId)
                .ForEachAsync(pi => _context.Remove(pi));
            _context.SaveChangesAsync();
        }
        private void DeleteHeaderItems(Guid pageId)
        {
            _context.HeaderInfo
                .Where(pi => pi.PageCreateParentId == pageId)
                .ForEachAsync(pi => _context.Remove(pi));
            _context.SaveChangesAsync();
        }
        private void DeleteFooterItems(Guid pageId)
        {
            _context.FooterInfo
                .Where(pi => pi.PageCreateParentId == pageId)
                .ForEachAsync(pi => _context.Remove(pi));
            _context.SaveChangesAsync();
        }

        //Find the page
        public PageCreate GetPage(string Title)
        {
            var page = _context.PageCreate
                .Where(p => p.Title.ToLower() == Title.ToLower())
                .Include(p => p.BodyItems)
                .Include(p => p.Headers)
                .Include(p => p.FooterItems)
                .FirstOrDefault();
            /* var pageViewModel = new PageViewModel
             {
                 Id = page.pageId,
                 Title = page.Title,
                 contents = new List<IContent>()
             };
             foreach (var item in page.Headers)
             {
                 pageViewModel.contents.Add(item);
             }
             foreach (var item in page.BodyItems)
             {
                 pageViewModel.contents.Add(item);
             }
             foreach (var item in page.FooterItems)
             {
                 pageViewModel.contents.Add(item);
             }
             //pageViewModel.contents = pageViewModel.contents.OrderBy(i => ).Reverse().ToList();
             return pageViewModel;*/
            return page;
        }

        public IEnumerable<PageCreate> GetPageList()
        {
            return _context.PageCreate.ToList();
        }
    }
}
