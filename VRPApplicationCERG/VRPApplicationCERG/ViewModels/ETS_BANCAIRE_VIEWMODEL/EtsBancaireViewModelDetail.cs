using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Helpers.Validators;
using VRPApplicationCERG.Models;
using VRPApplicationCERG.ViewModels.FRAMEWORKMVVM;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VRPApplicationCERG.ViewModels.ETS_BANCAIRE_VIEWMODEL
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class EtsBancaireViewModelDetail : BaseViewModel
    {

        public Command CancelCommand { get; }
        public Command UpdateCommand { get; }

        //Declaration des variables 
        private string itemId;
        private string _banquecodebceao ;
        private string _payscode ;
        private string _banquenom;
        private string _banquesigle;
        private string _banquedatesusp;
        private string _banqueclebceao;
        private string _banquecoderemet;
        private string _codeformule;
        private string _banquesdevmt;
        private string _banquebf;
        private string _etcivmatricule;



        //Constructeur
        public EtsBancaireViewModelDetail()
        {
            Title = "Detail etablissement bancaire";
            // mettre a jour l'Item
            UpdateCommand = new Command(OnUpdateInfos);

        }

        public string BANQUE_CODE_BCEAO
        {
            get => _banquecodebceao;
            set => SetProperty(ref _banquecodebceao, value);
        }
        public string PAYS_CODE
        {
            get => _payscode;
            set => SetProperty(ref _payscode, value);
        }
        public string BANQUE_NOM
        {
            get => _banquenom;
            set => SetProperty(ref _banquenom, value);
        }
        public string BANQUE_SIGLE
        {
            get => _banquesigle;
            set => SetProperty(ref _banquesigle, value);
        }
        public string BANQUE_DATE_SUSP
        {
            get => _banquedatesusp;
            set => SetProperty(ref _banquedatesusp, value);
        }
        public string BANQUE_CLE_BCEAO
        {
            get => _banqueclebceao;
            set => SetProperty(ref _banqueclebceao, value);
        }
        public string BANQUE_CODE_REMET
        {
            get => _banquecoderemet;
            set => SetProperty(ref _banquecoderemet, value);
        }
        public string CODE_FORMULE
        {
            get => _codeformule;
            set => SetProperty(ref _codeformule, value);
        }
        public string BANQUE_SDEVMT
        {
            get => _banquesdevmt;
            set => SetProperty(ref _banquesdevmt, value);
        }
        public string BANQUE_B_F
        {
            get => _banquebf;
            set => SetProperty(ref _banquebf, value);
        }
        public string ETCIV_MATRICULE
        {
            get => _etcivmatricule;
            set => SetProperty(ref _etcivmatricule, value);
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
            /// Fonction de chargement des details d'une banque
            /// </summary>
            /// <param name="itemId"></param>
            public async void LoadItemId(string itemId)
            {
                try
                {
                    var item = await App.etsBancaireDataStore.GetItemAsync(itemId);

                    BANQUE_CODE_BCEAO = item.BANQUE_CODE_BCEAO;
                    PAYS_CODE = item.PAYS_CODE;
                    BANQUE_NOM = item.BANQUE_NOM;
                    BANQUE_SIGLE = item.BANQUE_SIGLE;
                    BANQUE_DATE_SUSP = item.BANQUE_DATE_SUSP;
                    BANQUE_CLE_BCEAO = item.BANQUE_CLE_BCEAO;
                    BANQUE_CODE_REMET = item.BANQUE_CODE_REMET;
                    CODE_FORMULE = item.CODE_FORMULE;
                    BANQUE_SDEVMT = item.BANQUE_SDEVMT;
                    BANQUE_B_F = item.BANQUE_B_F;
                    ETCIV_MATRICULE = item.ETCIV_MATRICULE;
                }
                catch (Exception)
                {
                    Debug.WriteLine("ProbLeme lors du chargement des informations");
                }
            }


            /// <summary>
            /// Fonction de Mise a jour des details d'un etablissement bancaire
            /// </summary>
            /// <param name="itemId"></param>
            /// 
            private async void OnUpdateInfos(object obj)
            {
                try
                {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous ne disposez pas d'une connexion internet stable pour effectuer cette action. Vérifiez votre connexion internet et réessayez !", TimeSpan.FromSeconds(5));
                    return;
                }

                bool isUserAccept = await Shell.Current.DisplayAlert("Vérification", "L'action que vous etes sur le point d'effectuer, éffectuera une mise à jour de vos informations. Souhaitez-vous réellement éffectuer cette Opération ?", "Oui", "Non");
                    if (isUserAccept)
                    {
                        bool _varupdate = false;

                        ETS_BANCAIRE newItem = new ETS_BANCAIRE()
                        {
                            BANQUE_CODE_BCEAO = BANQUE_CODE_BCEAO,
                            PAYS_CODE = PAYS_CODE,
                            BANQUE_NOM = BANQUE_NOM,
                            BANQUE_SIGLE = BANQUE_SIGLE,
                            BANQUE_DATE_SUSP = BANQUE_DATE_SUSP,
                            BANQUE_CLE_BCEAO = BANQUE_CLE_BCEAO,
                            BANQUE_CODE_REMET = BANQUE_CODE_REMET,
                            CODE_FORMULE = CODE_FORMULE,
                            BANQUE_SDEVMT = BANQUE_SDEVMT,
                            BANQUE_B_F = BANQUE_B_F,
                            ETCIV_MATRICULE = ETCIV_MATRICULE
                        };

                        await App.etsBancaireDataStore.SaveTodoItemAsync(newItem, _varupdate);

                        await Shell.Current.DisplayAlert("Message", "Informations enregistrées avec succès !", "d'accord");
                        // Autoriser la mise a jour de la page liste
                        MessagingCenter.Send<App>((App)Application.Current, "ActualiserListe");

                        //This will pop the current page off the navigation stack
                        await Shell.Current.GoToAsync("..");
                    }
                    else
                    {
                        // Message
                        await Shell.Current.DisplayAlert("Alerte", "Opération Annulée !", "Bien");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    await Shell.Current.DisplayAlert("Alerte", "Nous rencontrons un problème avec cette opération. Si le problème persite, contacter votre administrateur", "Bien");
                }
        }

    }
}

