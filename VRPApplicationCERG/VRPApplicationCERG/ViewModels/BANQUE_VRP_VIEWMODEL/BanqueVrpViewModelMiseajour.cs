using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Models;
using VRPApplicationCERG.ViewModels.FRAMEWORKMVVM;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VRPApplicationCERG.ViewModels.BANQUE_VRP_VIEWMODEL
{
   
        [QueryProperty(nameof(ItemId), nameof(ItemId))]
        public class BanqueVrpViewModelMiseajour : BaseViewModel
        {


            //Declaration des commandes
            public Command SaveCommand { get; }
            public Command CancelCommand { get; }

            //Declaration des variables 
            private string itemId;
            private string _codevrp;
            private string _nomvrp;
            private string _prenomvrp;
            private string _emailvrp;
            private string _tel1vrp;
            private string _tel2vrp;
            private string _adr1vrp;
            private string _adr2vrp;

            //Ajout du frmeworkMVVM sur  les elements de classe
            public string CODE_VRP
            {
                get => _codevrp;
                set => SetProperty(ref _codevrp, value);
            }


            public string NOM_VRP
            {
                get => _nomvrp;
                set => SetProperty(ref _nomvrp, value);
            }


            public string PRENOM_VRP
            {
                get => _prenomvrp;
                set => SetProperty(ref _prenomvrp, value);
            }

            public string E_MAIL_VRP
            {
                get => _emailvrp;
                set => SetProperty(ref _emailvrp, value);
            }


            public string TEL1_VRP
            {
                get => _tel1vrp;
                set => SetProperty(ref _tel1vrp, value);
            }


            public string TEL2_VRP
            {
                get => _tel2vrp;
                set => SetProperty(ref _tel2vrp, value);
            }

            public string ADR1_VRP
            {
                get => _adr1vrp;
                set => SetProperty(ref _adr1vrp, value);
            }

            public string ADR2_VRP
            {
                get => _adr2vrp;
                set => SetProperty(ref _adr2vrp, value);
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
            //////////////////////////////////////////


            //Constructeur
            public BanqueVrpViewModelMiseajour()
            {
                SaveCommand = new Command(OnSave);
                CancelCommand = new Command(OnCancel);
                this.PropertyChanged +=
                    (_, __) => SaveCommand.ChangeCanExecute();

            }



            /// <summary>
            /// Fonction de chargement des details sur un vrp
            /// </summary>
            /// <param name="itemId"></param>
            public async void LoadItemId(string itemId)
            {
                try
                {
                    var item = await App.BanqueDataStore.GetItemAsync(itemId);
                    NOM_VRP = item.NOM_VRP;
                    PRENOM_VRP = item.PRENOM_VRP;
                    E_MAIL_VRP = item.E_MAIL_VRP;
                    CODE_VRP = item.CODE_VRP;
                    TEL1_VRP = item.TEL1_VRP;
                    TEL2_VRP = item.TEL2_VRP;
                    ADR1_VRP = item.ADR1_VRP;
                    ADR2_VRP = item.ADR2_VRP;
                }
                catch (Exception)
                {
                    Debug.WriteLine("ProbLeme lors du chargement des informations");
                }
            }


            /// <summary>
            /// Fonction de retour a l'ecran precedent
            /// </summary>
            private async void OnCancel()
            {
                // This will pop the current page off the navigation stack
                await Shell.Current.GoToAsync("..");
            }


            /// <summary>
            ///Fonction de mise a jour pour un nouvel element dns Banque VRP
            /// </summary>
            private async void OnSave()
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

                    bool isUserAccept = await Shell.Current.DisplayAlert("Vérification", "L'action que vous etes sur le point d'effectuer, Ajoutera un nouvel élément dans votre liste. Souhaitez-vous réellement éffectuer cette Opération ?", "Oui", "Non");
                    if (isUserAccept)
                    {
                        bool _varadd = false;

                        BANQUE_VRP newItem = new BANQUE_VRP()
                        {
                            CODE_VRP = CODE_VRP.ToString(),
                            NOM_VRP = NOM_VRP.ToString(),
                            PRENOM_VRP = PRENOM_VRP.ToString(),
                            E_MAIL_VRP = E_MAIL_VRP.ToString(),
                            TEL1_VRP = TEL1_VRP.ToString(),
                            TEL2_VRP = TEL2_VRP.ToString(),
                            ADR1_VRP = ADR1_VRP.ToString(),
                            ADR2_VRP = ADR2_VRP.ToString()
                        };

                        await App.BanqueDataStore.SaveTodoItemAsync(newItem, _varadd);

                        await Shell.Current.DisplayAlert("Message", "Informations enregistrées avec succes !", "d'accord");
                        // Autoriser la mise a jour de la page liste
                        MessagingCenter.Send<App>((App)Application.Current, "ActualiserListe");

                        //This will pop the current page off the navigation stack

                        await Shell.Current.GoToAsync("../..");
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

