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
        public IHttpActionResult  GetCustomers(string query = null)
        {
            return Ok(db.Customers.ToList().Select(mapper.Map<Customer, CustomerDto>));
           
        }

        //GET /api/customers/1
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer == null)
                return NotFound();
            return Ok(mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST /api/customers/
        [HttpPost]
        public IHttpActionResult PostCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return NotFound();

            var customer = mapper.Map<CustomerDto, Customer>(customerDto);
            db.Customers.Add(customer);
            try
            {
                db.SaveChanges();
            }
            catch
            {
                return NotFound();
            }
            customerDto.Id = customer.Id;
            return CreatedAtRoute("DefaultApi",new { customerDto.Id},customerDto);
        }

        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult PutCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = mapper.Map<CustomerDto, Customer>(customerDto);

            if (id != customer.Id)
                return BadRequest();

            db.Entry(customer).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch
            {
                return BadRequest();
            }
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer == null)
                return NotFound();
            db.Customers.Remove(customer);
            db.SaveChanges();
            return Ok(mapper.Map<Customer,CustomerDto>(customer));
        }
    }
}










   






   