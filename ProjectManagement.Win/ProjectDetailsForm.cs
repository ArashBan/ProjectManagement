using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.DataLayer.Entities.Courses;
using System;
using System.Windows.Forms;

namespace ProjectManagement.Win
{
    public partial class ProjectDetailsForm : Form
    {
        private readonly ICourseService _courseService;

        public ProjectDetailsForm(ICourseService courseService)
        {
            InitializeComponent();
            _courseService = courseService;
        }

        private async void ProjectDetailsForm_Load(object sender, EventArgs e)
        {
            var editProject = await _courseService.GetProjectRequestById(ProjectAndInternshipForm.SelectedProjectId);
            lblTitle.Text = editProject.Title;
            lblTeammateFullName.Text = editProject.TeammateName;
            lblTeammateStudentCode.Text = editProject.TeammateStudentCode;
            lblDescription.Text = editProject.Description;
            lblFeedback.Text = editProject.Feedback;
            lblPurpose.Text = editProject.Puprpose;
            switch (editProject.Platform)
            {
                case Platform.Windows:
                    lblPlatform.Text = "ویندوز";
                    break;
                case Platform.Web:
                    lblPlatform.Text = "وب";
                    break;
                case Platform.Mobile:
                    lblPlatform.Text = "موبایل";
                    break;
                case Platform.Other:
                    lblPlatform.Text = "سایر";
                    break;
            }
            switch (editProject.ProjectType)
            {
                case ProjectType.Programming:
                    lblProjectType.Text = "برنامه نویسی";
                    break;
                case ProjectType.Researching:
                    lblProjectType.Text = "تحقیقاتی";
                    break;
                case ProjectType.Handmade:
                    lblProjectType.Text = "ساخت";
                    break;
            }
            switch (editProject.Situation)
            {
                case AcceptSituation.UnderProgress:
                    lblSituation.Text = "در انتظار بررسی";
                    break;
                case AcceptSituation.Accepted:
                    lblSituation.Text = "تایید استاد راهنما";
                    break;
                case AcceptSituation.Confirm:
                    lblSituation.Text = "تایید نهایی";
                    break;
                case AcceptSituation.Rejected:
                    lblSituation.Text = "رد شده";
                    break;
            }
        }
    }
}
