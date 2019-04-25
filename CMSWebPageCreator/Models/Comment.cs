using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMSWebPageCreator.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Time { get; set; }


        public int? ParentId { get; set; }
        public string Content { get; set; }

        [ForeignKey(nameof(PageCreate))]
        public string PostId { get; set; }

    }
}
