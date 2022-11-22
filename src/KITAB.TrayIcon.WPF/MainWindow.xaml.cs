using System;
using System.Windows;
using System.Windows.Threading;

namespace KITAB.TrayIcon.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += timer_Tick;
        }

        private void btIniciar_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();

            icMessage.Items.Add("Iniciando o processamento...");

            btIniciar.IsEnabled = false;
            btParar.IsEnabled = true;
        }

        private void btParar_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();

            icMessage.Items.Add("Finalizando o processamento...");

            MessageBox.Show("O Robô foi finalizado...", "Situação", MessageBoxButton.OK, MessageBoxImage.Information);

            btIniciar.IsEnabled = true;
            btParar.IsEnabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            icMessage.Items.Add("Processando... Hora: " + DateTime.Now.ToLongTimeString() + "...");
        }
    }
}
