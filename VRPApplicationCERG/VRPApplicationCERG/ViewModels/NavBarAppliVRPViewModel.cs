using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using VRPApplicationCERG.Interface;
using VRPApplicationCERG.Views;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace VRPApplicationCERG.ViewModels
{
    public class NavBarAppliVRPViewModel
    {
        // Declaration des commandes 
        public Command PageDeMenu { get; }
        public Command PageDeRechercheAvancee { get; }
        public Command PagePopUp { get; }


        //Constructeur
        public NavBarAppliVRPViewModel()
        {
            PageDeMenu = new Command(OuvriMenu);
            PageDeRechercheAvancee = new Command(AllerARecherche);
            PagePopUp = new Command(OuvrirPopUp);
        }


        /// <summary>
        /// Permet d'afficher le menu lateral 'tiroir'
        /// </summary>
        /// <param name="obj"></param>
        private async void OuvrirPopUp(object obj)
        {

            await PopupNavigation.Instance.PushAsync(new PoPUpProfilSelecteur());
        }

        /// <summary>
        /// Rediriger l'utilisateur vers la page de recherche avancee
        /// </summary>
        /// <param name="obj"></param>
        private async void AllerARecherche(object obj)
        {
            await Shell.Current.GoToAsync(nameof(RecherchePage));
        }


        /// <summary>
        /// Ouvrir le PopUp sur la page actuelle
        /// </summary>
        /// <param name="obj"></param>
        private void OuvriMenu(object obj)
        {
            Shell.Current.FlyoutIsPresented = true;
            DependencyService.Get<IStatusBar>().HideStatusBar();
        }
    }



}
