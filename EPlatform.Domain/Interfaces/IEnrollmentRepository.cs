using EPlatform.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EPlatform.Domain.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>> GetAllAsync();
        Task AddAsync(Enrollment enrollment);
    }
}