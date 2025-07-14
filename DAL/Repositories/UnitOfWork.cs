using BLL.Interfaces;
using DAL.Interfaces;
using DataAccess;
using Interfaces.Interfaces;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IStudentRepository StudentRepository { get; private set; }   
        public ISubjectRepository SubjectRepository { get; private set; }
        public IBaseRepository<Payment> PaymentRepository { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            StudentRepository = new StudentRepository(_context);
            SubjectRepository = new SubjectRepository(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }



}
