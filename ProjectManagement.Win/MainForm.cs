using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Win.Tools;
using System.Diagnostics;
using System.Linq;

namespace ProjectManagement.Win
{
    public partial class MainForm : Form
    {
        private readonly INewsService _newsService;
        private readonly IMainFormService _mainFormService;

        public MainForm(IMainFormService mainFormService, INewsService newsService)
        {
            _newsService = newsService;
            _mainFormService = mainFormService;
            InitializeComponent();
        }

        public async Task LoadStats()
        {
            var mainForm = await _mainFormService.GetMainForm();
            lblStudentsCount.Text = mainForm.Stats.StudentsCount.ToString();
            lblTeachersCount.Text = mainForm.Stats.TeachersCount.ToString();
            lblProjectAndInternshipCount.Text = mainForm.Stats.RequestsCount.ToString();
            lblQuestionCount.Text = mainForm.Stats.QuestionsCount.ToString();
        }

        public async Task LoadNews()
        {
            try
            {
                var news = await _newsService.GetLastThree();
                for (var i = 0; i <= news.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            lblNewsTitle1.Text = news[i].Title;
                            lblNewsText1.Text = news[i].Body;
                            break;
                        case 1:
                            lblNewsTitle2.Text = news[i].Title;
                            lblNewsText2.Text = news[i].Body;
                            break;
                        case 2:
                            lblNewsTitle3.Text = news[i].Title;
                            lblNewsText3.Text = news[i].Body;
                            break;
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            Hide();
            var loginForm = new LoginForm();
            loginForm.ShowDialog();

            lblLoginTime.Text += DateTime.Now.Hour.ToString("0#:");
            lblLoginTime.Text += DateTime.Now.Minute.ToString("0#:");
            lblLoginTime.Text += DateTime.Now.Second.ToString("0#");
            await LoadStats();
            await LoadNews();

            chbShowBottomBox.Checked = Properties.Settings.Default.ShowNotifyIcon;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTodayTime.Text = DateTime.Now.ToString("HH:mm:ss  -  ");
            lblTodayTime.Text += DateTime.Now.ToString("dddd، dd MMMM yyyy");
            if (timer1.Interval == 1) timer1.Interval = 1000;
        }

        private void btnWeb_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://university-project.ir",
                UseShellExecute = true
            });
        }

        private void btnGuide_Click(object sender, EventArgs e)
        {
            using var guideForm = new GuideForm();
            guideForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از حساب کاربری خود خارج می شوید؟", "هشدار",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Hide();
                using var loginForm = Program.ServiceProvider.GetRequiredService<LoginForm>();
                loginForm.ShowDialog();
            }
        }

        #region Studetns

        private void pnlStudents_Click(object sender, EventArgs e)
        {
            using var studentForm = Program.ServiceProvider.GetRequiredService<StudentForm>();
            studentForm.ShowDialog();
        }

        private void lblStudents_Click(object sender, EventArgs e)
        {
            pnlStudents_Click(sender, e);
        }

        private void lblStudentsCount_Click(object sender, EventArgs e)
        {
            pnlStudents_Click(sender, e);
        }

        private void lblStudentsLine_Click(object sender, EventArgs e)
        {
            pnlStudents_Click(sender, e);
        }

        private void picStudentsLogo_Click(object sender, EventArgs e)
        {
            pnlStudents_Click(sender, e);
        }

        #endregion

        #region Teachers

        private void pnlTeachers_Click(object sender, EventArgs e)
        {
            using var teacherForm = Program.ServiceProvider.GetRequiredService<TeacherForm>();
            teacherForm.ShowDialog();
        }

        private void lblTeachers_Click(object sender, EventArgs e)
        {
            pnlTeachers_Click(sender, e);
        }

        private void lblTeachersCount_Click(object sender, EventArgs e)
        {
            pnlTeachers_Click(sender, e);
        }

        private void lblTeachersLine_Click(object sender, EventArgs e)
        {
            pnlTeachers_Click(sender, e);
        }

        private void picTeachersLogo_Click(object sender, EventArgs e)
        {
            pnlTeachers_Click(sender, e);
        }

        #endregion

        #region ProjectAndInternship

        private void pnlProjectAndInternship_Click(object sender, EventArgs e)
        {
            using var managementForm = Program.ServiceProvider.GetRequiredService<ProjectAndInternshipForm>();
            managementForm.ShowDialog();
        }

        private void lblProjectAndInternship_Click(object sender, EventArgs e)
        {
            pnlProjectAndInternship_Click(sender, e);
        }

        private void lblProjectAndInternshipCount_Click(object sender, EventArgs e)
        {
            pnlProjectAndInternship_Click(sender, e);
        }

        private void lblProjectAndInternshipLine_Click(object sender, EventArgs e)
        {
            pnlProjectAndInternship_Click(sender, e);
        }

        private void picProjectAndInternshipLogo_Click(object sender, EventArgs e)
        {
            pnlProjectAndInternship_Click(sender, e);
        }

        #endregion

        #region Questions

        private void pnlQuestion_Click(object sender, EventArgs e)
        {
            using var managementForm = Program.ServiceProvider.GetRequiredService<QuestionForm>();
            managementForm.ShowDialog();
        }

        private void lblQuestion_Click(object sender, EventArgs e)
        {
            pnlQuestion_Click(sender, e);
        }

        private void lblQuestionCount_Click(object sender, EventArgs e)
        {
            pnlQuestion_Click(sender, e);
        }

        private void lblQuestionLine_Click(object sender, EventArgs e)
        {
            pnlQuestion_Click(sender, e);
        }

        private void picQuestionsLogo_Click(object sender, EventArgs e)
        {
            pnlQuestion_Click(sender, e);
        }

        #endregion

        #region Settings

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value == 1)
                BackColor = Color.FromArgb(200, 200, 205);
            else if (trackBar1.Value == 2)
                BackColor = Color.FromArgb(186, 185, 191);
            else if (trackBar1.Value == 3)
                BackColor = Color.FromArgb(166, 165, 171);
        }

        private void chbShowBottomBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowNotifyIcon = chbShowBottomBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            if (txtCurrentPassword.Text.Trim().Length != 0 && txtNewPassword.Text.Trim().Length != 0 && txtRepeatPassword.Text.Trim().Length != 0)
            {
                if (txtCurrentPassword.Text.Trim() == Properties.Settings.Default.Password)
                {
                    if (txtNewPassword.Text.Trim() == txtRepeatPassword.Text.Trim())
                    {
                        Properties.Settings.Default.Password = txtNewPassword.Text;
                        Properties.Settings.Default.Save();
                        MessageBox.Show("!تغییر رمز عبور با موفقیت اعمال شد", "موفقیت",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCurrentPassword.Text = null;
                        txtNewPassword.Text = null;
                        txtRepeatPassword.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("!تکرار رمز عبور همخوانی ندارد", "خطا",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtRepeatPassword.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("!رمز عبور فعلی صحیح نمی باشد", "خطا",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCurrentPassword.Focus();
                }
            }
            else
            {
                MessageBox.Show("!لطفا همه مقادیر را وارد کنید", "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCurrentPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControllersFilter.Filter(e, true);
        }

        private void txtNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControllersFilter.Filter(e, true);
        }

        private void txtRepeatPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControllersFilter.Filter(e, true);
        }

        #endregion
    }
}
