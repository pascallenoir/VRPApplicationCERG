using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VRPApplicationCERG.Models
{
    public class UTILISATEURVRPCERGI
    {
        [JsonProperty("Id")]
        public string ID_USER_VRP { get; set; }

        [JsonProperty("Nom_Utilisateur")]
        public string NOM_USER_VRP { get; set; }

        [JsonProperty("Prenom_Utilisateur")]
        public string PRENOM_USER_VRP { get; set; }

        [JsonProperty("Email")]
        public string E_MAIL_USER_VRP { get; set; }

        [JsonProperty("Statut_Utilisateur")]
        public string STATUT_USER_VRP { get; set; }

        [JsonProperty("UserName")]
        public string USERNAME_USER_VRP { get; set; }

        [JsonProperty("Password")]
        public string MOTDEPASSE_USER_VRP { get; set; }

        [JsonProperty("ConfirmPassword")]
        public string CONFIRM_MOTDEPASSE_USER_VRP { get; set; }

        [JsonProperty("Photo_Utilisateur")]
        public string PHOTO_USER_VRP { get; set; }

       
    }
}
