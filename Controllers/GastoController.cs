using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AdminGastos.Models;

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

        //GET: api/Gasto/n
        [HttpGet("{id}")]
        public ActionResult<Gasto> GetGastoById(int id)
        {
            var gasto = _context.Gastos.Find(id);

            if(gasto == null)
            {
                return NotFound();
            }

            return gasto;
        }
    }
}
