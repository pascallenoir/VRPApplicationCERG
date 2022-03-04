using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Models;
using VRPApplicationCERG.Services;
using VRPApplicationCERG.ViewModels.FRAMEWORKMVVM;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VRPApplicationCERG.ViewModels.TYPE_RELATION_VRP_VIEWMODEL
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class TypeRelationViewModelDetail : BaseViewModel
    {
        
        //Declaration des commandes 
        public Command CancelCommand { get; }
        public Command SaveCommand { get; }

        //Declaration des variables 
        private string itemId;
        private string _codetyperelation;
        private string _libellerelation;


        //Constructeur
        public TypeRelationViewModelDetail()
        {
            // mettre a jour l'Item
            SaveCommand = new Command(OnUpdateItem);

            // fermer le pop up
            CancelCommand = new Command(OnCancel);

        }

       
        public string CODE_TYPE_RELATION
        {
            get => _codetyperelation;
            set => SetProperty(ref _codetyperelation, value);
        }


        public string LIBELLE_RELATION
        {
            get => _libellerelation;
            set => SetProperty(ref _libellerelation, value);
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
        /// Fonction de chargement des details des types de relation
        /// </summary>
        /// <param name="itemId"></param>
        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await App.typeRelationVrpDataStore.GetItemAsync(itemId);
                CODE_TYPE_RELATION = item.CODE_TYPE_RELATION;
                LIBELLE_RELATION = item.LIBELLE_RELATION;
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
                    TYPE_RELATION_VRP newItem = new TYPE_RELATION_VRP()
                    {
                        LIBELLE_RELATION = LIBELLE_RELATION
                    };

                    await App.typeRelationVrpDataStore.SaveTodoItemAsync(newItem, _varupdate);

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


