using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using Web_API.Models;

namespace Web_API.Repository
{
    public class FlightRepository : IDataRepository<Flight>
    {
        RegisterDBEntities _registerDBEntities;

        public FlightRepository(RegisterDBEntities registerDBEntities)
        {
            this._registerDBEntities = registerDBEntities;
        }
        public void Add(Flight entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int flightNo)
        {
            Flight flight = _registerDBEntities.Flights.Find(flightNo);
            _registerDBEntities.Flights.Remove(flight);
            //_registerDBEntities.SaveChanges();
        }


        public Flight Get(int id)
        {
            return _registerDBEntities.Flights.Find(id);
        }

        public IEnumerable<Flight> GetAll()
        {

            return _registerDBEntities.Flights.ToList();

        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return _registerDBEntities.Flights.ToList();
        }

        public void Update(Flight dbEntity)
        {
            throw new NotImplementedException();
        }
    }
}