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

using Opc.UaFx.Client;

namespace C__OPC_UA_Client
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

        private void WriteButton_Click(object sender, RoutedEventArgs e)
        {
            OpcClient client = new("opc.tcp://localhost:62640/");
            client.Connect();

            client.WriteNode("ns=2;s=Tag1", Convert.ToDouble(write_textbox.Text));

            client.Disconnect();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            OpcClient client = new("opc.tcp://localhost:62640/");
            client.Connect();

            read_textbox.Text = client.ReadNode("ns=2;s=Tag1").ToString();

            client.Disconnect();
        }
    }
}