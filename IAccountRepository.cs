using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_API.Models;

namespace Web_API.Repository
{
    internal interface IAccountRepository
    {
        Customer VerifyLogin(string userName , string password);
       
    }
}
