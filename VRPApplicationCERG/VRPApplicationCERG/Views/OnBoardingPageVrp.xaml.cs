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
    public partial class OnBoardingPageVrp : ContentPage
    {
        public OnBoardingPageVrp()
        {
            InitializeComponent();
           //DependencyService.Get<IStatusBar>().HideStatusBar();
        }

        private void navigationButton_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new AppShell();
        }
    }
}