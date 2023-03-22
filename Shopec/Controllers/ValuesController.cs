using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shopec.Controllers
{
	public class ValuesController : ApiController
	{
		// GET api/values
		[HttpGet]
		public async Task<IHttpActionResult> Get()
		{
			//return 
				 string[]  var = { "value1", "value2" };
			return Ok(var);
		}

		// GET api/values/5
		[HttpGet]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
