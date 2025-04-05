using LibreriaApi.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibreriaApi.Controllers
{
    public class EditorialController : ApiController
    {
        private DBContextProyect db = new DBContextProyect();
        // GET: api/Editorial
        /// <summary>
        /// Obtiene la lista completa de editoriales registradas en la base de datos
        /// </summary>
        /// <returns>JSON Editorial</returns>
        /// <response code="200">Devuelve la lista de editoriales si se encuentran registros en la base de datos</response>
        /// <response code="404">Devuelve un error si no se encuentran editoriales</response>
        [HttpGet]
        [SwaggerOperation("GetEditoriales")]
        [Route("api/GetEditoriales")]
        public IEnumerable<Editorial> Get()
        {
            return db.Editoriales;
        }

        // GET: api/Editorial/5

        /// <summary>
        /// Obtiene los detalles de una editorial específica utilizando su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JSON Editorial</returns>
        /// <response code="200">Devuelve la lista de editoriales si se encuentran registros en la base de datos</response>
        /// <response code="404">Devuelve un error si no encuentra editoriales</response>
        [HttpGet]
        [SwaggerOperation("GetEditorial")]
        [Route("api/GetEditorial")]
        public IHttpActionResult Get(int id)
        {
            Editorial editorial = db.Editoriales.Find(id);
            if (editorial == null)
            {
                return NotFound();
            }
            return Ok(editorial);
        }

        // POST: api/Editorial
        /// <summary>
        /// Crea una nueva editorial en la base de datos.
        /// </summary>
        /// <param name="editorial"></param>
        /// <returns>JSON Editorial</returns>
        /// <response code="200">Devuelve la editorial creada con los datos proporcionados</response>
        /// <respone code= "404">Devuelve un error si no se pudo crear la editorial</respone>
        [HttpPost]
        [SwaggerOperation("PostEditorial")]
        [Route("api/PostEditorial")]
        public IHttpActionResult Post(Editorial editorial)
        {
            db.Editoriales.Add(editorial);
            db.SaveChanges();
            return Ok(editorial);
        }

        // PUT: api/Editorial/5
        /// <summary>
        /// Actualiza los detalles de una editorial existente en la base de datos.
        /// </summary>
        /// <param name="editorialmodificado"></param>
        /// <returns>JSON Editorial</returns>
        /// <responde code="200">Devuelve la editorial actualizada si la operación es exitosa</responde>
        /// <response code="404">Devuelve un error si no se pudo encontrar o modificar la editorial</response>
        public IHttpActionResult Put(Editorial editorialmodificado)
        {
            int id = editorialmodificado.Id;
            db.Entry(editorialmodificado).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(editorialmodificado);
        }

        // DELETE: api/Editorial/5
        /// <summary>
        /// Elimina una editorial específica de la base de datos utilizando su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JSON Editorial</returns>
        /// <response code="200">Devuelve la editorial eliminada si la operación es exitosa</response>
        /// <response code="404">Devuelve un error si no se pudo eliminar la editorial</response>
        public IHttpActionResult Delete(int id)
        {
            Editorial editorial = db.Editoriales.Find(id);
            db.Editoriales.Remove(editorial);
            db.SaveChanges();
            return Ok(editorial);
        }
    }
}
