using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AdminGastos.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastoController : ControllerBase
    {
        private readonly GastoContext _context;

        public GastoController(GastoContext context) => _context = context;

        //GET: api/Gasto
        [HttpGet]
        public ActionResult<IEnumerable<Gasto>> GetGastos()
        {
            return _context.Gastos;
        }

        //GET: api/gasto/n
        [HttpGet("{id}")]
        public ActionResult<Gasto> GetGastoById(int id)
        {
            var gasto = _context.Gastos.Find(id);

            if (gasto == null)
            {
                return NotFound();
            }

            return gasto;
        }

        //POST: api/gasto

        [HttpPost]
        public ActionResult<Gasto> PostGasto(Gasto gasto)
        {
            _context.Gastos.Add(gasto);
            _context.SaveChanges();

            return CreatedAtAction("GetGastoById", new Gasto { ID = gasto.ID }, gasto);
        }

        //PUT: api/gasto/n
        [HttpPut("{id}")]
        public ActionResult PutGasto(int id, Gasto gasto)
        {
            if (id != gasto.ID)
            {
                return BadRequest();
            }

            _context.Entry(gasto).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        //DELETE: api/gasto/n
        [HttpDelete("{id}")]
        public ActionResult<Gasto> DeleteGasto(int id)
        {
            var gasto = _context.Gastos.Find(id);

            if (gasto == null)
            {
                return NotFound();
            }

            _context.Gastos.Remove(gasto);
            _context.SaveChanges();

            return gasto;
        }

    }
}
