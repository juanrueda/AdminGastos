using System.Collections.Generic;
using System.Threading.Tasks;
using AdminGastos.Dto.Gasto;
using AdminGastos.Models;
using Microsoft.AspNetCore.Mvc;

public interface IGastoService
{
    Task<ServiceResponse<IEnumerable<GetGastoDto>>> GetAllGastos();
    Task<ServiceResponse<GetGastoDto>> GetGastoById(int id);
    Task<ServiceResponse<IEnumerable<GetGastoDto>>> PostGasto(AddGastoDto gasto);
    Task<ServiceResponse<GetGastoDto>> PutGasto(int id, Gasto gasto);
    Task<ServiceResponse<IEnumerable<GetGastoDto>>> DeleteGasto(int id);

}