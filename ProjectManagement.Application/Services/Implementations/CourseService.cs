using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.Extensions;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Application.Utils;
using ProjectManagement.DataLayer.DTOs.Common;
using ProjectManagement.DataLayer.DTOs.Course;
using ProjectManagement.DataLayer.Entities.Courses;
using ProjectManagement.DataLayer.Entities.People;
using ProjectManagement.DataLayer.Repository;

namespace ProjectManagement.Application.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly IGenericRepository<Student> _studentRepository;
        private readonly IGenericRepository<Teacher> _teacherRepository;
        private readonly IGenericRepository<Course> _courseRepository;
        private readonly IGenericRepository<Enrollment> _enrollmentRepository;
        private readonly IGenericRepository<ProjectRequest> _projectRequestRepository;
        private readonly IGenericRepository<ProjectProgress> _projectProgressRepository;
        private readonly IGenericRepository<ProjectDefenseRequest> _projectDefenseRequestRepository;

        public CourseService(IGenericRepository<Course> courseRepository, IGenericRepository<Enrollment> enrollmentRepository, IGenericRepository<ProjectRequest> projectRequestRepository, IGenericRepository<ProjectProgress> projectProgressRepository, IGenericRepository<Student> studentRepository, IGenericRepository<Teacher> teacherRepository, IGenericRepository<ProjectDefenseRequest> projectDefenseRequestRepository)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _projectDefenseRequestRepository = projectDefenseRequestRepository;
            _courseRepository = courseRepository;
            _enrollmentRepository = enrollmentRepository;
            _projectRequestRepository = projectRequestRepository;
            _projectProgressRepository = projectProgressRepository;
        }


        public async Task<OperationResult> AddCourse(AddCourse course)
        {
            var newCourse = new Course
            {
                Name = course.Name,
                Unit = course.Unit
            };

            await _courseRepository.AddEntity(newCourse);
            await _courseRepository.SaveChanges();

            return new OperationResult
            {
                IsSucceed = true
            };
        }

        public async Task<OperationResult> AddProjectProgress(ProjectProgressDto progress, int studentId)
        {
            var projectProgress = new ProjectProgress
            {
                Title = progress.Title,
                Description = progress.Description,
                Result = ProgressResult.UnderProgress
            };

            var project = await GetConfirmedProjectByStudentId(studentId);
            projectProgress.ProjectId = project.RequestProjectId;

            await _projectProgressRepository.AddEntity(projectProgress);
            await _projectProgressRepository.SaveChanges();

            return new OperationResult
            {
                IsSucceed = true
            };
        }

        public async ValueTask DisposeAsync()
        {
            if (_courseRepository != null)
                await _courseRepository.DisposeAsync();
            if (_enrollmentRepository != null)
                await _enrollmentRepository.DisposeAsync();
            if (_projectRequestRepository != null)
                await _projectRequestRepository.DisposeAsync();
        }

        public async Task<OperationResult> EditProjectRequest(RequestProjectDto project)
        {
            var request = await _projectRequestRepository.GetEntityById(project.RequestProjectId);

            request.Title = project.Title;
            //request.Step = project.Step;
            //request.Description = project.Description;
            request.Platform = project.Platform;
            request.Situation = project.Situation;
            request.ProjectType = project.ProjectType;
            //request.TeammateName = project.TeammateName;
            //request.TeammateStudentCode = project.TeammateStudentCode;
            //request.Puprpose = project.Puprpose;

            await _projectRequestRepository.SaveChanges();

            return new OperationResult { IsSucceed = true };
        }

        public async Task<RequestProjectDto> GetConfirmedProjectByStudentId(int studentId)
        {
            return await _projectRequestRepository.GetQuery()
                .Select(x => new RequestProjectDto
                {
                    StudentId = x.StudentId,
                    ProjectType = x.ProjectType,
                    Situation = x.Situation,
                    Platform = x.Platform,
                    CreationDate = x.CreationDate.ToFarsi(),
                    Description = x.Description,
                    Puprpose = x.Puprpose,
                    TeammateName = x.TeammateName,
                    Title = x.Title,
                    TeacherId = x.TeacherId,
                    RequestProjectId = x.Id,
                    TeammateStudentCode = x.TeammateStudentCode,
                    Feedback = x.Feedback,
                    Step = x.Step,
                    TeacherFullName = $"{x.Teacher.Name} {x.Teacher.Family}"
                }).FirstOrDefaultAsync(x => x.StudentId == studentId && x.Situation == AcceptSituation.Confirm);
        }

        public async Task<OperationResult> RequestProjectDefense(ProjectDefenseRequestDto defenseRequest)
        {

            var projectDefense = new ProjectDefenseRequest
            {
                StudentId = defenseRequest.StudentId,
                TeacherId = defenseRequest.TeacherId,
                ProjectId = defenseRequest.ProjectId,
                Place = defenseRequest.Place,
                Time = defenseRequest.Time,
                Date = defenseRequest.Date,
                Situation = AcceptSituation.UnderProgress,
                Description = defenseRequest.Description,
            };

            await _projectDefenseRequestRepository.AddEntity(projectDefense);
            await _projectDefenseRequestRepository.SaveChanges();

            return new OperationResult
            {
                IsSucceed = true
            };
        }

        public async Task<List<ProjectDefenseRequestDto>> GetProjectDefenseRequestListByStudentId(int studentId)
        {
            return await _projectDefenseRequestRepository.GetQuery()
                .Include(x => x.Teacher)
                .Where(x => x.StudentId == studentId)
                .Select(x => new ProjectDefenseRequestDto
                {
                    StudentId = x.StudentId,
                    TeacherId = x.TeacherId,
                    ProjectId = x.ProjectId,
                    Place = x.Place,
                    Time = x.Time,
                    Date = x.Date,
                    Situation = x.Situation,
                    CreationDate = x.CreationDate.ToFarsi(),
                    Description = x.Description,
                    ProjectName = x.Project.Title,
                    DefenseRequestId = x.Id,
                    TeacherName = x.Teacher.Name + " " + x.Teacher.Family
                }).ToListAsync();
        }

        public async Task<List<ComboBoxSelectViewModel>> GetCourseList()
        {
            return await _courseRepository.GetQuery().Select(x => new ComboBoxSelectViewModel
            {
                Id = x.Id,
                Title = x.Name
            }).ToListAsync();
        }

        public async Task<List<ProjectProgressDto>> GetProjectProgressList(int studentId)
        {
            var project = await GetProjectByStudentId(studentId);

            return project?.ProjectProgresses.OrderByDescending(x => x.CreationDate).Select(x => new ProjectProgressDto
            {
                Description = x.Description,
                Feedback = x.Feedback,
                CreationDate = x.CreationDate.ToFarsi(),
                ProjectId = x.ProjectId,
                Result = x.Result,
                Title = x.Title,
                ProjectProgressId = x.Id,
                StudentId = project.StudentId
            }).ToList();
        }

        public async Task<RequestProjectDto> GetProjectRequestById(int requestId)
        {
            var request = await _projectRequestRepository.GetEntityById(requestId);

            return new RequestProjectDto
            {
                Title = request.Title,
                Description = request.Description,
                Feedback = request.Feedback,
                Puprpose = request.Puprpose,
                Platform = request.Platform,
                ProjectType = request.ProjectType,
                RequestProjectId = request.Id,
                Situation = request.Situation,
                StudentId = request.StudentId,
                TeammateName = request.TeammateName,
                TeammateStudentCode = request.TeammateStudentCode,
                TeacherId = request.TeacherId,
                Step = request.Step
            };
        }

        public async Task<OperationResult> RemoveProjectRequest(int requestId)
        {
            await _projectRequestRepository.DeleteEntity(requestId);
            await _projectRequestRepository.SaveChanges();

            return new OperationResult { IsSucceed = true };
        }

        public async Task<OperationResult> RequestProject(RequestProjectDto project)
        {
            var course = await _enrollmentRepository.GetQuery()
                .FirstOrDefaultAsync(x => x.StudentId == project.StudentId && x.CourseId == project.CourseId);

            if (await _projectRequestRepository.GetQuery()
                .AnyAsync(x => x.StudentId == project.StudentId && x.Situation != AcceptSituation.Rejected))
                return new OperationResult { IsSucceed = false, Message = "یک درخواست از قبل ثبت کرده اید." };

            var projectRequest = new ProjectRequest
            {
                Title = project.Title,
                Description = project.Description,
                Platform = project.Platform,
                Puprpose = project.Puprpose,
                Situation = AcceptSituation.UnderProgress,
                Step = ProjectStep.Request,
                TeammateName = project.TeammateName,
                TeammateStudentCode = project.TeammateStudentCode,
                ProjectType = project.ProjectType,
                StudentId = project.StudentId,
                TeacherId = course.TeacherId
            };

            await _projectRequestRepository.AddEntity(projectRequest);
            await _projectRequestRepository.SaveChanges();

            return new OperationResult
            {
                IsSucceed = true
            };
        }

        public async Task<List<RequestProjectDto>> SearchProjectRequests(ProjectRequestSearchModel model)
        {
            var data = await _projectRequestRepository.GetQuery()
                .IgnoreQueryFilters()
                .Include(x => x.Student)
                .Include(x => x.Teacher).Select(x => new RequestProjectDto
                {
                    Title = x.Title,
                    Description = x.Description,
                    Feedback = x.Feedback == null ? "-" : x.Feedback,
                    CreationDate = x.CreationDate.ToFarsi(),
                    Platform = x.Platform,
                    ProjectType = x.ProjectType,
                    Puprpose = x.Puprpose,
                    Situation = x.Situation,
                    RequestProjectId = x.Id,
                    Step = x.Step,
                    StudentCode = x.Student.StudentCode,
                    StudentFullName = $"{x.Student.Name} {x.Student.Family}",
                    TeacherFullName = $"{x.Teacher.Name} {x.Teacher.Family}",
                    TeammateName = x.TeammateName,
                    TeammateStudentCode = x.TeammateStudentCode,
                    StudentId = x.StudentId,
                    TeacherId = x.TeacherId,
                    IsRemoved = x.IsDeleted,
                    PlatformName = x.Platform.GetEnumName(),
                    ProjectTypeName = x.ProjectType.GetEnumName(),
                    SituationName = x.Situation.GetEnumName()
                }).ToListAsync();

            if (!string.IsNullOrWhiteSpace(model.Title))
                data = data.Where(x => x.Title.Contains(model.Title)).ToList();
            if (!string.IsNullOrWhiteSpace(model.StudentFullName))
                data = data.Where(x => x.StudentFullName.Contains(model.StudentFullName)).ToList();
            if (!string.IsNullOrWhiteSpace(model.TeacherFullName))
                data = data.Where(x => x.TeacherFullName.Contains(model.TeacherFullName)).ToList();
            if (!string.IsNullOrWhiteSpace(model.StudentCode))
                data = data.Where(x => x.StudentCode.Contains(model.StudentCode)).ToList();
            if (!string.IsNullOrWhiteSpace(model.CreationDate))
                data = data.Where(x => x.CreationDate.Contains(model.CreationDate)).ToList();
            if (model.HaveSituation)
                data = data.Where(x => x.Situation == model.Situation).ToList();
            if (model.HaveProjectType)
                data = data.Where(x => x.ProjectType == model.ProjectType).ToList();
            if (model.HavePlatform)
                data = data.Where(x => x.Platform == model.Platform).ToList();
            if (model.Removed)
                data = data.Where(x => x.IsRemoved).ToList();

            return data.OrderByDescending(x => x.RequestProjectId).ToList();
        }

        private async Task<ProjectRequest> GetProjectByStudentId(int studentId)
        {
            return await _projectRequestRepository.GetQuery()
                .Include(x => x.ProjectProgresses)
                .FirstOrDefaultAsync(x => x.StudentId == studentId && x.Situation == AcceptSituation.Confirm);
        }
    }
}
