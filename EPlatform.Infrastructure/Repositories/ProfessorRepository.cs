using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPlatform.Domain.Entities;
using EPlatform.Domain.Interfaces;


namespace EPlatform.Infrastructure.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        // lista estática para simular BD
        private static readonly List<Professor> _store = new List<Professor>();
        private static int _idSeq = 1;

        public Task<IEnumerable<Professor>> GetAllAsync()
        {
            return Task.FromResult(_store.AsEnumerable());
        }

        public Task<Professor?> GetByIdAsync(int id)
        {
            var p = _store.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(p);
        }

        public Task<Professor> CreateAsync(Professor professor)
        {
            professor.Id = _idSeq++;
            if (string.IsNullOrEmpty(professor.CreatedAt))
                professor.CreatedAt = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            _store.Add(professor);
            return Task.FromResult(professor);
        }

        public Task<Professor?> UpdateAsync(int id, Professor professor)
        {
            var existing = _store.FirstOrDefault(x => x.Id == id);
            if (existing == null) return Task.FromResult<Professor?>(null);

            existing.FirstName = string.IsNullOrEmpty(professor.FirstName) ? existing.FirstName : professor.FirstName;
            existing.LastName = string.IsNullOrEmpty(professor.LastName) ? existing.LastName : professor.LastName;
            existing.Email = string.IsNullOrEmpty(professor.Email) ? existing.Email : professor.Email;
            existing.HireNumber = string.IsNullOrEmpty(professor.HireNumber) ? existing.HireNumber : professor.HireNumber;
            existing.Course_id = professor.Course_id != 0 ? professor.Course_id : existing.Course_id;

            return Task.FromResult<Professor?>(existing);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var existing = _store.FirstOrDefault(x => x.Id == id);
            if (existing == null) return Task.FromResult(false);
            _store.Remove(existing);
            return Task.FromResult(true);
        }
    }
}
