using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace VRPApplicationCERG.Constants
{
    public static class Constants
    {
        // URL of REST service
        //public static string RestUrl = "https://YOURPROJECT.azurewebsites.net:8081/api/todoitems/{0}";

        // URL of REST service (Android does not use localhost)
        // Use http cleartext for local deployment. Change to https for production

        // Utile pouir la gestion du cache de l'application
        public static string ApplicationNameCache = "CergiVRPCache";

        /// <summary>
        /// authentification
        /// </summary>
        /// 
        public static string RestUrlLoginUser = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:60876/Token" : "http://localhost:60876/Token";
        public static string RestUrlInscriptionUser = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/60876/api/Account/Register" : "http://localhost:60876/api/Account/Register";


        #region
        //recuperer la liste des elements des tables a partir de ces URL
        public static string RestUrlBanqueVRPListe = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Banquevrp/GetAllBanquevrp" : "http://Localhost/vrpPUB/Api/Banquevrp/GetAllBanquevrp";
        public static string RestUrlBanqueVRPAccueilListe = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Vrprelationets/GetAllVrprelation" : "http://Localhost/vrpPUB/Api/Vrprelationets/GetAllVrprelation";
        public static string RestUrEtsBancaireListe = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Etsbancaire/GetAllEtsbancaire" : "http://Localhost/vrpPUB/Api/Etsbancaire/GetAllEtsbancaire";
        public static string RestUrOrganigrammeListe = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Organigramme/GetAllOganigramme" : "http://Localhost/vrpPUB/Api/Organigramme/GetAllOganigramme";
        public static string RestUrTypeRelationListe = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Typerelationvrp/GetTyprelavrp" : "http://Localhost/vrpPUB/Api/Typerelationvrp/GetTyprelavrp";
        public static string RestUrVRPRelationListe = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Vrprelationets/GetAllVrprelation" : "http://Localhost/vrpPUB/Api/Vrprelationets/GetAllVrprelation";
        public static string RestUrOrganEtsBncireListe = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Organetsbancaire/GetAllOganetsbancaire" : "http://Localhost/vrpPUB/Api/Organetsbancaire/GetAllOganetsbancaire";
        public static string RestUrlBanqueVRPAccueilListeParvrp = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Vrprelationets/GetVrprelationDetail?" : "http://Localhost/vrpPUB/Api/Vrprelationets/GetVrprelationDetail?";
        public static string RestUrletsBancaireByvrp = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/api/Vrprelationets/GetVrpIntervBank?codeVrp=" : "http://localhost/vrpPUB/api/Vrprelationets/GetVrpIntervBank?codeVrp=";
        public static string RestUrlPaysListe = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/api/Paysvrp/GetPaysvrp" : "http://localhost/vrpPUB/api/Paysvrp/GetPaysvrp";
        public static string RestUrlBanqueParPaysListe = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/api/Etsbancaire/GetBankByCountry?payscode=" : "http://localhost/vrpPUB/api/Etsbancaire/GetBankByCountry?payscode=";
        public static string RestUrlVrpParPaysEtBanque = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/api/Banquevrp/Get?banqueCode=" : "http://localhost/vrpPUB/api/Banquevrp/Get?banqueCode=";
        public static string RestUrlPaysDetailID = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/api/Paysvrp/GetPaysvrpDetail/" : "http://localhost/vrpPUB/api/Paysvrp/GetPaysvrpDetail/";
        #endregion

        #region
        //Enregistrer des elements dans les tables a partir de ces URL
        public static string RestUrlBanqueVRPSave = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Banquevrp/bANQUE_VRP" : "http://Localhost/vrpPUB/api/Banquevrp/bANQUE_VRP";
        public static string RestUrlBanqueVRPAccueilSave = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Vrprelationets/PostNewVrprelationets" : "http://Localhost/vrpPUB/Api/Vrprelationets/PostNewVrprelationets";
        public static string RestUrEtsBancaireSave = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Etsbancaire/etsbancaire" : "http://Localhost/vrpPUB/Api/Etsbancaire/etsbancaire";
        public static string RestUrOrganigrammeSave = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Organigramme/organigramme" : "http://Localhost/vrpPUB/Api/Organigramme/organigramme";
        public static string RestUrTypeRelationSave = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Typerelationvrp/typerelationets" : "http://Localhost/vrpPUB/Api/Typerelationvrp/typerelationets";
        public static string RestUrVRPRelationSave = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Vrprelationets/PostNewVrprelationets" : "http://Localhost/vrpPUB/Api/Vrprelationets/PostNewVrprelationets";
        public static string RestUrOrganEtsBncireSave = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Organetsbancaire/organetsban" : "http://Localhost/vrpPUB/Api/Organetsbancaire/organetsban";
        public static string RestUrlPaysNationalSave = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Paysvrp/pAYS_NATIONAL" : "http://Localhost/vrpPUB/Api/Paysvrp/pAYS_NATIONAL";
        #endregion

        #region
        //Mettre a jour des elements dans les tables a partir de ces URL
        public static string RestUrlBanqueVRPPut = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Banquevrp/bANQUE_VRP" : "http://Localhost/vrpPUB/Api/Banquevrp/bANQUE_VRP";
        public static string RestUrlBanqueVRPAccueilPut = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Vrprelationets/Put" : "http://Localhost/vrpPUB/Api/Vrprelationets/Put";
        public static string RestUrEtsBancairePut = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Etsbancaire/etsbancaire" : "http://Localhost/vrpPUB/Api/Etsbancaire/etsbancaire";
        public static string RestUrOrganigrammePut = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Organigramme/organigramme" : "http://Localhost/vrpPUB/Api/Organigramme/organigramme";
        public static string RestUrTypeRelationPut = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Typerelationvrp/typerelationets" : "http://Localhost/vrpPUB/Api/Typerelationvrp/typerelationets";
        public static string RestUrVRPRelationPut = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Vrprelationets/Put" : "http://Localhost/vrpPUB/Api/Vrprelationets/Put";
        public static string RestUrOrganEtsBncirePut = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Organetsbancaire/organetsban" : "http://Localhost/vrpPUB/Api/Organetsbancaire/organetsban";
        public static string RestUrlPaysNationalPut = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Paysvrp/pAYS_NATIONAL" : "http://Localhost/vrpPUB/Api/Paysvrp/pAYS_NATIONAL";

        #endregion

        #region
        //Supprimer tous les elements des tables a partir de ces URL
        public static string RestUrlBanqueVRPDelete = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Banquevrp" : "http://Localhost/vrpPUB/Api/Banquevrp";
        public static string RestUrlBanqueVRPAccueilDelete = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Vrprelationets" : "http://Localhost/vrpPUB/Api/Vrprelationets";
        public static string RestUrEtsBancaireDelete = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Etsbancaire" : "http://Localhost/vrpPUB/Api/Etsbancaire";
        public static string RestUrOrganigrammeDelete = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Organigramme" : "http://Localhost/vrpPUB/Api/Organigramme";
        public static string RestUrTypeRelationDelete = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Typerelationvrp	" : "http://Localhost/vrpPUB/Api/Typerelationvrp	";
        public static string RestUrVRPRelationDelete = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Vrprelationets" : "http://Localhost/vrpPUB/Api/Vrprelationets";
        public static string RestUrOrganEtsBncireDelete = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Organetsbancaire" : "http://Localhost/vrpPUB/Api/Organetsbancaire";
        #endregion

        #region
        //recuperer les details d'un element de la table a partir de ces URL
        public static string RestUrlBanqueVRPDetail = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Banquevrp/GetBanquevrpDetail/" : "http://Localhost/vrpPUB/Api/Banquevrp/GetBanquevrpDetail/";
        public static string RestUrlBanqueVRPAccueilDetail = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Vrprelationets/GetVrprelationDetail/{id}" : "http://Localhost/vrpPUB/Api/Vrprelationets/GetVrprelationDetail/{id}";
        public static string RestUrEtsBancaireDetail = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Etsbancaire/GetEtsbancaireDetail/" : "http://Localhost/vrpPUB/Api/Etsbancaire/GetEtsbancaireDetail/";
        public static string RestUrOrganigrammeDetail = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Organigramme/GetAllOgangramWithETSBanc/" : "http://Localhost/vrpPUB/Api/Organigramme/GetAllOgangramWithETSBanc/";
        public static string RestUrTypeRelationDetail = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Typerelationvrp/GetTyprelavrpDetail/" : "http://Localhost/vrpPUB/Api/Typerelationvrp/GetTyprelavrpDetail/";
        public static string RestUrVRPRelationDetail = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Vrprelationets/GetVrprelationDetail/" : "http://Localhost/vrpPUB/Api/Vrprelationets/GetVrprelationDetail/";
        public static string RestUrOrganEtsBncireDetail = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Organetsbancaire/GetOganestbancaireDetail/{id}" : "http://Localhost/vrpPUB/Api/Organetsbancaire/GetOganestbancaireDetail/{id}";
        #endregion

        #region
        //Supprimer un element d'une table partir de ces URL
        public static string RestUrlBanqueVRPDeleteID = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Banquevrp/Delete?CODE_VRP=" : "http://Localhost/vrpPUB/Api/Banquevrp/Delete?CODE_VRP=";
        public static string RestUrlBanqueVRPAccueilDeleteID = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Vrprelationets" : "http://Localhost/vrpPUB/Api/Vrprelationets";
        public static string RestUrEtsBancaireDeleteID = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Etsbancaire" : "http://Localhost/vrpPUB/Api/Etsbancaire";
        public static string RestUrOrganigrammeDeleteID = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Organigramme" : "http://Localhost/vrpPUB/Api/Organigramme";
        public static string RestUrTypeRelationDeleteID = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Typerelationvrp	" : "http://Localhost/vrpPUB/Api/Typerelationvrp	";
        public static string RestUrVRPRelationDeleteID = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Vrprelationets" : "http://Localhost/vrpPUB/Api/Vrprelationets";
        public static string RestUrOrganEtsBncireDeleteID = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Organetsbancaire" : "http://Localhost/vrpPUB/Api/Organetsbancaire";
        public static string RestUrlPaysNationalDeleteID = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.69/vrpPUB/Api/Paysvrp/Delete?PAYS_CODE=" : "http://Localhost/vrpPUB/Api/Paysvrp/Delete?PAYS_CODE=";
        #endregion
    }
}
