using Models.Dtos;

namespace Interfaces.Interfaces
{
    public interface IStudentService
    {
        public interface IStudentService
        {
            Task<StudentReadDto> CreateStudentAsync(StudentCreateDto studentCreateDto);
            Task<StudentReadDto> UpdateStudentAsync(Guid studentId, StudentUpdateDto studentUpdateDto);
            Task<StudentReadDto> UpdateInstallmentsAsync(Guid studentId, decimal paymentAmount);
            Task<bool> DeleteStudentAsync(Guid studentId);
            Task<StudentReadDto> GetStudentByIdAsync(Guid studentId);
            Task<IEnumerable<StudentReadDto>> GetAllStudentsAsync();
        }
    }
}
