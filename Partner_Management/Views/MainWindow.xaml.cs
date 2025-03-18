using Partner_Management.Models;
using Partner_Management.ViewModels;
using Partner_Management.Views;
using System.Windows;

namespace Partner_Management;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public enum Pages
    {
        PartnerList,
        UpdatePartner,
        CreatePartner,
        PartnerSales,
        MaterialUsage
    }

    public MainWindow()
    {
        InitializeComponent();

        OpenPage(Pages.PartnerList);
    }

    public void OpenPage(Pages page)
    {
        if (page == Pages.PartnerList)
        {
            MainFrame.Navigate(new PartnerList(this, new PartnerViewModel()));
        }
        else if (page == Pages.CreatePartner)
        {
            MainFrame.Navigate(new CreatePartner(this, new PartnerViewModel()));
        }
        else if (page == Pages.PartnerSales)
        {
            MainFrame.Navigate(new PartnerSales(this, new PartnerViewModel()));
        }
        else if (page == Pages.MaterialUsage)
        {
            MainFrame.Navigate(new MaterialUsage(this, new PartnerViewModel()));
        }
    }

    public void OpenPage(Pages page, Partner partner)
    {
        if (page == Pages.UpdatePartner)
        {
            MainFrame.Navigate(new UpdatePartner(this, new PartnerViewModel(), partner));
        }
    }
}