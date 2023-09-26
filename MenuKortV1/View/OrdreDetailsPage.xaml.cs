using MenuKortV1.ViewModel;

namespace MenuKortV1.View
{
	public partial class OrdreDetailsPage : ContentPage
	{
		public OrdreDetailsPage(OrdreDetailsViewModel vm)
		{
            InitializeComponent();
			BindingContext = vm;
		}
	}
}