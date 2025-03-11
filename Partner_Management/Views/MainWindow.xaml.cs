using Partner_Management.Models;
using Partner_Management.ViewModels;
using Partner_Management.Views;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        CreatePartner
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
    }

    public void OpenPage(Pages page, Partner partner)
    {
        if (page == Pages.UpdatePartner)
        {
            MainFrame.Navigate(new UpdatePartner(this, new PartnerViewModel(), partner));
        }
    }
}