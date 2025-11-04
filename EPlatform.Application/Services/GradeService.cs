using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EPlatform.Domain.Entities;
using EPlatform.Domain.Interfaces;
using EPlatform.Application.Dtos;
using EPlatform.Application.DTOs;


namespace EPlatform.Application.Services
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
                Id = g.id,
                EnrollmentId = g.EnrollmentId,
                Score = g.score,
                Remarks = g.remarks,
                RecordedAt = g.recordedAt
            });
        }

        public async Task<GradeDto?> GetByIdAsync(int id)
        {
            var g = await _repo.GetByIdAsync(id);
            if (g == null) return null;
            return new GradeDto
            {
                Id = g.id,
                EnrollmentId = g.EnrollmentId,
                Score = g.score,
                Remarks = g.remarks,
                RecordedAt = g.recordedAt
            };
        }

        public async Task<GradeDto> CreateAsync(CreateGradeDto dto)
        {
            var entity = new Grade
            {
                EnrollmentId = dto.EnrollmentId,
                score = dto.Score,
                remarks = dto.Remarks,
                recordedAt = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
            };

            var created = await _repo.CreateAsync(entity);

            return new GradeDto
            {
                Id = created.id,
                EnrollmentId = created.EnrollmentId,
                Score = created.score,
                Remarks = created.remarks,
                RecordedAt = created.recordedAt
            };
        }

        public async Task<GradeDto?> UpdateAsync(int id, UpdateGradeDto dto)
        {
            var toUpdate = new Grade
            {
                score = dto.Score ?? 0f,
                remarks = dto.Remarks,
            };

            var updated = await _repo.UpdateAsync(id, toUpdate);
            if (updated == null) return null;
            return new GradeDto
            {
                Id = updated.id,
                EnrollmentId = updated.EnrollmentId,
                Score = updated.score,
                Remarks = updated.remarks,
                RecordedAt = updated.recordedAt
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
