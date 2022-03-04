using VRPApplicationCERG.ViewModels.ETS_BANCAIRE_VIEWMODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VRPApplicationCERG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AjoutEtsBancairePage : ContentPage
    {
        public AjoutEtsBancairePage()
        {
            InitializeComponent();
            BindingContext = new EtsBancaireViewModelAjout();
        }

    }
}