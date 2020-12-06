using ProgKornyWPFbeadando.Models;
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

namespace ProgKornyWPFbeadando.Views
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
     
    public partial class ListWindow : Window
    {
        // Field: To be able to access the main window logic:
        public MainWindow mainWindow;

        // Ctor: Init list window:
        public ListWindow(MainWindow mw)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            mainWindow = mw;
            DataContext = mainWindow.personsVM;
        }

        // Event when clicking "Add" button: Close this current window and show the main window:
        private void Button_BackToAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            mainWindow.Show();
        }

        // Event when clicking "Delete" button: delete the selected persons from the list:
        private void Button_Delete_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(textBlock_SelectedId.Text);
                Person toDelete = mainWindow.personsVM.ObjPersonService.GetPersonById(id);
                mainWindow.personsVM.ObjPersonService.Delete(toDelete);
                mainWindow.personsVM.loadPeople();
            }
            catch (Exception) {}
        }

        // Event when closing this current window: close main window:
        private void ListWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try { mainWindow.Close(); }
            catch (Exception) {}
        }

        // Event: View Details of person with given id: 
        private void Button_Details_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(textBlock_SelectedId.Text);
                Person toView = mainWindow.personsVM.ObjPersonService.GetPersonById(id);

                mainWindow.personsVM.SelectedPerson.Id = toView.Id;
                mainWindow.personsVM.SelectedPerson.Name = toView.Name;
                mainWindow.personsVM.SelectedPerson.Email = toView.Email;
                mainWindow.personsVM.SelectedPerson.Mobile = toView.Mobile;
                mainWindow.personsVM.SelectedPerson.City = toView.City;

                this.Hide();
                mainWindow.detailsWindow.Show();
            }
            catch (Exception) {}
        }
    }
}
