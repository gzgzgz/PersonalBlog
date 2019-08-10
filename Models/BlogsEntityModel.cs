using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projects.Models
{
    [Table("blogs")]
    public class BlogsEntityModel
    {
        [Key, Column("blogid")]
        public int BlogID {get; set;}

        [Required, Column("title")]
        public string Title {get; set;}

        [DataType(DataType.Date), Required, Column("postdate")]
        public DateTime PostDate {get; set;}

        [Column("blog")]
        public string Blog {get; set;}
        [Column("bloghtml")]
        public string BlogHtml {get; set;}

        [Range(0,3),Required,Column("permission")]
        public int Permission {get; set;}
    }
}
