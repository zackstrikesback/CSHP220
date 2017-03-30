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
using System.Data.Entity;
using Tracker.Models;
using System.ComponentModel;

namespace Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GridViewColumnHeader listViewSortCol = null;

        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            var trackers = App.TrackerRepository.GetAll();

            uxList.ItemsSource = trackers
                .Select(t => TrackerModel.ToModel(t))
                .ToList();
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new New();

            if (window.ShowDialog() == true)
            {
                var uiTrackerModel = window.Tracker;

                var repositoryTrackerModel = uiTrackerModel.ToRepositoryModel();

                App.TrackerRepository.Add(repositoryTrackerModel);

                // OR
                //App.ContactRepository.Add(window.Contact.ToRepositoryModel());
                Load();
            }
        }

        private TrackerModel selectedTracking;

        private void uxContextFileDelete_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show(selectedTracking.Name + " will be deleted. Are you sure you want to delete?", "Delete?", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                App.TrackerRepository.Remove(selectedTracking.Id);
                selectedTracking = null;
                Load();
            }
        }

        private void uxContextFileChange_Click(object sender, RoutedEventArgs e)
        {
            var window = new New();
            window.Tracker = selectedTracking;

            if (window.ShowDialog() == true)
            {
                App.TrackerRepository.Update(window.Tracker.ToRepositoryModel());
                Load();
            }
        }

        private void uxList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTracking = (TrackerModel)uxList.SelectedValue;
            if (selectedTracking != null)
            {
                uxProgressBar.Visibility = Visibility.Visible;
                uxProgressBar.Maximum = selectedTracking.Total;
                uxProgressBar.Value = selectedTracking.Current;
                uxStatus.Text = selectedTracking.Current + "/" + selectedTracking.Total;
            }
            else
            {
                uxProgressBar.Visibility = Visibility.Hidden;
            }
        }

        private void uxContextFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxContextFileDelete.IsEnabled = (selectedTracking != null);
        }

        private void uxContextFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxContextFileChange.IsEnabled = (selectedTracking != null);
        }

        private void uxList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var window = new New();
            window.Tracker = selectedTracking;

            if (window.ShowDialog() == true)
            {
                App.TrackerRepository.Update(window.Tracker.ToRepositoryModel());
                Load();
            }
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                uxList.Items.SortDescriptions.Clear();
            }
            listViewSortCol = column;
            uxList.Items.SortDescriptions.Add(new SortDescription(sortBy, ListSortDirection.Ascending));
            uxList.Items.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
        }

        private void uxFileQuit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Quit?", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                App.Current.Shutdown();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            TrackerModel a = b.CommandParameter as TrackerModel;
            if(a.Current < a.Total)
            {
                int c = a.Current + 1;
                a.Current = c;
                App.TrackerRepository.Update(a.ToRepositoryModel());
                Load();
            }
        }
    }
}
