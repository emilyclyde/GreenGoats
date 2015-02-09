using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenGoats.Models
{
  public class BookViewModel
  {
    
      public string Title { get; set; }
      public DateTime Year { get; set; }
      public AuthorViewModel Author { get; set; }

  }

    public class AuthorViewModel
    {
      public string Name { get; set; }
    }

  }



