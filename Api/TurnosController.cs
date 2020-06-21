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
    public class TurnosController : Controller
    {
        private readonly DataContext contexto;
        private readonly IConfiguration config;

        public TurnosController(DataContext contexto, IConfiguration config)
        {
            this.contexto = contexto;
            this.config = config;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turno>>> Get()
        {
            return contexto.Turnos;
        }



        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                //var usuario = User.Identity.Name;
                return Ok(contexto.Turnos.SingleOrDefault(x => x.IdTurno == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(Turno entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contexto.Turnos.Add(entidad);
                    contexto.SaveChanges();
                    return CreatedAtAction(nameof(Get), new { id = entidad.IdTurno }, entidad);
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
