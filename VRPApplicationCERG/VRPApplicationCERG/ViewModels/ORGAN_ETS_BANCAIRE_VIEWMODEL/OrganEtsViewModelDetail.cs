using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using VRPApplicationCERG.ViewModels.FRAMEWORKMVVM;

namespace VRPApplicationCERG.ViewModels.ORGAN_ETS_BANCAIRE_VIEWMODEL
{
    class OrganEtsViewModelDetail : BaseViewModel
    { 

        //Declaration des variables 
        private string itemId;
        private string _banquecodebceao;
        private string _codeorg;
        private string _nom;
        private string _prenoms;
        private string _etcivmatricule;
        private string _email1;
        private string _email2;
        private string _tel1;
        private string _tel2;
        private string _adrespost1;
        private string _adrespost2;
        private string _adresgeo1;
        private string _adresgeo2;


        public string BANQUE_CODE_BCEAO
        {
            get => _banquecodebceao;
            set => SetProperty(ref _banquecodebceao, value);
        }


        public string CODE_ORG
        {
            get => _codeorg;
            set => SetProperty(ref _codeorg, value);
        }
        public string NOM
        {
            get => _nom;
            set => SetProperty(ref _nom, value);
        }


        public string PRENOMS
        {
            get => _prenoms;
            set => SetProperty(ref _prenoms, value);
        }
        public string ETCIV_MATRICULE
        {
            get => _etcivmatricule;
            set => SetProperty(ref _etcivmatricule, value);
        }


        public string E_MAIL1
        {
            get => _email1;
            set => SetProperty(ref _email1, value);
        }
        public string E_MAIL2
        {
            get => _email2;
            set => SetProperty(ref _email2, value);
        }


        public string TEL1
        {
            get => _tel1;
            set => SetProperty(ref _tel1, value);
        }
        public string TEL2
        {
            get => _tel2;
            set => SetProperty(ref _tel2, value);
        }


        public string ADR_POST1
        {
            get => _adrespost1;
            set => SetProperty(ref _adrespost1, value);
        }
        public string ADR_POST2
        {
            get => _adrespost2;
            set => SetProperty(ref _adrespost2, value);
        }


        public string ADR_GEO1
        {
            get => _adresgeo1;
            set => SetProperty(ref _adresgeo1, value);
        }
        public string ADR_GEO2
        {
            get => _adresgeo2;
            set => SetProperty(ref _adresgeo2, value);
        }

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

        /// <summary>
        /// Fonction de chargement des details d'un vrp
        /// </summary>
        /// <param name="itemId"></param>
        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await App.organEtsBancaireDataStore.GetItemAsync(itemId);

                BANQUE_CODE_BCEAO = item.BANQUE_CODE_BCEAO;
                CODE_ORG = item.CODE_ORG;
                NOM = item.NOM;
                PRENOMS = item.PRENOMS;
                ETCIV_MATRICULE = item.ETCIV_MATRICULE;
                E_MAIL1 = item.E_MAIL1;
                E_MAIL2 = item.E_MAIL2;
                TEL1 = item.TEL1;
                TEL2 = item.TEL2;
                ADR_POST1 = item.ADR_POST1;
                ADR_POST2 = item.ADR_POST2;
                ADR_GEO1 = item.ADR_GEO1;
                ADR_GEO2 = item.ADR_GEO2;
            }
            catch (Exception)
            {
                Debug.WriteLine("ProbLeme lors du chargement des informations");
            }
        }
    }
}