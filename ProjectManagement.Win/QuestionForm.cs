using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Application.Utils;
using ProjectManagement.DataLayer.DTOs.Common;
using ProjectManagement.DataLayer.Entities.Common;
using ProjectManagement.Win.Tools;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProjectManagement.Win
{
    public partial class QuestionForm : Form
    {
        private readonly IProblemService _problemService;
        private int _selectedId;
        private bool _flag; // False => Register & True => Edit

        public QuestionForm(IProblemService problemService)
        {
            InitializeComponent();
            _problemService = problemService;
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
                    case RichTextBox richTextBox:
                        richTextBox.Clear();
                        break;
                }
            }
        }

        private async void RefreshForm()
        {
            dgvQuestion.DataSource = await _problemService.GetQuestionsList();
            if (dgvQuestion.RowCount == 0) dgvQuestion.ContextMenuStrip = null;
            else dgvQuestion.ContextMenuStrip = cmsQuestion;
            lblRows.Text = "تعداد سطرها: " + dgvQuestion.Rows.Count;
        }

        private async void Search()
        {
            dgvQuestion.DataSource = await _problemService.SearchQuestions(txtSearch.Text);
            lblRows.Text = "تعداد سطرها: " + dgvQuestion.Rows.Count;
        }

        private async void ApplyOnContext()
        {
            var problem = new ProblemDto
            {
                Id = _selectedId,
                Question = txtQuestion.Text,
                Answer = txtAnswer.Text
            };

            switch (cmbType.SelectedIndex)
            {
                case 0:
                    problem.Type = InfoType.Project;
                    break;
                case 1:
                    problem.Type = InfoType.Internship;
                    break;
                case 2:
                    problem.Type = InfoType.Common;
                    break;
            }

            OperationResult operationResult;
            if (!_flag)
            {
                operationResult = await _problemService.AddQuestion(problem);
            }
            else
            {
                operationResult = await _problemService.EditQuestion(problem);
                _flag = false;
            }

            if (operationResult.IsSucceed)
            {
                lblMessage.Text = "ثبت مقادیر با موفقیت انجام شد";
                lblMessage.BackColor = Color.Green;
                lblMessage.Visible = true;
                RefreshForm();
                ClearControllers();
                txtQuestion.Focus();
                btnRegister.Text = "ثبت سوال";
                btnClearControllers.Text = "بازنشانی";
            }
            else
            {
                lblMessage.Text = operationResult.Message;
                lblMessage.BackColor = Color.Red;
                lblMessage.Visible = true;
            }
        }

        private bool CheckInputs()
        {
            return !groupBox1.Controls.Cast<Control>().Any(control => string.IsNullOrWhiteSpace(control.Text));
        }

        private void QuestionForm_Load(object sender, EventArgs e)
        {
            dgvQuestion.Columns[2].Width = 100;
            dgvQuestion.AutoGenerateColumns = false;
            RefreshForm();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!_flag)
            {
                if (!CheckInputs())
                {
                    lblMessage.Text = "هیچکدام از مقادیر نمی توانند خالی باشند";
                    lblMessage.BackColor = Color.Red;
                    lblMessage.Visible = true;
                }
                else
                    ApplyOnContext();
            }
            else
            {
                if (!CheckInputs())
                {
                    lblMessage.Text = "هیچکدام از مقادیر نمی توانند خالی باشند";
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
                _flag = false;
                btnRegister.Text = "ثبت سوال";
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

        private void dgvQuestion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedId = Convert.ToInt32(dgvQuestion.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception) { }
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            var box = sender as GroupBox;
            DrawGroupBox.Draw(box, e.Graphics, Color.Black, Color.DarkGray, this);
        }

        private void QuestionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((MainForm)System.Windows.Forms.Application.OpenForms["MainForm"])?.LoadStats();
        }

        #region ContextMenueStrip

        private async void cmsQuestionEdit_Click(object sender, EventArgs e)
        {
            if (_selectedId != 0)
            {
                ClearControllers();
                var editQuestion = await _problemService.GetQuestionById(_selectedId);
                txtQuestion.Text = editQuestion.Question;
                switch (editQuestion.Type)
                {
                    case InfoType.Project:
                        cmbType.SelectedIndex = 0;
                        break;
                    case InfoType.Internship:
                        cmbType.SelectedIndex = 1;
                        break;
                    case InfoType.Common:
                        cmbType.SelectedIndex = 2;
                        break;
                }
                txtAnswer.Text = editQuestion.Answer;

                btnRegister.Text = "ویرایش سوال";
                btnClearControllers.Text = "لغو";
                _flag = true;
            }
            else
                MessageBox.Show("!سطر مورد نظر خود را برای ویرایش انتخاب کنید", "هشدار",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private async void cmsQuestionDelete_Click(object sender, EventArgs e)
        {
            if (_selectedId != 0)
            {
                if (MessageBox.Show("آیا مطمئن هستید که این سطر را می خواهید حذف کنید؟", "هشدار",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    await _problemService.DeleteQuestion(_selectedId);
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
