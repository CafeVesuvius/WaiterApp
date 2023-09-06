using MenuKortV1.ViewModel;

namespace MenuKortV1.View
{
	public partial class ItemDetailsPage : ContentPage
	{
		public ItemDetailsPage(ItemDetailsPage vm2)
		{
			InitializeComponent();
			BindingContext = vm2;
		}
	}
}