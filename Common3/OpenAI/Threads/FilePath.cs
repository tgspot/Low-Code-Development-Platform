using Newtonsoft.Json;

namespace OpenAI.Threads
{
    public sealed class FilePath
    {
        /// <summary>
        /// The ID of the file that was generated.
        /// </summary>
        
        [JsonProperty("file_id")]
        public string FileId { get; private set; }
    }
}