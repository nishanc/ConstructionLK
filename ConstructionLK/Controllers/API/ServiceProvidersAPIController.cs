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
using ConstructionLK.Models;

namespace ConstructionLK.Controllers.API
{
    public class ServiceProvidersAPIController : ApiController
    {
        private ConstructionLKContext db = new ConstructionLKContext();

        // GET: api/ServiceProvidersAPI
        public IQueryable<ServiceProvider> GetServiceProviders()
        {
            return db.ServiceProviders;
        }

        // GET: api/ServiceProvidersAPI/5
        [ResponseType(typeof(ServiceProvider))]
        public IHttpActionResult GetServiceProvider(int id)
        {
            ServiceProvider serviceProvider = db.ServiceProviders.Find(id);
            if (serviceProvider == null)
            {
                return NotFound();
            }

            return Ok(serviceProvider);
        }

        // PUT: api/ServiceProvidersAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiceProvider(int id, ServiceProvider serviceProvider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceProvider.Id)
            {
                return BadRequest();
            }

            db.Entry(serviceProvider).State = EntityState.Modified;

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

        // POST: api/ServiceProvidersAPI
        [ResponseType(typeof(ServiceProvider))]
        public IHttpActionResult PostServiceProvider(ServiceProvider serviceProvider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiceProviders.Add(serviceProvider);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = serviceProvider.Id }, serviceProvider);
        }

        // DELETE: api/ServiceProvidersAPI/5
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