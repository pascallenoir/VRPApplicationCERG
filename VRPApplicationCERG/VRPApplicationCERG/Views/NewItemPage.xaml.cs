using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using VRPApplicationCERG.Models;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using VRPApplicationCERG.ViewModels.BANQUE_VRP_VIEWMODEL;

namespace VRPApplicationCERG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new BanqueVRPViewModelAjout();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }


        
    }
}