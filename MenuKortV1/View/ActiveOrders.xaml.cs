using MenuKortV1.ViewModel;

namespace MenuKortV1.View
{ 
	public partial class ActiveOrders : ContentPage
	{
		public ActiveOrders(ActiveOrdersViewModel vm)
		{
			InitializeComponent();
			BindingContext = vm;
		}
	}
}