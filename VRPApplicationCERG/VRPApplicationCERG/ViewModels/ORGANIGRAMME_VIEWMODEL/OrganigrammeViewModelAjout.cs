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

namespace VRPApplicationCERG.ViewModels.ORGANIGRAMME_VIEWMODEL
{
    public class OrganigrammeViewModelAjout : BaseViewModel
    {

        //Declaration des commandes
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }


        //Declaration des variables 
        private ValidatableObject<string> _codeorg = new ValidatableObject<string>();
        public ValidatableObject<string> CODE_ORG
        {
            get => _codeorg;
            set => SetProperty(ref _codeorg, value);
        }

        private ValidatableObject<string> _libellé = new ValidatableObject<string>();
        public ValidatableObject<string> LIBELLE
        {
            get => _libellé;
            set => SetProperty(ref _libellé, value);
        }

        private ValidatableObject<string> _niveau = new ValidatableObject<string>();
        public ValidatableObject<string> NIVEAU
        {
            get => _niveau;
            set => SetProperty(ref _niveau, value);
        }

        private ValidatableObject<string> _hierarchie = new ValidatableObject<string>();
        public ValidatableObject<string> HIERARCHIE
        {
            get => _hierarchie;
            set => SetProperty(ref _hierarchie, value);
        }

        //Constructeur
        public OrganigrammeViewModelAjout()
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
            CODE_ORG.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "le code organigramme est obligatoire !" });
            LIBELLE.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "le libelle est obligatoire !" });
            NIVEAU.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "le niveau est obligatoire!" });
            HIERARCHIE.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Le niveau hierarchique est obligatoire !" });
           
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

                            ORGANIGRAMME _organigramme = new ORGANIGRAMME()
                            {
                                CODE_ORG = CODE_ORG.ToString(),
                                LIBELLE = LIBELLE.ToString(),
                                NIVEAU = NIVEAU.ToString(),
                                HIERARCHIE = HIERARCHIE.ToString()
                            };

                            await App.organigrammeDataStore.SaveTodoItemAsync(_organigramme, _varadd);

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
            bool isCODEORGValid = CODE_ORG.Validate();
            bool isLIBELLEValid = LIBELLE.Validate();
            bool isNIVEAUPValid = NIVEAU.Validate();
            bool isHIERARCHIEValid = HIERARCHIE.Validate();

            return isCODEORGValid && isLIBELLEValid && isNIVEAUPValid && isHIERARCHIEValid;
        }
    }
}
