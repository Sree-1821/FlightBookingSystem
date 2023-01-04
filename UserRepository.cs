using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web_API.Models;

namespace Web_API.Repository
{
    public class UserRepository : IDataRepository<Customer>
    {
        private readonly RegisterDBEntities _RegisterDBContext;

        // Constructor Dependency Injection
        public UserRepository(RegisterDBEntities registerDBContext)
        {
            _RegisterDBContext = registerDBContext;
        }

        public void Add(Customer newUser)
        {
            _RegisterDBContext.Customers.Add(newUser);
            _RegisterDBContext.SaveChanges();
        }
        public IEnumerable<Customer> GetAll()
        {
            _RegisterDBContext.Customers.ToList();
            _RegisterDBContext.SaveChanges();
            return _RegisterDBContext.Customers;    
        }
        


        public void Delete(int entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

       
        public void Update(Customer dbEntity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAllFlights()
        {
            throw new NotImplementedException();
        }
    }
}