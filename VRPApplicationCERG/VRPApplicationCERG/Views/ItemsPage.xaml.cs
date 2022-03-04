using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using VRPApplicationCERG.Models;
using VRPApplicationCERG.Views;
using VRPApplicationCERG.ViewModels;
using VRPApplicationCERG.ViewModels.BANQUE_VRP_VIEWMODEL;
using VRPApplicationCERG.Interface;

namespace VRPApplicationCERG.Views
{
    public partial class ItemsPage : ContentPage
    {
        BanqueVrpViewModelListe _viewModel;

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new BanqueVrpViewModelListe();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            DependencyService.Get<IStatusBar>().ShowStatusBar();

        }
    }
}