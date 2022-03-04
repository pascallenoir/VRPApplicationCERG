using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Interface;
using VRPApplicationCERG.ViewModels.ETS_BANCAIRE_VIEWMODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VRPApplicationCERG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListeEtsBancaireVRPpage : ContentPage
    {

        //Initialisation de la class viewModel des vrp
        EtsBancaireViewModelListe _viewModel;


        public ListeEtsBancaireVRPpage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new EtsBancaireViewModelListe();
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