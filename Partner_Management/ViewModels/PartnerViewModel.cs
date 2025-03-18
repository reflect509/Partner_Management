using Partner_Management.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Partner_Management.ViewModels
{
    public class PartnerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<Partner> partners = new ObservableCollection<Partner>();

        public ObservableCollection<Partner> Partners
        {
            get { return partners; }
            set
            {
                partners = value;
                OnPropertyChanged(nameof(Partners));
            }
        }

        private ObservableCollection<string> partnerTypes = new ObservableCollection<string>();

        public ObservableCollection<string> PartnerTypes
        {
            get { return partnerTypes; }
            set
            {
                partnerTypes = value;
                OnPropertyChanged(nameof(PartnerTypes));
            }
        }

        private ObservableCollection<PartnerProduct> partnerSales = new ObservableCollection<PartnerProduct>();

        public ObservableCollection<PartnerProduct> PartnerSales
        {
            get { return partnerSales; }
            set
            {
                partnerSales = value;
                OnPropertyChanged(nameof(PartnerSales));
            }
        }

        private ObservableCollection<string> partnerNames;

        public ObservableCollection<string> PartnerNames
        {
            get { return partnerNames; }
            set
            {
                partnerNames = value;
                OnPropertyChanged(nameof(PartnerNames));
            }
        }

        private ObservableCollection<MaterialType> materialTypes;

        public ObservableCollection<MaterialType> MaterialTypes
        {
            get { return materialTypes; }
            set
            {
                materialTypes = value;
                OnPropertyChanged(nameof(MaterialTypes));
            }
        }

        private ObservableCollection<ProductType> productTypes;

        public ObservableCollection<ProductType> ProductTypes
        {
            get { return productTypes; }
            set
            {
                productTypes = value;
                OnPropertyChanged(nameof(ProductTypes));
            }
        }




        public PartnerViewModel()
        {
            LoadPartners();
        }

        private void LoadPartners()
        {
            DatabaseControl.GetDiscountForPartner();
            var partners = DatabaseControl.GetPartners();
            Partners = new ObservableCollection<Partner>(partners);
            PartnerTypes = new ObservableCollection<string>(partners.Select(p => p.PartnerTypeNavigation.PartnerTypeName).Distinct().ToList());
            PartnerNames = new ObservableCollection<string>(partners.Select(p => p.PartnerName).Distinct().ToList());
            MaterialTypes = new ObservableCollection<MaterialType>(DatabaseControl.GetMaterialTypes());
            ProductTypes = new ObservableCollection<ProductType>(DatabaseControl.GetProductTypes());
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
