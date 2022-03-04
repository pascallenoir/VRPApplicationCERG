using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using VRPApplicationCERG.ViewModels.FRAMEWORKMVVM;
using Xamarin.Forms;

namespace VRPApplicationCERG.ViewModels.VRP_RELATION_ETS_VIEWMODEL
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class VrpRelationEtsViewModelDetail : BaseViewModel
    {

        //Declaration des variables 
        private string itemId;
        private string _code_vrp;
        private string _banque_code_bceao;
        private string _code_org;
        private string _code_type_relation;
        private string _observation_rel;


        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public string CODE_VRP
        {
            get { return _code_vrp; }
            set { SetProperty(ref _code_vrp, value); }
        }

        public string BANQUE_CODE_BCEAO
        {
            get { return _banque_code_bceao; }
            set { SetProperty(ref _banque_code_bceao, value); }
        }


        public string CODE_ORG
        {
            get { return _code_org; }
            set { SetProperty(ref _code_org, value); }
        }


        public string CODE_TYPE_RELATION
        {
            get { return _code_type_relation; }
            set { SetProperty(ref _code_type_relation, value); }
        }


        public string OBSERVATION_REL
        {
            get { return _observation_rel; }
            set { SetProperty(ref _observation_rel, value); }
        }


        /// <summary>
        /// Fonction de chargement des details d'un vrp
        /// </summary>
        /// <param name="itemId"></param>
        public async void LoadItemId(string itemId)
        {
            try
            {
                //var item = await VrpRelationEtsDataStore.GetItemAsync(itemId);
                //NOM_VRP = item.NOM_VRP;
                //PRENOM_VRP = item.PRENOM_VRP;
                //E_MAIL_VRP = item.E_MAIL_VRP;
                //CODE_VRP = item.CODE_VRP;
                //TEL1_VRP = item.TEL1_VRP;
                //TEL2_VRP = item.TEL2_VRP;
                //ADR1_VRP = item.ADR1_VRP;
                //ADR2_VRP = item.ADR2_VRP;
            }
            catch (Exception)
            {
                Debug.WriteLine("ProbLeme lors du chargement des informations");
            }
        }

    }
}
