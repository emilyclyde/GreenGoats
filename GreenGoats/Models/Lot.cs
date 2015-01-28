using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GreenGoats.Models;

namespace GreenGoats.Models
{
  public class Lot
  {
    public int LotID { get; set; }
    public int GoatID { get; set; }
    public int CustomerID { get; set; }
    public string GoatName { get; set; }
    public string CustomerFirst { get; set; }
    public string CustomerLast { get; set; }
    public string LotAddress { get; set; }
    public string LotDescription { get; set; }

    public virtual ICollection<Goat> Goats { get; set; }
    public virtual ICollection<Customer> Customers { get; set; }
  }
}