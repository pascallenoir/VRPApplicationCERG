using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VRPApplicationCERG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavBarAppliVRP : ContentView
    {
        public NavBarAppliVRP()
        {
            InitializeComponent();
            BindingContext = new NavBarAppliVRPViewModel();
        }
    }
}