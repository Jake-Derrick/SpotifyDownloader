using System.Text.Json.Serialization;

namespace SpotifyDownloader.Models.Spotify
{
    /// <summary>
    /// The response from Spotify Playlist Items endpoint
    /// </summary>
    public class PlaylistItemsResponse
    {
        [JsonPropertyName("items")]
        public List<PlayListItem> Playlist { get; set; }

        /// <summary>
        /// The maximum number of items in the response
        /// </summary>
        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// The offset of items
        /// </summary>
        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// The total number of items
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }

        /// <summary>
        /// URL to the next page of items
        /// </summary>
        [JsonPropertyName("next")]
        public string Next { get; set; }
    }

    public class PlayListItem
    {
        [JsonPropertyName("track")]
        public Track Track { get; set; }
    }

    public class Track
    {
        [JsonPropertyName("artists")]
        public List<Artist> Artists { get; set; }

        [JsonPropertyName("duration_ms")]
        public int DurationMs { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Artist
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
