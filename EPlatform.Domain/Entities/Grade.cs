using EPlatform.Domain.Entities;

namespace webEscuela.Domain.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        public int EnrollmentId { get; set; }
        public double Score { get; set; }

        // Relación con Inscripción (1:1)
        public Enrollment? Enrollment { get; set; }
    }
}