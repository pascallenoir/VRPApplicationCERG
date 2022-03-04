using System;
using System.Windows.Input;
using VRPApplicationCERG.ViewModels.FRAMEWORKMVVM;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VRPApplicationCERG.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        //Declaration commande
        public ICommand MoreCommand { get; }
        public ICommand OpenWebCommand { get; }
       

        //Constructeur
        public AboutViewModel()
        {
            Title = "Paramètres";
            MoreCommand = new Command(async () =>
            {
                await Shell.Current.DisplayAlert("HEY", "Run your custom logic here", "Ok");
            });
        }
       
    }
}