using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ariketa1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private Process procesoFTP;
        private void lanzar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                procesoFTP = new Process();
                procesoFTP.StartInfo.FileName = "ftp.exe";
                procesoFTP.Start();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error al iniciar el proceso: " + ex.Message);
            }
        }

        private void matar_Click(object sender, RoutedEventArgs e)
        {
            if(procesoFTP != null)
            {
                procesoFTP.Kill();
                label.Content = "Processo FTP eliminado";
                procesoFTP = null;
            }
            else
            {
                label.Content = "No hay procesos FTP activos";
            }
        }

        private void mostrar_Click(object sender, RoutedEventArgs e)
        {
            combo.Items.Clear();
            Process[] procesos = Process.GetProcesses();
            foreach(Process p in procesos)
            {
                combo.Items.Add(p.ProcessName);
            }
        }
    }
}