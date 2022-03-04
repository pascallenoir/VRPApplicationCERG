using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Interface;
using VRPApplicationCERG.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VRPApplicationCERG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConferencesPage : ContentPage
    {
        public ConferencesPage()
        {
            InitializeComponent();
            BindingContext = new ConferenceViewModelPage();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DependencyService.Get<IStatusBar>().ShowStatusBar();

        }
    }
}