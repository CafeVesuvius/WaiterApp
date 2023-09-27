using MenuKortV1.ViewModel;

namespace MenuKortV1.View
{ 
	public partial class MenusPage : ContentPage
	{
		public MenusPage(MenusViewModel vm)
		{
			InitializeComponent();
			BindingContext = vm;
		}
	}
}