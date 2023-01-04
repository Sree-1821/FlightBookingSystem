using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_API.Models;

namespace Web_API.Repository
{
    public class AdminLoginRepository : IAdminLoginRepository
    {
        RegisterDBEntities _registerDBContext = null;
        public Admin VerifyAdminLogin(string Username, string password)
        {
            //RegisterDBEntities nd = new RegisterDBEntities();

            //var checkValidUser = objRegisterDBEntities.Customers.Where(m => m.Username == Ur.Username &&
            //m.Password == Ur.Password).FirstOrDefault();

            //if (checkValidUser != null)
            //{
            //    return Ok();
            //}

            //else
            //{
            //    return new System.Web.Http.Results.ResponseMessageResult(
            //    Request.CreateErrorResponse((HttpStatusCode)426, new HttpError("Something goes wrong")));
            //}
            Admin admin = null;
            try
            {
                var checkValidUser = _registerDBContext.Admins.Where(m => m.Username == Username &&
            m.password == password).FirstOrDefault();
                if (checkValidUser != null)
                {
                    admin = checkValidUser;
                }

                else
                {
                    admin = null;
                }
            }
            catch (Exception ex)
            {
            }
            return admin;
        }

        public AdminLoginRepository(RegisterDBEntities registerDBEntities)
        {
            this._registerDBContext = registerDBEntities;
        }
    }
}
    
    
