using Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
    public interface ISubjectService
    {
        Task<SubjectReadDto> CreateSubjectAsync(SubjectCreateOrUpdateDto dto);
        Task<SubjectReadDto> UpdateSubjectAsync(Guid id, SubjectCreateOrUpdateDto dto);
        Task<bool> DeleteSubjectAsync(Guid id);
        Task<SubjectReadDto> GetSubjectByIdAsync(Guid id);
        Task<IEnumerable<SubjectReadDto>> GetAllSubjectsAsync();
    }

}
