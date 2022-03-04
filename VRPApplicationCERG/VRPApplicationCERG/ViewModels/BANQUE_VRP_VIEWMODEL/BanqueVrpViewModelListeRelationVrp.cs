using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VRPApplicationCERG.Models;
using VRPApplicationCERG.ViewModels.FRAMEWORKMVVM;
using Xamarin.Forms;

namespace VRPApplicationCERG.ViewModels.BANQUE_VRP_VIEWMODEL
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    [QueryProperty(nameof(ItemIdSecond), nameof(ItemIdSecond))]
    public class BanqueVrpViewModelListeRelationVrp : BaseViewModel
    {

        //Declaration des Listes et selection 
        private RELATIONVRPCLASS _selectedItem;
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

        private ObservableCollection<RELATIONVRPCLASS> _vRPRelationItemsFiltered;
        private ObservableCollection<RELATIONVRPCLASS> _vRPRelationItemsUnfiltered;
        private ObservableCollection<RELATIONVRPCLASS> _vRPRelationList;
        public ObservableCollection<RELATIONVRPCLASS> VRPRelationList
        {
            get => _vRPRelationList;
            set => SetProperty(ref _vRPRelationList, value);
        }


        //Declaration des COMMANDES 
        public ICommand SearchCommand { get; private set; }
        public Command CancelCommand { get; }
        public Command<RELATIONVRPCLASS> ItemTapped { get; }
        public Command LoadItemsCommand { get; }


        //Declaration des variables 
        private string itemId;
        private string itemIdSecond;
        private string code_vrp;
        private string nom_vrp;
        private string banque_code_bceao;
        private string banque_nom;
        private string code_org;
        private string libelle;
        private string code_type_relation;
        private string libelle_relation;
        private string observation_rel;
        private int count;

        public int Count
        {
            set { SetProperty(ref count, value); }
            get { return count; }
        }


        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public string ItemIdSecond
        {
            get
            {
                return itemIdSecond;
            }
            set
            {
                itemIdSecond = value;
                ExecuteLoadItemsCommand(value, ItemId);
            }
        }


        public string CODE_VRP
        {
            get => code_vrp;
            set => SetProperty(ref code_vrp, value);
        }

        public string NOM_VRP
        {
            get => nom_vrp;
            set => SetProperty(ref nom_vrp, value);
        }

        public string BANQUE_CODE_BCEOA
        {
            get => banque_code_bceao;
            set => SetProperty(ref banque_code_bceao, value);
        }

        public string BANQUE_NOM
        {
            get => banque_nom;
            set => SetProperty(ref banque_nom, value);
        }


        public string CODE_ORG
        {
            get => code_org;
            set => SetProperty(ref code_org, value);
        }

        public string LIBELLE
        {
            get => libelle;
            set => SetProperty(ref libelle, value);
        }

        public string CODE_TYPE_RELATION
        {
            get => code_type_relation;
            set => SetProperty(ref code_type_relation, value);
        }

        public string LIBELLE_RELATION
        {
            get => libelle_relation;
            set => SetProperty(ref libelle_relation, value);
        }

        public string OBSERVATION_REL
        {
            get => observation_rel;
            set => SetProperty(ref observation_rel, value);
        }


        /// <summary>
        /// Constructeur
        /// 
        /// </summary>
        public BanqueVrpViewModelListeRelationVrp()
        {
            Title = "Liste des relation du vrp";

            // Initialisation de la liste des VRP
            VRPRelationList = new ObservableCollection<RELATIONVRPCLASS>();
            VRPRelationList.CollectionChanged += VRPRelationList_CollectionChanged;
            Count = VRPRelationList.Count;

            //// Commande pour le click sur l'un des Items de la liste
            ItemTapped = new Command<RELATIONVRPCLASS>(OnItemSelected);

            // Lancement de la recherche 
            SearchCommand = new Command(PerformSearch);

            // Fermer la page
            CancelCommand = new Command(FermerLaPage);
            // Chargement des donnees dans la liste 
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommandOnDemand());
        }

        private Task ExecuteLoadItemsCommandOnDemand()
        {
            ExecuteLoadItemsCommand(ItemId, ItemIdSecond);
            return Task.CompletedTask;
        }


        //Fermer la page
        private async void FermerLaPage(object obj)
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }


        /// <summary>
        /// Fonction de chargement des details sur un vrp
        /// </summary>
        /// <param name="itemId"></param>
        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await App.BanqueDataStore.GetItemAsync(itemId);
                NOM_VRP = item.NOM_VRP;
            }
            catch (Exception)
            {
                Debug.WriteLine("ProbLeme lors du chargement des informations");
            }
        }



        //Fonction pour effectuer une recherche dans la liste
        public void PerformSearch()
        {
            if (string.IsNullOrWhiteSpace(this._searchText))
                VRPRelationList = _vRPRelationItemsUnfiltered;
            else
            {
                _vRPRelationItemsFiltered = new ObservableCollection<RELATIONVRPCLASS>(_vRPRelationItemsUnfiltered
                    .Where(i => (i is RELATIONVRPCLASS && (((RELATIONVRPCLASS)i)
                    .LIBELLE.ToLower()
                    .Contains(_searchText.ToLower())))));
                VRPRelationList = _vRPRelationItemsFiltered;
            }
        }

        /// <summary>
        /// Recuperation de la liste des relations du vrp
        /// </summary>
        /// <param name="value"></param>
        /// <param name="itemId"></param>
        private async void ExecuteLoadItemsCommand(string value, string itemId)
        {
            IsBusy = true;

            try
            {
                VRPRelationList.Clear();
                var items = await App.RELATIONVRPCLASSDATASTORE.GetItemsAsyncById(value, itemId);
                foreach (var item in items)
                {
                    VRPRelationList.Add(item);
                    _vRPRelationItemsUnfiltered = VRPRelationList;
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
        }

        //Utilisation du selectedItem 
        public RELATIONVRPCLASS SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }


        //fonction agissant sur la selection d'un item dans la liste
        async void OnItemSelected(RELATIONVRPCLASS item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(DetailVRPFilActualite)}?{nameof(JoinTablesViewModelDetail.ItemId)}={item.CODE_VRP}&{nameof(JoinTablesViewModelDetail.ItemIdSecond)}={item.BANQUE_CODE_VRP}");
        }


        /// <summary>
        /// Fonction pour signaler a la variable Count si un elemnt a ete ajouter ou supprimé de la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VRPRelationList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Reset)
            {
                Count = VRPRelationList.Count;
            }
        }

    }
}
