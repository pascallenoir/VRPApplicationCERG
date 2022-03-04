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

namespace VRPApplicationCERG.ViewModels.PAYS_NATIONAL_VIEWMODEL
{
    public class PaysNationalViewModelListe : BaseViewModel
    {
        private PAYS_NATIONAL _selectedItem;
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

        private ObservableCollection<PAYS_NATIONAL> _paysItemsFiltered;
        private ObservableCollection<PAYS_NATIONAL> _paysItemsUnfiltered;
        private ObservableCollection<PAYS_NATIONAL> _paysList;

        public ObservableCollection<PAYS_NATIONAL> PaysList
        {
            get => _paysList;
            set => SetProperty(ref _paysList, value);
        }

        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command DeleteAllItemsCommand { get; }
        public Command CocheItemCommand { get; }

        private Command<PAYS_NATIONAL> _confirmSuppresItemCommand;
        public Command<PAYS_NATIONAL> ConfirmSuppresItemCommand =>
            _confirmSuppresItemCommand ?? (_confirmSuppresItemCommand = new Command<PAYS_NATIONAL>(async (item) => await SupprimerElement(item)));
        public Command AnnulerSuppresItemCommand { get; }
        public ICommand SearchCommand { get; private set; }
        public Command<PAYS_NATIONAL> ItemTapped { get; }


        public PaysNationalViewModelListe()
        {
            Title = "Pays";

            // Initialisation de la liste des pays
            PaysList = new ObservableCollection<PAYS_NATIONAL>();

            //// Commande pour le click sur l'un des Items de la liste
            ItemTapped = new Command<PAYS_NATIONAL>(OnItemSelected);

            //Annuler toutes actions
            AnnulerSuppresItemCommand = new Command(AnnulerConfirmSuppression);

            // Commande pour activer la selection de plusieurs elements d'une liste
            CocheItemCommand = new Command(OnActiveCocheelement);

            // Commande pou supprimer tous les elements de la liste
            DeleteAllItemsCommand = new Command(OnDeleteAll);

            // Lancement de la recherche 
            SearchCommand = new Command(PerformSearch);

            // Commande pour l'ajout d'un nouvel Item
            AddItemCommand = new Command(OnAddItem);

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
        async Task SupprimerElement(PAYS_NATIONAL item)
        {
            try
            {
                if (item == null)
                  
                    return;

                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Désolé, cette action requiert un accès a la connexion internet. Vérifiez l'état de votre connexion internet et réessayez !", TimeSpan.FromSeconds(5));
                    return;
                }

                bool isUserAccept = await Shell.Current.DisplayAlert("Vérification", "L'action que vous etes sur le point d'effectuer, supprimera définitivement certaines valeurs de la liste. Souhaitez-vous réellement éffectuer cette Opération ?", "Oui", "Non");
                if (isUserAccept)
                {
                    await App.paysVrpDataStore.DeleteTodoItemAsync(item.PAYS_CODE);
                    await Shell.Current.DisplayAlert("Alerte", "Opération éffectuée avec succès !", "Bien");
                    // Autoriser la mise a jour de la page liste
                    MessagingCenter.Send<App>((App)Application.Current, "ActualiserListe");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Alerte", "Opération Annulée !", "Bien");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Fonction pour supprimer tous les elements de la liste
        /// </summary>
        /// <param name="obj"></param>
        private async void OnDeleteAll(object obj)
        {
            try
            {
                if (PaysList.Count == 0)
                    return;

                bool isUserAccept = await Shell.Current.DisplayAlert("Vérification", "L'action que vous etes sur le point d'effectuer, supprimera définitivement certaines valeurs de la liste. Souhaitez-vous réellement éffectuer cette Opération ?", "Oui", "Non");
                if (isUserAccept)
                {
                    PaysList.Clear();
                    //    var items = await App.paysVrpDataStore.(;
                    //    foreach (var item in items)
                    //    {
                    //        PaysList.Add(item);
                    //    }
                    await Shell.Current.DisplayAlert("Alerte", "Opération éffectuée avec succès !", "Bien");
                    // Autoriser la mise a jour de la page liste
                    MessagingCenter.Send<App>((App)Application.Current, "ActualiserListe");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Alerte", "Opération Annulée !", "Bien");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
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
                PaysList = _paysItemsUnfiltered;
            else
            {
                _paysItemsFiltered = new ObservableCollection<PAYS_NATIONAL>(_paysItemsUnfiltered
                    .Where(i => (i is PAYS_NATIONAL && (((PAYS_NATIONAL)i)
                    .PAYS_NOM.ToLower()
                    .Contains(_searchText.ToLower())))));
                PaysList = _paysItemsFiltered;
            }
        }

        //Fonction pour la recuperation de la lISTE des pays / fonxtionne aussi avec le refresh
        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                PaysList.Clear();
                var items = await App.paysVrpDataStore.RefreshDatafreshAsync(true);
                foreach (var item in items)
                {
                    PaysList.Add(item);
                    _paysItemsUnfiltered = PaysList;

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
        public PAYS_NATIONAL SelectedItem
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
            await Shell.Current.GoToAsync(nameof(AjoutPaysPage));
        }


        //fonction agissant sur la selection d'un item dans la liste
        async void OnItemSelected(PAYS_NATIONAL item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(DetailsPaysNationalPage)}?{nameof(PaysNationalViewModelDetail.ItemId)}={item.PAYS_CODE}");
        }
    }
}
