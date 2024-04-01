using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Application.Utils;
using ProjectManagement.DataLayer.DTOs.Student;
using ProjectManagement.Win.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectManagement.Win
{
    public partial class StudentForm : Form
    {
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private int _selectedId;
        private string _nationalCode;
        private bool _flag; // False => Register & True => Edit

        public StudentForm(IStudentService studentService, ITeacherService teacherService)
        {
            InitializeComponent();
            _studentService = studentService;
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
            cmbProject.DataSource = await _teacherService.GetTeacherList(true);
            cmbProject.DisplayMember = "Title";
            cmbProject.ValueMember = "Id";
            cmbProject.Text = null;

            cmbInternship.DataSource = await _teacherService.GetTeacherList(false);
            cmbInternship.DisplayMember = "Title";
            cmbInternship.ValueMember = "Id";
            cmbInternship.Text = null;

            dgvStudent.DataSource = await _studentService.GetAllStudents();
            if (dgvStudent.RowCount == 0) dgvStudent.ContextMenuStrip = null;
            else dgvStudent.ContextMenuStrip = cmsStudent;
            lblRows.Text = "تعداد سطرها: " + dgvStudent.Rows.Count;
        }

        private async void Search()
        {
            dgvStudent.DataSource = await _studentService.SearchStudent(txtSearch.Text);
            lblRows.Text = "تعداد سطرها: " + dgvStudent.Rows.Count;
        }

        private async void ApplyOnContext()
        {
            var student = new StudentDto
            {
                Id = _selectedId,
                Name = txtName.Text,
                Family = txtFamily.Text,
                StudentCode = txtStudentCode.Text,
                NationalCode = txtNationalCode.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Field = txtField.Text,
                Semester = cmbSemester.Text,
                Type = cmbType.Text
            };

            var studentCourse = new List<StudentCourse>();
            if (chbProject.Checked)
            {
                studentCourse.Add(new StudentCourse
                {
                    CourseId = 1,
                    TeacherId = Convert.ToByte(cmbProject.SelectedValue)
                });
            }
            if (chbInternship.Checked)
            {
                studentCourse.Add(new StudentCourse
                {
                    CourseId = 2,
                    TeacherId = Convert.ToByte(cmbInternship.SelectedValue)
                });
            }
            student.Courses = studentCourse;

            OperationResult operationResult;
            if (!_flag)
            {
                operationResult = await _studentService.RegisterStudent(student);
            }
            else
            {
                operationResult = await _studentService.EditStudent(student);
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
                btnRegister.Text = "ثبت دانشجو";
                btnClearControllers.Text = "بازنشانی";
                chbProject.Enabled = true;
                chbInternship.Enabled = true;
            }
            else
            {
                lblMessage.Text = operationResult.Message;
                lblMessage.BackColor = Color.Red;
                lblMessage.Visible = true;
            }
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            dgvStudent.Columns[7].Width = 90;
            dgvStudent.Columns[8].Width = 90;
            dgvStudent.AutoGenerateColumns = false;
            RefreshForm();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!_flag)
            {
                if (txtName.Text.Trim().Length == 0 || txtFamily.Text.Trim().Length == 0 ||
                    txtStudentCode.Text.Trim().Length == 0 || txtNationalCode.Text.Trim().Length == 0 ||
                    txtPhoneNumber.Text.Trim().Length == 0 || txtField.Text.Trim().Length == 0 ||
                    cmbSemester.Text == "" || cmbType.Text == "")
                {
                    lblMessage.Text = "هیچکدام از مقادیر نمی توانند خالی باشند";
                    lblMessage.BackColor = Color.Red;
                    lblMessage.Visible = true;
                }
                else if (txtStudentCode.Text.Trim().Length != 14)
                {
                    lblMessage.Text = "مقدار شماره دانشجویی باید 14 رقمی باشد";
                    lblMessage.BackColor = Color.Red;
                    lblMessage.Visible = true;
                    txtStudentCode.Focus();
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
                else if (chbProject.Checked && cmbProject.Text == "")
                {
                    lblMessage.Text = "استاد مربوط به درس پروژه باید انتخاب شود";
                    lblMessage.BackColor = Color.Red;
                    lblMessage.Visible = true;
                }
                else if (chbInternship.Checked && cmbInternship.Text == "")
                {
                    lblMessage.Text = "استاد مربوط به درس کارآموزی باید انتخاب شود";
                    lblMessage.BackColor = Color.Red;
                    lblMessage.Visible = true;
                }
                else
                    ApplyOnContext();
            }
            else
            {
                if (txtName.Text.Trim().Length == 0 || txtFamily.Text.Trim().Length == 0 ||
                    txtStudentCode.Text.Trim().Length == 0 || txtNationalCode.Text.Trim().Length == 0 ||
                    txtPhoneNumber.Text.Trim().Length == 0 || txtField.Text.Trim().Length == 0 ||
                    cmbSemester.Text == "" || cmbType.Text == "")
                {
                    lblMessage.Text = "هیچکدام از مقادیر نمی توانند خالی باشند";
                    lblMessage.BackColor = Color.Red;
                    lblMessage.Visible = true;
                }
                else if (txtStudentCode.Text.Trim().Length != 14)
                {
                    lblMessage.Text = "مقدار شماره دانشجویی باید 14 رقمی باشد";
                    lblMessage.BackColor = Color.Red;
                    lblMessage.Visible = true;
                    txtStudentCode.Focus();
                }
                else if (txtNationalCode.Text.Trim().Length != 10)
                {
                    lblMessage.Text = "مقدار کد ملی باید 10 رقمی باشد";
                    lblMessage.BackColor = Color.Red;
                    lblMessage.Visible = true;
                    txtNationalCode.Focus();
                }
                else
                    ApplyOnContext();
            }
        }

        private void btnClearControllers_Click(object sender, EventArgs e)
        {
            if (btnClearControllers.Text == "لغو")
            {
                chbProject.Enabled = true;
                chbInternship.Enabled = true;
                cmbProject.Enabled = true;
                cmbInternship.Enabled = true;

                _flag = false;
                btnRegister.Text = "ثبت دانشجو";
                btnClearControllers.Text = "بازنشانی";
                ClearControllers();
            }
            else
                ClearControllers();
        }

        private  void btnSearch_Click(object sender, EventArgs e)
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

        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedId = Convert.ToInt32(dgvStudent.Rows[e.RowIndex].Cells[0].Value);
                _nationalCode = dgvStudent.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            catch (Exception) { }
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            var box = sender as GroupBox;
            DrawGroupBox.Draw(box, e.Graphics, Color.Black, Color.DarkGray, this);
        }

        private void StudentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((MainForm)System.Windows.Forms.Application.OpenForms["MainForm"])?.LoadStats();
        }

        #region CheckBox

        private void chbProject_CheckedChanged(object sender, EventArgs e)
        {
            cmbProject.Enabled = chbProject.Checked;
        }

        private void chbInternship_CheckedChanged(object sender, EventArgs e)
        {
            cmbInternship.Enabled = chbInternship.Checked;
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

        private void txtStudentCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControllersFilter.Filter(e, true);
        }

        private void txtNationalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControllersFilter.Filter(e, true);
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControllersFilter.Filter(e, true);
        }

        #endregion

        #region ContextMenueStrip

        private async void cmsStudentEdit_Click(object sender, EventArgs e)
        {
            if (_selectedId != 0)
            {
                ClearControllers();
                var editStudent = await _studentService.GetStudentByNationalCode(_nationalCode);
                txtName.Text = editStudent.Name;
                txtFamily.Text = editStudent.Family;
                txtStudentCode.Text = editStudent.StudentCode;
                txtNationalCode.Text = editStudent.NationalCode;
                txtPhoneNumber.Text = editStudent.PhoneNumber;
                txtField.Text = editStudent.Field;
                cmbSemester.Text = editStudent.Semester;
                cmbType.Text = editStudent.Type;
                if (editStudent.HasCourse(1))
                {
                    chbProject.Checked = true;
                    cmbProject.SelectedValue = editStudent.GetCourseTeacherId(1);
                }
                if (editStudent.HasCourse(2))
                {
                    chbInternship.Checked = true;
                    cmbInternship.SelectedValue = editStudent.GetCourseTeacherId(2);
                }

                chbProject.Enabled = false;
                chbInternship.Enabled = false;
                cmbProject.Enabled = false;
                cmbInternship.Enabled = false;

                btnRegister.Text = "ویرایش دانشجو";
                btnClearControllers.Text = "لغو";
                _flag = true;
            }
            else
                MessageBox.Show("!سطر مورد نظر خود را برای ویرایش انتخاب کنید", "هشدار",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private async void cmsStudentDelete_Click(object sender, EventArgs e)
        {
            if (_selectedId != 0)
            {
                if (MessageBox.Show("آیا مطمئن هستید که این سطر را می خواهید حذف کنید؟", "هشدار",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    await _studentService.DeleteStudent(_selectedId);
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
