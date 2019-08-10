using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projects.Models
{
    [Table("blogs")]
    public class BlogsEntityModel
    {
        [Key]
        public int BlogID {get; set;}

        [Required]
        public string Title {get; set;}

        [DataType(DataType.Date), Required]
        public DateTime PostDate {get; set;}

        public string Blog {get; set;}

        public string BlogHtml {get; set;}

        [Range(0,3),Required]
        public int Permission {get; set;}
    }
}
