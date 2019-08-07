using System;
using System.ComponentModel.DataAnnotations;

namespace Projects.Models
{
    public class BlogViewModel
    {
        public int ID {get; set;}

        [Display(Name="文章标题"), Required]
        public string Title {get; set;}

        public DateTime PostDate {get; set;}


        public string Blog {get; set;}

        public string BlogHtml {get; set;}

        [Display(Name="选择文章可见度"), Range(0,3),Required]
        public int Permission {get; set;}
        
    }
}