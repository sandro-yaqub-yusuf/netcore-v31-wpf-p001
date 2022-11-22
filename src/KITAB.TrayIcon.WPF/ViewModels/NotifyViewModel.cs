using System.Windows.Forms;
using System.Windows.Input;
using KITAB.TrayIcon.WPF.Commands;

namespace KITAB.TrayIcon.WPF.ViewModels
{
    public class NotifyViewModel : ViewModelBase
    {
        public ICommand NotifyCommand { get; }

        public NotifyViewModel(NotifyIcon notifyIcon)
        {
            NotifyCommand = new NotifyCommand(notifyIcon);
        }
    }
}
