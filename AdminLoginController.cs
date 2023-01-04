using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using Web_API.Models;
using Web_API.Repository;

namespace Web_API.Controllers
{
    [RoutePrefix("api/Account")]

    public class AdminLoginController : ApiController
    
    {
        private IAdminLoginRepository _adminloginRepository;
        public AdminLoginController()
        {
            this._adminloginRepository = new AdminLoginRepository(new RegisterDBEntities());
        }

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult VerifyLogin(Login objlogin)
        {
            Admin admin = null;
            try
            {
                admin = _adminloginRepository.VerifyAdminLogin(objlogin.UserName, objlogin.Password);

                if (admin != null)
                {
                    //return NotFound();
                    return Ok(admin);

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

    

