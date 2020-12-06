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
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>

    public partial class DetailsWindow : Window
    {
        // Field: To be able to access the previous list window logic:
        public MainWindow mainWindow;

        // Ctor: Init details window:
        public DetailsWindow(MainWindow mw)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            mainWindow = mw;
            DataContext = mainWindow.personsVM;
        }

        // Event when clicking "View" button: Back to list view window and closing current window:
        private void Button_View_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.listWindow.Show();
            this.Hide();
        }

        // Event when closing current details window: Display main window and close listview window:
        private void DeatilsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try { mainWindow.Close(); }
            catch (Exception) {}
        }
    }
}
