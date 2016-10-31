using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using ChessWebApi.Models;

namespace ChessWebApi.Controllers
{
    public class ContactsController: ApiController
    {

        private AuthContext db = new AuthContext();

        // POST: api/Applications
        [ResponseType(typeof(ContactModel))]
        public IHttpActionResult Add(ContactModel contactModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ContactModels.Add(contactModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contactModel.Id }, contactModel);
        }
    }
}