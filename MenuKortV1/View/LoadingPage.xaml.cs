using MenuKortV1.ViewModel;

namespace MenuKortV1.View
{
	public partial class LoadingPage : ContentPage
	{
		public LoadingPage(LoadingViewModel vm)
		{
			InitializeComponent();
			BindingContext = vm;
		}
	}
}