using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sistemaUniversidade.Models
{
    public class Departamento
    {
        [Display(Name="Departamento ID")]
        public int ID { get; set; }
        [Display(Name = "Nome do departamento")]
        public string Nome { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}
