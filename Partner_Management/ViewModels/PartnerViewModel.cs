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

        public PartnerViewModel()
        {
            LoadProducts();
        }

        private void LoadProducts()
        {   
            Partners = new ObservableCollection<Partner>(DatabaseControl.GetPartners());
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
