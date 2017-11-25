using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using ConstructionLK.DTOs;
using ConstructionLK.Models;

namespace ConstructionLK.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ConstructionLKContext db = new ConstructionLKContext();

        // GET: api/Customers
        //public IQueryable<Customer> GetCustomers()
        //{
        //    return db.Customers;
        //}
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return db.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }
        // GET: api/Customers/5
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }
        //[ResponseType(typeof(Customer))]
        //public IHttpActionResult GetCustomer(int id)
        //{
        //    Customer customer = db.Customers.Find(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(customer);
        //}

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customerInDb = db.Customers.SingleOrDefault(c => c.Id == id);
            if (id != customerDto.Id)
            {
                return BadRequest();
            }
            Mapper.Map(customerDto, customerInDb);
            //db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            db.Customers.Add(customer);
            db.SaveChanges();
            customerDto.Id = customer.Id;
            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.Id == id) > 0;
        }
    }

}