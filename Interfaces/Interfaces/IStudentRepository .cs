using DAL.Interfaces;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<Student> GetStudentWithSubjectsAsync(Guid id); // Get student with related subjects
        Task<IEnumerable<Student>> GetAllStudentsWithSubjectsAsync(); // Get all students with their subjects
        Task<Student> GetStudentByEmailAsync(string email); // Get student by email
        Task<IEnumerable<Student>> GetStudentsBySubjectAsync(Guid subjectId); // Get students by a specific subject
    }
}
