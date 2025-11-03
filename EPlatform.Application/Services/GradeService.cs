using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webEscuela.Application.DTOs;
using webEscuela.Domain.Entities;
using webEscuela.Domain.Interfaces;

namespace webEscuela.Application.Services
{
    public class GradeService
    {
        private readonly IGradeRepository _repo;

        public GradeService(IGradeRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<GradeDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(g => new GradeDto
            {
                Id = g.Id,
                EnrollmentId = g.EnrollmentId,
                Score = g.Score,
                Remarks = g.Remarks,
                RecordedAt = g.RecordedAt
            });
        }

        public async Task<GradeDto?> GetByIdAsync(int id)
        {
            var g = await _repo.GetByIdAsync(id);
            if (g == null) return null;
            return new GradeDto
            {
                Id = g.Id,
                EnrollmentId = g.EnrollmentId,
                Score = g.Score,
                Remarks = g.Remarks,
                RecordedAt = g.RecordedAt
            };
        }

        public async Task<GradeDto> CreateAsync(CreateGradeDto dto)
        {
            var entity = new Grade
            {
                EnrollmentId = dto.EnrollmentId,
                Score = dto.Score,
                Remarks = dto.Remarks,
                RecordedAt = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
            };

            var created = await _repo.CreateAsync(entity);

            return new GradeDto
            {
                Id = created.Id,
                EnrollmentId = created.EnrollmentId,
                Score = created.Score,
                Remarks = created.Remarks,
                RecordedAt = created.RecordedAt
            };
        }

        public async Task<GradeDto?> UpdateAsync(int id, UpdateGradeDto dto)
        {
            var toUpdate = new Grade
            {
                Score = dto.Score ?? 0m,
                Remarks = dto.Remarks
            };

            var updated = await _repo.UpdateAsync(id, toUpdate);
            if (updated == null) return null;
            return new GradeDto
            {
                Id = updated.Id,
                EnrollmentId = updated.EnrollmentId,
                Score = updated.Score,
                Remarks = updated.Remarks,
                RecordedAt = updated.RecordedAt
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
