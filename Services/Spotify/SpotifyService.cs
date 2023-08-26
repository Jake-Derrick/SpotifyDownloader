using SpotifyDownloader.Models.Spotify;
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


        public async Task<string> GetSpotifyPlaylist(string playlistId)
        {
            await Authorize();
            throw new NotImplementedException();
        }

        internal async Task Authorize()
        {
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
