using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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
    public class ServiceProvidersController : ApiController
    {
        private ConstructionLKContext db = new ConstructionLKContext();

        // GET: api/ServiceProviders
        //public IQueryable<ServiceProvider> GetServiceProviders()
        //{
        //    return db.ServiceProviders;
        //}
        public IEnumerable<ServiceProviderDto> GetServiceProviders()
        {
            return db.ServiceProviders
                .Include(s => s.ServiceProviderType)
                .ToList()
                .Select(Mapper.Map<ServiceProvider, ServiceProviderDto>);
        }
        // GET: api/ServiceProviders/5
        //[ResponseType(typeof(ServiceProvider))]
        //public IHttpActionResult GetServiceProvider(int id)
        //{
        //    ServiceProvider serviceProvider = db.ServiceProviders.Find(id);
        //    if (serviceProvider == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(serviceProvider);
        //}
        public IHttpActionResult GetServiceProvider(int id)
        {
            var serviceProvider = db.ServiceProviders.SingleOrDefault(s => s.Id == id);
            if (serviceProvider == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<ServiceProvider, ServiceProviderDto>(serviceProvider));
        }
        // PUT: api/ServiceProviders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiceProvider(int id, ServiceProviderDto serviceProviderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var serviceProviderInDb = db.ServiceProviders.SingleOrDefault(s => s.Id == id);
            if (id != serviceProviderDto.Id)
            {
                return BadRequest();
            }
            Mapper.Map(serviceProviderDto, serviceProviderInDb);
            //db.Entry(serviceProviderDto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceProviderExists(id))
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

        // POST: api/ServiceProviders
        [ResponseType(typeof(ServiceProviderDto))]
        public IHttpActionResult PostServiceProvider(ServiceProviderDto serviceProviderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var serviceProvider = Mapper.Map<ServiceProviderDto, ServiceProvider>(serviceProviderDto);
            db.ServiceProviders.Add(serviceProvider);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            serviceProviderDto.Id = serviceProvider.Id;
            return CreatedAtRoute("DefaultApi", new { id = serviceProviderDto.Id }, serviceProviderDto);
        }

        // DELETE: api/ServiceProviders/5
        [ResponseType(typeof(ServiceProvider))]
        public IHttpActionResult DeleteServiceProvider(int id)
        {
            ServiceProvider serviceProvider = db.ServiceProviders.Find(id);
            if (serviceProvider == null)
            {
                return NotFound();
            }

            db.ServiceProviders.Remove(serviceProvider);
            db.SaveChanges();

            return Ok(serviceProvider);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceProviderExists(int id)
        {
            return db.ServiceProviders.Count(e => e.Id == id) > 0;
        }
    }
}