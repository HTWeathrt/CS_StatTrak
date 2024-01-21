using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using Path = System.IO.Path;
using Window = System.Windows.Window;
using Newtonsoft.Json;

namespace CS_StatTrak
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

        private void openfilelocation(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog nex = new FolderBrowserDialog();
            DialogResult result = nex.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(nex.SelectedPath))
            {
                string selecfolder = nex.SelectedPath;
                textbox_folderimage.Text = selecfolder;
            }
        }
        private void openfilerecipe(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult)
            {
                return;
            }
            textbox_folderimage_Copy.Text = openFileDialog.FileName;

        }
        List<Tablelist> list = new List<Tablelist>();
        private void loadingimagefolder(object sender, RoutedEventArgs e)
        {
            string Forder = textbox_folderimage.Text;
            string NameImage = nameimage.Text;
            DirectoryInfo ParentVP2Dir = new DirectoryInfo(Forder);
            DirectoryInfo[] subVP2Dic = ParentVP2Dir.GetDirectories();
            foreach (DirectoryInfo sub in subVP2Dic)
            {
                list.Add(new Tablelist(sub.Name, sub.FullName, NameImage));
            }
            tableloading.ItemsSource = list;

        }
  
        private void transparen(object sender, RoutedEventArgs e)
        {
            try
            {
               
                TcpClient client = new TcpClient("127.0.0.1", 8080);
                StreamWriter writer = new StreamWriter(client.GetStream(), Encoding.UTF8);
                string jsondata = JsonConvert.SerializeObject(list);
                string adobe = "Hehe";

                writer.WriteLine(adobe);
                writer.Flush();
                writer.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        private void connectiontest(object sender, RoutedEventArgs e)
        {
            
                
            
        }
    }




    
}
