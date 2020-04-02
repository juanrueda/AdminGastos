using System.Collections.Generic;
using System.Threading.Tasks;
using AdminGastos.Dto.Gasto;
using AdminGastos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Linq;

public class GastoService : IGastoService
{
    private readonly GastoContext _context;
    private readonly IMapper _mapper;

    public GastoService(IMapper mapper, GastoContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ServiceResponse<IEnumerable<GetGastoDto>>> GetAllGastos()
    {
        ServiceResponse<IEnumerable<GetGastoDto>> serviceResponse = new ServiceResponse<IEnumerable<GetGastoDto>>();
        serviceResponse.Data = _context.Gastos.Select(g => _mapper.Map<GetGastoDto>(g));
        return serviceResponse;
    }
    public async Task<ServiceResponse<GetGastoDto>> GetGastoById(int id)
    {
        ServiceResponse<GetGastoDto> serviceResponse = new ServiceResponse<GetGastoDto>();
        serviceResponse.Data = _mapper.Map<GetGastoDto>(_context.Gastos.Find(id));
        return serviceResponse;
    }
    public async Task<ServiceResponse<IEnumerable<GetGastoDto>>> PostGasto(AddGastoDto gasto)
    {
        ServiceResponse<IEnumerable<GetGastoDto>> serviceResponse = new ServiceResponse<IEnumerable<GetGastoDto>>();

        _context.Gastos.Add(_mapper.Map<Gasto>(gasto));
        _context.SaveChanges();

        serviceResponse.Data = _context.Gastos.Select(g => _mapper.Map<GetGastoDto>(g));

        return serviceResponse;
    }
    public async Task<ServiceResponse<GetGastoDto>> PutGasto(int id, Gasto gasto)
    {
        ServiceResponse<GetGastoDto> serviceResponse = new ServiceResponse<GetGastoDto>();

        _context.Entry(gasto).State = EntityState.Modified;
        _context.SaveChanges();

        serviceResponse.Data = _mapper.Map<GetGastoDto>(gasto);

        return serviceResponse;
    }
    public async Task<ServiceResponse<IEnumerable<GetGastoDto>>> DeleteGasto(int id)
    {
        ServiceResponse<IEnumerable<GetGastoDto>> serviceResponse = new ServiceResponse<IEnumerable<GetGastoDto>>();

        var gasto = _context.Gastos.Find(id);

        _context.Gastos.Remove(gasto);
        _context.SaveChanges();

        serviceResponse.Data = _context.Gastos.Select(g => _mapper.Map<GetGastoDto>(g));

        return serviceResponse;
    }
}