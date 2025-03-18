using Partner_Management.Models;
using Partner_Management.ViewModels;
using System.Windows;
using System.Windows.Controls;

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
            mainWindow.Title = "Добавление партнера";
            DataContext = partnerViewModel;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.PartnerList);
        }

        private void AddPartner(object sender, RoutedEventArgs e)
        {
            var ratingCorrect = Decimal.TryParse(RatingTextBox.Text, out decimal rating);

            if (!ratingCorrect)
            {
                MessageBox.Show("Рейтинг введен неправильно");
                return;
            }

            if (PartnerTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберет тип партнера");
                return;
            }

            if (rating < 0 || rating > 10)
            {
                MessageBox.Show("Рейтинг находится от 0 до 10");
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

        private void CEONameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CEONameTextBox.Text == "Введите директора")
            {
                CEONameTextBox.Text = "";
            }
        }

        private void CEONameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CEONameTextBox.Text == "")
            {
                CEONameTextBox.Text = "Введите директора";
            }
        }

        private void PartnerNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PartnerNameTextBox.Text == "Введите название партнера")
            {
                PartnerNameTextBox.Text = "";
            }

        }

        private void PartnerNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PartnerNameTextBox.Text == "")
            {
                PartnerNameTextBox.Text = "Введите название партнера";
            }
        }

        private void PhoneTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PhoneTextBox.Text == "Введите номер телефона(10 цифр)")
            {
                PhoneTextBox.Text = "";
            }
        }

        private void PhoneTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PhoneTextBox.Text == "")
            {
                PhoneTextBox.Text = "Введите номер телефона(10 цифр)";
            }
        }

        private void EmailTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (EmailTextBox.Text == "Введите email")
            {
                EmailTextBox.Text = "";
            }
        }

        private void EmailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (EmailTextBox.Text == "")
            {
                EmailTextBox.Text = "Введите email";
            }
        }

        private void RatingTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (RatingTextBox.Text == "Введите рейтинг")
            {
                RatingTextBox.Text = "";
            }
        }

        private void RatingTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (RatingTextBox.Text == "")
            {
                RatingTextBox.Text = "Введите рейтинг";
            }
        }

        private void AddressTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (AddressTextBox.Text == "Введите адрес")
            {
                AddressTextBox.Text = "";
            }
        }

        private void AddressTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (AddressTextBox.Text == "")
            {
                AddressTextBox.Text = "Введите адрес";
            }
        }
    }
}
