namespace GreenGoats.Migrations
{
  using System;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;
  using GreenGoats.DAL;
  using GreenGoats.Models;
  using System.Collections.Generic;

  internal sealed class Configuration : DbMigrationsConfiguration<GreenGoats.DAL.GrazingContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

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

      var pastures = new List<Pasture>
            {
              new Pasture{GoatID=1, Field="A"},
              new Pasture{GoatID=2, Field="B"},
              new Pasture{GoatID=3, Field="C"},
              new Pasture{GoatID=4, Field="D"},
            };
      pastures.ForEach(p => context.Pastures.Add(p));
      context.SaveChanges();

      var lots = new List<Lot>
            {
            new Lot{LotID= 1, GoatID=1, CustomerID=1, CustomerFirst="Ashley", CustomerLast="Smith", GoatName="Carson", LotAddress="123 West Ave", LotDescription= "Hill"},
            new Lot{LotID= 2, GoatID=2, CustomerID=2, CustomerFirst="Jerry", CustomerLast="Jones", GoatName="Meredith", LotAddress="456 East Ave", LotDescription= "Trees"},
            new Lot{LotID= 3, GoatID=3, CustomerID=3, CustomerFirst="Timmy", CustomerLast="Wilson",GoatName="Arturo", LotAddress="789 North Ave", LotDescription= "Level"}
            };

      lots.ForEach(l => context.Lots.Add(l));
      context.SaveChanges();

      var customers = new List<Customer>
      {
        new Customer{CustomerID=1, CustomerFirst="Ashley", CustomerLast="Smith", CustomerEmail="ashley@email.com", CustomerAddress="123 West Ave",},
        new Customer{CustomerID=2, CustomerFirst="Jerry",CustomerLast="Jones", CustomerEmail="jerry@email.com", CustomerAddress="456 East Ave"},
        new Customer{CustomerID=3, CustomerFirst="Timmy",CustomerLast="Wilson", CustomerEmail="timmy@email.com", CustomerAddress="789 North Ave"}
      };

      customers.ForEach(c => context.Customers.Add(c));
      context.SaveChanges();


      var authors = new List<Author>
            {
            new Author{Name="Sue Weaver", ID=1},
            new Author{Name="Cheryl K. Smith",ID=2},
            new Author{Name="Taylor David",ID=3},
            
            };
      authors.ForEach(a => context.Authors.Add(a));
      context.SaveChanges();


      var books = new List<Book>
            {
            new Book{Title="The Backyard Goat", Year=DateTime.Parse("2011-04-16"), AuthorID=1},
            new Book{Title="Raising Goats For Dummies", Year=DateTime.Parse("2010-02-19"),AuthorID=2},
            new Book{Title="Nigerian Dwarf Goats Care", Year=DateTime.Parse("2013-06-27"), AuthorID=3},
            
            };

      books.ForEach(b => context.Books.Add(b));
      context.SaveChanges();

    }
  }
}


