using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sistemaUniversidade.Models
{
    public enum Graduation
    {
        TECNOLOGO,
        LICENSIADO,
        BACHARELADO,
        MESTRADO,
        DOUTORADO
    }
    public class Professor
    {
        [Display(Name ="ID professor")]
        public int ID { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Formação Acadêmica")]
        public Graduation Formacao { get; set; }
        [Display(Name = "Salário")]
        public float Salario { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public string Telefone{ get; set; }
        [Display(Name = "Data de contratação")]
        public DateTime DataContratacao{ get; set; }
        public int DepartamentoID { get; set; }
        public Departamento Departamento { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
    }
}

