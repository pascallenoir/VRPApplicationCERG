using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Helpers.Validators;
using VRPApplicationCERG.Helpers.Validators.Rules;
using VRPApplicationCERG.Models;
using VRPApplicationCERG.ViewModels.FRAMEWORKMVVM;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VRPApplicationCERG.ViewModels.TYPE_RELATION_VRP_VIEWMODEL
{
    public class TypeRelationViewModelAjout : BaseViewModel
    {
        //Declaration des commandes
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }


        //Declaration des variables 

        private string _codetyperelation;

        public string CODE_TYPE_RELATION
        {
            get => _codetyperelation;
            set => SetProperty(ref _codetyperelation, value);
        }


        private ValidatableObject<string> _libellerelation = new ValidatableObject<string>();
        public ValidatableObject<string> LIBELLE_RELATION
        {
            get => _libellerelation;
            set => SetProperty(ref _libellerelation, value);
        }

        //Constructeur 
        public TypeRelationViewModelAjout()
        {
            AddValidationRules();
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }



        //gestionnaire de validation
        public void AddValidationRules()
        {
            //Champs de saisie Validation Rules
            LIBELLE_RELATION.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "le champs est obligatoire !" });
        }

        // Fonction pour annuler l"enregistrement et fermer le pop up
        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        /// <summary>
        /// Fonction d'enregistrement
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

                if (AreFieldsValid())
                {

                        bool isUserAccept = await Shell.Current.DisplayAlert("Vérification", "L'action que vous etes sur le point d'effectuer, Ajoutera un nouvel élément dans votre liste. Souhaitez-vous réellement éffectuer cette Opération ?", "Oui", "Non");
                       if (isUserAccept)
                       {
                           bool _varadd = true;

                           TYPE_RELATION_VRP _typerelation = new TYPE_RELATION_VRP()
                           {
                               CODE_TYPE_RELATION = Guid.NewGuid().ToString(),
                               LIBELLE_RELATION = LIBELLE_RELATION.ToString()
                           };

                           await App.typeRelationVrpDataStore.SaveTodoItemAsync(_typerelation, _varadd);

                           // Autoriser la mise a jour de la page liste
                           MessagingCenter.Send<App>((App)Application.Current, "ActualiserListe");

                           //Fermer la page popup
                           await Shell.Current.GoToAsync("..");
                       }
                       else
                       {
                           // Message
                           await Shell.Current.DisplayAlert("Alerte", "Opération Annulée !", "Bien");
                       }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Alerte", "Nous rencontrons un problème avec cette opération. Si le problème persite, contacter votre administrateur", "Bien");
            }
        }

        //Verifier si les champs respect les criteres de validation de champs avant enregistrement
        bool AreFieldsValid()
        {
            bool isLIBELLERELATIONValid = LIBELLE_RELATION.Validate();
           

            return isLIBELLERELATIONValid ;
        }
    }
}
