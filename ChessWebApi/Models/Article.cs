using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChessWebApi.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Author { get; set; } 

        public string Title { get; set; }

        public string Body { get; set; }

        public string ImageURL { get; set; }

        public string Selector { get; set; } 
        public bool ShowInMenu { get; set; }

    }
}