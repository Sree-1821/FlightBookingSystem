using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.UI.WebControls;
using Web_API.Models;
using Web_API.Repository;

namespace Web_API.Controllers
{

    public class RegisterController : ApiController
    {
        private IDataRepository<Customer> _dataRepository;

        public RegisterController()
        {
            this._dataRepository = new UserRepository(new RegisterDBEntities());
        }

        [HttpPost]
        public IHttpActionResult CreateUser([FromBody] Customer userObj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dataRepository.Add(userObj);
            }
            
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(userObj);
        }
        [HttpGet]
        public IEnumerable<Customer> GetAll()
        {
            return _dataRepository.GetAll();
        }

        /* commented to implement repository pattern working code
        public RegisterController()
        {
            objRegisterDBEntities = new RegisterDBEntities();
        }
        */

        /*
       Author : Sai Lakshmi Saidu
       Class Name : RegisterController.cs
       Methos Name : custregform()
       Description : In this Method we are taking the values from Home Controller index method
                    Now we are checking here all the validations from client side as User Name
                    existing in the DB already or not , Mobile Number length
                    if these validation failed then we are assigning status codes dynamically
                    and showing the error message to user

                    If all validaions passed and i.e. 200 OK then we are showing user success msg
                    and the particulars will be get inserted in the DB. 
       Created on : 13th Dec, 2022. 
       */
        RegisterDBEntities objRegisterDBEntities;

        public IHttpActionResult custregform(UserRegisterModel Ur)
        {

            RegisterDBEntities nd = new RegisterDBEntities();

            if (nd.Customers.Any(model => model.Username == Ur.Username))
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse((HttpStatusCode)422, new HttpError("Something goes wrong")));
            }

            else if (Ur.MobileNumber == Ur.MobileNumber)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse((HttpStatusCode)423, new HttpError("Something goes wrong")));
            }

            else if (nd.Customers.Any(model => model.MobileNumber == Ur.MobileNumber))
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse((HttpStatusCode)424, new HttpError("Something goes wrong")));
            }

            else if (nd.Customers.Any(model => model.EmailID == Ur.EmailID))
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse((HttpStatusCode)425, new HttpError("Something goes wrong")));
            }

            else
            {
                _ = nd.Customers.Add(new Customer()
                {
                    CustomerID = Ur.CustomerID,
                    Firstname = Ur.Firstname,
                    Lastname = Ur.Lastname,
                    Age = Ur.Age,
                    Gender = Ur.Gender,
                    EmailID = Ur.EmailID,
                    MobileNumber = (string)Ur.MobileNumber,
                    Username = Ur.Username,
                    Password = Ur.Password,
                });
                nd.SaveChanges();
                return Ok();
            }

        }

        //This is the WebAPI Customer Login Details checking methos 
        //In this method we will take up the user entered Username & Password from Front end 
        //We check the Username & Password matching or not in 91st line witha where condition 
        //if UserName & Password are valid API retuns 200 OK status code ==> Login Success full
        //if UserName & password are invalid Dinamically we are sending 426 as a login failure status code
        public IHttpActionResult custLogin(UserRegisterModel Ur)
        {
            RegisterDBEntities nd = new RegisterDBEntities();

            var checkValidUser = objRegisterDBEntities.Customers.Where(m => m.Username == Ur.Username && 
            m.Password == Ur.Password).FirstOrDefault();

            if (checkValidUser != null)
            {
                return Ok();
            }

            else
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse((HttpStatusCode)426, new HttpError("Something goes wrong")));
            }
        }

    }
}
