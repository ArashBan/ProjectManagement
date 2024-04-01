using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.DataLayer.DTOs.Common;
using ProjectManagement.DataLayer.Entities.Common;
using ProjectManagement.DataLayer.Entities.Courses;
using ProjectManagement.DataLayer.Entities.People;
using ProjectManagement.DataLayer.Repository;

namespace ProjectManagement.Application.Services.Implementations
{
    public class MainFormService : IMainFormService
    {
        private readonly IGenericRepository<Student> _studentRepository;
        private readonly IGenericRepository<Teacher> _teacherRepository;
        private readonly IGenericRepository<Problem> _problemRepository;
        private readonly IGenericRepository<ProjectRequest> _projectRequestRepository;
        private readonly IGenericRepository<InternshipRequest> _internshipRequestRepository;

        public MainFormService(IGenericRepository<Student> studentRepository, IGenericRepository<Teacher> teacherRepository, IGenericRepository<Problem> problemRepository, IGenericRepository<ProjectRequest> projectRequestRepository, IGenericRepository<InternshipRequest> internshipRequestRepository)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _problemRepository = problemRepository;
            _projectRequestRepository = projectRequestRepository;
            _internshipRequestRepository = internshipRequestRepository;
        }

        public async ValueTask DisposeAsync()
        {
            if (_internshipRequestRepository != null)
                await _internshipRequestRepository.DisposeAsync();
            if (_problemRepository != null)
                await _problemRepository.DisposeAsync();
            if (_studentRepository != null)
                await _studentRepository.DisposeAsync();
            if (_projectRequestRepository != null)
                await _projectRequestRepository.DisposeAsync();
            if (_teacherRepository != null)
                await _teacherRepository.DisposeAsync();
        }

        public async Task<MainFormDto> GetMainForm()
        {
            var stats = new MainFormStats
            {
                StudentsCount = await _studentRepository.GetQuery().CountAsync(),
                TeachersCount = await _teacherRepository.GetQuery().CountAsync(),
                RequestsCount = await _projectRequestRepository.GetQuery().CountAsync() +
                                await _internshipRequestRepository.GetQuery().CountAsync(),
                QuestionsCount = await _problemRepository.GetQuery().CountAsync()
            };

            return new MainFormDto
            {
                Stats = stats
            };
        }
    }
}
