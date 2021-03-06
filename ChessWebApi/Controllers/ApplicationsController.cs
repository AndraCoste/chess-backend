﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ChessWebApi;
using ChessWebApi.Models;

namespace ChessWebApi.Controllers
{
    public class ApplicationsController : ApiController
    {
        private AuthContext db = new AuthContext();

        // GET: api/Applications
        private IQueryable<Application> GetAplications()
        {
            return db.Aplications;
        }

        // GET: api/Applications/5
        [ResponseType(typeof(Application))]
        private IHttpActionResult GetApplication(int id)
        {
            Application application = db.Aplications.Find(id);
            if (application == null)
            {
                return NotFound();
            }

            return Ok(application);
        }

        // PUT: api/Applications/5
        [ResponseType(typeof(void))]
        private IHttpActionResult PutApplication(int id, Application application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != application.Id)
            {
                return BadRequest();
            }

            db.Entry(application).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(id))
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

        // POST: api/Applications
        [ResponseType(typeof(Application))]
        public IHttpActionResult Register(Application application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Aplications.Add(application);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = application.Id }, application);
        }

        // DELETE: api/Applications/5
        [ResponseType(typeof(Application))]
        private IHttpActionResult DeleteApplication(int id)
        {
            Application application = db.Aplications.Find(id);
            if (application == null)
            {
                return NotFound();
            }

            db.Aplications.Remove(application);
            db.SaveChanges();

            return Ok(application);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationExists(int id)
        {
            return db.Aplications.Count(e => e.Id == id) > 0;
        }
    }
}