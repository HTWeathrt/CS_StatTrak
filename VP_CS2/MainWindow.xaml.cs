using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Reflection.Emit;
using MessageBox = System.Windows.MessageBox;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections;

namespace VP_CS2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("LGDVH_AlgoInspection_Tech.dll")]
        public static extern void ProcessImage(string image,int x,int y ,int width,int height, out int result);

        public MainWindow()
        {
            InitializeComponent();
            StartServer(); ;
        }
        private TcpListener tcpListener;
        private TcpClient tcpClient;
        private void StartServer()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 8080);
                tcpListener.Start();
                Task.Run(() => ListenForData());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        private async Task ListenForData()
        {
            try
            {
                while (true)
                {
                    tcpClient = await tcpListener.AcceptTcpClientAsync();
                    NetworkStream reader = tcpClient.GetStream();
                    byte[] buffer = new byte[8080];
                    int bytesRead =await reader.ReadAsync(buffer,0,buffer.Length);
                    string jsondata = Encoding.UTF8.GetString(buffer,0,bytesRead);
                    

                    List<Tablelist> list = JsonConvert.DeserializeObject<List<Tablelist>>(jsondata);
                    foreach (var tablelist in list)
                    {
                        string adbx = System.IO.Path.Combine(tablelist.Patch, tablelist.NameImage);
                        MessageBox.Show(adbx);
                    }
                    reader.Close();
                    tcpClient.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           /* Stopwatch sw = new Stopwatch();
            sw.Start();
            int brightness;
            int x = Convert.ToInt32(tbox_x.Text);
            int y = Convert.ToInt32(tbox_y.Text);
            int width = Convert.ToInt32(tbox_width.Text);
            int height = Convert.ToInt32(tbox_height.Text);
            ProcessImage("D:\\huy\\P2E6390K15A1475151C6_B01.bmp", x,y,width,height, out brightness);*/
            //labeldata.Text = brightness.ToString();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
