using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenGoats.Models
{
  public class Customer
  {
    public int CustomerID { get; set; }
    public string CustomerFirst { get; set; }
    public string CustomerLast { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerEmail { get; set; }

    public virtual ICollection<Lot> Lots { get; set; }
  }
}