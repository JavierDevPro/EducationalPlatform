using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public int ProfessorId { get; set; }
        public Professor? Professor { get; set; }

        public ICollection<Section>? Sections { get; set; }
    }
}