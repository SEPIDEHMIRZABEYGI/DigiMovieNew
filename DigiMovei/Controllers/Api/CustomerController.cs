using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using DigiMovei.Models;
using DigiMovei.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace DigiMovei.Api
{
    public class CustomerController : ApiController
    {
        private ApplicationDbContext db;
        private IMapper mapper;

        public CustomerController()
        {
            db = new ApplicationDbContext();
            mapper = new MapperConfiguration(c =>
            {
                c.CreateMap<Customer, CustomerDto>();
                c.CreateMap<CustomerDto, Customer>();
            }).CreateMapper();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        //GET /api/customers
        [HttpGet]
        public IEnumerable<CustomerDto> GetCustomers(string query = null)
        {
            return db.Customers.ToList().Select(mapper.Map<Customer, CustomerDto>);
        }

        //GET /api/customers/1
        [HttpGet]
        public CustomerDto GetCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return mapper.Map<Customer, CustomerDto>(customer);
        }

        //POST /api/customers/
        [HttpPost]
        public CustomerDto PostCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var customer = mapper.Map<CustomerDto, Customer>(customerDto);
            db.Customers.Add(customer);
            try
            {
                db.SaveChanges();
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            customerDto.Id = customer.Id;
            return customerDto;
        }

        //PUT /api/customers/1
        [HttpPut]
        public void PutCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = mapper.Map<CustomerDto, Customer>(customerDto);

            if (id != customer.Id)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            db.Entry(customer).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            db.Customers.Remove(customer);
            db.SaveChanges();
        }
    }
}










   






   