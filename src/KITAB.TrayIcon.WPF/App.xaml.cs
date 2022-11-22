using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows;
using KITAB.TrayIcon.WPF.ViewModels;
using Forms = System.Windows.Forms;

namespace KITAB.TrayIcon.WPF
{
    public partial class App : Application
    {
        private readonly Forms.NotifyIcon _notifyIcon;

        public App()
        {
            _notifyIcon = new Forms.NotifyIcon();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

            _notifyIcon.Icon = new Icon("icon.ico");
            _notifyIcon.Text = "KITAB.TrayIcon.WPF";
            _notifyIcon.Click += NotifyIcon_Click;
            _notifyIcon.BalloonTipClicked += NotifyIcon_BalloonTipClicked;
            _notifyIcon.Visible = true;

            _notifyIcon.ContextMenuStrip = new Forms.ContextMenuStrip();

            _notifyIcon.ContextMenuStrip.Items.Add("Situação", Image.FromFile("icon.ico"), OnStatusClicked);

            MainWindow = new MainWindow();

            MainWindow.DataContext = new NotifyViewModel(_notifyIcon);
            MainWindow.Title = "KITAB.TrayIcon.WPF";
            MainWindow.ShowInTaskbar = false;

            MainWindow.Show();

            base.OnStartup(e);
        }

        private void NotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            // MessageBox.Show("O Robô foi inicializado...", "Situação", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnStatusClicked(object sender, EventArgs e)
        {
            MessageBox.Show("O Robô foi inicializado...", "Situação", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            MainWindow.WindowState = WindowState.Normal;

            MainWindow.Activate();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _notifyIcon.Dispose();

            base.OnExit(e);
        }
    }
}
