using SpotifyDownloader.Models.Spotify;
using System.Net.Http.Headers;
using System.Text.Json;

namespace SpotifyDownloader.Services.Spotify
{
    /// <summary>
    /// 
    /// </summary>
    public class SpotifyService : ISpotifyService
    {
        private string AccessToken;
        private DateTime TokenExpiration;
        private readonly HttpClient _httpClient;

        public SpotifyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<PlayListItem>> GetSpotifyPlaylist(string playlistId)
        {
            await RefreshAccessTokenIfNeeded();

            var request = new HttpRequestMessage(HttpMethod.Get, Endpoints.GetPlaylistItems(playlistId));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

            var response = await _httpClient.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();

            // TODO iterate to other pages
            var playlistResponse = JsonSerializer.Deserialize<PlaylistItemsResponse>(json);
            return playlistResponse.Playlist;
        }

        /// <summary>
        /// Gets an access token if
        /// </summary>
        /// <returns></returns>
        internal async Task RefreshAccessTokenIfNeeded()
        {
         
            if (DateTime.Now < TokenExpiration)
                return;

            var content = new Dictionary<string, string>
            {
                { "client_id", Secrets.ClientId },
                { "client_secret", Secrets.ClientSecret },
                { "grant_type", "client_credentials" }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, Endpoints.Token)
            {
                Content = new FormUrlEncodedContent(content)
            };

            var response = await _httpClient.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(json);
                AccessToken = tokenResponse.AccessToken;
                // Setting a minute early to avoid requests getting unauthorized last second
                TokenExpiration = DateTime.Now.AddSeconds(tokenResponse.ExpiresIn - 60);
            }
            else
            {
                // TODO: Handle bad status
            }
        }
    }
}
