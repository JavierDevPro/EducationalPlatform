namespace EPlatform.Application.DTOs
{
    public class GradeDto
    {
        public int Id { get; set; }
        public int EnrollmentId { get; set; }
        public float Score { get; set; }
        public string? Remarks { get; set; }
        public string? RecordedAt { get; set; }
    }

    public class CreateGradeDto
    {
        public int EnrollmentId { get; set; }
        public float Score { get; set; }
        public string? Remarks { get; set; }
    }

    public class UpdateGradeDto
    {
        public float? Score { get; set; }
        public string? Remarks { get; set; }
    }
}