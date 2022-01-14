using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAngularTest.Models
{
    public class CreateArticleRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
