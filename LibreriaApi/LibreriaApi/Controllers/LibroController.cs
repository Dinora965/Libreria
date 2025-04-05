using LibreriaApi.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace LibreriaApi.Controllers
{
    public class LibroController : ApiController
    {
        private DBContextProyect db = new DBContextProyect();
        // GET: api/Libro
        /// <summary>
        /// Obtener valores
        /// </summary>
        /// <returns>JSON Libro</returns>
        /// <response code="200">Devuelve si los valores son encontrados</response>
        /// <response code="404">Devuelve si no son encontrados</response>
        [HttpGet]
        [SwaggerOperation("GetLibros")]
        [Route("api/GetLibros")]
        public IHttpActionResult Get()
        {
            var query = from autor1 in db.Autores
                        join libro in db.Libros on autor1.AutorId equals libro.Autor.AutorId
                        join editorial1 in db.Editoriales on libro.Editorial.Id equals editorial1.Id
                        join ubicacion1 in db.Ubicaciones on libro.Ubicacion.UbicacionId equals ubicacion1.UbicacionId
                        join proveedor1 in db.Proveedores on libro.Proveedor.Id equals proveedor1.Id
                        select new
                        {
                            IdLibro = libro.Id,
                            TituloLibro = libro.Titulo,
                            IdAutor = autor1.AutorId,
                            Ideditorial = editorial1.Id,
                            Aniodepublicacion = libro.Aniopublicacion,
                            cantidad = libro.Cantidad,
                            precio = libro.Precio,
                            ubicacion = ubicacion1.UbicacionId,
                            proveedor = proveedor1.Id
                        };

            return Ok(query);
        }


        // GET: api/Libro/5

        /// <summary>
        /// Obtener valor
        /// </summary>
        /// <returns>JSON Libro</returns>
        /// <response code="200">Devuelve si el valor es encontrado</response>
        /// <response code="404">Devuelve si no es encontrado</response>
        [HttpGet]
        [SwaggerOperation("GetLibro")]
        [Route("api/GetLibro")]
        public IHttpActionResult Get(int id)
        {
            var query = from autor1 in db.Autores
                        join libro in db.Libros on autor1.AutorId equals libro.Autor.AutorId
                        join editorial1 in db.Editoriales on libro.Editorial.Id equals editorial1.Id
                        join ubicacion1 in db.Ubicaciones on libro.Ubicacion.UbicacionId equals ubicacion1.UbicacionId
                        join proveedor1 in db.Proveedores on libro.Proveedor.Id equals proveedor1.Id
                        where libro.Id == id
                        select new
                        {
                            IdLibro = libro.Id,
                            TituloLibro = libro.Titulo,
                            IdAutor = autor1.AutorId,
                            Ideditorial = editorial1.Id,
                            Aniodepublicacion = libro.Aniopublicacion,
                            cantidad = libro.Cantidad,
                            precio = libro.Precio,
                            ubicacion = ubicacion1.UbicacionId,
                            proveedor = proveedor1.Id
                        };

            return Ok(query);
        }

        // POST: api/Libro

        /// <summary>
        /// Agregar valor
        /// </summary>
        /// <returns>JSON Libro</returns>
        /// <response code="200">Devuelve si los valores son agregados</response>
        /// <response code="404">Devuelve si no son agregados</response>
        [HttpPost]
        [SwaggerOperation("PostLibro")]
        [Route("api/PostLibro")]
        public IHttpActionResult Post(Libro libro, int idautor, int ideditorial, int idubicacion, int idproveedor)
        {
            Autor autorexistente = db.Autores.Find(idautor);
            if (autorexistente == null)
            {
                return NotFound();
            }
            libro.Autor = autorexistente;
            Editorial editoexistente = db.Editoriales.Find(ideditorial);
            if (editoexistente == null)
            {
                return NotFound();
            }
            libro.Editorial = editoexistente;
            Ubicacion ubiexistente = db.Ubicaciones.Find(idubicacion);
            if (ubiexistente == null)
            {
                return NotFound();
            }
            libro.Ubicacion = ubiexistente;
            Proveedor proveedorexistente = db.Proveedores.Find(idproveedor);
            if (proveedorexistente == null)
            {
                return NotFound();
            }
            libro.Proveedor = proveedorexistente;
            db.Libros.Add(libro);
            db.SaveChanges();
            return Ok(libro);
        }

        // PUT: api/Libro/5

        /// <summary>
        /// modificar valores
        /// </summary>
        /// <returns>JSON Libro</returns>
        /// <response code="200">Devuelve si los valores son moficados</response>
        /// <response code="404">Devuelve si no son modificados</response>
        [HttpPut]
        [SwaggerOperation("PutLibro")]
        [Route("api/PutLibro")]
        public IHttpActionResult Put(Libro libromodificar, int idautor, int ideditorial, int idubicacion, int idproveedor)
        {
            Autor autorexistente = db.Autores.Find(idautor);
            if (autorexistente == null)
            {
                return NotFound();
            }
            libromodificar.Autor = autorexistente;
            Editorial editoexistente = db.Editoriales.Find(ideditorial);
            if (editoexistente == null)
            {
                return NotFound();
            }
            libromodificar.Editorial = editoexistente;
            Ubicacion ubiexistente = db.Ubicaciones.Find(idubicacion);
            if (ubiexistente == null)
            {
                return NotFound();
            }
            libromodificar.Ubicacion = ubiexistente;
            Proveedor proveedorexistente = db.Proveedores.Find(idproveedor);
            if (proveedorexistente == null)
            {
                return NotFound();
            }
            libromodificar.Proveedor = proveedorexistente;
            int id = libromodificar.Id;
            db.Entry(libromodificar).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(libromodificar);
        }

        // DELETE: api/Libro/5

        /// <summary>
        /// Eliminar valores
        /// </summary>
        /// <returns>JSON Libro</returns>
        /// <response code="200">Devuelve si los valores son eliminados</response>
        /// <response code="404">Devuelve si no son eliminados</response>
        [HttpDelete]
        [SwaggerOperation("DeleteLibro")]
        [Route("api/DeleteLibro")]
        public IHttpActionResult Delete(int id)
        {
            Libro libro = db.Libros.Find(id);
            db.Libros.Remove(libro);
            db.SaveChanges();
            return Ok(libro);

        }
    }
}
