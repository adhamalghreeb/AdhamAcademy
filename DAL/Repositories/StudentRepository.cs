using BLL.Interfaces;
using DataAccess;
using Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsWithSubjectsAsync()
        {
            return await _context.Students.Include(s => s.StudentSubjects)
                .ThenInclude(ss => ss.Subject)
                .ToListAsync();
        }

        public async Task<Student> GetStudentByEmailAsync(string email)
        {
            return await _context.Students
                .Include(s => s.StudentSubjects)
                .ThenInclude(ss => ss.Subject)
                .Include(s => s.Payments)
                .FirstOrDefaultAsync(s => s.Email == email);
        }


        public async Task<IEnumerable<Student>> GetStudentsBySubjectAsync(Guid subjectId)
        {
            return await _context.Students
                .Where(s => s.StudentSubjects.Any(ss => ss.SubjectId == subjectId))
                .Include(s => s.StudentSubjects)
                .ThenInclude(ss => ss.Subject)
                .ToListAsync();
        }


        public async Task<Student> GetStudentWithSubjectsAsync(Guid id)
        {
            return await _context.Students.Include(s => s.StudentSubjects)
                .ThenInclude(ss => ss.Subject)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }

}
