using ProjectManagement.Win.Tools;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectManagement.Win
{
    public partial class GuideForm : Form
    {
        public GuideForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            var box = sender as GroupBox;
            DrawGroupBox.Draw(box, e.Graphics, Color.Black, Color.DarkGray, this);
        }
    }
}
