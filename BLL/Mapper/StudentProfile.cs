using AutoMapper;
using Models.Dtos;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapper
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            // Student → StudentReadDto
            CreateMap<Student, StudentReadDto>()
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmountAssigned))
                .ForMember(dest => dest.AmountPaid, opt => opt.MapFrom(src => src.TotalAmountPaid))
                .ForMember(dest => dest.AmountLeftToPay, opt => opt.MapFrom(src => src.TotalAmountAssigned - src.TotalAmountPaid));

            // Payment → PaymentDto
            CreateMap<Payment, PaymentDto>();
            CreateMap<Subject, SubjectReadDto>();
            CreateMap<SubjectCreateOrUpdateDto, Subject>();

            // StudentCreateDto → Student
            CreateMap<StudentCreateDto, Student>()
                .ForMember(dest => dest.StudentSubjects, opt => opt.MapFrom(src =>
                    src.Subjects.Select(s => new StudentSubject
                    {
                        SubjectId = s.SubjectId,
                        PriceAssigned = s.PriceAssigned
                    })
                ));
        }
    }
}
