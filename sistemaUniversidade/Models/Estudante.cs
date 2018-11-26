using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sistemaUniversidade.Models
{
    public enum Gender{
          MASCULINO,
          FEMININO
    }
    public class Estudante
    {
        public Estudante()
        {
            this.Cursos = new HashSet<Curso>();
        }

        [Display(Name = "ID estudante")]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        [Display(Name = "Data de cadastro")]
        public DateTime DataCadastro { get; set; }
        [Display(Name = "E-mail")]
        public Gender Sexo { get; set; }
        public string Email{ get; set; }
        public int? DepartamentoID { get; set; }
        public Departamento Departamento { get; set; }
        public virtual ICollection<Curso> Cursos{ get; set; }

    }
}

