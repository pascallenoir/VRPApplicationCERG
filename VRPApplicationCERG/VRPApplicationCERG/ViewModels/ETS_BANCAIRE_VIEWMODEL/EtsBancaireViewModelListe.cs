using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VRPApplicationCERG.Models;
using VRPApplicationCERG.ViewModels.FRAMEWORKMVVM;
using VRPApplicationCERG.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VRPApplicationCERG.ViewModels.ETS_BANCAIRE_VIEWMODEL
{
    public class EtsBancaireViewModelListe : BaseViewModel
    {

        //Declaration des variables et listes
        private ETS_BANCAIRE _selectedItem;
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        private ObservableCollection<ETS_BANCAIRE> _etsBancaireItemsFiltered;
        private ObservableCollection<ETS_BANCAIRE> _etsBancaireItemsUnfiltered;
        private ObservableCollection<ETS_BANCAIRE> _etsBancaireList;

        public ObservableCollection<ETS_BANCAIRE> EtsBancaireList
        {
            get => _etsBancaireList;
            set => SetProperty(ref _etsBancaireList, value);
        }


        //Declaration des commandes
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command DeleteAllItemsCommand { get; }
        public Command CocheItemCommand { get; }

        private Command<ETS_BANCAIRE> _confirmSuppresItemCommand;
        public Command<ETS_BANCAIRE> ConfirmSuppresItemCommand =>
            _confirmSuppresItemCommand ?? (_confirmSuppresItemCommand = new Command<ETS_BANCAIRE>(async (item) => await SupprimerElement(item)));
        public Command AnnulerSuppresItemCommand { get; }
        public ICommand SearchCommand { get; private set; }
        public Command<ETS_BANCAIRE> ItemTapped { get; }


        public EtsBancaireViewModelListe()
        {
            Title = "Banques";

            // Initialisation de la liste des ETSBANCAIRE
            EtsBancaireList = new ObservableCollection<ETS_BANCAIRE>();

            //// Commande pour le click sur l'un des Items de la liste
            ItemTapped = new Command<ETS_BANCAIRE>(OnItemSelected);
            //Annuler toutes actions
            AnnulerSuppresItemCommand = new Command(AnnulerConfirmSuppression);

            // Commande pour activer la selection de plusieurs elements d'une liste
            CocheItemCommand = new Command(OnActiveCocheelement);

            // Commande pou supprimer tous les elements de la liste
            DeleteAllItemsCommand = new Command(OnDeleteAll);

            // Commande pour l'ajout d'un nouvel Item
            AddItemCommand = new Command(OnAddItem);

            // Lancement de la recherche 
            SearchCommand = new Command(PerformSearch);

            //Actualisation de la liste 
            MessagingCenter.Subscribe<App>((App)Application.Current, "ActualiserListe", (sender) =>
            {
                // Chargement des donnees dans la liste 
                _ = ExecuteLoadItemsCommand();
            });

            // Chargement des donnees dans la liste 
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

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
        async Task SupprimerElement(ETS_BANCAIRE item)
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
                    await App.etsBancaireDataStore.DeleteTodoItemAsync(item.BANQUE_CODE_BCEAO);

                    await Shell.Current.DisplayAlert("Message", "Informations supprimée avec succès !", "d'accord");
                    // Autoriser la mise a jour de la page liste
                    MessagingCenter.Send<App>((App)Application.Current, "ActualiserListe");

                    //This will pop the current page off the navigation stack
                    await Shell.Current.GoToAsync("..");
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
            //        await App.BanqueDataStore.DeleteTodoItemAsync(itemId);

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



        //Fonction pour effectuer une recherche dans la liste
        public void PerformSearch()
        {
            if (string.IsNullOrWhiteSpace(this._searchText))
                EtsBancaireList = _etsBancaireItemsUnfiltered;
            else
            {
                _etsBancaireItemsFiltered = new ObservableCollection<ETS_BANCAIRE>(_etsBancaireItemsUnfiltered
                    .Where(i => (i is ETS_BANCAIRE && (((ETS_BANCAIRE)i)
                    .BANQUE_NOM.ToLower()
                    .Contains(_searchText.ToLower())))));
                EtsBancaireList = _etsBancaireItemsFiltered;
            }
        }


        //Fonction pour la recuperation de la lISTE des etsBancaire / fonxtionne aussi avec le refresh
        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                EtsBancaireList.Clear();
                var items = await App.etsBancaireDataStore.RefreshDatafreshAsync(true);
                foreach (var item in items)
                {
                    EtsBancaireList.Add(item);
                    _etsBancaireItemsUnfiltered = EtsBancaireList;
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
        public ETS_BANCAIRE SelectedItem
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
            await Shell.Current.GoToAsync(nameof(AjoutEtsBancairePage));
        }


        //fonction agissant sur la selection d'un item dans la liste
        async void OnItemSelected(ETS_BANCAIRE item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(DetailEtsBancairePage)}?{nameof(EtsBancaireViewModelDetail.ItemId)}={item.BANQUE_CODE_BCEAO}");
        }
    }
}

