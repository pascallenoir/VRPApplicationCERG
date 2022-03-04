using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Interface;
using VRPApplicationCERG.ViewModels.TYPE_RELATION_VRP_VIEWMODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VRPApplicationCERG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListeTyperelationVRP : ContentPage
    {

        //Initialisation de la class viewModel des TYPES RELATION
        TypeRelationViewModelListe _viewModel;
        public ListeTyperelationVRP()
        {
            InitializeComponent();
            BindingContext = _viewModel = new TypeRelationViewModelListe();
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