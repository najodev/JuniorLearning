using System;
using System.Text.Json.Serialization;

namespace WebAPIClient
{
    public class Repository

    {
        /// <summary> 
        /// Name of the repository
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary> 
        /// Desciption of the repository
        /// </summary>
        [JsonPropertyName("description")]
        public string Description 
        {
            get; set;
        }
        /// <summary> 
        /// Url of repository
        /// </summary>
        [JsonPropertyName("html_url")]
        public Uri GitHubHomeUrl 
        {
            get; set;
        }
        /// <summary> 
        /// Homepage of the repository
        /// </summary>
        [JsonPropertyName("homepage")]
        public Uri Homepage
        {
            get; set;
        }
        /// <summary> 
        /// Watchers of th repository
        /// </summary>
        [JsonPropertyName("watchers")] 
            public int Watchers
            {
                get; set;
            }
        /// <summary> 
        /// Last Push of the repository in Local Time 
        /// </summary>
        [JsonPropertyName("pushed_at")]
        public DateTime LastPushUtc { get; set; }
        public DateTime LastPush => LastPushUtc.ToLocalTime();

    }
}
