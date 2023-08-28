using SpotifyDownloader.Views.MainPage;

namespace SpotifyDownloader
{
	public partial class MainPage : ContentPage
	{
		public MainPage(MainPageVM viewModel)
		{
			InitializeComponent();
			BindingContext = viewModel;
		}
	}
}


