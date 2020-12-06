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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProgKornyWPFbeadando.ViewModels;
using ProgKornyWPFbeadando.Views;

namespace ProgKornyWPFbeadando
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        // Fields:
        #region Fields
        public ListWindow listWindow;
        public DetailsWindow detailsWindow;
        public PersonsViewModel personsVM;
    #endregion

        // Ctor: Init the three windows:
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            personsVM = new PersonsViewModel();
            listWindow = new ListWindow(this);
            detailsWindow = new DetailsWindow(this);
            DataContext = personsVM;
        }

        // Event when clicking "Add" button: Add a new person or display error message:
        private void Button_Add_Click(object sender, RoutedEventArgs e) {}

        // Event when clicking "View" button: Load the list view window and hide current window:
        private void Button_View_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            listWindow.Show();
        }

        // Event when closing this window: Close all other windows as well:
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try { listWindow.Close(); }
            catch (Exception) {}
            try { detailsWindow.Close(); }
            catch (Exception) {}
        }
    }
}
