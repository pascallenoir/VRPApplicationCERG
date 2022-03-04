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

namespace VRPApplicationCERG.ViewModels.ORGAN_ETS_BANCAIRE_VIEWMODEL
{
    public class OrganEtsBancaireViewModelListe : BaseViewModel
    {

        private ORGAN_ETS_BANCAIRE _selectedItem;

        private ObservableCollection<ORGAN_ETS_BANCAIRE> _organEtsBancaireList;

        public ObservableCollection<ORGAN_ETS_BANCAIRE> OrganEtsBancaireList
        {
            get => _organEtsBancaireList;
            set => SetProperty(ref _organEtsBancaireList, value);
        }

        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command recehercheAvancee { get; }
        public Command<ORGAN_ETS_BANCAIRE> ItemTapped { get; }


        public OrganEtsBancaireViewModelListe()
        {
            Title = "Organ ets bancaire";

            // Initialisation de la liste des TypeRelation
            OrganEtsBancaireList = new ObservableCollection<ORGAN_ETS_BANCAIRE>();

            //// Commande pour le click sur l'un des Items de la liste
            ItemTapped = new Command<ORGAN_ETS_BANCAIRE>(OnItemSelected);

            // Commande pour l'ajout d'un nouvel Item
            AddItemCommand = new Command(OnAddItem);

            // Lancement de la page de recherche avancées
            recehercheAvancee = new Command(OnRecherchePage);

            // Chargement des donnees dans la liste 
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }


        //Fonction pour aller vers la page de recherche avancée
        private async void OnRecherchePage(object obj)
        {
            await Shell.Current.GoToAsync(nameof(RecherchePage));
        }


        //Fonction pour la recuperation de la lISTE des type relation/ fonxtionne aussi avec le refresh
        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                OrganEtsBancaireList.Clear();
                var items = await App.organEtsBancaireDataStore.RefreshDatafreshAsync(true);
                foreach (var item in items)
                {
                    OrganEtsBancaireList.Add(item);
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
        public ORGAN_ETS_BANCAIRE SelectedItem
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
            await Shell.Current.GoToAsync(nameof(LaboCode));
        }


        //fonction agissant sur la selection d'un item dans la liste
        async void OnItemSelected(ORGAN_ETS_BANCAIRE item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(DetailOrganigrammePage)}?{nameof(OrganEtsViewModelDetail.ItemId)}={item.CODE_ORG}");
        }
    }
}