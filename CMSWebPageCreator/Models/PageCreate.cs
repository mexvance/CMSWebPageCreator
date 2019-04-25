using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSWebPageCreator.Models
{
    public class PageCreate
    {
        [Key]
        public Guid pageId { get; set; }
        public string Title { get; set; }
        public List<HeaderInfo> Headers { get; set; }
        public List<BodyInfo> BodyItems { get; set; }
        public List<FooterInfo> FooterItems { get; set; }
    }
}
