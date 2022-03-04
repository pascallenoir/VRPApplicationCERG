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

namespace VRPApplicationCERG.ViewModels.PAYS_NATIONAL_VIEWMODEL
{
    public class PaysNationalViewModelAjout : BaseViewModel
    {
        //Declaration des commandes
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }


        //Declaration des variables 
        private ValidatableObject<string> _payscode = new ValidatableObject<string>();
        public ValidatableObject<string> PAYS_CODE
        {
            get => _payscode;
            set => SetProperty(ref _payscode, value);
        }


        private ValidatableObject<string> _paysnom = new ValidatableObject<string>();
        public ValidatableObject<string> PAYS_NOM
        {
            get => _paysnom;
            set => SetProperty(ref _paysnom, value);
        }


        //Constructeur
        public PaysNationalViewModelAjout()
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
            PAYS_CODE.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "le code du pays est obligatoire !" });
            PAYS_NOM.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "le nom du pays est obligatoire !" });
            
        }



        // Fonction pour annuler l"enregistrement et fermer le pop up
        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        /// <summary>
        /// Fonction d'enregistrement d'un nouveau pays
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

                            PAYS_NATIONAL _pays_national = new PAYS_NATIONAL()
                            {
                                PAYS_CODE = PAYS_CODE.ToString(),
                                PAYS_NOM = PAYS_NOM.ToString()
                            };

                           
                            await App.paysVrpDataStore.SaveTodoItemAsync(_pays_national, _varadd);

                            // Message
                            await Shell.Current.DisplayAlert("Alerte", "Opération éffectuée avec succès !", "Bien");

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
            bool isPAYSCODEValid = PAYS_CODE.Validate();
            bool isPAYSNOMValid = PAYS_NOM.Validate();
           
            return isPAYSCODEValid && isPAYSNOMValid;
        }
    }
}
