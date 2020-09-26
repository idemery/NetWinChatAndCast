using idemery.Remoot.ClientHelper;
using SecuredChat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace idemery.Remoot.Forms
{
    public partial class FormCast : Form, ICastForm
    {
        public FormCast()
        {
            InitializeComponent();
        }

        public Desktop DesktopRef { get { return this.Desktop; } set { this.Desktop = value; } }

        private void FormCast_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
