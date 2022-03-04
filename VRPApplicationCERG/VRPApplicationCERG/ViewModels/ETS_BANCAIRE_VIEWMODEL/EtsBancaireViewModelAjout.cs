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

namespace VRPApplicationCERG.ViewModels.ETS_BANCAIRE_VIEWMODEL
{
    public class EtsBancaireViewModelAjout : BaseViewModel
    {
        // Declaration des commandes
        public Command SaveCommand { get; }
        public Command CancelCommand { get; } 

        //////Declaration des variables 
        private ValidatableObject<string> _banquecodebceao = new ValidatableObject<string>();
        private ValidatableObject<string> _payscode = new ValidatableObject<string>();
        private ValidatableObject<string> _banquenom = new ValidatableObject<string>();
        private ValidatableObject<string> _banquesigle = new ValidatableObject<string>();
        private ValidatableObject<string> _banquedatesusp = new ValidatableObject<string>();
        private ValidatableObject<string> _banqueclebceao = new ValidatableObject<string>();
        private ValidatableObject<string> _banquecoderemet = new ValidatableObject<string>();
        private ValidatableObject<string> _codeformule = new ValidatableObject<string>();
        private ValidatableObject<string> _banquesdevmt = new ValidatableObject<string>();
        private ValidatableObject<string> _banquebf = new ValidatableObject<string>();
        private ValidatableObject<string> _etcivmatricule = new ValidatableObject<string>();

        public ValidatableObject<string> BANQUE_CODE_BCEAO
        {
            get => _banquecodebceao;
            set => SetProperty(ref _banquecodebceao, value);
        }
        public ValidatableObject<string> PAYS_CODE
        {
            get => _payscode;
            set => SetProperty(ref _payscode, value);
        }
        public ValidatableObject<string> BANQUE_NOM
        {
            get => _banquenom;
            set => SetProperty(ref _banquenom, value);
        }
        public ValidatableObject<string> BANQUE_SIGLE
        {
            get => _banquesigle;
            set => SetProperty(ref _banquesigle, value);
        }
        public ValidatableObject<string> BANQUE_DATE_SUSP
        {
            get => _banquedatesusp;
            set => SetProperty(ref _banquedatesusp, value);
        }
        public ValidatableObject<string> BANQUE_CLE_BCEAO
        {
            get => _banqueclebceao;
            set => SetProperty(ref _banqueclebceao, value);
        }
        public ValidatableObject<string> BANQUE_CODE_REMET
        {
            get => _banquecoderemet;
            set => SetProperty(ref _banquecoderemet, value);
        }
        public ValidatableObject<string> CODE_FORMULE
        {
            get => _codeformule;
            set => SetProperty(ref _codeformule, value);
        }
        public ValidatableObject<string> BANQUE_SDEVMT
        {
            get => _banquesdevmt;
            set => SetProperty(ref _banquesdevmt, value);
        }
        public ValidatableObject<string> BANQUE_B_F
        {
            get => _banquebf;
            set => SetProperty(ref _banquebf, value);
        }
        public ValidatableObject<string> ETCIV_MATRICULE
        {
            get => _etcivmatricule;
            set => SetProperty(ref _etcivmatricule, value);
        }
        //////////////////////////////////////////


        //Constructeur
        public EtsBancaireViewModelAjout()
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
            BANQUE_CODE_BCEAO.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "le code de banque est obligatoire !" });
            PAYS_CODE.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "le code du pays est obligatoire !" });
            BANQUE_NOM.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "le nom de la banque est obligatoire!" });
            //ADR1_VRP.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "L'adresse principale est obligatoire !" });
            ////ADR2_VRP.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Last Name Required" });
            //TEL1_VRP.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "le contact principal est obligatoire !" });
            //TEL1_VRP.Validations.Add(new IsLenghtValidRule<string> { ValidationMessage = "le numero de telephone doit etre compris entre 8 et 18 caracteres", MaximunLenght = 20, MinimunLenght = 8 });
            ////TEL2_VRP.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Phone Number Required" });
            //TEL2_VRP.Validations.Add(new IsLenghtValidRule<string> { ValidationMessage = "le numero de telephone doit etre compris entre 8 et 18 caracteres", MaximunLenght = 20, MinimunLenght = 8 });

            ////Email Validation Rules
            //E_MAIL_VRP.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "l'adresse mail est obligatoire" });
            //E_MAIL_VRP.Validations.Add(new IsValidEmailRule<string> { ValidationMessage = "Email non valide" });

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
        ///Fonction d'enregistrement pour un nouvel element dns ETS_BANCAIRE
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

                            ETS_BANCAIRE newItem = new ETS_BANCAIRE()
                            {
                               BANQUE_CODE_BCEAO = BANQUE_CODE_BCEAO.ToString(),
                               PAYS_CODE = PAYS_CODE.ToString(),
                               BANQUE_NOM = BANQUE_NOM.ToString(),
                               BANQUE_SIGLE = BANQUE_SIGLE.ToString(),
                               BANQUE_DATE_SUSP = BANQUE_DATE_SUSP.ToString(),
                               BANQUE_CLE_BCEAO = BANQUE_CLE_BCEAO.ToString(),
                               BANQUE_CODE_REMET = BANQUE_CODE_REMET.ToString(),
                               CODE_FORMULE = CODE_FORMULE.ToString(),
                               BANQUE_SDEVMT = BANQUE_SDEVMT.ToString(),
                               BANQUE_B_F = BANQUE_B_F.ToString(),
                               ETCIV_MATRICULE = ETCIV_MATRICULE.ToString()
                            };

                            await App.etsBancaireDataStore.SaveTodoItemAsync(newItem, _varadd);

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


            //Verifier si les champs respect les criteres de validation de champs avant enregistrement
            bool AreFieldsValid()
            {
                bool isBANQUECODEBCEAOValid = BANQUE_CODE_BCEAO.Validate();
                bool isPAYSCODEValid = PAYS_CODE.Validate();
                bool isBANQUENOMValid = BANQUE_NOM.Validate();
                //bool isADR1VRPValid = ADR1_VRP.Validate();
                ////bool isADR2VRPValid = ADR2_VRP.Validate();
                //bool isTEL1VRPValid = TEL1_VRP.Validate();
                ////bool isTEL2VRPValid = TEL2_VRP.Validate();
                //bool isEMAILVRPValid = E_MAIL_VRP.Validate();

                return isBANQUECODEBCEAOValid && isPAYSCODEValid && isBANQUENOMValid;
            }
        }
    }
}
