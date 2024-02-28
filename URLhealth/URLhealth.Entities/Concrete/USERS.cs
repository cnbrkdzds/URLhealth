using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using URLhealth.Core.Entities;

namespace URLhealth.Entities.Concrete
{
    public class USERS:IEntity
    {
        [JsonPropertyName("ID")]
        public int ID { get; set; }
        [JsonPropertyName("MAIL")]
        public string MAIL { get; set; }

        //public virtual List<URL> Url { get; set; }
    }
}
