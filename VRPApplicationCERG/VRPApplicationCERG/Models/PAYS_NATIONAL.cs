using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VRPApplicationCERG.Models
{
    public class PAYS_NATIONAL
    {
        [JsonProperty("PAYS_CODE")]
        public string PAYS_CODE { get; set; }

        [JsonProperty("PAYS_NOM")]
        public string PAYS_NOM { get; set; }

    }
}
