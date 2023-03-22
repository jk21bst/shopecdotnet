using Microsoft.AspNet.Identity.EntityFramework;
using Shopec.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shopec.Data
{
	public class DataContext :DbContext 
	{
	
		public DataContext() : base("DefaultConnection") {


			Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Shopec.Migrations.Configuration>());
		}

		public DbSet<Products> Products { get; set; }
		public DbSet<Orders> Orders { get; set; }
		public DbSet<ShoppingCart> ShoppingCart { get; set; }
		public DbSet<ShoppingCartDetails> ShoppingCartDetails { get; set; }
		public DbSet<User> User { get; set; }
	}
}