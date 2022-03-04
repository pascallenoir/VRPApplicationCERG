using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VRPApplicationCERG.Models
{
    public class BANQUE_VRP
    {
        [JsonProperty("CODE_VRP")]
        public string CODE_VRP { get; set; }

        [JsonProperty("NOM_VRP")]
        public string NOM_VRP { get; set; }

        [JsonProperty("PRENOM_VRP")]
        public string PRENOM_VRP { get; set; }

        [JsonProperty("E_MAIL_VRP")]
        public string E_MAIL_VRP { get; set; }

        [JsonProperty("TEL1_VRP")]
        public string TEL1_VRP { get; set; }

        [JsonProperty("TEL2_VRP")]
        public string TEL2_VRP { get; set; }

        [JsonProperty("ADR1_VRP")]
        public string ADR1_VRP { get; set; }

        [JsonProperty("ADR2_VRP")]
        public string ADR2_VRP { get; set; }

        [JsonProperty("VRP_RELATION_ETS")]
        public List<VRP_RELATION_ETS> VRP_RELATION_ETS { get; set; }
    }
}
