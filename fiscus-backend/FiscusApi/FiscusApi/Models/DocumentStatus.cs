using System.Text.Json.Serialization;

namespace FiscusApi.Models
{
    public class DocumentStatus
    {
        [JsonPropertyName("Id")]
        public int DocumentStatus_Id { get; set; }

        [JsonPropertyName("Description")]
        public string DocumentStatus_Description { get; set; }
    }
}
