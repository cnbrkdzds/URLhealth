using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace URLhealth.Entities.DTO
{
    public class UrlDTO
    {
        [JsonPropertyName("ID")]
        public int ID { get; set; }
        [JsonPropertyName("URL_LINK")]
        public string URL_LINK { get; set; }
        [JsonPropertyName("TIMER")]
        public int TIMER { get; set; }

        [JsonPropertyName("USER_ID")]
        public int USER_ID { get; set; }
        [JsonPropertyName("UserMail")]
        public string UserMail { get; set; }
        [JsonPropertyName("UserMail")]
        public DateTime? LastPingDate { get; set; }
        [JsonPropertyName("OldSituation")]
        public bool? OldSituation { get; set; }
    }
}
