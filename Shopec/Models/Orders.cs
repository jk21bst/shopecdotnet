using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shopec.Models
{
	public class Orders
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }
		public string deliveryType { get; set; }
		public DateTime orderdate { get; set; }
		public double totalPrice { get; set; }
		public int productsPurchased { get; set; }

		[ForeignKey("ShoppingCart")]
		public int shoppingCartId { get; set; }





		//[Required]
		//[ForeignKey("ShoppingCartId")]
		//public virtual ShoppingCart ShoppingCart { get; set; }
	}
}