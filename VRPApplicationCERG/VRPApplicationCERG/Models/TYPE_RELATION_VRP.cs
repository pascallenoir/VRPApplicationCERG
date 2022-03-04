using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VRPApplicationCERG.Models
{
    public class TYPE_RELATION_VRP
    {
       [JsonProperty("CODE_TYPE_RELATION")]
        public string CODE_TYPE_RELATION { get; set; }

        [JsonProperty("LIBELLE_RELATION")]
        public string LIBELLE_RELATION { get; set; }

        [JsonProperty("VRP_RELATION_ETS")]
        public List<VRP_RELATION_ETS> VRP_RELATION_ETS { get; set; }

    }
}
