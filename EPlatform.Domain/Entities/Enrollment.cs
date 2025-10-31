using System;
using System.ComponentModel.DataAnnotations;

namespace EPlatform.Domain.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        [Required]
        public int SectionId { get; set; }
        public Section? Section { get; set; }

        public DateTime EnrolledAt { get; set; } = DateTime.Now;

        public Grade? Grade { get; set; }
    }
}