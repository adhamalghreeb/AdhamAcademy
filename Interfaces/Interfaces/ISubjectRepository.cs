using DAL.Interfaces;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
    public interface ISubjectRepository : IBaseRepository<Subject>
    {
        Task<Subject> GetSubjectByIdAsync(Guid id);
        Task<Subject> GetSubjectByNameAsync(string name);
        Task<IEnumerable<Subject>> GetAllSubjectsAsync();
    }

}
