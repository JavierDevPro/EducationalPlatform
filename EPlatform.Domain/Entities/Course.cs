using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPlatform.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }

        [Required, MaxLength(10)]
        public string Code { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime CreatedAt {get; set;}

        public int ProfessorId { get; set; }
      
        [ForeignKey("ProfessorId")]
        public  Professor professor { get; set; }

        public List<Section> sections = new List<Section>();
    }
}