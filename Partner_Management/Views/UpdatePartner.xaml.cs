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


        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.PartnerList);
        }
    }
}
