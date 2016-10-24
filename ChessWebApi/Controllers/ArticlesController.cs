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
using ChessWebApi;
using ChessWebApi.Models;

namespace ChessWebApi.Controllers
{
    public class ArticlesController : ApiController
    {
        private AuthContext db = new AuthContext();

        // GET: api/Articles
        [HttpGet]
        public IQueryable<Article> All()
        {
            return db.Articles;
        }

        // GET: api/Articles/5
        [ResponseType(typeof(Article))]
        [HttpGet]
        public IHttpActionResult GetArticleById(int id)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }
        // GET: api/Articles/liga-ac
        [ResponseType(typeof(Article))]
        [HttpGet]
        public IHttpActionResult GetArticleBySelector(string selector)
        {
            var article =
                db.Articles.FirstOrDefault(
                    art => art.Selector.Equals(selector, StringComparison.InvariantCultureIgnoreCase));
            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        // PUT: api/Articles/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Update(int id, Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != article.Id)
            {
                return BadRequest();
            }

            db.Entry(article).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(id))
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

        // POST: api/Articles
        [ResponseType(typeof(Article))]
        [HttpPost]
        public IHttpActionResult Add(Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Articles.Add(article);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = article.Id }, article);
        }

        [ResponseType(typeof(List<Article>))]
        [HttpPost]
        public IHttpActionResult AddMany(List<Article> articles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (var article in articles)
            {
                db.Articles.Add(article);
            }
            db.SaveChanges();

            return Created("DefaultApi", articles);
        }

        // DELETE: api/Articles/5
        [ResponseType(typeof(Article))]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            db.Articles.Remove(article);
            db.SaveChanges();

            return Ok(article);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArticleExists(int id)
        {
            return db.Articles.Count(e => e.Id == id) > 0;
        }
    }
}