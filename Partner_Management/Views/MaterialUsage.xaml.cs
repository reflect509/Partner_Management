using Partner_Management.Models;
using Partner_Management.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Partner_Management.Views
{
    /// <summary>
    /// Interaction logic for MaterialUsage.xaml
    /// </summary>
    public partial class MaterialUsage : Page
    {
        private MainWindow mainWindow;
        private PartnerViewModel partnerViewModel;

        public MaterialUsage(MainWindow mainWindow, PartnerViewModel partnerViewModel)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            this.partnerViewModel = partnerViewModel;
            DataContext = partnerViewModel;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.PartnerList);
        }

        private void CalculateMaterial_Click(object sender, RoutedEventArgs e)
        {
            var lengthCorrect = decimal.TryParse(LengthTextBox.Text, out decimal length);
            var widthCorrect = decimal.TryParse(WidthTextBox.Text, out decimal width);
            var quantityCorrect = int.TryParse(QuantityTextBox.Text, out int quantity);

            if (!lengthCorrect ||
                !widthCorrect ||
                !quantityCorrect)
            {
                MessageBox.Show("Данные введены неправильно");
                return;
            }

            decimal productTypeCoefficient;
            decimal materialBrokeRate;

            if (ProductTypeNameComboBox.SelectedItem == null ||
                MaterialTypeNameComboBox.SelectedItem == null)
            {
                productTypeCoefficient = -1;
                materialBrokeRate = -1;
            }
            else
            {
                productTypeCoefficient = ((ProductType)ProductTypeNameComboBox.SelectedItem).TypeCoefficient;
                materialBrokeRate = ((MaterialType)MaterialTypeNameComboBox.SelectedItem).BrokenCoefficient;
            }

            var res = CalculateMaterialUsage(
                productTypeCoefficient,
                materialBrokeRate,
                quantity,
                length,
                width);
            MessageBox.Show($"Количество материала равно: {res}");
        }

        public int CalculateMaterialUsage(
            decimal productCoefficient,
            decimal materialBrokeCoefficient,
            int quantity,
            decimal length,
            decimal width
            )
        {
            if (quantity <= 0)
            {
                return -1;
            }
            if (length <= 0 || width <= 0)
            {
                return -1;
            }

            if (productCoefficient == -1 || materialBrokeCoefficient == -1)
            {
                return -1;
            }

            int materialUsage = (int)Math.Ceiling((quantity * (length * width * productCoefficient) * (materialBrokeCoefficient + 1)));

            return materialUsage;
        }
    }
}
