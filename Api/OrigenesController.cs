using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Laboratorio.Models;
using Microsoft.Extensions.Configuration;

namespace Laboratorio.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrigenesController : Controller
    {
        private readonly DataContext contexto;
        private readonly IConfiguration config;

        public OrigenesController(DataContext contexto, IConfiguration config)
        {
            this.contexto = contexto;
            this.config = config;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Origen>>> Get()
        {
            return contexto.Origenes;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                //var usuario = User.Identity.Name;
                return Ok(contexto.Origenes.SingleOrDefault(x => x.IdOrigen == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(Origen entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entidad.IdOrigen = contexto.Origenes.Single(e => e.Email == User.Identity.Name).IdOrigen;
                    contexto.Origenes.Add(entidad);
                    contexto.SaveChanges();
                    return CreatedAtAction(nameof(Get), new { id = entidad.IdOrigen }, entidad);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            //contexto.Propietarios.Update()


        }
    }
}
