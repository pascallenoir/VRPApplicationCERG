using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VRPApplicationCERG.Models
{
    public class VRP_RELATION_ETS
    {
       [JsonProperty("CODE_VRP")]
        public string CODE_VRP { get; set; }

        [JsonProperty("BANQUE_CODE_BCEAO")]
        public string BANQUE_CODE_BCEAO { get; set; }

        [JsonProperty("CODE_ORG")]
        public string CODE_ORG { get; set; }

        [JsonProperty("CODE_TYPE_RELATION")]
        public string CODE_TYPE_RELATION { get; set; }

        [JsonProperty("OBSERVATION_REL")]
        public string OBSERVATION_REL { get; set; }

        [JsonProperty("BANQUE_VRP")]
        public BANQUE_VRP BANQUE_VRP { get; set; }

        [JsonProperty("ORGAN_ETS_BANCAIRE")]
        public ORGAN_ETS_BANCAIRE ORGAN_ETS_BANCAIRE { get; set; }

        [JsonProperty("TYPE_RELATION_VRP")]
        public TYPE_RELATION_VRP TYPE_RELATION_VRP { get; set; }
    }
}
