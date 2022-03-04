using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using VRPApplicationCERG.Models;
using VRPApplicationCERG.ViewModels.FRAMEWORKMVVM;
using Xamarin.Forms;

namespace VRPApplicationCERG.ViewModels.PAYS_NATIONAL_VIEWMODEL
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class PaysNationalViewModelDetail : BaseViewModel
    {

        public Command CancelCommand { get; }
        public Command SaveCommand { get; }

        //Declaration des variables 
        private string itemId;
        private string _payscode;
        private string _paysnom;

        public PaysNationalViewModelDetail()
        {
            // mettre a jour l'Item
            SaveCommand = new Command(OnUpdateItem);

            // fermer le pop up
            CancelCommand = new Command(OnCancel);

        }


        public string PAYS_CODE
        {
            get => _payscode;
            set => SetProperty(ref _payscode, value);
        }


        public string PAYS_NOM
        {
            get => _paysnom;
            set => SetProperty(ref _paysnom, value);
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
        /// Fonction de chargement des details d'un pays
        /// </summary>
        /// <param name="itemId"></param>
        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await App.paysVrpDataStore.GetItemAsync(itemId);
                PAYS_CODE = item.PAYS_CODE;
                PAYS_NOM = item.PAYS_NOM;
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
        /// Misde a jour de l'element
        /// </summary>
        /// <param name="obj"></param>
        private async void OnUpdateItem(object obj)
        {
            try
            {
                bool isUserAccept = await Shell.Current.DisplayAlert("Vérification", "L'action que vous etes sur le point d'effectuer, Modifiera les valeurs de cet l'élément. Souhaitez-vous réellement éffectuer cette Opération ?", "Oui", "Non");
                if (isUserAccept)
                {
                    bool _varupdate = false;
                    PAYS_NATIONAL newItem = new PAYS_NATIONAL()
                    {
                        PAYS_CODE = PAYS_CODE,
                        PAYS_NOM = PAYS_NOM
                    };

                    await App.paysVrpDataStore.SaveTodoItemAsync(newItem, _varupdate);

                    // Message
                    await Shell.Current.DisplayAlert("Alerte", "Opération éffectuée avec succès !", "Bien");

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
