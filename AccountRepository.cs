using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Repository
{
    public class AccountRepository : IAccountRepository
    {
        RegisterDBEntities _registerDBContext = null;
        public Customer VerifyLogin(string userName, string password)
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
            Customer customer = null;
            try
            {
                var checkValidUser = _registerDBContext.Customers.Where(m => m.Username == userName &&
            m.Password == password).FirstOrDefault();
                if (checkValidUser != null)
                {
                    customer = checkValidUser;
                }

                else
                {
                    customer = null;
                }
            }
            catch (Exception ex)
            {
            }
            return customer;
        }

        public AccountRepository(RegisterDBEntities registerDBEntities)
        {
            this._registerDBContext = registerDBEntities;
        }
    }
}