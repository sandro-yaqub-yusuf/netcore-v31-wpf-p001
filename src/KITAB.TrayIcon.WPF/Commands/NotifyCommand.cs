using System.Windows.Forms;

namespace KITAB.TrayIcon.WPF.Commands
{
    public class NotifyCommand : BaseCommand
    {
        private readonly NotifyIcon _notifyIcon;

        public NotifyCommand(NotifyIcon notifyIcon)
        {
            _notifyIcon = notifyIcon;
        }

        public override void Execute(object parameter)
        {
            _notifyIcon.ShowBalloonTip(3000, "Situação", "O Robô iniciou o processamento...", ToolTipIcon.Info);
        }
    }
}
