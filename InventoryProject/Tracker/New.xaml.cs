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
using System.Windows.Shapes;
using Tracker.Models;
using System.Text.RegularExpressions;

namespace Tracker
{
    /// <summary>
    /// Interaction logic for New.xaml
    /// </summary>
    public partial class New : Window
    {
        public New()
        {
            InitializeComponent();
            ShowInTaskbar = false;
        }
        
        // for update use code to update the radio buttons and the date
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Tracker != null)
            {
                if (Tracker.Type == "Show")
                {
                    uxShow.IsChecked = true;
                }
                else
                {
                    uxBook.IsChecked = true;
                }
                uxSubmit.Content = "Update";
            }
            else
            {
                Tracker = new TrackerModel();
            }

            uxGrid.DataContext = Tracker;
        } // end of updating the radio buttons

        public TrackerModel Tracker { get; set; }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Tracker = new TrackerModel();

            //Tracker.Name = uxName.Text;
            //Tracker.Genre = uxGenre.Text;

            if (uxShow.IsChecked.Value)
            {
                Tracker.Type = "Show";
            }
            else
            {
                Tracker.Type = "Book";
            }

            //Tracker.Current = Int32.Parse(uxCurrent.Text);
            //Tracker.Total = Int32.Parse(uxTotal.Text);

            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
