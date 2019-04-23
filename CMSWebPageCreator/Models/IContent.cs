using System;
using System.ComponentModel.DataAnnotations;

namespace CMSWebPageCreator.Models
{
    public interface IContent
    {
    }
    public class HeaderInfo
    {
        public Guid PageCreateParentId { get; set; }
        [Key]
        public Guid HeaderItem { get; set; }
        public string HeaderContent { get; set; }
        public HeaderStyleType ContentType { get; set; }
    }

    public class FooterInfo : IContent
    {
        public Guid PageCreateParentId { get; set; }
        [Key]
        public Guid FooterItem { get; set; }
        public string FooterContent { get; set; }
        public FooterStyleType ContentType { get; set; }
    }
    public class BodyInfo
    {
        public Guid PageCreateParentId { get; set; }
        [Key]
        public Guid BodyItem { get; set; }
        public string BodyContent { get; set; }
        public BodyStyleType ContentType { get; set; }
    }

    public enum BodyStyleType { Title, BodyText, Image, ImageLink, ImageDescription, TextLink }
    public enum FooterStyleType { FooterText, Image, ImageLink, ImageDescription, TextLink }
    public enum HeaderStyleType { Title, HeaderText, Image, ImageLink, ImageDescription, TextLink }
}