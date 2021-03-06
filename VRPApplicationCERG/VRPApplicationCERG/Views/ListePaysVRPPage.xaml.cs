using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Interface;
using VRPApplicationCERG.ViewModels.PAYS_NATIONAL_VIEWMODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VRPApplicationCERG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListePaysVRPPage : ContentPage
    {
        //Initialisation de la class viewModel des pays
        PaysNationalViewModelListe _viewModel;


        public ListePaysVRPPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new PaysNationalViewModelListe();
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