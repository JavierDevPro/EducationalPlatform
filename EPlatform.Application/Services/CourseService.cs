using System.Collections.Generic;
using System.Threading.Tasks;
using EPlatform.Domain.Entities;
using EPlatform.Infrastructure.Repositories;
using EPlatform.Application.Interfaces;

namespace EPlatform.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly CourseRepository _repository;

        public CourseService(CourseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Course>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Course> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task AddAsync(Course course) => await _repository.AddAsync(course);

        public async Task UpdateAsync(Course course) => await _repository.UpdateAsync(course);

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}