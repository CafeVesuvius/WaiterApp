using MenuKortV1.ViewModel;

namespace MenuKortV1.View
{
	public partial class OrdrePage : ContentPage
	{
		public OrdrePage(OrdreViewModel vm)
		{
			InitializeComponent();
			BindingContext = vm;
		}
	}
}