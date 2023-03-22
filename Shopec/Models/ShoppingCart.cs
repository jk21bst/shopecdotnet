using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shopec.Models
{
	public class ShoppingCart
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

		public int id { get; set; }

		public string refernceno { get; set; }

		//@Column(name = "userid")
		public int userId { get; set; }

		public Boolean active { get; set; }

		public DateTime expiry { get; set; }
		
		//public  Orders order { get; set; }

		public  ICollection<ShoppingCartDetails> items { get; set; }

		// //	@OneToMany(fetch = FetchType.LAZY, mappedBy = "shoppingCart", cascade = CascadeType.ALL)
		// public HashSet<ShoppingCartDetails> items = new HashSet<ShoppingCartDetails>();

		// //@OneToOne(mappedBy="shoppingCart",cascade = CascadeType.ALL)
		//[ForeignKey("ShoppingCartId")]
	 //public Orders order;

	}
}