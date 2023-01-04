using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Web_MVC.Repository
{
    public class ServiceRepository
    {
        HttpClient client;

        public ServiceRepository()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiBaseURL"].ToString());
        }
        public HttpResponseMessage PostResponse(string url, object model)
        {
            return client.PostAsJsonAsync(url, model).Result;
        }

        public HttpResponseMessage VerifyLogin(string url, object model)
        {
            return client.PostAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage GetResponse(string url)
        {
            return client.GetAsync(url).Result;
        }
        public HttpResponseMessage DeleteResponse(string url)
        {
            return client.DeleteAsync(url).Result;
        }
        public HttpResponseMessage VerifyAdminLogin(string url, object model)
        {
            return client.PostAsJsonAsync(url, model).Result;
        }

    }
}
