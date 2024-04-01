using System.Windows.Forms;

namespace ProjectManagement.Win.Tools
{
    public class ControllersFilter
    {
        public static void Filter(KeyPressEventArgs e, bool canNumber = false, bool canLetters = false,
            bool canFarsi = false, bool canEnglish = false)
        {
            if (canNumber)
            {
                if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar)))
                    e.Handled = true;
            }

            if (canLetters)
            {
                if (char.IsDigit(e.KeyChar))
                    e.Handled = true;
            }

            if (canFarsi)
            {
                if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= '0' && e.KeyChar <= '9'))
                    e.Handled = true;
            }

            if (canEnglish)
            {
                if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'آ' && e.KeyChar <= 'ی'))
                    e.Handled = true;
            }
        }
    }
}
