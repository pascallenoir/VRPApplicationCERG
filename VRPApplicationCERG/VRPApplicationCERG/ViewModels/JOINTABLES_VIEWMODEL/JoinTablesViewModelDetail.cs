using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Models;
using VRPApplicationCERG.ViewModels.FRAMEWORKMVVM;
using Xamarin.Forms;

namespace VRPApplicationCERG.ViewModels.JOINTABLES_VIEWMODEL
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    [QueryProperty(nameof(ItemIdSecond), nameof(ItemIdSecond))]
    public class JoinTablesViewModelDetail : BaseViewModel
    {
        //Declaration des variables 
        private string itemIdSecond;
        private string itemId;
        private string code_vrp;
        private string nom_vrp;
        private string banque_code_vrp;
        private string banque_nom;
        private string _prenomvrp;
        private string _emailvrp;
        private string _tel1vrp;
        private string _tel2vrp;
        private string _adr1vrp;
        private string _adr2vrp;

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


        public string BANQUE_CODE_VRP
        {
            get => banque_code_vrp;
            set => SetProperty(ref banque_code_vrp, value);
        }

        public string BANQUE_NOM
        {
            get => banque_nom;
            set => SetProperty(ref banque_nom, value);
        }

        public string PRENOM_VRP
        {
            get => _prenomvrp;
            set => SetProperty(ref _prenomvrp, value);
        }

        public string E_MAIL_VRP
        {
            get => _emailvrp;
            set => SetProperty(ref _emailvrp, value);
        }


        public string TEL1_VRP
        {
            get => _tel1vrp;
            set => SetProperty(ref _tel1vrp, value);
        }


        public string TEL2_VRP
        {
            get => _tel2vrp;
            set => SetProperty(ref _tel2vrp, value);
        }

        public string ADR1_VRP
        {
            get => _adr1vrp;
            set => SetProperty(ref _adr1vrp, value);
        }

        public string ADR2_VRP
        {
            get => _adr2vrp;
            set => SetProperty(ref _adr2vrp, value);
        }

        private BANQUE_VRP _selectedItem;


        //Initialisation de la liste 
        private ObservableCollection<RELATIONVRPCLASS> _jointableVRPList;

        public ObservableCollection<RELATIONVRPCLASS> JointableVRPList
        {
            get => _jointableVRPList;
            set => SetProperty(ref _jointableVRPList, value);
        }


        //Initialisation des commandes
        //public Command LoadItemsCommand { get; }
        public Command<BANQUE_VRP> ItemTapped { get; }

        public JoinTablesViewModelDetail()
        {
            Title = "Details VRP";

            // Initialisation de la liste des VRP
            JointableVRPList = new ObservableCollection<RELATIONVRPCLASS>();

            //// Commande pour le click sur l'un des Items de la liste
            ItemTapped = new Command<BANQUE_VRP>(OnItemSelected);

            //// Chargement des donnees dans la liste 
            //LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
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
                LoadItemDetailCommand(value);
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
                ExecuteLoadItemsCommand(value,ItemId);
            }
        }


        /// <summary>
        /// Fonction de chargement des details d'un vrp
        /// </summary>
        /// <param name="itemId"></param>
        private async void LoadItemDetailCommand(string itemId)
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



        //Fonction pour la recuperation de la lISTE des VRP / fonxtionne aussi avec le refresh
        public async void ExecuteLoadItemsCommand(string itemIdSecond, string itemId)
        {
            IsBusy = true;

            try
            {
                JointableVRPList.Clear();
                var items = await App.RELATIONVRPCLASSDATASTORE.GetItemsAsyncById(itemId, itemIdSecond);
                foreach (var item in items)
                {
                    JointableVRPList.Add(item);
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


        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
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

        //fonction agissant sur la selection d'un item dans la liste
        async void OnItemSelected(BANQUE_VRP item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(DetailVRPPage)}?{nameof(BanqueVrpViewModelDetail.ItemId)}={item.CODE_VRP}");
        }
    }
}
