using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyDownloader.Services.Spotify
{
    public static class Endpoints
    {
        private static string BaseUrl => "https://api.spotify.com/v1";

        public static string GetPlaylistItems(string id) => $"{BaseUrl}/playlists/{id}/tracks";

        public static string Token => "https://accounts.spotify.com/api/token";
    }
}
