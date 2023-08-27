using AndroidX.Lifecycle;
using SpotifyDownloader.Extensions;
using SpotifyDownloader.Models.Spotify;
using SpotifyDownloader.Services.Spotify;
using System.ComponentModel;

namespace SpotifyDownloader;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    new public event PropertyChangedEventHandler PropertyChanged;

    private string PlaylistId;
	private string _errorMessage = "";
    public string ErrorMessage
    {
        get => _errorMessage;
        set
        {
            if (_errorMessage != value)
            {
				_errorMessage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ErrorMessage)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HasError)));
            }
        }
    }
    public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

    private ISpotifyService _spotifyService;
    public MainPage(ISpotifyService spotifyService)
	{
		InitializeComponent();
		BindingContext = this;
		_spotifyService = spotifyService;
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		await _spotifyService.GetSpotifyPlaylist("5Vq4MAzpvm4w8S5fjK3vUk");
	}

	private async void OnSyncButtonClicked(object sender, EventArgs e)
    {
        if (!playlistLink.Text.IsValidPlaylistUrl())
		{
			ErrorMessage = "Not a valid playlist Url";
			return;
		}

		PlaylistId = playlistLink.Text.ToPlaylistId();
		try
		{
			// TODO: ShowLoading
			var response = await _spotifyService.GetSpotifyPlaylist(PlaylistId);

		}
		catch (NotFoundException)
		{
			ErrorMessage = "Playlist was not found. Validate the url is correct and the playlist is set to Public";
		}
		catch
		{
			ErrorMessage = "We ran into an issue connecting to Spotify. Please try again";
		}
		finally
		{
			// TODO: HideLoading
		}
    }

}

