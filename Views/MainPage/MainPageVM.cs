using Microsoft.Maui.Platform;
using SpotifyDownloader.Extensions;
using SpotifyDownloader.Models.Spotify;
using SpotifyDownloader.Services.Spotify;
using System.Windows.Input;

namespace SpotifyDownloader.Views.MainPage
{
    public class MainPageVM : BaseViewModel
    {
        private string _playlistUrl;
        public string PlaylistUrl
        {
            get => _playlistUrl;
            set
            {
                _playlistUrl = value;
            }
        }
        private string PlaylistId;

        private ISpotifyService _spotifyService;
        public ICommand GetPlaylistCommand { get; protected set; }
        public MainPageVM(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
            GetPlaylistCommand = new Command(async () => await GetPlaylist());
        }


        private async Task GetPlaylist()
        {
            ErrorMessage = "";

            if (!PlaylistUrl.IsValidPlaylistUrl())
            {
                ErrorMessage = "Not a valid playlist Url";
                return;
            }

            PlaylistId = PlaylistUrl.ToPlaylistId();
            try
            {
                ShowLoading = true;
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
                ShowLoading = false;
                // TODO: HideLoading
            }
        }
    }
}
