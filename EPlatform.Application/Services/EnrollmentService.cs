using System.Collections.Generic;
using System.Threading.Tasks;
using EPlatform.Domain.Entities;
using EPlatform.Infrastructure.Repositories;
using EPlatform.Application.Interfaces;

namespace EPlatform.Application.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly EnrollmentRepository _repository;

        public EnrollmentService(EnrollmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Enrollment>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Enrollment> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task AddAsync(Enrollment enrollment) => await _repository.AddAsync(enrollment);

        public async Task UpdateAsync(Enrollment enrollment) => await _repository.UpdateAsync(enrollment);

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}