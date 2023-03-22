using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shopec.Models
{
	public class User
	{
	  [Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }


		public string username { get; set; }
		public string password { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string usertype { get; set; }
		public string address { get; set; }
		public string city { get; set; }
		public int zip { get; set; }
		public string state { get; set; }
		public string emailAddress { get; set; }
		public int phoneNumber { get; set; }

	}
}