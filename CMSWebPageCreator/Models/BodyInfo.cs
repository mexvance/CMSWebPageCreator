using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMSWebPageCreator.Models
{
    public class BodyInfo
    {
        public Guid PageCreateParentId { get; set; }
        [Key]
        public Guid BodyItem { get; set; }
        public string BodyContent { get; set; }
        public BodyStyleType ContentType { get; set; }
    }
    public enum BodyStyleType { Title, BodyText, Image, ImageLink, ImageDescription, TextLink}
}
