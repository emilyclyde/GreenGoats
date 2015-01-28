using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GreenGoats.Models;

namespace GreenGoats.DAL
{
    public class GrazeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GrazingContext>
    {
      protected override void Seed(GrazingContext context)
      {
        var goats = new List<Goat>
            {
            new Goat{GoatName="Carson",GoatColor="Black", GoatType="Alpine", GoatGender="Buck"},
            new Goat{GoatName="Meredith",GoatColor="White",GoatType="Pygmy", GoatGender="Doe"},
            new Goat{GoatName="Arturo",GoatColor="Red",GoatType="Cross", GoatGender="Doe"},
            new Goat{GoatName="Gytis",GoatColor="Brown",GoatType="Boer", GoatGender="Buck"},
            };

        goats.ForEach(g => context.Goats.Add(g));
        context.SaveChanges();
        var customers = new List<Customer>
            {
            new Customer{CustomerID=1050, CustomerFirst="Ashley",CustomerLast="Smith", CustomerAddress="123 Smith Street", CustomerEmail="smith@email.com"},
            new Customer{CustomerID=4022, CustomerFirst="Jerry",CustomerLast="Johns", CustomerAddress="456 Johns Street", CustomerEmail="johns@email.com"},
            new Customer{CustomerID=4041, CustomerFirst="Timmy",CustomerLast="Clark", CustomerAddress="789 Clark Street",CustomerEmail="clark@email.com" },
            new Customer{CustomerID=1045, CustomerFirst="Leo",CustomerLast="Albright", CustomerAddress="246 Albright Street", CustomerEmail="albright@email.com"},
            };
        customers.ForEach(c => context.Customers.Add(c));
        context.SaveChanges();
        var lots = new List<Lot>
            {
            new Lot{GoatID=1,CustomerID=1050,CustomerFirst="Ashley", CustomerLast="Smith", GoatName="Carson", LotAddress="123 Smith Street", LotDescription="Hill"},
            new Lot{GoatID=2,CustomerID=4022,CustomerFirst="Jerry", CustomerLast="Johns", GoatName="Meredith", LotAddress="456 Johns Street", LotDescription="Level"},
            new Lot{GoatID=3,CustomerID=4041,CustomerFirst="Timmy", CustomerLast="Clark", GoatName="Arturo", LotAddress="789 Clark Street", LotDescription="Blackberries"},
            new Lot{GoatID=4,CustomerID=1045,CustomerFirst="Leo", CustomerLast="Albright", GoatName="Gytis", LotAddress="246 Albright Street", LotDescription="Treed"},
            
            };
        lots.ForEach(l => context.Lots.Add(l));
        context.SaveChanges();
      }
    }
  }
