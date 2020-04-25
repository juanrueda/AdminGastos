using System.Collections.Generic;
using System.Threading.Tasks;
using AdminGastos.Dto.GastoDto;
using AdminGastos.Models;
using AdminGastos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Linq;
using System;

public class GastoService : IGastoService
{
    private readonly GastoContext _context;
    private readonly IMapper _mapper;

    public GastoService(IMapper mapper, GastoContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ServiceResponse<IEnumerable<GetGastoDto>>> GetAllGastos(int userId)
    {
        ServiceResponse<IEnumerable<GetGastoDto>> serviceResponse = new ServiceResponse<IEnumerable<GetGastoDto>>();

        IEnumerable<Gasto> gastos = await _context.Gastos.Where(g => g.User.Id == userId).ToListAsync();

        serviceResponse.Data = gastos.Select(g => _mapper.Map<GetGastoDto>(g));
        return serviceResponse;
    }
    public async Task<ServiceResponse<GetGastoDto>> GetGastoById(int id)
    {
        ServiceResponse<GetGastoDto> serviceResponse = new ServiceResponse<GetGastoDto>();
        
        Gasto gasto = await _context.Gastos.FindAsync(id);

        serviceResponse.Data = _mapper.Map<GetGastoDto>(gasto);
        return serviceResponse;
    }
    public async Task<ServiceResponse<IEnumerable<GetGastoDto>>> PostGasto(AddGastoDto newGasto)
    {
        ServiceResponse<IEnumerable<GetGastoDto>> serviceResponse = new ServiceResponse<IEnumerable<GetGastoDto>>();

        User user = await _context.Users.FindAsync(newGasto.UserId);

        Gasto gasto = new Gasto();

        gasto.Nombre = newGasto.Nombre;
        gasto.Importe = newGasto.Importe;
        gasto.FechaVencimiento = newGasto.FechaVencimiento;
        gasto.Pagado = newGasto.Pagado;
        gasto.User = user;
        
        //Gasto gasto = _mapper.Map<Gasto>(newGasto);

        await _context.Gastos.AddAsync(gasto);
        await _context.SaveChangesAsync();

        serviceResponse.Data = _context.Gastos.Select(g => _mapper.Map<GetGastoDto>(g));

        return serviceResponse;
    }
    public async Task<ServiceResponse<GetGastoDto>> PutGasto(UpdateGastoDto updatedGasto)
    {
        ServiceResponse<GetGastoDto> serviceResponse = new ServiceResponse<GetGastoDto>();
        try
        {
            Gasto gasto = await _context.Gastos.FindAsync(updatedGasto.ID);

            gasto.Nombre = updatedGasto.Nombre;
            gasto.Importe = updatedGasto.Importe;
            gasto.Pagado = updatedGasto.Pagado;
            gasto.FechaVencimiento = updatedGasto.FechaVencimiento;

            //_context.Entry(_mapper.Map<Gasto>(updatedGasto)).State = EntityState.Modified;
            _context.Gastos.Update(gasto);
            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<GetGastoDto>(updatedGasto);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
    public async Task<ServiceResponse<IEnumerable<GetGastoDto>>> DeleteGasto(int id)
    {
        ServiceResponse<IEnumerable<GetGastoDto>> serviceResponse = new ServiceResponse<IEnumerable<GetGastoDto>>();

        try
        {
            Gasto gasto = await _context.Gastos.FindAsync(id);

            _context.Gastos.Remove(gasto);
            await _context.SaveChangesAsync();

            serviceResponse.Data = _context.Gastos.Select(g => _mapper.Map<GetGastoDto>(g));
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}