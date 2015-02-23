using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenGoats.Models
{
  public class Book
  {
    public int BookID { get; set; }
    public int AuthorID { get; set; }
    public string Title { get; set; }
    
    public DateTime Year { get; set; }
  }
}