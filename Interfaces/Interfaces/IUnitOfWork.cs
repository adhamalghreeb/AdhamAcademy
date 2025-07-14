using DAL.Interfaces;
using Interfaces.Interfaces;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository StudentRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        IBaseRepository<Payment> PaymentRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
