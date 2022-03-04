using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VRPApplicationCERG.Models
{
    public class ORGANIGRAMME
    {
        [JsonProperty("CODE_ORG")]
        public string CODE_ORG { get; set; }

        [JsonProperty("LIBELLE")]
        public string LIBELLE { get; set; }

        [JsonProperty("NIVEAU")]
        public string NIVEAU { get; set; }

        [JsonProperty("HIERARCHIE")]
        public string HIERARCHIE { get; set; }

        [JsonProperty("ORGAN_ETS_BANCAIRE")]
        public List<ORGAN_ETS_BANCAIRE> ORGAN_ETS_BANCAIRE { get; set; }


    }
}
