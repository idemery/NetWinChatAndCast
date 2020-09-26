using DarkUI.Config;
using System.Windows.Forms;

namespace DarkUI.Controls
{
    public class DarkRichTextBox : RichTextBox
    {
        #region Constructor Region

        public DarkRichTextBox()
        {
            BackColor = Colors.LightBackground;
            ForeColor = Colors.LightText;
            Padding = new Padding(2, 2, 2, 2);
            BorderStyle = BorderStyle.FixedSingle;
        }

        #endregion
    }
}
