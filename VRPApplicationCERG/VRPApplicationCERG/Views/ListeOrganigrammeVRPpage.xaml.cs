using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Interface;
using VRPApplicationCERG.ViewModels.ORGANIGRAMME_VIEWMODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VRPApplicationCERG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListeOrganigrammeVRPpage : ContentPage
    {

        //Initialisation de la class viewModel des organigramme
        OrganigrammeViewModelListe _viewModel;
        public ListeOrganigrammeVRPpage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new OrganigrammeViewModelListe();

        }
      
        //Fonction de chargement des element au moment ou les l'ecran apparait
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            DependencyService.Get<IStatusBar>().ShowStatusBar();

        }
    }
}