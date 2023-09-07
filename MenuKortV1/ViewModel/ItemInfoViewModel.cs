using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuKortV1.ViewModel
{
    [QueryProperty("MenuItem", "SelectedMenuItem")]
    public partial class ItemInfoViewModel : ObservableObject
    {
        [ObservableProperty]
        MenuItem menuItem;
    }
}
