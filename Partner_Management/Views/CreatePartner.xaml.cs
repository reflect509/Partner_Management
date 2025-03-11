using Partner_Management.Models;
using Partner_Management.ViewModels;
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

namespace Partner_Management.Views
{
    /// <summary>
    /// Interaction logic for CreatePartner.xaml
    /// </summary>
    public partial class CreatePartner : Page
    {
        private MainWindow mainWindow;

        public CreatePartner(MainWindow mainWindow, PartnerViewModel partnerViewModel)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            DataContext = partnerViewModel;

            PartnerTypeComboBox.SelectedItem = "Введите тип партнера";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.PartnerList);
        }

        private void AddPartner(object sender, RoutedEventArgs e)
        {
            var rating = Decimal.Parse(RatingTextBox.Text);
            if (rating < 0)
            {
                MessageBox.Show("Рейтинг не может быть отрицательным");
                return;
            }
            Partner partner = new Partner
            {
                PartnerName = PartnerNameTextBox.Text,
                PartnerType = DatabaseControl.GetPartnerId(PartnerTypeComboBox.SelectedItem.ToString()),
                CeoName = CEONameTextBox.Text,
                PartnerAddress = AddressTextBox.Text,
                PartnerEmail = EmailTextBox.Text,
                PartnerPhone = PhoneTextBox.Text,
                Rating = rating
            };

            DatabaseControl.AddPartner(partner);
            MessageBox.Show("Партнер добавлен успешно");
        }
    }
}
