using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSWebPageCreator.Models
{
    public class FooterInfo
    {
        public Guid PageCreateParentId { get; set; }
        [Key]
        public Guid FooterItem { get; set; }
        public string FooterContent { get; set; }
        public FooterStyleType ContentType { get; set; }
    }
    public enum FooterStyleType { FooterText, Image, ImageLink, ImageDescription, TextLink }
}
