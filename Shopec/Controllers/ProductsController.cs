using Shopec.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shopec.Controllers
{

    //[Route ("api/[controller]")]
    //[ApiController]
    public class ProductsController : ApiController
    {

        private DataContext _context = new DataContext();
        public ProductsController()
        {
        }
                      
        [HttpGet]
        [ActionName("testing")]
        public IHttpActionResult test()
        {
            return Ok("test");
        }
        [HttpGet]
        [ActionName("list")]
        public async Task<IHttpActionResult> list()
        {
            var list2 = await _context.Products.ToListAsync();
            //var list1 = _context.Products.Select(x => x).ToList(); //verify    
            if (list2 != null)
                return Ok(list2);
            return Ok("");
        }
        [HttpGet]
        [ActionName("update")]
        public async Task<IHttpActionResult> update([FromBody]int id, [FromBody] int quantity)
        {
            var productToUpdate = _context.Products.Where(e => e.id == id).FirstOrDefault();
            if (productToUpdate != null)
            {
                productToUpdate.quantity = Convert.ToString(Convert.ToInt32(productToUpdate.quantity) - quantity);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
     