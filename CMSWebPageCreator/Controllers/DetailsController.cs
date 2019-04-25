using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSWebPageCreator.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMSWebPageCreator.Controllers
{
    public class DetailsController : Controller
    {
        private readonly DBContext dBContext;

        public DetailsController(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DetailDB(string searchString)
        {


            var pageCount=dBContext.PageCreate.Count();
            searchString = "M";
            var search = dBContext.PageCreate.Where(b => b.Title.ToLower().Contains(searchString.ToLower()));
            var searchCount = search.Count();
            var detailPageVM = new DbDetailViewModel();
         
            detailPageVM.PageCount = pageCount;
            detailPageVM.SearchCount = searchCount;

            return View(detailPageVM);
        }


        


    }
}