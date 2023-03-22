using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shopec.Models
{
	public class ShoppingCartDetails
	{	

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }
		public int productId { get; set; }

		public double price { get; set; }

		public int quantity { get; set; }

		// @ManyToOne(fetch = FetchType.LAZY)
		// @JoinColumn(name = "shoppingcartid", nullable = false, insertable=true, updatable=false)
		
	
		public  ShoppingCart shoppingCartId { get; set; }
	}
}