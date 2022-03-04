using System;
using System.Collections.Generic;
using System.Text;

namespace VRPApplicationCERG.Models
{
    /// <summary>
    /// Classe a afficher sur l'ecran d'accueil de l'application
    /// permet d'avoir une vue d'ensemble sur les VRP de l'application ainsi que leurs relations
    /// </summary>
    public class JOINTABLESCLASS
    {
        public string CODE_VRP { get; set; }
        public string NOM_VRP { get; set; }
        public string BANQUE_CODE_VRP { get; set; }
        public string BANQUE_NOM { get; set; }
    }
}
