using CMSWebPageCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSWebPageCreator.ViewModel
{
    public class PageViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<IContent> contents { get; set; }
    }
}
