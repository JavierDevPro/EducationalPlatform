using System.ComponentModel.DataAnnotations.Schema;
using EPlatform.Domain.Entities;

namespace EPlatform.Domain.Entities
{
    public class Grade
    {
      public int id { get; set; }
      public float score { get; set; }
      public string remarks { get; set; }
      public string recordedAt { get; set; }

      public int EnrollmentId { get; set; }
      [ForeignKey("EnrollmentId")]
      public Enrollment enrollment { get; set; }
    }
}