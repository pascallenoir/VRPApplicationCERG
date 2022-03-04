using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Interface;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VRPApplicationCERG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilUserPage : ContentPage
    {
        public ProfilUserPage()
        {
            InitializeComponent();
            //BindingContext = new BanqueVrpViewModelDetail();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DependencyService.Get<IStatusBar>().ShowStatusBar();

        }

        private void ModifierProfil(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("ModifierProfilUserPage");
        }
    }
}