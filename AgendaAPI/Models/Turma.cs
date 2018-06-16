using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaAPI.Models
{
    public class Turma
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Local { get; set; }

        [Required]
        public int ProfessorId { get; set; }

        public Professor Professor { get; set; }

        [Required]
        public int CursoId { get; set; }
        
        public Curso Curso { get; set; }
    }
}