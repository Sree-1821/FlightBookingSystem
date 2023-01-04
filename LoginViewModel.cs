using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Web_MVC.Models
{
    public class LoginViewModel
    {
        public string userName { get; set; }

        public string Password { get; set; }
    }
}