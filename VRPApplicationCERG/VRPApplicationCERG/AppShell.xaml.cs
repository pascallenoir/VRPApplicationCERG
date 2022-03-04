using System;
using System.Collections.Generic;
using VRPApplicationCERG.Interface;
using VRPApplicationCERG.ViewModels;
using VRPApplicationCERG.Views;
using Xamarin.Forms;

namespace VRPApplicationCERG
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //  Chemins vers les listes
            Routing.RegisterRoute(nameof(ItemsPage), typeof(ItemsPage));
            Routing.RegisterRoute(nameof(ListeTyperelationVRP), typeof(ListeTyperelationVRP));
            Routing.RegisterRoute(nameof(RelationVRPPage), typeof(RelationVRPPage));
            Routing.RegisterRoute(nameof(ListeOrganigrammeVRPpage), typeof(ListeOrganigrammeVRPpage));
            Routing.RegisterRoute(nameof(ListeEtsBancaireVRPpage), typeof(ListeEtsBancaireVRPpage));
            Routing.RegisterRoute(nameof(ListeVRPpage), typeof(ListeVRPpage));
            Routing.RegisterRoute(nameof(ListePaysVRPPage), typeof(ListePaysVRPPage));

            ///////////////////////////////////////////////////////////////
            ///

            // Chemins vers les pages de details
            Routing.RegisterRoute(nameof(DetailTypeRelationPage), typeof(DetailTypeRelationPage));
            Routing.RegisterRoute(nameof(DetailEtsBancairePage), typeof(DetailEtsBancairePage));
            Routing.RegisterRoute(nameof(DetailOrganigrammePage), typeof(DetailOrganigrammePage));
            Routing.RegisterRoute(nameof(DetailsPaysNationalPage), typeof(DetailsPaysNationalPage));
            Routing.RegisterRoute(nameof(DetailVRPPage), typeof(DetailVRPPage));
            

            ////////////////////////////////////////////////////////////
            ///

            // Chemins vers les pages d'ajout de nouvel element
            Routing.RegisterRoute(nameof(AjoutTypeRelationPage), typeof(AjoutTypeRelationPage));
            Routing.RegisterRoute(nameof(AjoutEtsBancairePage), typeof(AjoutEtsBancairePage));
            Routing.RegisterRoute(nameof(AjoutOrganigrammePage), typeof(AjoutOrganigrammePage));
            Routing.RegisterRoute(nameof(AjoutPaysPage), typeof(AjoutPaysPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(MiseajourVRPPage), typeof(MiseajourVRPPage));

            ////////////////////////////////////////////////////////////
            ///


            // Chemins vers les pages auxiliaires
            Routing.RegisterRoute(nameof(PageDesParametres), typeof(PageDesParametres));
            Routing.RegisterRoute(nameof(NotificationVRPpage), typeof(NotificationVRPpage));
            Routing.RegisterRoute(nameof(LaboCode), typeof(LaboCode));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(MessageriePage), typeof(MessageriePage));
            Routing.RegisterRoute(nameof(ProfilUserPage), typeof(ProfilUserPage)); 
            Routing.RegisterRoute(nameof(ModifierProfilUserPage), typeof(ModifierProfilUserPage));
            Routing.RegisterRoute(nameof(ListeUserPage), typeof(ListeUserPage));
            Routing.RegisterRoute(nameof(ConversationUserPage), typeof(ConversationUserPage));
            ////////////////////////////////////////////////////////////
            ///

            ////////////////////////////////////////////////////////////
            ///

            // Chemins vers les pages de recuperation de mot de passe
            Routing.RegisterRoute(nameof(MotDePasseOubliePagePrincipam), typeof(MotDePasseOubliePagePrincipam));
            Routing.RegisterRoute(nameof(EmailVerificationPage), typeof(EmailVerificationPage));
            Routing.RegisterRoute(nameof(MotDePasseOublieUpdate), typeof(MotDePasseOublieUpdate));
        }

        private async void OnMenuItemClickedParametres(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("PageDesParametres");
            Shell.Current.FlyoutIsPresented = false;
        }


        private async void OnMenuItemClickedAbout(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("AboutPage");
            Shell.Current.FlyoutIsPresented = false;
        }
    }
}
