using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.DataLayer.DTOs.Course;
using ProjectManagement.DataLayer.Entities.Courses;
using ProjectManagement.Win.Tools;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectManagement.Win
{
    public partial class ProjectAndInternshipForm : Form
    {
        private readonly ICourseService _courseService;
        private readonly IInternshipService _internshipService;
        public static int SelectedProjectId;
        public static int SelectedInternshipId;

        public ProjectAndInternshipForm(ICourseService courseService, IInternshipService internshipService)
        {
            InitializeComponent();
            _courseService = courseService;
            _internshipService = internshipService;
        }

        private void ProjectClearControllers()
        {
            foreach (Control control in groupBox1.Controls)
            {
                switch (control)
                {
                    case TextBox textBox:
                        textBox.Clear();
                        break;
                    case ComboBox comboBox:
                        comboBox.Text = "همه";
                        break;
                    case CheckBox checkBox:
                        checkBox.Checked = false;
                        break;
                }
            }
        }

        private void InternshipClearControllers()
        {
            foreach (Control control in groupBox2.Controls)
            {
                switch (control)
                {
                    case TextBox textBox:
                        textBox.Clear();
                        break;
                    case ComboBox comboBox:
                        comboBox.Text = "همه";
                        break;
                    case CheckBox checkBox:
                        checkBox.Checked = false;
                        break;
                }
            }
        }

        private async void RefreshForm()
        {
            dgvProject.DataSource = await _courseService.SearchProjectRequests(new ProjectRequestSearchModel());
            if (dgvProject.RowCount == 0) dgvProject.ContextMenuStrip = null;
            else dgvProject.ContextMenuStrip = cmsProject;
            lblProjectRows.Text = "تعداد سطرها: " + dgvProject.Rows.Count;

            dgvInternship.DataSource = await _internshipService.SearchInternshipRequests(new InternshipRequestSearchModel());
            if (dgvInternship.RowCount == 0) dgvInternship.ContextMenuStrip = null;
            else dgvInternship.ContextMenuStrip = cmsInternship;
            lblInternshipRows.Text = "تعداد سطرها: " + dgvInternship.Rows.Count;
        }

        private void ManagementForm_Load(object sender, EventArgs e)
        {
            cmbProjectPlatform.SelectedIndex = 0;
            cmbProjectSituation.SelectedIndex = 0;
            cmbProjectType.SelectedIndex = 0;
            cmbInternshipSituation.SelectedIndex = 0;

            dgvProject.AutoGenerateColumns = false;
            dgvInternship.AutoGenerateColumns = false;
            RefreshForm();
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            var box = sender as GroupBox;
            DrawGroupBox.Draw(box, e.Graphics, Color.Black, Color.DarkGray, this);
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            var box = sender as GroupBox;
            DrawGroupBox.Draw(box, e.Graphics, Color.Black, Color.DarkGray, this);
        }

        private void ProjectAndInternshipForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((MainForm)System.Windows.Forms.Application.OpenForms["MainForm"])?.LoadStats();
        }

        #region Project

        private async void btnProjectEdit_Click(object sender, EventArgs e)
        {
            if (txtProjectTitle.Text.Trim().Length == 0)
            {
                lblProjectMessage.Text = "هیچکدام از مقادیر نمی توانند خالی باشند";
                lblProjectMessage.BackColor = Color.Red;
                lblProjectMessage.Visible = true;
            }
            else if (cmbProjectPlatform.SelectedIndex == 0 || cmbProjectSituation.SelectedIndex == 0 ||
                cmbProjectType.SelectedIndex == 0)
            {
                lblProjectMessage.Text = "نمی توان گزینه همه را برای هیچکدام از مقادیر انتخاب کرد";
                lblProjectMessage.BackColor = Color.Red;
                lblProjectMessage.Visible = true;
            }
            else
            {
                var course = new RequestProjectDto
                {
                    RequestProjectId = SelectedProjectId,
                    Title = txtProjectTitle.Text
                };
                switch (cmbProjectPlatform.SelectedIndex)
                {
                    case 1:
                        course.Platform = Platform.Windows;
                        break;
                    case 2:
                        course.Platform = Platform.Web;
                        break;
                    case 3:
                        course.Platform = Platform.Mobile;
                        break;
                    case 4:
                        course.Platform = Platform.Other;
                        break;
                }
                switch (cmbProjectType.SelectedIndex)
                {
                    case 1:
                        course.ProjectType = ProjectType.Programming;
                        break;
                    case 2:
                        course.ProjectType = ProjectType.Researching;
                        break;
                    case 3:
                        course.ProjectType = ProjectType.Handmade;
                        break;
                }
                switch (cmbProjectSituation.SelectedIndex)
                {
                    case 1:
                        course.Situation = AcceptSituation.UnderProgress;
                        break;
                    case 2:
                        course.Situation = AcceptSituation.Accepted;
                        break;
                    case 3:
                        course.Situation = AcceptSituation.Confirm;
                        break;
                    case 4:
                        course.Situation = AcceptSituation.Rejected;
                        break;
                }

                var operationResult = await _courseService.EditProjectRequest(course);

                if (operationResult.IsSucceed)
                {
                    lblProjectMessage.Text = "ثبت مقادیر با موفقیت انجام شد";
                    lblProjectMessage.BackColor = Color.Green;
                    lblProjectMessage.Visible = true;
                    RefreshForm();
                    ProjectClearControllers();

                    lblProjectStudentFullName.Enabled = true;
                    txtProjectStudentFullName.Enabled = true;
                    lblProjectStudentCode.Enabled = true;
                    txtProjectStudentCode.Enabled = true;
                    lblProjectCreationDate.Enabled = true;
                    txtProjectCreationDate.Enabled = true;
                    lblProjectTeacherFullName.Enabled = true;
                    txtProjectTeacherFullName.Enabled = true;
                    chbProjectRemoved.Enabled = true;

                    btnProjectEdit.Visible = false;
                    btnProjectCancel.Visible = false;
                }
                else
                {
                    lblProjectMessage.Text = operationResult.Message;
                    lblProjectMessage.BackColor = Color.Red;
                    lblProjectMessage.Visible = true;
                }
            }
        }

        private void btnProjectCancel_Click(object sender, EventArgs e)
        {
            lblProjectStudentFullName.Enabled = true;
            txtProjectStudentFullName.Enabled = true;
            lblProjectStudentCode.Enabled = true;
            txtProjectStudentCode.Enabled = true;
            lblProjectCreationDate.Enabled = true;
            txtProjectCreationDate.Enabled = true;
            lblProjectTeacherFullName.Enabled = true;
            txtProjectTeacherFullName.Enabled = true;
            chbProjectRemoved.Enabled = true;

            btnProjectEdit.Visible = false;
            btnProjectCancel.Visible = false;
            ProjectClearControllers();
        }

        private async void btnProjectSearch_Click(object sender, EventArgs e)
        {
            var projectRequestSearchModel = new ProjectRequestSearchModel
            {
                StudentFullName = txtProjectStudentFullName.Text,
                StudentCode = txtProjectStudentCode.Text,
                Title = txtProjectTitle.Text,
                CreationDate = txtProjectCreationDate.Text,
                TeacherFullName = txtProjectTeacherFullName.Text,
                Removed = chbProjectRemoved.Checked
            };

            if (cmbProjectPlatform.SelectedIndex <= 0)
            {
                projectRequestSearchModel.HavePlatform = false;
            }
            else
            {
                projectRequestSearchModel.HavePlatform = true;

                switch (cmbProjectPlatform.SelectedIndex)
                {
                    case 1:
                        projectRequestSearchModel.Platform = Platform.Windows;
                        break;
                    case 2:
                        projectRequestSearchModel.Platform = Platform.Web;
                        break;
                    case 3:
                        projectRequestSearchModel.Platform = Platform.Mobile;
                        break;
                    case 4:
                        projectRequestSearchModel.Platform = Platform.Other;
                        break;
                }
            }

            if (cmbProjectType.SelectedIndex <= 0)
            {
                projectRequestSearchModel.HaveProjectType = false;
            }
            else
            {
                projectRequestSearchModel.HaveProjectType = true;

                switch (cmbProjectType.SelectedIndex)
                {
                    case 1:
                        projectRequestSearchModel.ProjectType = ProjectType.Programming;
                        break;
                    case 2:
                        projectRequestSearchModel.ProjectType = ProjectType.Researching;
                        break;
                    case 3:
                        projectRequestSearchModel.ProjectType = ProjectType.Handmade;
                        break;
                }
            }

            if (cmbProjectSituation.SelectedIndex <= 0)
            {
                projectRequestSearchModel.HaveSituation = false;
            }
            else
            {
                projectRequestSearchModel.HaveSituation = true;

                switch (cmbProjectSituation.SelectedIndex)
                {
                    case 1:
                        projectRequestSearchModel.Situation = AcceptSituation.UnderProgress;
                        break;
                    case 2:
                        projectRequestSearchModel.Situation = AcceptSituation.Accepted;
                        break;
                    case 3:
                        projectRequestSearchModel.Situation = AcceptSituation.Confirm;
                        break;
                    case 4:
                        projectRequestSearchModel.Situation = AcceptSituation.Rejected;
                        break;
                }
            }

            dgvProject.DataSource = await _courseService.SearchProjectRequests(projectRequestSearchModel);
        }

        private void btnProjectShowAll_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void lblProjectMessage_Click(object sender, EventArgs e)
        {
            lblProjectMessage.Visible = false;
        }

        private void dgvProject_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SelectedProjectId = int.Parse(dgvProject.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            catch (Exception) { }
        }

        #endregion

        #region Internship

        private async void btnInternshipEdit_Click(object sender, EventArgs e)
        {
            if (txtInternshipTitle.Text.Trim().Length == 0 || txtInternshipPlaceName.Text.Trim().Length == 0 ||
                txtInternshipAddress.Text.Trim().Length == 0)
            {
                lblInternshipMessage.Text = "هیچکدام از مقادیر نمی توانند خالی باشند";
                lblInternshipMessage.BackColor = Color.Red;
                lblInternshipMessage.Visible = true;
            }
            else if (cmbInternshipSituation.SelectedIndex == 0)
            {
                lblInternshipMessage.Text = "نمی توان گزینه همه را برای هیچکدام از مقادیر انتخاب کرد";
                lblInternshipMessage.BackColor = Color.Red;
                lblInternshipMessage.Visible = true;
            }
            else
            {
                var internship = new InternshipDto
                {
                    InternshipId = SelectedInternshipId,
                    Title = txtInternshipTitle.Text,
                    PlaceName = txtInternshipPlaceName.Text,
                    Address = txtInternshipAddress.Text
                };
                switch (cmbInternshipSituation.SelectedIndex)
                {
                    case 1:
                        internship.Situation = AcceptSituation.UnderProgress;
                        break;
                    case 2:
                        internship.Situation = AcceptSituation.Accepted;
                        break;
                    case 3:
                        internship.Situation = AcceptSituation.Confirm;
                        break;
                    case 4:
                        internship.Situation = AcceptSituation.Rejected;
                        break;
                }

                var operationResult = await _internshipService.EditInternshipRequest(internship);

                if (operationResult.IsSucceed)
                {
                    lblInternshipMessage.Text = "ثبت مقادیر با موفقیت انجام شد";
                    lblInternshipMessage.BackColor = Color.Green;
                    lblInternshipMessage.Visible = true;
                    RefreshForm();
                    InternshipClearControllers();

                    lblInternshipStudentFullName.Enabled = true;
                    txtInternshipStudentFullName.Enabled = true;
                    lblInternshipStudentCode.Enabled = true;
                    txtInternshipStudentCode.Enabled = true;
                    lblInternshipCreationDate.Enabled = true;
                    txtInternshipCreationDate.Enabled = true;
                    lblInternshipTeacherFullName.Enabled = true;
                    txtInternshipTeacherFullName.Enabled = true;
                    chbInternshipRemoved.Enabled = true;

                    btnInternshipEdit.Visible = false;
                    btnInternshipCancel.Visible = false;
                }
                else
                {
                    lblInternshipMessage.Text = operationResult.Message;
                    lblInternshipMessage.BackColor = Color.Red;
                    lblInternshipMessage.Visible = true;
                }
            }
        }

        private void btnInternshipCancel_Click(object sender, EventArgs e)
        {
            lblInternshipStudentFullName.Enabled = true;
            txtInternshipStudentFullName.Enabled = true;
            lblInternshipStudentCode.Enabled = true;
            txtInternshipStudentCode.Enabled = true;
            lblInternshipCreationDate.Enabled = true;
            txtInternshipCreationDate.Enabled = true;
            lblInternshipTeacherFullName.Enabled = true;
            txtInternshipTeacherFullName.Enabled = true;
            chbInternshipRemoved.Enabled = true;

            btnInternshipEdit.Visible = false;
            btnInternshipCancel.Visible = false;
            InternshipClearControllers();
        }

        private async void btnInternshipSearch_Click(object sender, EventArgs e)
        {
            var internshipRequestSearchModel = new InternshipRequestSearchModel()
            {
                StudentFullName = txtInternshipStudentFullName.Text,
                StudentCode = txtInternshipStudentCode.Text,
                Title = txtInternshipTitle.Text,
                CreationDate = txtInternshipCreationDate.Text,
                TeacherFullName = txtInternshipTeacherFullName.Text,
                PlaceName = txtInternshipPlaceName.Text,
                Address = txtInternshipAddress.Text,
                Removed = chbInternshipRemoved.Checked
            };

            if (cmbInternshipSituation.SelectedIndex <= 0)
            {
                internshipRequestSearchModel.HaveSituation = false;
            }
            else
            {
                internshipRequestSearchModel.HaveSituation = true;

                switch (cmbInternshipSituation.SelectedIndex)
                {
                    case 1:
                        internshipRequestSearchModel.Situation = AcceptSituation.UnderProgress;
                        break;
                    case 2:
                        internshipRequestSearchModel.Situation = AcceptSituation.Accepted;
                        break;
                    case 3:
                        internshipRequestSearchModel.Situation = AcceptSituation.Confirm;
                        break;
                    case 4:
                        internshipRequestSearchModel.Situation = AcceptSituation.Rejected;
                        break;
                }
            }

            dgvInternship.DataSource = await _internshipService.SearchInternshipRequests(internshipRequestSearchModel);
        }

        private void btnInternshipShowAll_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void lblInternshipMessage_Click(object sender, EventArgs e)
        {
            lblInternshipMessage.Visible = false;
        }

        private void dgvInternship_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SelectedInternshipId = int.Parse(dgvInternship.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            catch (Exception) { }
        }

        #endregion

        #region ContextMenueStripProject

        private async void cmsProjectEdit_Click(object sender, EventArgs e)
        {
            if (SelectedProjectId != 0)
            {
                ProjectClearControllers();
                var editProject = await _courseService.GetProjectRequestById(SelectedProjectId);
                txtProjectStudentFullName.Text = dgvProject.Rows[dgvProject.CurrentCell.RowIndex].Cells[1].Value.ToString();
                txtProjectStudentCode.Text = dgvProject.Rows[dgvProject.CurrentCell.RowIndex].Cells[2].Value.ToString();
                txtProjectTitle.Text = editProject.Title;
                txtProjectCreationDate.Text = dgvProject.Rows[dgvProject.CurrentCell.RowIndex].Cells[4].Value.ToString();
                txtProjectTeacherFullName.Text = dgvProject.Rows[dgvProject.CurrentCell.RowIndex].Cells[5].Value.ToString();
                switch (editProject.Platform)
                {
                    case Platform.Windows:
                        cmbProjectPlatform.SelectedIndex = 1;
                        break;
                    case Platform.Web:
                        cmbProjectPlatform.SelectedIndex = 2;
                        break;
                    case Platform.Mobile:
                        cmbProjectPlatform.SelectedIndex = 3;
                        break;
                    case Platform.Other:
                        cmbProjectPlatform.SelectedIndex = 4;
                        break;
                }
                switch (editProject.ProjectType)
                {
                    case ProjectType.Programming:
                        cmbProjectType.SelectedIndex = 1;
                        break;
                    case ProjectType.Researching:
                        cmbProjectType.SelectedIndex = 2;
                        break;
                    case ProjectType.Handmade:
                        cmbProjectType.SelectedIndex = 3;
                        break;
                }
                switch (editProject.Situation)
                {
                    case AcceptSituation.UnderProgress:
                        cmbProjectSituation.SelectedIndex = 1;
                        break;
                    case AcceptSituation.Accepted:
                        cmbProjectSituation.SelectedIndex = 2;
                        break;
                    case AcceptSituation.Confirm:
                        cmbProjectSituation.SelectedIndex = 3;
                        break;
                    case AcceptSituation.Rejected:
                        cmbProjectSituation.SelectedIndex = 4;
                        break;
                }

                lblProjectStudentFullName.Enabled = false;
                txtProjectStudentFullName.Enabled = false;
                lblProjectStudentCode.Enabled = false;
                txtProjectStudentCode.Enabled = false;
                lblProjectCreationDate.Enabled = false;
                txtProjectCreationDate.Enabled = false;
                lblProjectTeacherFullName.Enabled = false;
                txtProjectTeacherFullName.Enabled = false;
                chbProjectRemoved.Enabled = false;

                btnProjectEdit.Visible = true;
                btnProjectCancel.Visible = true;
            }
            else
                MessageBox.Show("!سطر مورد نظر خود را برای ویرایش انتخاب کنید", "هشدار",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private async void cmsProjectDelete_Click(object sender, EventArgs e)
        {
            if (SelectedProjectId != 0)
            {
                if (MessageBox.Show("آیا مطمئن هستید که این سطر را می خواهید حذف کنید؟", "هشدار",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    await _courseService.RemoveProjectRequest(SelectedProjectId);
                    lblInternshipMessage.Text = "حذف سطر با موفقیت انجام شد";
                    lblInternshipMessage.BackColor = Color.Green;
                    lblInternshipMessage.Visible = true;
                    RefreshForm();
                }
            }
            else
                MessageBox.Show("!سطر مورد نظر خود را برای حذف انتخاب کنید", "هشدار",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cmsProjectDetails_Click(object sender, EventArgs e)
        {
            if (SelectedProjectId != 0)
            {
                using var projectDetailsForm = Program.ServiceProvider.GetRequiredService<ProjectDetailsForm>();
                projectDetailsForm.lblStudentFullName.Text = dgvProject.Rows[dgvProject.CurrentCell.RowIndex].Cells[1].Value.ToString();
                projectDetailsForm.lblStudentCode.Text = dgvProject.Rows[dgvProject.CurrentCell.RowIndex].Cells[2].Value.ToString();
                projectDetailsForm.lblCreationDate.Text = dgvProject.Rows[dgvProject.CurrentCell.RowIndex].Cells[4].Value.ToString();
                projectDetailsForm.lblTeacherFullName.Text = dgvProject.Rows[dgvProject.CurrentCell.RowIndex].Cells[5].Value.ToString();
                projectDetailsForm.ShowDialog();
            }
            else
                MessageBox.Show("!سطر مورد نظر خود را برای نمایش جزییات انتخاب کنید", "هشدار",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

        #region ContextMenueStripInternship

        private async void cmsInternshipEdit_Click(object sender, EventArgs e)
        {
            if (SelectedInternshipId != 0)
            {
                InternshipClearControllers();
                var editInternship = await _internshipService.GetInternshipById(SelectedInternshipId);
                txtInternshipStudentFullName.Text = dgvInternship.Rows[dgvInternship.CurrentCell.RowIndex].Cells[1].Value.ToString();
                txtInternshipStudentCode.Text = dgvInternship.Rows[dgvInternship.CurrentCell.RowIndex].Cells[2].Value.ToString();
                txtInternshipTitle.Text = editInternship.Title;
                txtInternshipCreationDate.Text = dgvInternship.Rows[dgvInternship.CurrentCell.RowIndex].Cells[4].Value.ToString();
                txtInternshipTeacherFullName.Text = dgvInternship.Rows[dgvInternship.CurrentCell.RowIndex].Cells[5].Value.ToString();
                txtInternshipAddress.Text = editInternship.Address;
                txtInternshipPlaceName.Text = editInternship.PlaceName;
                switch (editInternship.Situation)
                {
                    case AcceptSituation.UnderProgress:
                        cmbInternshipSituation.SelectedIndex = 1;
                        break;
                    case AcceptSituation.Accepted:
                        cmbInternshipSituation.SelectedIndex = 2;
                        break;
                    case AcceptSituation.Confirm:
                        cmbInternshipSituation.SelectedIndex = 3;
                        break;
                    case AcceptSituation.Rejected:
                        cmbInternshipSituation.SelectedIndex = 4;
                        break;
                }

                lblInternshipStudentFullName.Enabled = false;
                txtInternshipStudentFullName.Enabled = false;
                lblInternshipStudentCode.Enabled = false;
                txtInternshipStudentCode.Enabled = false;
                lblInternshipCreationDate.Enabled = false;
                txtInternshipCreationDate.Enabled = false;
                lblInternshipTeacherFullName.Enabled = false;
                txtInternshipTeacherFullName.Enabled = false;
                chbInternshipRemoved.Enabled = false;

                btnInternshipEdit.Visible = true;
                btnInternshipCancel.Visible = true;
            }
            else
                MessageBox.Show("!سطر مورد نظر خود را برای ویرایش انتخاب کنید", "هشدار",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private async void cmsInternshipDelete_Click(object sender, EventArgs e)
        {
            if (SelectedInternshipId != 0)
            {
                if (MessageBox.Show("آیا مطمئن هستید که این سطر را می خواهید حذف کنید؟", "هشدار",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    await _internshipService.RemoveInternshipRequest(SelectedInternshipId);
                    lblInternshipMessage.Text = "حذف سطر با موفقیت انجام شد";
                    lblInternshipMessage.BackColor = Color.Green;
                    lblInternshipMessage.Visible = true;
                    RefreshForm();
                }
            }
            else
                MessageBox.Show("!سطر مورد نظر خود را برای حذف انتخاب کنید", "هشدار",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cmsInternshipDetails_Click(object sender, EventArgs e)
        {
            if (SelectedInternshipId != 0)
            {
                using var internshipDetailsForm = Program.ServiceProvider.GetRequiredService<InternshipDetailsForm>();
                internshipDetailsForm.lblStudentFullName.Text = dgvInternship.Rows[dgvInternship.CurrentCell.RowIndex].Cells[1].Value.ToString();
                internshipDetailsForm.lblStudentCode.Text = dgvInternship.Rows[dgvInternship.CurrentCell.RowIndex].Cells[2].Value.ToString();
                internshipDetailsForm.lblCreationDate.Text = dgvInternship.Rows[dgvInternship.CurrentCell.RowIndex].Cells[4].Value.ToString();
                internshipDetailsForm.lblTeacherFullName.Text = dgvInternship.Rows[dgvInternship.CurrentCell.RowIndex].Cells[5].Value.ToString();
                internshipDetailsForm.ShowDialog();
            }
            else
                MessageBox.Show("!سطر مورد نظر خود را برای نمایش جزییات انتخاب کنید", "هشدار",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

        #region ControllersFilter

        private void txtProjectStudentFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControllersFilter.Filter(e, false, true, true);
        }

        private void txtProjectStudentCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControllersFilter.Filter(e, true);
        }

        private void txtProjectTeacherFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControllersFilter.Filter(e, false, true, true);
        }

        private void txtInternshipStudentFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControllersFilter.Filter(e, false, true, true);
        }

        private void txtInternshipStudentCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControllersFilter.Filter(e, true);
        }

        private void txtInternshipTeacherFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControllersFilter.Filter(e, false, true, true);
        }

        #endregion
    }
}
