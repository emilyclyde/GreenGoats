using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenGoats.Models
{
  public class Author
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ID { get; set; }
    [Column("Name")]
   [Display(Name = "Author Name")]
    public string Name { get; set; }

    public virtual ICollection<Book> Books { get; set; }
  }
}
