using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VRPApplicationCERG.Models;
using VRPApplicationCERG.ViewModels.FRAMEWORKMVVM;
using VRPApplicationCERG.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VRPApplicationCERG.ViewModels.BANQUE_VRP_VIEWMODEL
{
    public class BanqueVrpViewModelListe : BaseViewModel
    {

        //Declaration des listes et variables
        private BANQUE_VRP _selectedItem;
       

        private ObservableCollection<BANQUE_VRP> _banqueVRPList;
        public ObservableCollection<BANQUE_VRP> BanqueVRPList
        {
            get => _banqueVRPList;
            set => SetProperty(ref _banqueVRPList, value);
        }

        //Visibilité du bouton flotant
        bool _visibilityButtonAjoutFlottant = true;
        public bool VisibilityButtonAjoutFlottant
        {
            get { return _visibilityButtonAjoutFlottant; }
            set { SetProperty(ref _visibilityButtonAjoutFlottant, value); }
        }


        //Visibilité du bouton Ajouter
        bool _boutonActionAJOUTERVisibility = false;
        public bool BoutonActionAJOUTERVisibility
        {
            get { return _boutonActionAJOUTERVisibility; }
            set { SetProperty(ref _boutonActionAJOUTERVisibility, value); }
        }


        //Declaration des commandes
        public ICommand ScrolledCommand { get; set; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command DeleteAllItemsCommand { get; }
        public Command CocheItemCommand { get; }

        private Command<BANQUE_VRP> _confirmSuppresItemCommand;
        public Command<BANQUE_VRP> ConfirmSuppresItemCommand =>
            _confirmSuppresItemCommand ?? (_confirmSuppresItemCommand = new Command<BANQUE_VRP>(async (item) => await SupprimerElement(item)));
        public Command AnnulerSuppresItemCommand { get; }
        public Command recehercheAvancee { get; }
        public Command<BANQUE_VRP> ItemTapped { get; }


        public BanqueVrpViewModelListe()
        {
            Title = "VRP";

            //// Commande pour le click sur l'un des Items de la liste
            ItemTapped = new Command<BANQUE_VRP>(OnItemSelected);

            //Annuler toutes actions
            AnnulerSuppresItemCommand = new Command(AnnulerConfirmSuppression);

            // Commande pour activer la selection de plusieurs elements d'une liste
            CocheItemCommand = new Command(OnActiveCocheelement);

            // Commande pou supprimer tous les elements de la liste
            DeleteAllItemsCommand = new Command(OnDeleteAll);

            // Commande pour l'ajout d'un nouvel Item
            AddItemCommand = new Command(OnAddItem);

            // Lancement de la page de recherche avancées
            recehercheAvancee = new Command(OnRecherchePage);

            // Initialisation de la liste des VRP
            BanqueVRPList = new ObservableCollection<BANQUE_VRP>();

            //Actualisation de la liste 
            MessagingCenter.Subscribe<App>((App)Application.Current, "ActualiserListe", (sender) =>
            {
                // Chargement des donnees dans la liste 
                _ = ExecuteLoadItemsCommand();
            });

            ScrolledCommand = new Command<object>((object args) => ActionScrolledList(args));

            // Chargement des donnees dans la liste 
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }


        //Fonction pour jouer une animation sur le scroll de la liste
        private void ActionScrolledList(object args)
        {
            double i = 0;
            if (args is ItemsViewScrolledEventArgs itemArgs)
            {
                if (itemArgs.VerticalOffset != i)
                {
                    VisibilityButtonAjoutFlottant = false;
                    BoutonActionAJOUTERVisibility = true;
                }
                else
                {
                    VisibilityButtonAjoutFlottant = true;
                    BoutonActionAJOUTERVisibility = false;
                }
            }
        }


        /// <summary>
        /// Fonction pour  annuler la suppression des elements de la liste
        /// </summary>
        /// <param name="obj"></param>
        private void AnnulerConfirmSuppression(object obj)
        {
            BoutonActionSuppression = true;
            BoutonConfirmSuppression = false;
        }

        /// <summary>
        /// Fonction pour supprimer un element de la liste
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        async Task SupprimerElement(BANQUE_VRP item)
        {
            try
            {

                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Désolé, cette action requiert un accès a la connexion internet. Vérifiez l'état de votre connexion internet et réessayez !", TimeSpan.FromSeconds(5));
                    return;
                }

                bool isUserAccept = await Shell.Current.DisplayAlert("Vérification", "L'action que vous etes sur le point d'effectuer, supprimera cet élément de votre liste. Souhaitez-vous réellement éffectuer cette Opération ?", "Oui", "Non");
                if (isUserAccept)
                {
                    await App.BanqueDataStore.DeleteTodoItemAsync(item.CODE_VRP);

                    await Shell.Current.DisplayAlert("Message", "Informations supprimée avec succès !", "d'accord");
                    // Autoriser la mise a jour de la page liste
                    MessagingCenter.Send<App>((App)Application.Current, "ActualiserListe");

                }
                else
                {
                    // Message
                    await Shell.Current.DisplayAlert("Alerte", "Opération Annulée !", "Bien");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Alerte", "Nous rencontrons un problème avec cette opération. Si le problème persite, contacter votre administrateur", "Bien");
            }
        }

        /// <summary>
        /// Fonction pour supprimer tous les elements de la liste
        /// </summary>
        /// <param name="obj"></param>
        private async void OnDeleteAll(object obj)
        {
            //try
            //{

            //    //Verifier l'etat de la connexion
            //    if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            //    {
            //        await Task.Yield();
            //        UserDialogs.Instance.Toast("Désolé, cette action requiert un accès a la connexion internet. Vérifiez l'état de votre connexion internet et réessayez !", TimeSpan.FromSeconds(5));
            //        return;
            //    }

            //    bool isUserAccept = await Shell.Current.DisplayAlert("Vérification", "L'action que vous etes sur le point d'effectuer, supprimera cet élément de votre liste. Souhaitez-vous réellement éffectuer cette Opération ?", "Oui", "Non");
            //    if (isUserAccept)
            //    {
            //        await App.BanqueDataStore.DeleteTodoItemAsync(item.CODE_VRP);

            //        await Shell.Current.DisplayAlert("Message", "Informations supprimée avec succès !", "d'accord");
            //        // Autoriser la mise a jour de la page liste
            //        MessagingCenter.Send<App>((App)Application.Current, "ActualiserListe");

            //        //This will pop the current page off the navigation stack
            //        await Shell.Current.GoToAsync("..");
            //    }
            //    else
            //    {
            //        // Message
            //        await Shell.Current.DisplayAlert("Alerte", "Opération Annulée !", "Bien");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex);
            //    await Shell.Current.DisplayAlert("Alerte", "Nous rencontrons un problème avec cette opération. Si le problème persite, contacter votre administrateur", "Bien");
            //}
            //try
            //{
            //    BanqueVRPList.Clear();
            //    var items = await App.BanqueDataStore.DeleteTodoItemAsync(;
            //    foreach (var item in items)
            //    {
            //        Items.Add(item);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex);
            //}
        }

        /// <summary>
        /// Fonction pour activer la selection des elemnts multiple de la liste
        /// </summary>
        /// <param name="obj"></param>
        private void OnActiveCocheelement(object obj)
        {
            BoutonActionSuppression = false;
            BoutonConfirmSuppression = true;
        }

        

        //Fonction pour aller vers la page de recherche avancée
        private async void OnRecherchePage(object obj)
        {
            await Shell.Current.GoToAsync(nameof(RecherchePage));
        }


        //Fonction pour la recuperation de la lISTE des VRP / fonxtionne aussi avec le refresh
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                BanqueVRPList.Clear();
                var items = await App.BanqueDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    BanqueVRPList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        //Fonction a l'affichage 
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
            BoutonConfirmSuppression = false;
            BoutonActionSuppression = true;
        }

        //Utilisation du selectedItem 
        public BANQUE_VRP SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

       

        //Fonction pour aller a l'ecran d'ajout d'un nouvel enregistement
        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }


        //fonction agissant sur la selection d'un item dans la liste
        async void OnItemSelected(BANQUE_VRP item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(DetailVRPPage)}?{nameof(BanqueVrpViewModelDetail.ItemId)}={item.CODE_VRP}");
        }

    }
}

