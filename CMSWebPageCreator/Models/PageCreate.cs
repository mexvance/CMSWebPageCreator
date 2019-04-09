using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSWebPageCreator.Models
{
    public class PageCreate
    {
        public Guid pageId { get; set; }
        public string Title { get; set; }
        public HeaderInfo MyHeader { get; set; }
        public BodyInfo MyBody { get; set; }
        public FooterInfo MyFooter { get; set; }
    }
}
