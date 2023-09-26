using MenuKortV1.ViewModel;

namespace MenuKortV1.View
{
	public partial class OrdrePage : ContentPage
	{
		public OrdrePage(OrdrePageViewModel vm)
		{
			InitializeComponent();
			BindingContext = vm;
		}
	}
}