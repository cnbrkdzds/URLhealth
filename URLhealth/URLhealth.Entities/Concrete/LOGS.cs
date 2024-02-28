using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using URLhealth.Core.Entities;

namespace URLhealth.Entities.Concrete
{
    public class LOGS:IEntity
    {
        [JsonPropertyName("ID")]
        public long ID { get; set; }
        [JsonPropertyName("LEVEL")]
        public string LEVEL { get; set; }
        [JsonPropertyName("URL")]
        public string URL { get; set; }
        [JsonPropertyName("MESSAGE")]
        public string MESSAGE { get; set; }
        [JsonPropertyName("CREATED_DATE")]
        public DateTime CREATED_DATE { get; set; }

        private static LOGS _instance;

        public static LOGS GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LOGS();
            }
            return _instance;
        }
    }
}
