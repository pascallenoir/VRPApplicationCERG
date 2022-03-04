using VRPApplicationCERG.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using VRPApplicationCERG.ViewModels.FRAMEWORKMVVM;
using Xamarin.Essentials;
using System.Threading.Tasks;
using Acr.UserDialogs;
using VRPApplicationCERG.Helpers.Validators;
using VRPApplicationCERG.Helpers.Validators.Rules;
using System.Diagnostics;
using VRPApplicationCERG.Models;

namespace VRPApplicationCERG.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command ForgetPasswordCommand { get; }


        private ValidatableObject<string> _emailuservrp = new ValidatableObject<string>();
        private ValidatableObject<string> _motdepasseuservrp = new ValidatableObject<string>();
        private ValidatableObject<string> _prenomvrp = new ValidatableObject<string>();

        public ValidatableObject<string> E_MAIL_USER_VRP
        {
            get => _emailuservrp;
            set => SetProperty(ref _emailuservrp, value);
        }

        public ValidatableObject<string> MOTDEPASSE_USER_VRP
        {
            get => _motdepasseuservrp;
            set => SetProperty(ref _motdepasseuservrp, value);
        }


        //CONSTRUCTEUR
        public LoginViewModel()
        {
            AddValidationRules();

            ForgetPasswordCommand = new Command(ForgetPasswordPage);
            LoginCommand = new Command(OnLoginClicked);
            this.PropertyChanged +=
                (_, __) => LoginCommand.ChangeCanExecute();
        }


        //gestionnaire de validation
        public void AddValidationRules()
        {
            //Champs de saisie Validation Rules
            MOTDEPASSE_USER_VRP.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "le mot de passe est obligatoire !" });

            //Email Validation Rules
            E_MAIL_USER_VRP.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "l'adresse mail est obligatoire" });
            E_MAIL_USER_VRP.Validations.Add(new IsValidEmailRule<string> { ValidationMessage = "Email non valide" });

        }


        //Aller a la page principale du mot de passe oublie
        private async void ForgetPasswordPage(object obj)
        {
           
            await Shell.Current.GoToAsync(nameof(MotDePasseOubliePagePrincipam));
        }


        private async void OnLoginClicked(object obj)
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

                if (AreFieldsValid() == true)
                {

                    var accesstoken = await App.authentificationDataStore.CheckUserExistAsync(E_MAIL_USER_VRP.ToString(), MOTDEPASSE_USER_VRP.ToString());

                    //Message
                    UserDialogs.Instance.Toast("Vous etes maintenant connecté !", TimeSpan.FromSeconds(5));

                    if (!string.IsNullOrEmpty(accesstoken))
                    {
                        try
                        {
                            await SecureStorage.SetAsync("acces_token", accesstoken.ToString());

                            //This will pop the current page off the navigation stack
                            await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
                        }
                        catch (Exception ex)
                        {
                            // Possible that device doesn't support secure storage on device.
                            UserDialogs.Instance.Toast("Possible that device doesn't support secure storage on device !", TimeSpan.FromSeconds(15));

                        }
                    }

                }
                else
                {
                    //Message
                    await Shell.Current.DisplayAlert("Alerte", "verifier les informations que vous avez saisies !", "Bien");
                    return;
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
            bool isemailuserVRPValid = E_MAIL_USER_VRP.Validate();
            bool ismotdePasseUserRPValid = MOTDEPASSE_USER_VRP.Validate();
          
            return isemailuserVRPValid && ismotdePasseUserRPValid;
        }

        internal async void OnAppearing()
        {
            var loggedin = false;
            if(loggedin)
                await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
        }
    }
}
