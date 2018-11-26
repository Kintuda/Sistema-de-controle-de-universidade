using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sistemaUniversidade.Models
{
    public class Curso
    {
        public Curso()
        {
            this.Estudantes = new HashSet<Estudante>();
        }
        [Display(Name="Departamento ID")]
        public int ID { get; set; }
        [Display(Name = "Nome do curso")]
        public string Nome { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Data inicial do curso")]
        public DateTime inicioAula { get; set; }
        [Display(Name = "Duração do curso")]
        public int Duracao { get; set; }
        public int DepartamentoID { get; set; }
        public Departamento Departamento { get; set; }
        public int? ProfessorID { get; set; }
        public Professor Professor { get; set; }
        public virtual ICollection<Estudante> Estudantes{ get; set; }
    }
}

