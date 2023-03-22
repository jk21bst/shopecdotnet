using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shopec.Models
{
	public class Products
	{	
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }

		public string code { get; set; }
		public string name { get; set; }
		public string description { get; set; }
		public string quantity { get; set; }
		public double price { get; set; }
	}
}