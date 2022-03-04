using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Interface;
using VRPApplicationCERG.ViewModels.JOINTABLES_VIEWMODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VRPApplicationCERG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecherchePage : ContentPage
    {
        JoinTablesViewModelListe _viewModel;

        public RecherchePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new JoinTablesViewModelListe();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            DependencyService.Get<IStatusBar>().ShowStatusBar();
        }
    }
}