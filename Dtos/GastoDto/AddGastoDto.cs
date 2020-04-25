using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdminGastos.Models;

namespace AdminGastos.Dto.GastoDto
{
    public class AddGastoDto
    {
        public string Nombre { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Importe { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaVencimiento { get; set; }
        public bool Pagado { get; set; }
        public int UserId {get; set;}
    }
}