using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyDownloader.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Validates we can extract a playlistId from a playlistUrl
        /// </summary>
        /// <param name="playlistUrl"></param>
        /// <returns></returns>
        public static bool IsValidPlaylistUrl(this string playlistUrl)
        {
            var playlistIndex = playlistUrl.IndexOf("playlist/");
            var r =  playlistIndex != -1 && playlistIndex < playlistUrl.Length;
            return r;
        }

        /// <summary>
        /// Extracts the playlistId form a playlistUrl
        /// </summary>
        /// <param name="playlistUrl"></param>
        /// <returns></returns>
        public static string ToPlaylistId(this string playlistUrl)
        {
            // There are two url formats that I'm aware of.
            // Copied from the browser: playlist/{id}
            // Copied from the share button: playlist/{id}?si={sessionId}

            // Trim the extra stuff off the share button url
            var url = playlistUrl.Split('?').First();

            return url.Substring(url.LastIndexOf("/") + 1);
        }
    }
}
