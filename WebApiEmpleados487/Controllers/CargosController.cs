using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Security;
using WebApiEmpleados487.Extensiones;
using WebApiEmpleados487.Models;

namespace WebApiEmpleados487.Controllers
{
    [Authorize]
    [EnableCors("*","*","*")]
    public class CargosController : ApiController
    {
        private empleadosEntities db = new empleadosEntities();

        // GET: api/Cargos
        [AllowAnonymous]
        public IQueryable<Cargos> GetCargos()
        {
            return db.Cargos;
        }

        // GET: api/Cargos/5
        [ResponseType(typeof(Cargos))]
        [FiltroLog]
        public IHttpActionResult GetCargos(int id)
        {
            Cargos cargos = db.Cargos.Find(id);
            if (cargos == null)
            {
                return NotFound();
            }

            return Ok(cargos);
        }

        // PUT: api/Cargos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCargos(int id, Cargos cargos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cargos.id)
            {
                return BadRequest();
            }

            db.Entry(cargos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargosExists(id))
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

        // POST: api/Cargos
        [ResponseType(typeof(Cargos))]
        [Authorize(Roles="Admin")]
        public IHttpActionResult PostCargos(Cargos cargos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cargos.Add(cargos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cargos.id }, cargos);
        }

        // DELETE: api/Cargos/5
        [ResponseType(typeof(Cargos))]
        public IHttpActionResult DeleteCargos(int id)
        {
            Cargos cargos = db.Cargos.Find(id);
            if (cargos == null)
            {
                return NotFound();
            }

            db.Cargos.Remove(cargos);
            db.SaveChanges();

            return Ok(cargos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CargosExists(int id)
        {
            return db.Cargos.Count(e => e.id == id) > 0;
        }
    }
}