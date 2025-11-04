using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPlatform.Application.DTOs;
using EPlatform.Domain.Entities;
using EPlatform.Domain.Interfaces;
using webEscuela.Application.DTOs;

namespace webEscuela.Application.Services
{
    public class ProfessorService
    {
        private readonly IProfessorRepository _repo;

        public ProfessorService(IProfessorRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ProfessorDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(p => new ProfessorDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                HireNumber = p.HireNumber,
                CreateAt = p.CreatedAt,
                Course_id = p.Course_id
            });
        }

        public async Task<ProfessorDto?> GetByIdAsync(int id)
        {
            var p = await _repo.GetByIdAsync(id);
            if (p == null) return null;
            return new ProfessorDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                HireNumber = p.HireNumber,
                CreateAt = p.CreatedAt,
                Course_id = p.Course_id
            };
        }

        public async Task<ProfessorDto> CreateAsync(CreateProfessorDto dto)
        {
            var entity = new Professor
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                HireNumber = dto.HireNumber,
                Course_id = dto.Course_id,
                CreatedAt = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
            };

            var created = await _repo.CreateAsync(entity);
            return new ProfessorDto
            {
                Id = created.Id,
                FirstName = created.FirstName,
                LastName = created.LastName,
                Email = created.Email,
                HireNumber = created.HireNumber,
                CreateAt = created.CreatedAt,
                Course_id = created.Course_id
            };
        }

        public async Task<ProfessorDto?> UpdateAsync(int id, UpdateProfessorDto dto)
        {
            var toUpdate = new Professor
            {
                FirstName = dto.FirstName ?? string.Empty,
                LastName = dto.LastName ?? string.Empty,
                Email = dto.Email ?? string.Empty,
                HireNumber = dto.HireNumber ?? string.Empty,
                Course_id = dto.Course_id ?? 0
            };

            var updated = await _repo.UpdateAsync(id, toUpdate);
            if (updated == null) return null;

            return new ProfessorDto
            {
                Id = updated.Id,
                FirstName = updated.FirstName,
                LastName = updated.LastName,
                Email = updated.Email,
                HireNumber = updated.HireNumber,
                CreateAt = updated.CreatedAt,
                Course_id = updated.Course_id
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
