using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuKortV1.ViewModel
{
    public partial class OrdrePageViewModel : ObservableObject
    {

        public Entry ThisEntry { get; set; } = new Entry();

        [RelayCommand]
        void PostOrder()
        {

        }

    }
}
