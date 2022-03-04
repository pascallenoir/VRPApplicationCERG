using Acr.UserDialogs;
using Rg.Plugins.Popup.Extensions;
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

namespace VRPApplicationCERG.ViewModels.TYPE_RELATION_VRP_VIEWMODEL
{
    public class TypeRelationViewModelListe : BaseViewModel
    {

        private TYPE_RELATION_VRP _selectedItem;
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

        private ObservableCollection<TYPE_RELATION_VRP> _typeRelationItemsFiltered;
        private ObservableCollection<TYPE_RELATION_VRP> _typeRelationItemsUnfiltered;
        private ObservableCollection<TYPE_RELATION_VRP> _typeRelationVrpList;

        public ObservableCollection<TYPE_RELATION_VRP> TypeRelationVrpList
        {
            get => _typeRelationVrpList;
            set => SetProperty(ref _typeRelationVrpList, value);
        }

        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command DeleteAllItemsCommand { get; }
        public Command CocheItemCommand { get; }

        private Command<TYPE_RELATION_VRP> _confirmSuppresItemCommand;
        public Command<TYPE_RELATION_VRP> ConfirmSuppresItemCommand =>
            _confirmSuppresItemCommand ?? (_confirmSuppresItemCommand = new Command<TYPE_RELATION_VRP>(async (item) => await SupprimerElement(item)));
        public Command AnnulerSuppresItemCommand { get; }
        public ICommand SearchCommand { get; private set; }
        public Command<TYPE_RELATION_VRP> ItemTapped { get; }


        public TypeRelationViewModelListe()
        {
            Title = "Relations";

            // Initialisation de la liste des TypeRelation
            TypeRelationVrpList = new ObservableCollection<TYPE_RELATION_VRP>();

            //// Commande pour le click sur l'un des Items de la liste
            ItemTapped = new Command<TYPE_RELATION_VRP>(OnItemSelected);
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
        async Task SupprimerElement(TYPE_RELATION_VRP item)
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
                    await App.typeRelationVrpDataStore.DeleteTodoItemAsync(item.CODE_TYPE_RELATION);

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
                TypeRelationVrpList = _typeRelationItemsUnfiltered;
            else
            {
                _typeRelationItemsFiltered = new ObservableCollection<TYPE_RELATION_VRP>(_typeRelationItemsUnfiltered
                    .Where(i => (i is TYPE_RELATION_VRP && (((TYPE_RELATION_VRP)i)
                    .LIBELLE_RELATION.ToLower()
                    .Contains(_searchText.ToLower())))));
                TypeRelationVrpList = _typeRelationItemsFiltered;
            }
        }


        //Fonction pour la recuperation de la lISTE des type relation/ fonxtionne aussi avec le refresh
        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                TypeRelationVrpList.Clear();
                var items = await App.typeRelationVrpDataStore.RefreshDatafreshAsync(true);
                foreach (var item in items)
                {
                    TypeRelationVrpList.Add(item);
                    _typeRelationItemsUnfiltered = TypeRelationVrpList;
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
        public TYPE_RELATION_VRP SelectedItem
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
            await Shell.Current.GoToAsync(nameof(AjoutTypeRelationPage));
        }


        //fonction agissant sur la selection d'un item dans la liste
        async void OnItemSelected(TYPE_RELATION_VRP item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(DetailTypeRelationPage)}?{nameof(TypeRelationViewModelDetail.ItemId)}={item.CODE_TYPE_RELATION}");
        }
    }
}