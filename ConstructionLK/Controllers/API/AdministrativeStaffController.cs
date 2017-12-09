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
    public class AdministrativeStaffController : ApiController
    {
        private ConstructionLKContext db = new ConstructionLKContext();

        // GET: api/AdministrativeStaff
        //public IQueryable<AdministrativeStaff> GetAdministrativeStaffs()
        //{
        //    return db.AdministrativeStaffs;
        //}
        public IEnumerable<AdminDto> GetAdministrativeStaffs()
        {
            return db.AdministrativeStaffs.ToList().Select(Mapper.Map<AdministrativeStaff, AdminDto>);
        }
        // GET: api/AdministrativeStaff/5
        [ResponseType(typeof(AdministrativeStaff))]
        public IHttpActionResult GetAdministrativeStaff(int id)
        {
            AdministrativeStaff administrativeStaff = db.AdministrativeStaffs.Find(id);
            if (administrativeStaff == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<AdministrativeStaff, AdminDto>(administrativeStaff));
            //return Ok(administrativeStaff);
        }

        // PUT: api/AdministrativeStaff/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdministrativeStaff(int id, AdminDto adminDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var adminInDb = db.AdministrativeStaffs.SingleOrDefault(a => a.Id == id);
            if (id != adminDto.Id)
            {
                return BadRequest();
            }
            Mapper.Map(adminDto, adminInDb);
            //db.Entry(administrativeStaff).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministrativeStaffExists(id))
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

        // POST: api/AdministrativeStaff
        [ResponseType(typeof(AdministrativeStaff))]
        public IHttpActionResult PostAdministrativeStaff(AdminDto adminDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var admin = Mapper.Map<AdminDto, AdministrativeStaff>(adminDto);
            db.AdministrativeStaffs.Add(admin);
            db.SaveChanges();
            adminDto.Id = admin.Id;
            return CreatedAtRoute("DefaultApi", new { id = admin.Id }, admin);
        }

        // DELETE: api/AdministrativeStaff/5
        [ResponseType(typeof(AdministrativeStaff))]
        public IHttpActionResult DeleteAdministrativeStaff(int id)
        {
            AdministrativeStaff administrativeStaff = db.AdministrativeStaffs.Find(id);
            if (administrativeStaff == null)
            {
                return NotFound();
            }

            db.AdministrativeStaffs.Remove(administrativeStaff);
            db.SaveChanges();

            return Ok(administrativeStaff);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdministrativeStaffExists(int id)
        {
            return db.AdministrativeStaffs.Count(e => e.Id == id) > 0;
        }
    }
}