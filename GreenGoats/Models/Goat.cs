using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GreenGoats.Models;

namespace GreenGoats.Models
{
  public class Goat
  {
    public int GoatID { get; set; }
    public string GoatName { get; set; }
    public string GoatColor { get; set; }
    public string GoatType { get; set; }
    public string GoatGender { get; set; }
    
    public virtual ICollection<Lot> Lots { get; set; }
  }
}