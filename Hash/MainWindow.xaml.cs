using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Security.Cryptography;
using System.IO;
using Microsoft.Win32;

namespace Hash
{
    public partial class MainWindow : Window
    {
        string fileName = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                fileName = dialog.FileName;
                lblFileName.Content = fileName;
            }
        }

        private async void btnCompute_Click(object sender, RoutedEventArgs e)
        {
            HashAlgorithm h = MD5.Create();

            switch (((ComboBoxItem)cboHashAlg.SelectedItem).Content.ToString())
            {
                case "MD5":
                    h = MD5.Create();
                    break;
                case "SHA1":
                    h = SHA1.Create();
                    break;
                case "SHA384":
                    h = SHA384.Create();
                    break;
                case "SHA256":
                    h = SHA256.Create();
                    break;
                case "SHA512":
                    h = SHA512.Create();
                    break;
                default:
                    break;
            }
            if (!File.Exists(fileName))
                return;
            using (FileStream f = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var t = Task.Run(() => h.ComputeHash(f));

                byte[] result = await t;

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    sb.Append(result[i].ToString("X2"));
                    if (i % 4 == 3)
                    {
                        sb.Append(" ");
                    }
                }
                txtHashResult.Text = sb.ToString();
            }
        }
    }
}
