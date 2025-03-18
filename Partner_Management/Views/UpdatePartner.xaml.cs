using Partner_Management.Models;
using Partner_Management.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Partner_Management.Views
{
    /// <summary>
    /// Interaction logic for UpdatePartner.xaml
    /// </summary>
    public partial class UpdatePartner : Page
    {
        private MainWindow mainWindow;
        private Partner partner;

        public UpdatePartner(MainWindow mainWindow, PartnerViewModel partnerViewModel, Partner partner)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            mainWindow.Title = "Изменение данных партнера";
            this.partner = partner;
            DataContext = partnerViewModel;

            PartnerNameTextBox.Text = partner.PartnerName;
            PartnerTypeComboBox.SelectedItem = partner.PartnerTypeNavigation.PartnerTypeName;
            CEONameTextBox.Text = partner.CeoName;
            AddressTextBox.Text = partner.PartnerAddress;
            EmailTextBox.Text = partner.PartnerEmail;
            PhoneTextBox.Text = partner.PartnerPhone;
            RatingTextBox.Text = partner.Rating.ToString();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.PartnerList);
        }

        private void EditPartner(object sender, RoutedEventArgs e)
        {
            var ratingCorrect = Decimal.TryParse(RatingTextBox.Text, out decimal rating);

            if (!ratingCorrect)
            {
                MessageBox.Show("Рейтинг введен неправильно");
                return;
            }

            if (rating < 0 || rating > 10)
            {
                MessageBox.Show("Рейтинг находится от 0 до 10");
                return;
            }

            if (PartnerNameTextBox.Text == "" || CEONameTextBox.Text == "" || AddressTextBox.Text == "" || EmailTextBox.Text == "" || PhoneTextBox.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            Partner partner = new Partner
            {
                PartnerId = this.partner.PartnerId,
                PartnerName = PartnerNameTextBox.Text,
                PartnerType = DatabaseControl.GetPartnerId(PartnerTypeComboBox.SelectedItem.ToString()),
                CeoName = CEONameTextBox.Text,
                PartnerAddress = AddressTextBox.Text,
                PartnerEmail = EmailTextBox.Text,
                PartnerPhone = PhoneTextBox.Text,
                Rating = rating
            };

            DatabaseControl.UpdatePartner(partner);
        }
    }
}
