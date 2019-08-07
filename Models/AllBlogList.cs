using System;
using System.Collections.Generic;

namespace Projects.Models
{
    public class BlogAbstractView
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public DateTime PostDate {get; set;}
    }
    public class AllBlogList
    {
        public List<BlogAbstractView> allRecords {get; set;}
    }
}