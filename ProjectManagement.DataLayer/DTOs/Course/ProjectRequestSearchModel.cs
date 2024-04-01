using ProjectManagement.DataLayer.DTOs.Common;
using ProjectManagement.DataLayer.Entities.Courses;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.DataLayer.DTOs.Course
{
    public class ProjectRequestSearchModel
    {
        public string StudentCode { get; set; }
        public string StudentFullName { get; set; }
        public string Title { get; set; }
        public string CreationDate { get; set; }
        public ProjectType ProjectType { get; set; }
        public Platform Platform { get; set; }
        public AcceptSituation Situation { get; set; } // if all selected => empty
        public int TeacherId { get; set; }
        public string TeacherFullName { get; set; }

        public bool HaveSituation { get; set; } // if all selected => false
        public bool HavePlatform { get; set; }
        public bool HaveProjectType { get; set; }
        public bool Removed { get; set; }
    }

    public class InternshipRequestSearchModel
    {
        public string StudentCode { get; set; }
        public string CreationDate { get; set; }
        public string StudentFullName { get; set; }
        public string Title { get; set; }
        public string PlaceName { get; set; }
        public string Address { get; set; }
        public string TeacherFullName { get; set; }
        public AcceptSituation Situation { get; set; }

        public bool HaveSituation { get; set; }
        public bool Removed { get; set; }
    }
}
