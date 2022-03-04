using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VRPApplicationCERG.Models
{
    public class NOTIFICATIONS
    {
        [JsonProperty("TITRE")]
        public string TITRE{ get; set; }

        [JsonProperty("DESCRIPTION")]
        public string DESCRIPTION { get; set; }

        //public NotificationType Type { get; set; }
    }
}
