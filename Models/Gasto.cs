using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminGastos.Models
{
    public class Gasto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public decimal Importe { get; set; }
        public bool Pagado { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaVencimiento { get; set; }
        public User User {get; set; }


    }
}