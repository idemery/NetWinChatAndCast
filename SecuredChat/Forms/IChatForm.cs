using System;
using System.Windows.Forms;

namespace SecuredChat
{
    public interface IChatForm
    {
        string ClientName { get; set; }
        string Password { get; set; }
        string HostAddress { get; set; }
        bool Connected { get; set; }
        ListBox ClientsListBox { get; }
        RichTextBox TextBox { get; }
        ICastForm CastForm { get; }
        void Status(string text);

        object Invoke(Delegate method);
        object Invoke(Delegate method, params object[] args);

        void Notify(string tipTitle, string tipText);
    }
}
