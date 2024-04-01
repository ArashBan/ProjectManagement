using System;
using System.Windows.Forms;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.DataLayer.Entities.Courses;

namespace ProjectManagement.Win
{
    public partial class InternshipDetailsForm : Form
    {
        private readonly IInternshipService _internshipService;

        public InternshipDetailsForm(IInternshipService internshipService)
        {
            InitializeComponent();
            _internshipService = internshipService;
        }

        private async void InternshipDetailsForm_Load(object sender, EventArgs e)
        {
            var editInternship = await _internshipService.GetInternshipById(ProjectAndInternshipForm.SelectedInternshipId);
            lblTitle.Text = editInternship.Title;
            lblDescription.Text = editInternship.Description;
            lblFeedback.Text = editInternship.Feedback;
            lblDaysOfAttendance.Text = editInternship.RenderDaysOfAttendanceToText();
            lblAddress.Text = editInternship.Address;
            lblPlacePhoneNumber.Text = editInternship.PlacePhoneNumber;
            lblPlaceName.Text = editInternship.PlaceName;
            lblSupervisorFullName.Text = editInternship.SupervisorFullName;
            switch (editInternship.Situation)
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
