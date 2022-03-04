using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VRPApplicationCERG.Models
{
    public class USER_MESSAGE_DATA
    {
        [JsonProperty("MessageId")]
        public string MESSAGEID{ get; set; }

        [JsonProperty("Content")]
        public string CORPSDUMESSAGE { get; set; }

        [JsonProperty("IsRead")]
        public bool IsRead { get; set; }

        [JsonProperty("IsBound")]
        public bool IsInbound { get; set; }

        [JsonProperty("Timestamp")]
        public string DATEDERECEPION { get; set; }

        [JsonProperty("FromUser")]
        public UTILISATEURVRPCERGI FROM { get; set; }

    }
}
