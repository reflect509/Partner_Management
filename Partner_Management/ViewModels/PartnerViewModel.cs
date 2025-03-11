using Partner_Management.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
