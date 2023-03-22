using Shopec.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shopec.Controllers
{
	public class OrderController : ApiController
	{

        private readonly IAuthRepository _authRepository;
        public OrderController()
        {
        }
        public OrderController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost]
        [ActionName("create")]
        public IHttpActionResult create([FromBody] ShoppingCartDto SpcDto)
        {
            var orderPlaced = _authRepository.placeOrder(SpcDto);
            if (orderPlaced != null)
            {
                return Ok(new OrderDto() { orderNo = orderPlaced.Id });
            }

            else
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }

    }
}
	