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

namespace VRPApplicationCERG.ViewModels.ORGANIGRAMME_VIEWMODEL
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class OrganigrammeViewModelDetail : BaseViewModel
    {
        //Declaration des commandes 
        public Command CancelCommand { get; }
        public Command SaveCommand { get; }


        //Declaration des variables 
        private string itemId;
        private string _codeorg;
        private string _libelle;
        private string _niveau;
        private string _hierarchie;


        public string CODE_ORG
        {
            get => _codeorg;
            set => SetProperty(ref _codeorg, value);
        }
        public string LIBELLE
        {
            get => _libelle;
            set => SetProperty(ref _libelle, value);
        }
        public string NIVEAU
        {
            get => _niveau;
            set => SetProperty(ref _niveau, value);
        }
        public string HIERARCHIE
        {
            get => _hierarchie;
            set => SetProperty(ref _hierarchie, value);
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

        //Constructeur
        public OrganigrammeViewModelDetail()
        {
            // mettre a jour l'Item
            SaveCommand = new Command(OnUpdateItem);

            // fermer le pop up
            CancelCommand = new Command(OnCancel);

        }

        /// <summary>
        /// Fonction de chargement des details d'un vrp
        /// </summary>
        /// <param name="itemId"></param>
        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await App.organigrammeDataStore.GetItemAsync(itemId);

                CODE_ORG = item.CODE_ORG;
                LIBELLE = item.LIBELLE;
                NIVEAU = item.NIVEAU;
                HIERARCHIE = item.HIERARCHIE;
            }
            catch (Exception)
            {
                Debug.WriteLine("ProbLeme lors du chargement des informations");
            }
        }


        /// <summary>
        /// Fermeture du popup
        /// </summary>
        /// <param name="obj"></param>
        private async void OnCancel(object obj)
        {
            await Shell.Current.GoToAsync("..");
        }


        /// <summary>
        /// Mise a jour de l'element
        /// </summary>
        /// <param name="obj"></param>
        private async void OnUpdateItem(object obj)
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

                bool isUserAccept = await Shell.Current.DisplayAlert("Vérification", "L'action que vous etes sur le point d'effectuer, Modifiera les valeurs de cet l'élément. Souhaitez-vous réellement éffectuer cette Opération ?", "Oui", "Non");
                if (isUserAccept)
                {
                    bool _varupdate = false;
                    ORGANIGRAMME _organigramme = new ORGANIGRAMME()
                    {
                        CODE_ORG = CODE_ORG,
                        LIBELLE = LIBELLE,
                        NIVEAU = NIVEAU,
                        HIERARCHIE = HIERARCHIE
                    };

                    await App.organigrammeDataStore.SaveTodoItemAsync(_organigramme, _varupdate);

                    // Autoriser la mise a jour de la page liste
                    MessagingCenter.Send<App>((App)Application.Current, "ActualiserListe");

                    //Fermer la page popup
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
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


