﻿using System.Text.Json.Serialization;

namespace SpotifyDownloader.Models.Spotify
{
    /// <summary>
    /// The response from Spotify Token endpoint
    /// </summary>
    public class TokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
