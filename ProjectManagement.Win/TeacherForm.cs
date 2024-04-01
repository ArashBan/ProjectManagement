using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Application.Utils;
using ProjectManagement.DataLayer.DTOs.Teacher;
using ProjectManagement.Win.Tools;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectManagement.Win
{
    public partial class TeacherForm : Form
    {
        private readonly ITeacherService _teacherService;
        private int _selectedId;
        private bool _flag; // False => Register & True => Edit

        public TeacherForm(ITeacherService teacherService)
        {
            InitializeComponent();
            _teacherService = teacherService;
        }

        private void ClearControllers()
        {
            foreach (Control control in groupBox1.Controls)
            {
                switch (control)
                {
                    case TextBox textBox:
                        textBox.Clear();
                        break;
                    case ComboBox comboBox:
                        comboBox.Text = null;
                        break;
                    case CheckBox checkBox:
                        checkBox.Checked = false;
                        break;
                }
            }
        }

        private async void RefreshForm()
        {
            cmbParent.DataSource = await _teacherService.GetParentsList();
            cmbParent.DisplayMember = "FullName";
            cmbParent.ValueMember = "Id";

            dgvTeacher.DataSource = await _teacherService.GetAllTeachers();
            if (dgvTeacher.RowCount == 0) dgvTeacher.ContextMenuStrip = null;
            else dgvTeacher.ContextMenuStrip = cmsTeacher;
            lblRows.Text = "تعداد سطرها: " + dgvTeacher.Rows.Count;
        }

        private async void Search()
        {
            dgvTeacher.DataSource = await _teacherService.SearchTeacher(txtSearch.Text);
            lblRows.Text = "تعداد سطرها: " + dgvTeacher.Rows.Count;
        }

        private async void ApplyOnContext()
        {
            var teacher = new TeacherDto
            {
                Id = _selectedId,
                Name = txtName.Text,
                Family = txtFamily.Text,
                NationalCode = txtNationalCode.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Position = cmbPosition.Text,
                Project = chbProject.Checked,
                Internship = chbInternship.Checked
            };

            if (txtLatinName.Enabled && txtLatinName.Text.Trim().Length >= 2)
                teacher.Password = txtLatinName.Text.ToLower().Substring(0, 1) +
                                   txtLatinFamily.Text.ToLower().Substring(0, 1) + txtNationalCode.Text;
            if (txtLatinFamily.Enabled && txtLatinFamily.Text.Trim().Length >= 2)
                teacher.Username = txtLatinFamily.Text.ToLower() + "_" + txtLatinName.Text.Substring(0, 2).ToLower();

            if (cmbPosition.SelectedIndex == 1)
                teacher.ParentId = 0;
            else
                teacher.ParentId = Convert.ToInt16(cmbParent.SelectedValue);

            OperationResult operationResult;
            if (!_flag)
            {
                operationResult = await _teacherService.AddTeacher(teacher);
            }
            else
            {
                operationResult = await _teacherService.EditTeacher(teacher);
                _flag = false;
            }

            if (operationResult.IsSucceed)
            {
                lblMessage.Text = "ثبت مقادیر با موفقیت انجام شد";
                lblMessage.BackColor = Color.Green;
                lblMessage.Visible = true;
                RefreshForm();
                ClearControllers();
                txtName.Focus();
                btnRegister.Text = "ثبت استاد";
                btnClearControllers.Text = "بازنشانی";
                lblLatinName.Enabled = true;
                txtLatinName.Enabled = true;
                lblLatinFamily.Enabled = true;
                txtLatinFamily.Enabled = true;
                chbProject.Enabled = true;
                chbInternship.Enabled = true;
                lblCourses.Enabled = true;
            }
            else
            {
                lblMessage.Text = operationResult.Message;
                lblMessage.BackColor = Color.Red;
                lblMessage.Visible = true;
            }
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            dgvTeacher.AutoGenerateColumns = false;
            RefreshForm();
        }

        private void btnStudentRegister_Click(object sender, EventArgs e)
        {
            if (!_flag)
            {
                if (txtName.Text.Trim().Length == 0 || txtFamily.Text.Trim().Length == 0 ||
                    txtNationalCode.Text.Trim().Length == 0 || txtPhoneNumber.Text.Trim().Length == 0 ||
                    cmbPosition.Text == "")
                {
                    lblMessage.Text = "هیچکدام از مقادیر نمی توانند خالی باشند";
                    lblMessage.BackColor = Color.Red;
                    lblMessage.Visible = true;
                }
                else if (txtNationalCode.Text.Trim().Length != 10)
                {
                    lblMessage.Text = "مقدار کد ملی باید 10 رقمی باشد";
                    lblMessage.BackColor = Color.Red;
                    lblMessage.Visible = true;
                    txtNationalCode.Focus();
                }
                else if (!chbProject.Checked && !chbInternship.Checked)
                {
                    lblMessage.Text = "حداقل باید یک درس انتخاب شود";
                    lblMessage.BackColor = Color.Red;
                    lblMessage.Visible = true;
                }
                else if (cmbParent.Enabled && cmbParent.Text == "")
                {
                    lblMessage.Text = "باید یک مدیر گروه برای استاد راهنما انتخاب شود";
                    lblMessage.BackColor = Color.Red;
                    lblMessage.Visible = true;
                }
                else if (txtLatinName.Text.Trim().Length < 2 || txtLatinFamily.Text.Trim().Length < 2)
                {
                    lblMessage.Text = "مقادیر لاتین باید حداقل 2 حرف باشند";
                    lblMessage.BackColor = Color.Red;
                    lblMessage.Visible = true;
                }
                else
                    ApplyOnContext();
            }
            else
            {
                if (txtName.Text.Trim().Length == 0 || txtFamily.Text.Trim().Length == 0 ||
                    txtNationalCode.Text.Trim().Length == 0 || txtPhoneNumber.Text.Trim().Length == 0 ||
                    cmbPosition.Text == "")
                {
                    lblMessage.Text = "هیچکدام از مقادیر نمی توانند خالی باشند";
                    lblMessage.BackColor = Color.Red;
                    lblMessage.Visible = true;
                }
                else if (txtNationalCode.Text.Trim().Length != 10)
                {
                    lblMessage.Text = "مقدار کد ملی باید 10 رقمی باشد";
                    lblMessage.BackColor = Color.Red;
                    lblMessage.Visible = true;
                    txtNationalCode.Focus();
                }
                else if (cmbParent.Enabled && cmbParent.Text == "")
                {
                    lblMessage.Text = "باید یک مدیر گروه برای استاد راهنما انتخاب شود";
                    lblMessage.BackColor = Color.Red;
                    lblMessage.Visible = true;
                }
                else
                    ApplyOnContext();
            }
        }

        private void btnClearControllers_Click(object sender, EventArgs e)
        {
            if (btnClearControllers.Text == "لغو")
            {
                lblLatinName.Enabled = true;
                txtLatinName.Enabled = true;
                lblLatinFamily.Enabled = true;
                txtLatinFamily.Enabled = true;
                chbProject.Enabled = true;
                chbInternship.Enabled = true;
                lblCourses.Enabled = true;

                _flag = false;
                btnRegister.Text = "ثبت استاد";
                btnClearControllers.Text = "بازنشانی";
                ClearControllers();
            }
            else
                ClearControllers();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Text = null;
            Search();
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
        }

        private void dgvTeacher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedId = Convert.ToInt32(dgvTeacher.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception) { }
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            var box = sender as GroupBox;
            DrawGroupBox.Draw(box, e.Graphics, Color.Black, Color.DarkGray, this);
        }

        private void TeacherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((MainForm)System.Windows.Forms.Application.OpenForms["MainForm"])?.LoadStats();
        }

        #region ComboBox

        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPosition.SelectedIndex == 0)
            {
                lblParent.Enabled = true;
                cmbParent.Enabled = true;
            }
            else
            {
                lblParent.Enabled = false;
                cmbParent.Enabled = false;
                cmbParent.Text = null;
            }
        }

        #endregion

        #region ControllersFilter

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControllersFilter.Filter(e, false, true, true);
        }

        private void txtFamily_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControllersFilter.Filter(e, false, true, true);
        }

        private void txtNationalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControllersFilter.Filter(e, true);
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControllersFilter.Filter(e, true);
        }

        private void txtLatinName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControllersFilter.Filter(e, false, true, false, true);
        }

        private void txtLatinFamily_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControllersFilter.Filter(e, false, true, false, true);
        }

        #endregion

        #region ContextMenueStrip

        private async void cmsTeacherEdit_Click(object sender, EventArgs e)
        {
            if (_selectedId != 0)
            {
                ClearControllers();
                var editTeacher = await _teacherService.GetTeacherById(_selectedId);
                txtName.Text = editTeacher.Name;
                txtFamily.Text = editTeacher.Family;
                txtNationalCode.Text = editTeacher.NationalCode;
                txtPhoneNumber.Text = editTeacher.PhoneNumber;
                cmbPosition.Text = editTeacher.Position;
                chbProject.Checked = editTeacher.Project;
                chbInternship.Checked = editTeacher.Internship;
                if (editTeacher.IsParent())
                {
                    cmbParent.Enabled = false;
                }
                else
                {
                    cmbParent.Enabled = true;
                    cmbParent.SelectedValue = editTeacher.ParentId;
                }
                if (editTeacher.HasCourse(1))
                    chbProject.Checked = true;
                if (editTeacher.HasCourse(2))
                    chbInternship.Checked = true;

                lblLatinName.Enabled = false;
                txtLatinName.Enabled = false;
                lblLatinFamily.Enabled = false;
                txtLatinFamily.Enabled = false;
                chbProject.Enabled = false;
                chbInternship.Enabled = false;
                lblCourses.Enabled = false;

                btnRegister.Text = "ویرایش استاد";
                btnClearControllers.Text = "لغو";
                _flag = true;
            }
            else
                MessageBox.Show("!سطر مورد نظر خود را برای ویرایش انتخاب کنید", "هشدار",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private async void cmsTeacherDelete_Click(object sender, EventArgs e)
        {
            if (_selectedId != 0)
            {
                if (MessageBox.Show("آیا مطمئن هستید که این سطر را می خواهید حذف کنید؟", "هشدار",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    await _teacherService.DeleteTeacher(_selectedId);
                    lblMessage.Text = "حذف سطر با موفقیت انجام شد";
                    lblMessage.BackColor = Color.Green;
                    lblMessage.Visible = true;
                    RefreshForm();
                }
            }
            else
                MessageBox.Show("!سطر مورد نظر خود را برای حذف انتخاب کنید", "هشدار",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion
    }
}
