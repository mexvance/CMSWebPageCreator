using System;
using System.ComponentModel.DataAnnotations;

namespace CMSWebPageCreator.Models
{
    public interface IContent
    {
    }
    public class HeaderInfo : IContent
    {
        public Guid PageCreateParentId { get; set; }
        [Key]
        public Guid HeaderId { get; set; }
        public string HeaderContent { get; set; }
        public HeaderStyleType ContentType { get; set; }
    }

    public class FooterInfo : IContent
    {
        public Guid PageCreateParentId { get; set; }
        [Key]
        public Guid FooterId { get; set; }
        public string FooterContent { get; set; }
        public FooterStyleType ContentType { get; set; }
    }
    public class BodyInfo :IContent
    {
        public Guid PageCreateParentId { get; set; }
        [Key]
        public Guid BodyId { get; set; }
        public string BodyContent { get; set; }
        public BodyStyleType ContentType { get; set; }
    }

    public enum BodyStyleType { Title, BodyText, ImageAddress}
    public enum FooterStyleType {Title, FooterText}
    public enum HeaderStyleType { Title, HeaderText}
}