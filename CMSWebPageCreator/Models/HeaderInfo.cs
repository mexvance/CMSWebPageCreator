using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSWebPageCreator.Models
{
    public class HeaderInfo
    {
        public Guid PageCreateParentId { get; set; }
        [Key]
        public Guid HeaderItem { get; set; }
        public string HeaderContent { get; set; }
        public HeaderStyleType ContentType { get; set; }
}
        public enum HeaderStyleType { Title, HeaderText, Image, ImageLink, ImageDescription, TextLink }
}
