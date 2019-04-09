using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSWebPageCreator.Models
{
    public class HeaderInfo
    {
            public Guid PageCreateParentId { get; set; }
            public Guid HeaderItem { get; set; }
            public string HeaderContent { get; set; }
            public HeaderStyleType ContentType { get; set; }
    }
        public enum HeaderStyleType { Title, HeaderText, Image, ImageLink, ImageDescription, TextLink }
}
