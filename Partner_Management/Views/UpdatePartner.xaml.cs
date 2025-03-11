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
            Partner partner = new Partner
            {
                PartnerId = this.partner.PartnerId,
                PartnerName = PartnerNameTextBox.Text,
                PartnerType = DatabaseControl.GetPartnerId(PartnerTypeComboBox.SelectedItem.ToString()),
                CeoName = CEONameTextBox.Text,
                PartnerAddress = AddressTextBox.Text,
                PartnerEmail = EmailTextBox.Text,
                PartnerPhone = PhoneTextBox.Text,
                Rating = Decimal.Parse(RatingTextBox.Text)
            };

            DatabaseControl.UpdatePartner(partner);
        }
    }
}
