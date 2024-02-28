using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using URLhealth.Core.Entities;

namespace URLhealth.Entities.Concrete
{
    public class URL:IEntity
    {
        [JsonPropertyName("ID")]
        public int ID { get; set; }
        [JsonPropertyName("URL_LINK")]
        public string URL_LINK { get; set; }
        [JsonPropertyName("TIMER")]
        public int TIMER { get; set; }

        [JsonPropertyName("USER_ID")]
        public int USER_ID { get; set; }

        //[JsonPropertyName("LAST_REQUEST_DATE")]
        //public DateTime LAST_REQUEST_DATE { get; set; }
        //public virtual USERS? Users { get; set; }
    }
}
