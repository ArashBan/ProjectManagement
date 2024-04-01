using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.Extensions;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Application.Utils;
using ProjectManagement.DataLayer.DTOs.Course;
using ProjectManagement.DataLayer.Entities.Courses;
using ProjectManagement.DataLayer.Repository;

namespace ProjectManagement.Application.Services.Implementations
{
    public class InternshipService : IInternshipService
    {
        private readonly IGenericRepository<Enrollment> _enrollmentRepository;
        private readonly IGenericRepository<InternshipReport> _internshipReportRepository;
        private readonly IGenericRepository<InternshipRequest> _internshipRequestRepository;

        public InternshipService(IGenericRepository<InternshipRequest> internshipRequestRepository, IGenericRepository<Enrollment> enrollmentRepository, IGenericRepository<InternshipReport> internshipReportRepository)
        {
            _enrollmentRepository = enrollmentRepository;
            _internshipReportRepository = internshipReportRepository;
            _internshipRequestRepository = internshipRequestRepository;
        }


        public async Task<OperationResult> RequestInternship(InternshipDto request)
        {
            if (await _internshipRequestRepository.GetQuery()
                .AnyAsync(x => x.StudentId == request.StudentId && x.Situation != AcceptSituation.Rejected))
                return new OperationResult { IsSucceed = false, Message = "یک درخواست از قبل ثبت کرده اید." };

            var course = await _enrollmentRepository.GetQuery()
               .FirstOrDefaultAsync(x => x.StudentId == request.StudentId && x.CourseId == request.CourseId);

            var internship = new InternshipRequest
            {
                Address = request.Address,
                DaysOfAttendance = request.RenderDaysOfAttendanceToNumber(),
                Description = request.Description,
                Feedback = request.Feedback,
                SupervisorFullName = request.SupervisorFullName,
                Title = request.Title,
                StudentId = request.StudentId,
                TeacherId = course.TeacherId,
                PlaceName = request.PlaceName,
                Situation = AcceptSituation.UnderProgress,
                PlacePhoneNumber = request.PlacePhoneNumber
            };


            await _internshipRequestRepository.AddEntity(internship);
            await _internshipRequestRepository.SaveChanges();

            return new OperationResult { IsSucceed = true };
        }

        public async Task<OperationResult> SendWeeklyReport(InternshipReportDto progress, int studentId)
        {
            var internship = await GetConfirmedInternshipByStudentId(studentId);

            var report = new InternshipReport
            {
                EndDate = progress.EndDate,
                Saturday = progress.Saturday,
                StartDate = progress.StartDate,
                Sunday = progress.Sunday,
                Thursday = progress.Thursday,
                Result = ProgressResult.UnderProgress,
                Monday = progress.Monday,
                Tuesday = progress.Tuesday,
                Wednesday = progress.Wednesday,
                InternshipId = internship.InternshipId
            };

            await _internshipReportRepository.AddEntity(report);
            await _internshipReportRepository.SaveChanges();

            return new OperationResult { IsSucceed = true };
        }

        public async Task<InternshipDto> GetConfirmedInternshipByStudentId(int studentId)
        {
            return await _internshipRequestRepository.GetQuery()
                .Select(x => new InternshipDto
                {
                    StudentId = studentId,
                    InternshipId = x.Id,
                    TeacherId = x.TeacherId,
                    DaysOfAttendance = x.DaysOfAttendance,
                    SupervisorFullName = x.SupervisorFullName,
                    Title = x.Title,
                    TeacherFullName = $"{x.Teacher.Name} {x.Teacher.Family}",
                    Address = x.Address,
                    CreationDate = x.CreationDate.ToFarsi(),
                    Description = x.Description,
                    Feedback = x.Feedback,
                    PlaceName = x.PlaceName,
                    Situation = x.Situation,
                    PlacePhoneNumber = x.PlacePhoneNumber
                }).FirstOrDefaultAsync(x => x.StudentId == studentId);
        }

        public async ValueTask DisposeAsync()
        {
            if (_internshipRequestRepository != null)
                await _internshipRequestRepository.DisposeAsync();
            if (_internshipReportRepository != null)
                await _internshipReportRepository.DisposeAsync();
            if (_enrollmentRepository != null)
                await _enrollmentRepository.DisposeAsync();
        }

        public async Task<string> GetAttendanceDaysByStudentId(int studentId)
        {
            var result = await GetConfirmedInternshipByStudentId(studentId);

            return result.DaysOfAttendance;
        }

        public async Task<OperationResult> EditInternshipRequest(InternshipDto project)
        {
            var request = await _internshipRequestRepository.GetEntityById(project.InternshipId);

            request.Title = project.Title;
            request.Situation = project.Situation;
            request.Address = project.Address;
            //request.DaysOfAttendance = project.DaysOfAttendance;
            //request.Description = project.Description;
            request.PlaceName = project.PlaceName;
            //request.SupervisorFullName = project.SupervisorFullName;
            //request.PlacePhoneNumber = project.PlacePhoneNumber;

            await _internshipRequestRepository.SaveChanges();

            return new OperationResult { IsSucceed = true };
        }

        public async Task<OperationResult> RemoveInternshipRequest(int requestId)
        {
            await _internshipRequestRepository.DeleteEntity(requestId);
            await _internshipRequestRepository.SaveChanges();

            return new OperationResult { IsSucceed = true };
        }

        public async Task<List<InternshipDto>> SearchInternshipRequests(InternshipRequestSearchModel model)
        {
            var data = await _internshipRequestRepository.GetQuery()
                .Include(x => x.Student)
                .Include(x => x.Teacher).Select(x => new InternshipDto
                {
                    Title = x.Title,
                    Description = x.Description,
                    Feedback = x.Feedback == null ? "-" : x.Feedback,
                    CreationDate = x.CreationDate.ToFarsi(),
                    Situation = x.Situation,
                    InternshipId = x.Id,
                    StudentCode = x.Student.StudentCode,
                    StudentFullName = $"{x.Student.Name} {x.Student.Family}",
                    TeacherFullName = $"{x.Teacher.Name} {x.Teacher.Family}",
                    StudentId = x.StudentId,
                    TeacherId = x.TeacherId,
                    DaysOfAttendance = x.DaysOfAttendance,
                    Address = x.Address,
                    PlaceName = x.PlaceName,
                    PlacePhoneNumber = x.PlacePhoneNumber,
                    SupervisorFullName = x.SupervisorFullName, //!
                    IsRemoved = x.IsDeleted,
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
            if (!string.IsNullOrWhiteSpace(model.PlaceName))
                data = data.Where(x => x.CreationDate.Contains(model.PlaceName)).ToList();
            if (model.HaveSituation)
                data = data.Where(x => x.Situation == model.Situation).ToList();
            if (model.Removed)
                data = data.Where(x => x.IsRemoved).ToList();

            return data.OrderByDescending(x => x.InternshipId).ToList();
        }

        public async Task<InternshipDto> GetInternshipById(int internshipId)
        {
            var internship = await _internshipRequestRepository.GetEntityById(internshipId);

            return new InternshipDto
            {
                Title = internship.Title,
                Address = internship.Address,
                DaysOfAttendance = internship.DaysOfAttendance,
                Description = internship.Description,
                PlaceName = internship.PlaceName,
                Situation = internship.Situation,
                PlacePhoneNumber = internship.PlacePhoneNumber,
                InternshipId = internship.Id,
                SupervisorFullName = internship.SupervisorFullName,
                StudentId = internship.StudentId,
                TeacherId = internship.TeacherId,
                Feedback = internship.Feedback
            };
        }

        public async Task<List<InternshipReportDto>> GetInternshipReportsList(int studentId)
        {
            var internship = await GetInternshipByStudentId(studentId);

            return internship?.InternshipReports.OrderByDescending(x => x.CreationDate).Select(x => new InternshipReportDto
            {
                Feedback = x.Feedback,
                CreationDate = x.CreationDate.ToFarsi(),
                Result = x.Result,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                InternshipReportId = x.Id,
                InternshipId = internship.Id,
                Monday = x.Monday,
                Saturday = x.Saturday,
                Sunday = x.Sunday,
                Thursday = x.Thursday,
                Tuesday = x.Tuesday,
                Wednesday = x.Wednesday,
                DaysOfAttendance = x.Internship.DaysOfAttendance
            }).ToList();
        }

        private async Task<InternshipRequest> GetInternshipByStudentId(int studentId)
        {
            return await _internshipRequestRepository.GetQuery()
                .Include(x => x.InternshipReports)
                .FirstOrDefaultAsync(x => x.StudentId == studentId && x.Situation == AcceptSituation.Confirm);
        }
    }
}
