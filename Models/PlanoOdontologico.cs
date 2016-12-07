using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoDeBancoDeDados.Models
{
    public class PlanoOdontologico
    {
        public int ID { get; set; }

        [Display(Name = "Número")]
        public int Numero { get; set; }
        public string Tipo { get; set; }

        [DataType(DataType.Date)]
        public DateTime Validade { get; set; }
        public string Titular { get; set; }
        public decimal Valor { get; set; }
    }
}
