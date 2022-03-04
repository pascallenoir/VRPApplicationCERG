using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.ViewModels.BANQUE_VRP_VIEWMODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VRPApplicationCERG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListeVRPpage : ContentPage
    {

        //Initialisation de la class viewModel des vrp
        BanqueVrpViewModelListe _viewModel;

        public ListeVRPpage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new BanqueVrpViewModelListe();
        }

        //Fonction de chargement des element au moment ou les l'ecran apparait
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}