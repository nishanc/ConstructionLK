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
    public class ItemsController : ApiController
    {
        private ConstructionLKContext db = new ConstructionLKContext();

        // GET: api/Items
        //public IQueryable<Item> GetItems()
        //{
        //    return db.Items;
        //}
        public IEnumerable<ItemDto> GetItems()
        {
            return db.Items.Select(Mapper.Map<Item, ItemDto>);
        }
        // GET: api/Items/5

        //[ResponseType(typeof(Item))]
        //public IHttpActionResult GetItem(int id)
        //{
        //    Item item = db.Items.Find(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(item);
        //}
        public ItemDto GetItem(int id)
        {
            var item = db.Items.SingleOrDefault(i => i.Id == id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<Item, ItemDto>(item);
        }
        // PUT: api/Items/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItem(int id, ItemDto itemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var itemInDb = db.Items.SingleOrDefault(i => i.Id == id);
            if (id != itemDto.Id)
            {
                return BadRequest();
            }
            Mapper.Map(itemDto, itemInDb);
            //db.Entry(itemDto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/Items
        [ResponseType(typeof(Item))]
        public IHttpActionResult PostItem(ItemDto itemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = Mapper.Map<ItemDto, Item>(itemDto);
            db.Items.Add(item);
            db.SaveChanges();
            itemDto.Id = item.Id;
            return CreatedAtRoute("DefaultApi", new { id = itemDto.Id }, itemDto);
        }

        // DELETE: api/Items/5
        [ResponseType(typeof(Item))]
        public IHttpActionResult DeleteItem(int id)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            db.Items.Remove(item);
            db.SaveChanges();

            return Ok(item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemExists(int id)
        {
            return db.Items.Count(e => e.Id == id) > 0;
        }
    }
}