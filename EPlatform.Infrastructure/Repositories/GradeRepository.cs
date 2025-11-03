using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPlatform.Domain.Entities;
using webEscuela.Domain.Interfaces;


namespace webEscuela.Infrastructure.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private static readonly List<Grade> _store = new List<Grade>();
        private static int _idSeq = 1;

        public Task<IEnumerable<Grade>> GetAllAsync()
        {
            return Task.FromResult(_store.AsEnumerable());
        }

        public Task<Grade?> GetByIdAsync(int id)
        {
            var g = _store.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(g);
        }

        public Task<Grade> CreateAsync(Grade grade)
        {
            grade.Id = _idSeq++;
            if (string.IsNullOrEmpty(grade.RecordedAt))
                grade.RecordedAt = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            _store.Add(grade);
            return Task.FromResult(grade);
        }

        public Task<Grade?> UpdateAsync(int id, Grade grade)
        {
            var existing = _store.FirstOrDefault(x => x.Id == id);
            if (existing == null) return Task.FromResult<Grade?>(null);

            existing.Score = grade.Score != 0m ? grade.Score : existing.Score;
            existing.Remarks = grade.Remarks ?? existing.Remarks;

            return Task.FromResult<Grade?>(existing);
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