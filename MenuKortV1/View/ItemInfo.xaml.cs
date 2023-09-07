using MenuKortV1.ViewModel;

namespace MenuKortV1.View
{
	public partial class ItemInfo : ContentPage
	{
		public ItemInfo(ItemInfoViewModel vm2)
		{
            InitializeComponent();
            BindingContext = vm2;
        }
	}
}