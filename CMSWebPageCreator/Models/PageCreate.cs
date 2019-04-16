using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSWebPageCreator.Models
{
    public class PageCreate
    {
        public PageCreate()
        {
            Headers = new List<HeaderInfo>();
        }
        [Key]
        public Guid pageId { get; set; }
        public string Title { get; set; }
        public List<HeaderInfo> Headers { get; set; }
        public BodyInfo MyBody { get; set; }
        public FooterInfo MyFooter { get; set; }
        public HeaderInfo MyHeader { get; set; }
    }
}
