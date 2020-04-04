using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AdminGastos.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AdminGastos.Dto.Gasto;

namespace AdminGastos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GastoController : ControllerBase
    {
        private readonly IGastoService _gastoService;

        public GastoController(IGastoService gastoService)
        {
            _gastoService = gastoService;
        }

        //GET: Gasto
        [HttpGet]
        public async Task<IActionResult> GetAllGastos()
        {
            return Ok(await _gastoService.GetAllGastos());
        }

        //GET: Gasto/n
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGastoById(int id)
        {
            var gasto = _gastoService.GetGastoById(id);

            if (gasto == null)
            {
                return NotFound();
            }

            return Ok(await gasto);
        }

        // //GET: Gasto/nombre
        // [HttpGet("{nombre}")]
        // public IActionResult GetGastoByNombre(string nombre)
        // {
        //     return Ok(_context.Gastos.AllAsync(g => g.Nombre == nombre));
        // }


        // //GET: Gasto/suma
        // [HttpGet("suma")]
        // public ActionResult<decimal> SumaGastos()
        // {
        //     decimal suma = 0;
        //     foreach (Gasto gasto in _context.Gastos)
        //     {
        //         suma = suma + gasto.Importe;
        //     }

        //     return suma;
        // }


        //POST: Gasto
        [HttpPost]
        public async Task<IActionResult> PostGasto(AddGastoDto gasto)
        {
            return Ok(await _gastoService.PostGasto(gasto));
        }

        //PUT: Gasto
        [HttpPut]
        public async Task<IActionResult> PutGasto(UpdateGastoDto updatedGasto)
        {
            ServiceResponse<GetGastoDto> response = await _gastoService.PutGasto(updatedGasto);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        //DELETE: Gasto/n
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGasto(int id)
        {
            ServiceResponse<IEnumerable<GetGastoDto>> response = await _gastoService.DeleteGasto(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

    }
}
