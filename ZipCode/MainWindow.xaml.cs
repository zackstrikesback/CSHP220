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
using System.Text.RegularExpressions;

namespace ZipCode
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

        private bool isCanadian(string s)
        {
            string z = "([A-Z])([0-9])([A-Z])([0-9])([A-Z])([0-9])";
            return Regex.IsMatch(s, z);
        }
        
        private bool isAmerican(string s)
        {
            string z = @"^\d{5}(?:[-\s]\d{4})?$";
            return Regex.IsMatch(s, z);
        }

        private void uxZip_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isCanadian(uxZip.Text) && uxZip.Text.Length == 6)
            {
                uxSubmit.IsEnabled = true;
            }
            else if (isAmerican(uxZip.Text))
            {
                uxSubmit.IsEnabled = true;
            }
            else
            {
                uxSubmit.IsEnabled = false;
            }
        }
    }
}
