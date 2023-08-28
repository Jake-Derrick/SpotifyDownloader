using SpotifyDownloader.Models.Spotify;

namespace SpotifyDownloader.Services.Spotify
{
    /// <summary>
    /// Connects to the Spotify API
    /// </summary>
    public interface ISpotifyService
    {
        /// <summary>
        /// Retrieves a list of Tracks in a Spotify playlist
        /// </summary>
        /// <param name="playlistId"></param>
        /// <returns></returns>
        Task<List<PlayListItem>> GetSpotifyPlaylist(string playlistId);
    }
}
