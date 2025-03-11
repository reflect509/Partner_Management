﻿using Partner_Management.Models;
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
using System.Collections.ObjectModel;

namespace Partner_Management.Views
{
    /// <summary>
    /// Interaction logic for PartnerSales.xaml
    /// </summary>
    public partial class PartnerSales : Page
    {
        private MainWindow mainWindow;

        public PartnerSales(MainWindow mainWindow, PartnerViewModel partnerViewModel)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;            
            DataContext = partnerViewModel;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.PartnerList);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var partner = DatabaseControl.GetPartnerByName(PartnerNameComboBox.SelectedItem.ToString());

            if (partner == null)
            {
                MessageBox.Show("Партнер не найден");
                return;
            }

            var partnerSales = DatabaseControl.GetPartnerProducts(partner.PartnerId);
            PartnerViewModel partnerViewModel = (PartnerViewModel)DataContext;
            partnerViewModel.PartnerSales = new ObservableCollection<PartnerProduct>(partnerSales);
        }
    }
}
