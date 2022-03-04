using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Models;
using VRPApplicationCERG.ViewModels.FRAMEWORKMVVM;
using VRPApplicationCERG.Views;
using Xamarin.Forms;

namespace VRPApplicationCERG.ViewModels.JOINTABLES_VIEWMODEL
{
    public class JoinTablesViewModelListe : BaseViewModel
    {

        /// Declaration des listes et des selecteurs

        
        // Liste principale pour la liste des relation du vrp avec selecteur
        private ObservableCollection<RELATIONVRPCLASS> _vRPRelationList;
        
        public ObservableCollection<RELATIONVRPCLASS> VRPRelationList
        {
            get => _vRPRelationList;
            set => SetProperty(ref _vRPRelationList, value);
        }


        // Liste des vrp par banque et pays avec selecteur
        private int _selectedVrpIndex;
        public int SelectedVrpIndex
        {
            get => _selectedVrpIndex;
            set
            {
                SetProperty(ref _selectedVrpIndex, value);
            }
        }

        private LSPAYSVRPINTCLASS _selectedVrpItem;
        public LSPAYSVRPINTCLASS SelectedVrpItem
        {
            get => _selectedVrpItem;
            set
            {
                SetProperty(ref _selectedVrpItem, value);
                OnItemVrpSelected(value);
            }
        }


        private ObservableCollection<LSPAYSVRPINTCLASS> vrpList;

        public ObservableCollection<LSPAYSVRPINTCLASS> VrpList
        {
            get => vrpList;
            set => SetProperty(ref vrpList, value);
        }


        // Liste des banque par pays avec selecteur

        private int _selectedBanqueIndex;
        public int SelectedBanqueIndex
        {
            get => _selectedBanqueIndex;
            set
            {
                SetProperty(ref _selectedBanqueIndex, value);
            }
        }

        private BANKBYCOUNTCLASS _selectedBanqueItem;
        public BANKBYCOUNTCLASS SelectedBanqueItem
        {
            get => _selectedBanqueItem;
            set
            {
                SetProperty(ref _selectedBanqueItem, value);
                OnItemBanqueSelected(value);
            }
        }

        private ObservableCollection<BANKBYCOUNTCLASS> banquesList;

        public ObservableCollection<BANKBYCOUNTCLASS> BanquesList
        {
            get => banquesList;
            set => SetProperty(ref banquesList, value);
        }



        // Liste des pays avec selecteur

        private int _selectedPaysIndex;
        public int SelectedPaysIndex
        {
            get => _selectedPaysIndex;
            set
            {
                SetProperty(ref _selectedPaysIndex, value);
            }
        }

        private PAYS_NATIONAL _selectedPaysItem;
        public PAYS_NATIONAL SelectedPaysItem
        {
            get => _selectedPaysItem;
            set
            {
                SetProperty(ref _selectedPaysItem, value);
                OnItemPaysSelected(value);
            }
        }

        private ObservableCollection<PAYS_NATIONAL> _paysList;

        public ObservableCollection<PAYS_NATIONAL> PaysList
        {
            get => _paysList;
            set => SetProperty(ref _paysList, value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////

        public Command LoadItemsCommand { get; }
        public Command<BANQUE_VRP> ItemTapped { get; }
        public Command<PAYS_NATIONAL> ItemPaysTapped { get; }
        public Command<BANKBYCOUNTCLASS> ItemBankByCountTapped { get; }
        public Command<LSPAYSVRPINTCLASS> ItemVrpTapped { get; }

        public JoinTablesViewModelListe()
        {
            Title = "Liste des relation du vrp";

            // Initialisation de la liste des relation du VRP
            VRPRelationList = new ObservableCollection<RELATIONVRPCLASS>();

            // Initialisation de la liste des VRP
            VrpList = new ObservableCollection<LSPAYSVRPINTCLASS>();

            // Initialisation de la liste des Banques
            BanquesList = new ObservableCollection<BANKBYCOUNTCLASS>();

            // Initialisation de la liste des Banques
            PaysList = new ObservableCollection<PAYS_NATIONAL>();

            //// Commande pour le click sur l'un des Items de la liste
            ItemPaysTapped = new Command<PAYS_NATIONAL>(OnItemPaysSelected);

            //// Commande pour le click sur l'un des Items de la liste
            ItemBankByCountTapped = new Command<BANKBYCOUNTCLASS>(OnItemBanqueSelected);

            //// Commande pour le click sur l'un des Items de la liste
            ItemVrpTapped = new Command<LSPAYSVRPINTCLASS>(OnItemVrpSelected);


            // Chargement des donnees dans la liste
            ChargementListPays();

        }


        /// <summary>
        /// Chargement de la liste des pays dans la combo box
        /// </summary>
        private async void ChargementListPays()
        {
            try
            {
                PaysList.Clear();
                var items = await App.paysVrpDataStore.GetTasksAsync();
                foreach (var item in items)
                {
                    PaysList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }


        /// <summary>
        /// chargement de la liste des banques par pays dans la combo box
        ///
        /// </summary>
        /// <param name="itemId"></param>
        private async void
        /// <summary>
        /// chargement de la liste des banques par pays dans la combo box
        ///
        /// </summary>
        /// <param name="itemId"></param
        ChargementListBanqueParPays(string itemId)
        {
            try
            {
                BanquesList.Clear();
                var items = await App.bankByCountDataStore.GetElementsById(itemId);
                foreach (var item in items)
                {
                    if (item == null)
                   
                        return;
                   
                    BanquesList.Add(item);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
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
            SelectedPaysItem = null;
            SelectedBanqueItem = null;
            SelectedVrpItem = null;
            SelectedPaysIndex = -1;
            SelectedBanqueIndex = -1;
            SelectedVrpIndex = -1;
        }

        //fonction agissant sur la selection d'un item dans la liste
        void OnItemPaysSelected(PAYS_NATIONAL value)
        {
            if (value == null)
                return;

            ChargementListBanqueParPays(value.PAYS_CODE);
        }



        //fonction agissant sur la selection d'un item dans la liste
        private void OnItemBanqueSelected(BANKBYCOUNTCLASS value)
        {
            if (value == null)
                return;

            ChargementListVrpParPaysEtBanque(value.Pays_code,value.Banque_code_bceao);
        }


        //fonction agissant sur la selection d'un item dans la liste
        private void OnItemVrpSelected(LSPAYSVRPINTCLASS value)
        {
            if (value == null)
                return;

            ExecuteLoadItemsCommand(value.CODE_VRP, value.BANQUE_CODE_BCEAO);
        }


        /// <summary>
        /// Chargement de la liste des vrp par pays et banque dans la combo box
        /// </summary>
        private async void ChargementListVrpParPaysEtBanque(string pays_code, string banque_code_bceao)
        {
            try
            {
                VrpList.Clear();
                var items = await App.LsPaysVrpIntClassDataStore.GetItemsAsyncById(banque_code_bceao,pays_code) ;
                foreach (var item in items)
                {
                    if (item == null)

                        return;

                    VrpList.Add(item);
                }

                if (VrpList.Count == 0)
                {
                    await Shell.Current.DisplayAlert("Message", "Nous n'avons trouvé aucune ressource disponible dans cette banque", "Bien");
                    return;
                } 
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

    }
}