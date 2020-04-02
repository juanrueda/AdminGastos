using System;
using System.ComponentModel.DataAnnotations;

namespace AdminGastos.Dto.Gasto
{
    public class AddGastoDto
    {
        public string Nombre { get; set; }
        public decimal Importe { get; set; }
        public bool Pagado { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaVencimiento { get; set; }
    }
}