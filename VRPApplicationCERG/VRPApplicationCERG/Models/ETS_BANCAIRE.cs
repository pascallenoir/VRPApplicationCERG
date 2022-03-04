using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VRPApplicationCERG.Models
{
    public class ETS_BANCAIRE
    {
       [JsonProperty("BANQUE_CODE_BCEAO")]
        public string BANQUE_CODE_BCEAO { get; set; }

        [JsonProperty("PAYS_CODE")]
        public string PAYS_CODE { get; set; }

        [JsonProperty("BANQUE_NOM")]
        public string BANQUE_NOM { get; set; }

        [JsonProperty("BANQUE_SIGLE")]
        public string BANQUE_SIGLE { get; set; }

        [JsonProperty("BANQUE_DATE_SUSP")]
        public string BANQUE_DATE_SUSP { get; set; }

        [JsonProperty("BANQUE_CLE_BCEAO")]
        public string BANQUE_CLE_BCEAO { get; set; }

        [JsonProperty("BANQUE_CODE_REMET")]
        public string BANQUE_CODE_REMET { get; set; }

        [JsonProperty("CODE_FORMULE")]
        public string CODE_FORMULE { get; set; }

        [JsonProperty("BANQUE_SDEVMT")]
        public string BANQUE_SDEVMT { get; set; }

        [JsonProperty("BANQUE_B_F")]
        public string BANQUE_B_F { get; set; }

        [JsonProperty("ETCIV_MATRICULE")]
        public string ETCIV_MATRICULE { get; set; }

        [JsonProperty("ORGAN_ETS_BANCAIRE")]
        public List<ORGAN_ETS_BANCAIRE> ORGAN_ETS_BANCAIRE { get; set; }
    }
}
