using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoDeBancoDeDados.Models
{
    public class Seguradora
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
