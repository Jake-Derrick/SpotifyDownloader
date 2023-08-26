namespace SpotifyDownloader.Services.Spotify
{
    /// <summary>
    /// Connects to the Spotify API
    /// </summary>
    public interface ISpotifyService
    {
        /// <summary>
        /// Retrieves a list of songs in a Spotify playlist
        /// </summary>
        /// <param name="playlistId"></param>
        /// <returns></returns>
        Task<string> GetSpotifyPlaylist(string playlistId); // TODO: Make model for response
    }
}
