using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;

namespace VRPApplicationCERG.ViewModels.FRAMEWORKMVVM
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        //Declaration de variable utiles dans tous le projet
      
        bool _notifications = true;
        public bool Notifications
        {
            get { return _notifications; }
            set { SetProperty(ref _notifications, value); }
        }
       

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }


        private bool _boutonConfirmSuppression = false;
        public bool BoutonConfirmSuppression
        {
            get => _boutonConfirmSuppression;
            set => SetProperty(ref _boutonConfirmSuppression, value);
        }


        private bool _boutonActionSuppression = true;
        public bool BoutonActionSuppression
        {
            get => _boutonActionSuppression;
            set => SetProperty(ref _boutonActionSuppression, value);
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        ////////////////////////////////////////////////////////////////////////

        public BaseViewModel()
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        ~BaseViewModel()
        {
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }


        //Verification de l'etat de la connexion sur le peripherique 
        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess != NetworkAccess.Internet)
                UserDialogs.Instance.Toast("Oups, Il semble que vous n'avez pas de connexion internet :(", TimeSpan.FromSeconds(5));
            else
                UserDialogs.Instance.Toast("Votre connexion internet est rétablie :)", TimeSpan.FromSeconds(5));
        }


        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
