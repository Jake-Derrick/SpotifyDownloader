using SpotifyDownloader.Services.Spotify;

namespace SpotifyDownloader;

public partial class MainPage : ContentPage
{
	private ISpotifyService _spotifyService;

	public MainPage(ISpotifyService spotifyService)
	{
		InitializeComponent();
		_spotifyService = spotifyService;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{

		_spotifyService.GetSpotifyPlaylist("");

	}
}

