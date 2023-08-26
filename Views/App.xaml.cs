using SpotifyDownloader.Services.Spotify;

namespace SpotifyDownloader;

public partial class App : Application
{
	public App(ISpotifyService spotifyService)
	{
		InitializeComponent();

		MainPage = new NavigationPage(new MainPage(spotifyService));
	}
}
