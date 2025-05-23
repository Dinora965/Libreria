﻿using LibreriaApi.Models;
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
    public class ProveedorController : ApiController
    {
        private DBContextProyect db = new DBContextProyect();
        // GET: api/Proveedor
        /// <summary>
        /// Obtener valores
        /// </summary>
        /// <returns>JSON Proveedor</returns>
        /// <response code="200">Devuelve al obtener los valore</response>
        /// <response code="404">Devueleve si no obtuvo los valores</response>
        [HttpGet]
        [SwaggerOperation("GetProveedores")]
        [Route("api/GetProveedores")]
        public IEnumerable<Proveedor> Get()
        {
            return db.Proveedores;
        }

        // GET: api/Proveedor/5

        /// <summary>
        /// Obtener un valor
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JSON Proveedor</returns>
        /// <response code="200">Devueleve si encuentra valor</response>
        /// <response code="404">Devuelve si no encuentra valor</response>
        [HttpGet]
        [SwaggerOperation("GetProveedor")]
        [Route("api/GetProveedor")]
        public IHttpActionResult Get(int id)
        {
            Proveedor proveedor = db.Proveedores.Find(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return Ok(proveedor);
        }

        // POST: api/Proveedor
        /// <summary>
        /// Agregar valor
        /// </summary>
        /// <param name="proveedor"></param>
        /// <returns>JSON Proveedor</returns>
        /// <response code="200">Devuelve cuando se agrega valor</response>
        /// <respone code= "404">Devueleve cuando no se agrega</respone>
        [HttpPost]
        [SwaggerOperation("PostProveedor")]
        [Route("api/PostProveedor")]
        public IHttpActionResult Post(Proveedor proveedor)
        {
            db.Proveedores.Add(proveedor);
            db.SaveChanges();
            return Ok(proveedor);
        }

        // PUT: api/Proveedor/5
        /// <summary>
        /// Modificar valor
        /// </summary>
        /// <param name="proveedormodificado"></param>
        /// <returns>JSON Proveedor</returns>
        /// <responde code="200">Devuelve cuando se ha modificado el valor</responde>
        /// <response code="404">Devuelve si no se ha modificado</response>
        public IHttpActionResult Put(Proveedor proveedormodificado)
        {
            int id = proveedormodificado.Id;
            db.Entry(proveedormodificado).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(proveedormodificado);
        }

        // DELETE: api/Proveedor/5
        /// <summary>
        /// Eliminar valor
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JSON Proveedor</returns>
        /// <response code="200">Devuelve al eliminar valor</response>
        /// <response code="404">Devuelve al no eliminarlo</response>
        public IHttpActionResult Delete(int id)
        {
            Proveedor proveedor = db.Proveedores.Find(id);
            db.Proveedores.Remove(proveedor);
            db.SaveChanges();
            return Ok(proveedor);
        }
    }
}
