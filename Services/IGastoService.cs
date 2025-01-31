using System.Collections.Generic;
using System.Threading.Tasks;
using AdminGastos.Dto.Gasto;
using AdminGastos.Models;
using Microsoft.AspNetCore.Mvc;

public interface IGastoService
{
    Task<ServiceResponse<IEnumerable<GetGastoDto>>> GetAllGastos(int userId);
    Task<ServiceResponse<GetGastoDto>> GetGastoById(int id);
    Task<ServiceResponse<IEnumerable<GetGastoDto>>> PostGasto(AddGastoDto newGasto);
    Task<ServiceResponse<GetGastoDto>> PutGasto(UpdateGastoDto updatedGasto);
    Task<ServiceResponse<IEnumerable<GetGastoDto>>> DeleteGasto(int id);

}