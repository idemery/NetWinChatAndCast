using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecuredChat
{
    public interface ICastForm
    {
        idemery.Remoot.ClientHelper.Desktop DesktopRef { get; set; }
        string Text { get; set; }
        void Show();
        void Hide();
    }
}
