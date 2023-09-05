using MenuKortV1.ViewModel;

namespace MenuKortV1.View
{
	public partial class MenuItemPage : ContentPage
	{
		public MenuItemPage(MenuItemViewModel vm1)
		{
			InitializeComponent();
			BindingContext = vm1;
		}
	}
}