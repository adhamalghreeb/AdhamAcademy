using DataAccess;
using Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        private readonly AppDbContext _context;

        public SubjectRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Subject> GetSubjectByIdAsync(Guid id)
        {
            return await _context.Subjects.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Subject> GetSubjectByNameAsync(string name)
        {
            return await _context.Subjects.FirstOrDefaultAsync(s => s.Name.ToLower() == name.ToLower());
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _context.Subjects.ToListAsync();
        }
    }

}
