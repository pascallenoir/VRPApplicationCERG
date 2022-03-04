using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.ViewModels.BANQUE_VRP_VIEWMODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VRPApplicationCERG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MiseajourVRPPage : ContentPage
    {
        public MiseajourVRPPage()
        {
            InitializeComponent();
            BindingContext = new BanqueVrpViewModelMiseajour();
        }
    }
}