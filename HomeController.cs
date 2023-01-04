using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;

using System.Web;
using System.Web.Mvc;
using Web_API.Models;
using Web_API.Controllers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Configuration;
using Web_MVC.Models;
using Web_MVC.Repository;
using System.Web.Security;

namespace Web_MVC.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<UserViewModel> user = new List<UserViewModel>();
            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("http://localhost:60308/Register/GetAll")) 
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<List<UserViewModel>>(apiResponse);
                }
            }
            return View(user);
        }


        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RegisterUser(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                UserViewModel newUser = new UserViewModel();
                var service = new ServiceRepository();
                {

                    using (var response = service.PostResponse("http://localhost:60308/Register/CreateUser", user))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        newUser
                            = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                    }
                }

                return RedirectToAction("LoginUser");
            }
            return View(user);
        }

        /*
        Author : Sai Lakshmi Saidu
        Class Name : RegistrationController.cs
        Methos Name : RegisterUser()
        Description : In this Method we are Assigning the values of user inputs of Registration filelds
                      And we are passing the same to custregform method in Register controller of
                      Web_API project and retutn back we are getting status code
                      based on status code we are moving a head the registration part
                      If status code 200 means success, else based on status code we're showing Error messages
        Created on : 16th Dec, 2022. 
        */



        [HttpPost]
        public ActionResult RegisterUserZ(UserRegisterModel Ur)
        {
            //RegisterController reg = new RegisterController();

            if (ModelState.IsValid)
            {
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("http://localhost:60308/Register/custregform");
                var insertrec = hc.PostAsJsonAsync<UserRegisterModel>("custregform", Ur);//Asynchronosly passing the values in Json Format to API
                var savrec = insertrec.Result;//Saving the User Details 

                //Condition for Successfull Registartion 
                if ((int)savrec.StatusCode == 200)
                {
                    ViewBag.Successmessage = "Successfully Registered!!!!!";
                }
                //Condition for User Already Existing Check
                if ((int)savrec.StatusCode == 422)
                {
                    ViewBag.userAlreadymessage = "User Name Already Exist, please provide a new User Name";
                }
                //Condition for Mobile Num Should be 10 digits
                if ((int)savrec.StatusCode == 423)
                {
                    ViewBag.MobileLengthmessage = "Mobile Num Should be 10 Digits Only";
                }
                //Condition for Mobile Num Already Exist
                if ((int)savrec.StatusCode == 424)
                {
                    ViewBag.MobileExistmessage = "Mobile Num Already Exist, please provide a new Mobile Number";
                }
                //Condition for Email Id Already Exist
                if ((int)savrec.StatusCode == 425)
                {
                    ViewBag.EmailExistmessage = "Email Already Exist, please provide a new Email ID";
                }
            }
            return View();

        }


        //This Action method is used to display Login View
        public ActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LoginUser(LoginViewModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserViewModel newUser = new UserViewModel();
                    var service = new ServiceRepository();
                    {
                        using (var response = service.VerifyLogin("api/Account/Login", login))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            newUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                        }
                    }
                    if (newUser != null)
                    {
                        ViewBag.message = "Login Success";
                    }
                    else
                    {
                        ViewBag.message = "incorrect";
                    }
                }
            }
            catch
            {

            }
            return RedirectToAction("flightdetails","Flight");

        }

        //This Post Method will validate the userName & Password valid or not using WebAPI
        [HttpPost]
        public ActionResult LoginUserZ(UserRegisterModel Ur)
        {
            if (!(string.IsNullOrEmpty(Ur.Username) || string.IsNullOrEmpty(Ur.Password)))
            {

                if (!ModelState.IsValid)
                {
                    HttpClient hc = new HttpClient();
                    hc.BaseAddress = new Uri("http://localhost:60308/Register/custLogin"); // URL for Login WebAPI
                    var checkLoginDetails = hc.PostAsJsonAsync<UserRegisterModel>("custLogin", Ur);//Asynchronosly passing the values in Json Format to API
                    var checkrec = checkLoginDetails.Result;//Checking the User Login ID & Password 

                    //Condition for Successfull Login We need to Navigate to Flght Seach Page 
                    if ((int)checkrec.StatusCode == 200)
                    {
                        ViewBag.message = "Login Success!!";
                    }
                    //Condition for Invalid User Name & Password
                    if ((int)checkrec.StatusCode == 426)
                    {
                        ViewBag.message = "Invalid User Id & Password";
                    }
                }
            }
            return View();

        }
        public ActionResult AdminLoginUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AdminLoginUser(LoginViewModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserViewModel newUser = new UserViewModel();
                    var service = new ServiceRepository();
                    {
                        using (var response = service.VerifyLogin("api/Account/Login", login))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            newUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                        }
                    }
                    if (newUser != null)
                    {
                        ViewBag.message = "Login Success";
                    }
                    else
                    {
                        ViewBag.message = "incorrect";
                    }
                }
            }
            catch
            {

            }
            return RedirectToAction("Index","Home");

        }


    }
}