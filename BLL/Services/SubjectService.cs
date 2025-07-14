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
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SubjectReadDto> CreateSubjectAsync(SubjectCreateOrUpdateDto dto)
        {
            var subject = _mapper.Map<Subject>(dto);

            await _unitOfWork.SubjectRepository.AddAsync(subject);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<SubjectReadDto>(subject);
        }

        public async Task<SubjectReadDto> UpdateSubjectAsync(Guid id, SubjectCreateOrUpdateDto dto)
        {
            var subject = await _unitOfWork.SubjectRepository.GetByIdAsync(id);

            if (subject == null)
                throw new Exception("Subject not found");

            _mapper.Map(dto, subject);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<SubjectReadDto>(subject);
        }

        public async Task<bool> DeleteSubjectAsync(Guid id)
        {
            var subject = await _unitOfWork.SubjectRepository.GetByIdAsync(id);

            if (subject == null)
                throw new Exception("Subject not found");

            await _unitOfWork.SubjectRepository.DeleteAsync(subject);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<SubjectReadDto> GetSubjectByIdAsync(Guid id)
        {
            var subject = await _unitOfWork.SubjectRepository.GetByIdAsync(id);
            return _mapper.Map<SubjectReadDto>(subject);
        }

        public async Task<IEnumerable<SubjectReadDto>> GetAllSubjectsAsync()
        {
            var subjects = await _unitOfWork.SubjectRepository.GetAllSubjectsAsync();
            return _mapper.Map<IEnumerable<SubjectReadDto>>(subjects);
        }
    }

}
