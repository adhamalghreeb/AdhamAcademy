using AutoMapper;
using BLL.Interfaces;
using Interfaces.Interfaces;
using Models.Dtos;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{

    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // 1. Create Student
        public async Task<StudentReadDto> CreateStudentAsync(StudentCreateDto studentCreateDto)
        {
            var student = _mapper.Map<Student>(studentCreateDto);

            // Assign subjects to the student
            foreach (var subjectDto in studentCreateDto.Subjects)
            {
                var studentSubject = new StudentSubject
                {
                    SubjectId = subjectDto.SubjectId,
                    PriceAssigned = subjectDto.PriceAssigned
                };
                student.StudentSubjects.Add(studentSubject);
            }

            await _unitOfWork.StudentRepository.AddAsync(student);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<StudentReadDto>(student);
        }

        // 2. Update Student
        public async Task<StudentReadDto> UpdateStudentAsync(Guid studentId, StudentUpdateDto studentUpdateDto)
        {
            var student = await _unitOfWork.StudentRepository.GetByIdAsync(studentId);

            if (student == null)
            {
                throw new Exception("Student not found");
            }

            // Update basic info
            _mapper.Map(studentUpdateDto, student);

            // Add new subjects
            if (studentUpdateDto.SubjectIdsToAdd != null)
            {
                foreach (var subjectId in studentUpdateDto.SubjectIdsToAdd)
                {
                    if (student.StudentSubjects.All(ss => ss.SubjectId != subjectId))
                    {
                        var studentSubject = new StudentSubject
                        {
                            SubjectId = subjectId,
                            PriceAssigned = 0
                        };
                        student.StudentSubjects.Add(studentSubject);
                    }
                }
            }

            // Remove subjects
            if (studentUpdateDto.SubjectIdsToRemove != null)
            {
                foreach (var subjectId in studentUpdateDto.SubjectIdsToRemove)
                {
                    var subjectToRemove = student.StudentSubjects.FirstOrDefault(ss => ss.SubjectId == subjectId);
                    if (subjectToRemove != null)
                    {
                        student.StudentSubjects.Remove(subjectToRemove);
                    }
                }

                // Ensure at least one subject remains
                if (!student.StudentSubjects.Any())
                {
                    throw new Exception("Student must have at least one subject.");
                }
            }

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<StudentReadDto>(student);
        }

        // 3. Update Installments (Payments)
        public async Task<StudentReadDto> UpdateInstallmentsAsync(Guid studentId, decimal paymentAmount)
        {
            var student = await _unitOfWork.StudentRepository.GetByIdAsync(studentId);

            if (student == null)
            {
                throw new Exception("Student not found");
            }

            var payment = new Payment
            {
                AmountPaid = paymentAmount,
                PaymentDate = DateTime.Now
            };

            student.Payments.Add(payment);
            student.TotalAmountPaid += paymentAmount;

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<StudentReadDto>(student);
        }

        // 4. Delete Student
        public async Task<bool> DeleteStudentAsync(Guid studentId)
        {
            var student = await _unitOfWork.StudentRepository.GetByIdAsync(studentId);

            if (student == null)
            {
                throw new Exception("Student not found");
            }

            await _unitOfWork.StudentRepository.DeleteAsync(student);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        // 5. Get Student by Id
        public async Task<StudentReadDto> GetStudentByIdAsync(Guid studentId)
        {
            var student = await _unitOfWork.StudentRepository.GetStudentWithSubjectsAsync(studentId);
            return _mapper.Map<StudentReadDto>(student);
        }

        // 6. Get All Students
        public async Task<IEnumerable<StudentReadDto>> GetAllStudentsAsync()
        {
            var students = await _unitOfWork.StudentRepository.GetAllStudentsWithSubjectsAsync();
            return _mapper.Map<IEnumerable<StudentReadDto>>(students);
        }
    }


}
