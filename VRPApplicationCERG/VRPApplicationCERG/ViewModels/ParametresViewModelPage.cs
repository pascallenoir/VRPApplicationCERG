using System;
using System.Collections.Generic;
using System.Text;
using VRPApplicationCERG.ViewModels.FRAMEWORKMVVM;
using VRPApplicationCERG.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VRPApplicationCERG.ViewModels
{
    public class ParametresViewModelPage : BaseViewModel
    {
        //Declaration de variable
        private string _numeroBuild;
        public string NumeroBuild
        {
            get => _numeroBuild;
            set => SetProperty(ref _numeroBuild, value);
        }


        private string _numeroVersion;
        public string NumeroVersion
        {
            get => _numeroVersion;
            set => SetProperty(ref _numeroVersion, value);
        }

        //Declaration des commandes
        public Command AllerAlisteBanque { get; }
        public Command AllerAlisteRelation { get; }
        public Command AllerAlistePays { get; }
        public Command AllerAOrganigramme { get; }
        public Command AllerAEcranApropros { get; }
        public Command ChangeLangugeCommand { get; }
        public Command ToProfileCommand { get; }

        //Constructeur
        public ParametresViewModelPage()
        {
            Title = "Paramètres";

            // Aller vers l'ecran de profil
            ToProfileCommand = new Command(AllerVersProfil);

            // Aller vers l'ecran de la liste des banques
            AllerAlisteBanque = new Command(AllerVersEcranListeBanque);

            // Aller vers l'ecran de la liste des relations
            AllerAlisteRelation = new Command(AllerVersEcranListeRelation);

            // Aller vers l'ecran de la liste des pays
            AllerAlistePays = new Command(AllerVersEcranListePays);

            // Aller vers l'ecran de la liste organigramme
            AllerAOrganigramme = new Command(AllerVersEcranOrganigramme);

            // Aller vers l'ecran à propos
            AllerAEcranApropros = new Command(AllerVersEcranAPropos);

            ChangeLangugeCommand = new Command(AllerVersEcranAPropos);
            VersionTracking.Track();

            //Recuperation du numero de version
            NumeroVersion = VersionTracking.CurrentVersion.ToString();
            //Recuperation du numero de build
            NumeroBuild = VersionTracking.CurrentBuild.ToString();

        }



        // Aller vers l'ecran de profil
        private async void AllerVersProfil(object obj)
        {
            await Shell.Current.GoToAsync(nameof(ProfilUserPage));
        }


        // Aller vers l'ecran à propos
        private async void AllerVersEcranAPropos(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AboutPage));
        }


        // Aller vers l'ecran de la liste organigramme
        private async void AllerVersEcranOrganigramme(object obj)
        {
            await Shell.Current.GoToAsync(nameof(ListeOrganigrammeVRPpage));
        }


        // Aller vers l'ecran de la liste des pays
        private async void AllerVersEcranListePays(object obj)
        {
            await Shell.Current.GoToAsync(nameof(ListePaysVRPPage));
        }

        // Aller vers l'ecran de la liste des relations
        private async void AllerVersEcranListeRelation(object obj)
        {
            await Shell.Current.GoToAsync(nameof(ListeTyperelationVRP));
        }

        // Aller vers l'ecran de la liste des banques
        private async void AllerVersEcranListeBanque(object obj)
        {
            await Shell.Current.GoToAsync(nameof(ListeEtsBancaireVRPpage));
        }

        internal void OnAppearing()
        {
           
        }
    }
}
