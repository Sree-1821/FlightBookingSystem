using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.Http;
using System.Web.UI.WebControls;
using Web_API.Models;
using Web_API.Repository;

namespace Web_API.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private IAccountRepository _accountRepository;
        public AccountController()
        {
            this._accountRepository = new AccountRepository(new RegisterDBEntities());
        }

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult VerifyLogin(Login objlogin)
        {
            Customer customer = null;
            try
            {
                customer = _accountRepository.VerifyLogin(objlogin.UserName, objlogin.Password);

                if (customer != null)
                {
                    //return NotFound();
                    return Ok(customer);

                }

            }
            catch (Exception ex)
            {

            }

            //return Ok(customer);
            return NotFound();

        }
    }

}
