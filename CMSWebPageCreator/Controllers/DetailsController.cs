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
        public IActionResult DetailDB()
        {
            var pageCount=dBContext.PageCreate.Count();
            var numOfPageWithALetter = dBContext.PageCreate.Count();
            var detailPageVM = new DbDetailViewModel();
         
            detailPageVM.PageCount = pageCount;

            return View(detailPageVM);
        }

        


    }
}