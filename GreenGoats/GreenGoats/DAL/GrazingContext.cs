using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GreenGoats.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GreenGoats.DAL
{
  
    public class GrazingContext : DbContext
    {

      public GrazingContext() : base("GrazingContext")
      {
      }

      public DbSet<Goat> Goats { get; set; }
      public DbSet<Lot> Lots { get; set; }

      public DbSet<Pasture> Pastures { get; set; }
      
      public DbSet<Customer> Customers { get; set; }
      
      public DbSet<Book> Books { get; set; }
      public DbSet<Author> Authors { get; set; }

      
    
      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      }
    }
  }
