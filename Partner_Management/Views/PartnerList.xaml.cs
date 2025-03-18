using Partner_Management.Models;
using Partner_Management.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Partner_Management.Views
{
    /// <summary>
    /// Interaction logic for PartnerList.xaml
    /// </summary>
    public partial class PartnerList : Page
    {
        private MainWindow mainWindow;
        public PartnerList(MainWindow mainWindow, PartnerViewModel viewModel)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            mainWindow.Title = "Список партнеров";

            DataContext = viewModel;
        }

        private void UpdatePartner_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Partner partner = (Partner)PartnerListBox.SelectedItem;
            mainWindow.OpenPage(MainWindow.Pages.UpdatePartner, partner);
        }

        private void CreatePartner_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.CreatePartner);
        }

        private void PartnerSales_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.PartnerSales);
        }

        private void MaterialUsage_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.MaterialUsage);
        }
    }
}
