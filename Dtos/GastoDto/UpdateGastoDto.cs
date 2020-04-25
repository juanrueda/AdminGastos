using System;
using System.ComponentModel.DataAnnotations;

namespace AdminGastos.Dto.GastoDto
{
    public class UpdateGastoDto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public decimal Importe { get; set; }
        public bool Pagado { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaVencimiento { get; set; }   

    }
}