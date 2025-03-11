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
    /// Interaction logic for PartnerList.xaml
    /// </summary>
    public partial class PartnerList : Page
    {
        private MainWindow mainWindow;
        public PartnerList(MainWindow mainWindow, PartnerViewModel viewModel)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;

            DataContext = viewModel;
        }
    }
}
