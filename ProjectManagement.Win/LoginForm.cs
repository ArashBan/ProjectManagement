using ProjectManagement.Win.Tools;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ProjectManagement.Win
{
    public partial class LoginForm : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern bool EnableWindow(IntPtr hwnd, bool bEnable);

        private void MoveForm()
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Text = Properties.Settings.Default.LoginUsername;
            txtPassword.Text = Properties.Settings.Default.LoginPassword;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim().ToLower() == "admin" &&
                txtPassword.Text.Trim() == Properties.Settings.Default.Password)
            {
                if (Properties.Settings.Default.ShowNotifyIcon)
                {
                    (((MainForm)System.Windows.Forms.Application.OpenForms["MainForm"])!).notifyIcon1.BalloonTipTitle = "به نرم افزار مدیریت پروژه و کارآموزی خوش آمدید!";
                    ((MainForm)System.Windows.Forms.Application.OpenForms["MainForm"]).notifyIcon1.BalloonTipText = "ساعت ورود شما: " + DateTime.Now.ToString("HH:mm:ss");
                    ((MainForm)System.Windows.Forms.Application.OpenForms["MainForm"]).notifyIcon1.Icon = SystemIcons.Information;
                    ((MainForm)System.Windows.Forms.Application.OpenForms["MainForm"]).notifyIcon1.ShowBalloonTip(1);
                }
                ((MainForm)System.Windows.Forms.Application.OpenForms["MainForm"])?.Show();
                Close();
            }
            else
                lblMessage.Text = "نام کاربری و یا رمز عبور اشتباه وارد شده است!";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (chbRemember.Checked)
            {
                Properties.Settings.Default.LoginUsername = txtUsername.Text;
                Properties.Settings.Default.LoginPassword = txtPassword.Text;
                Properties.Settings.Default.Save();
            }
            else
                Properties.Settings.Default.Reset();
        }

        #region ControllersFilter

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControllersFilter.Filter(e, false, true, false, true);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControllersFilter.Filter(e, true);
        }

        #endregion

        #region MoveForm

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm();
        }

        private void picLogo_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm();
        }

        private void lblUsername_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm();
        }

        private void lblPassword_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm();
        }

        private void lblMessage_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm();
        }

        #endregion
    }
}
