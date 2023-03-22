using Shopec.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shopec.Controllers
{
	public class AccountController : ApiController
	{

        
        private IAuthRepository _authRepository { get; set; }
        public AccountController() {
        }
        public AccountController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }


        [HttpGet]
        [ActionName("gettest")]
        public IHttpActionResult getTestResult()
        {
            var result = this._authRepository.ToString();
            if (result is null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            return StatusCode(HttpStatusCode.OK); }

        [HttpGet]

        [ActionName("login")]

        public async Task<IHttpActionResult> login()
        {
            var header = Request.Headers; header.Contains("Authorization");
            var authHeader = header.GetValues("Authorization").First();
            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

                int seperatorIndex = usernamePassword.IndexOf(':');
                var username = usernamePassword.Substring(0, seperatorIndex);
                var password = usernamePassword.Substring(seperatorIndex + 1);
                //var User = _context.User.Where(e => e.username == userForLogin.username && e.password == userForLogin.password).FirstOrDefault();         
                var userLogedIn = await _authRepository.Login(username, password);
                var nothing = 0;
                if (userLogedIn != null)
                {
                    var data = userLogedIn;
                    //var config = new MapperConfiguration(cf => {                    //    cf.CreateMap<User, Principal>().ReverseMap();                    //});                    //var mapper = new Mapper(config);                    //mapper.Map<Principal>(data);                    //var userToSend =new ObjectLogin() {                    //    principal=mapper.Map<Principal>(data);          
                    //} 
                    var userToSend = new ObjectLogin()
                    {
                        principal = new Principal()
                        {
                            id = data.id,
                            username = data.username,
                            password = data.password,
                            firstName = data.firstName,
                            lastName = data.lastName,
                            usertype = data.usertype,
                            address = data.address,
                            city = data.city,
                            zip = data.zip,
                            state = data.state,
                            emailAddress = data.emailAddress,
                            phoneNumber = data.phoneNumber
                        }
                    };
                    var sendToSend = userToSend;
                    return Ok(userToSend);
                }
                return NotFound();
            }
            return StatusCode(HttpStatusCode.Unauthorized);
        }
    }
}



