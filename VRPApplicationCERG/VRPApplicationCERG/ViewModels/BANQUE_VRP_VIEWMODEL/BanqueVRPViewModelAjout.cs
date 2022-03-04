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

namespace VRPApplicationCERG.ViewModels.BANQUE_VRP_VIEWMODEL
{
    public class BanqueVRPViewModelAjout : BaseViewModel
    {

        //Declaration des commandes
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        //////Declaration des variables 
        private ValidatableObject<string> _codevrp = new ValidatableObject<string>();
        private ValidatableObject<string> _nomvrp = new ValidatableObject<string>();
        private ValidatableObject<string> _prenomvrp = new ValidatableObject<string>();
        private ValidatableObject<string> _emailvrp = new ValidatableObject<string>();
        private ValidatableObject<string> _tel1vrp= new ValidatableObject<string>();
        private ValidatableObject<string> _tel2vrp= new ValidatableObject<string>();
        private ValidatableObject<string> _adr1vrp= new ValidatableObject<string>();
        private ValidatableObject<string> _adr2vrp= new ValidatableObject<string>();

        public ValidatableObject<string> CODE_VRP
        {
            get => _codevrp;
            set => SetProperty(ref _codevrp, value);
        }

        public ValidatableObject<string> NOM_VRP
        {
            get => _nomvrp;
            set => SetProperty(ref _nomvrp, value);
        }

        public ValidatableObject<string> PRENOM_VRP
        {
            get => _prenomvrp;
            set => SetProperty(ref _prenomvrp, value);
        }

        public ValidatableObject<string> E_MAIL_VRP
        {
            get => _emailvrp;
            set => SetProperty(ref _emailvrp, value);
        }

        public ValidatableObject<string> TEL1_VRP
        {
            get => _tel1vrp;
            set => SetProperty(ref _tel1vrp, value);
        }


        public ValidatableObject<string> TEL2_VRP
        {
            get => _tel2vrp;
            set => SetProperty(ref _tel2vrp, value);
        }


        public ValidatableObject<string> ADR1_VRP
        {
            get => _adr1vrp;
            set => SetProperty(ref _adr1vrp, value);
        }

        public ValidatableObject<string> ADR2_VRP
        {
            get => _adr2vrp;
            set => SetProperty(ref _adr2vrp, value);
        } 
        //////////////////////////////////////////


        //Constructeur
        public BanqueVRPViewModelAjout()
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
            CODE_VRP.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "le code VRP est obligatoire !" });
            NOM_VRP.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "le nom du vrp est obligatoire !" });
            PRENOM_VRP.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "le prenom du vrp est obligatoire!" });
            ADR1_VRP.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "L'adresse principale est obligatoire !" });
            //ADR2_VRP.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Last Name Required" });
            TEL1_VRP.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "le contact principal est obligatoire !" });
            TEL1_VRP.Validations.Add(new IsLenghtValidRule<string> { ValidationMessage = "le numero de telephone doit etre compris entre 8 et 18 caracteres", MaximunLenght = 20, MinimunLenght = 8 });
            //TEL2_VRP.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Phone Number Required" });
            TEL2_VRP.Validations.Add(new IsLenghtValidRule<string> { ValidationMessage = "le numero de telephone doit etre compris entre 8 et 18 caracteres", MaximunLenght = 20, MinimunLenght = 8 });

            //Email Validation Rules
            E_MAIL_VRP.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "l'adresse mail est obligatoire" });
            E_MAIL_VRP.Validations.Add(new IsValidEmailRule<string> { ValidationMessage = "Email non valide" });

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
        ///Fonction d'enregistrement pour un nouvel element dns Banque VRP
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
            bool isCODEVRPValid = CODE_VRP.Validate();
            bool isNOMVRPValid = NOM_VRP.Validate();
            bool isPRENOMVRPValid = PRENOM_VRP.Validate();
            bool isADR1VRPValid = ADR1_VRP.Validate();
            //bool isADR2VRPValid = ADR2_VRP.Validate();
            bool isTEL1VRPValid = TEL1_VRP.Validate();
            //bool isTEL2VRPValid = TEL2_VRP.Validate();
            bool isEMAILVRPValid = E_MAIL_VRP.Validate();

            return isCODEVRPValid && isNOMVRPValid && isPRENOMVRPValid && isADR1VRPValid && isTEL1VRPValid && isEMAILVRPValid;
        }
    }
}

