using Acr.UserDialogs;
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
using VRPApplicationCERG.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.OpenWhatsApp;

namespace VRPApplicationCERG.ViewModels.BANQUE_VRP_VIEWMODEL
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class BanqueVrpViewModelDetail : BaseViewModel
    {

        //Declaration des variables 
        private string itemId;
        private string _codevrp;
        private string _nomvrp;
        private string _prenomvrp;
        private string _emailvrp;
        private string _tel1vrp;
        private string _tel2vrp;
        private string _adr1vrp;
        private string _adr2vrp;

        //Declaration de la liste et de l'action de selection
        private VRPINTERV_BANQUE _selectedItem;
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                SetProperty(ref _searchText, value);
            }
        }

        private ObservableCollection<VRPINTERV_BANQUE> _etsBancaireItemsFiltered;
        private ObservableCollection<VRPINTERV_BANQUE> _etsBancaireItemsUnfiltered;

        private ObservableCollection<VRPINTERV_BANQUE> _etsBancaireList;
        public ObservableCollection<VRPINTERV_BANQUE> EtsBancaireList
        {
            get => _etsBancaireList;
            set => SetProperty(ref _etsBancaireList, value);
        }


        //Declaration des commandes
        public Command DeleteCommand { get; }
        public Command LoadItemsCommand { get; }
        public Command<VRPINTERV_BANQUE> ItemTapped { get; }
        public Command WhatsAppCommand { get; }
        public Command EditCommand { get; }
        public Command MessageCommand { get; }
        public Command AppelCommand { get; }
        public Command RetourCommand { get; }
        public ICommand SearchCommand { get; private set; }


        //Constructeur
        public BanqueVrpViewModelDetail()
        {

            Title = "Informations VRP";

            // Commande pour supprimer un element de la liste
            DeleteCommand = new Command(DeleteItemId);

            // Commande pour envoyer un message
            MessageCommand = new Command(OnMessageOptionSelected);

            // Commande pour aller a la page de modification
            EditCommand = new Command(AllerAUpdatePage);

            // Commande pour fermer la page actuelle et retourner a la page precedente
            RetourCommand = new Command(RetournerFonction);

            // Commande pour passer un appel
            AppelCommand = new Command(OnAppelOptionSelected);

            // Commande pour whatsapps
            WhatsAppCommand = new Command(OnWhatsappOptionSelected);
            // Lancement de la recherche 
            SearchCommand = new Command(PerformSearch);

            // Initialisation de la liste des ETSBANCAIRE
            EtsBancaireList = new ObservableCollection<VRPINTERV_BANQUE>();
            EtsBancaireList.CollectionChanged += EtsBancaireList_CollectionChanged;
            Count = EtsBancaireList.Count;

            // Commande pour le click sur l'un des Items de la liste
            ItemTapped = new Command<VRPINTERV_BANQUE>(OnItemSelected);
        }


        /// <summary>
        /// Commande pour fermer la page actuelle et retourner a la page precedente
        /// </summary>
        /// <param name="obj"></param>
        async void RetournerFonction(object obj)
        {
            await Shell.Current.GoToAsync("..");
        }



        /// <summary>
        /// Fonction pour utiliser la fonction de whatsapp
        /// </summary>
        /// <param name="obj"></param>
        async void OnWhatsappOptionSelected(object obj)
        {
            if (TEL1_VRP == null && TEL2_VRP == null)
            {
                await Shell.Current.DisplayAlert("Alerte", "Merci de bien vouloir enregistrer un numero de téléphone avant d'utiliser cette fonction", "Bien");
                return;
            }
            else
            {
                string action = await Shell.Current.DisplayActionSheet("Selectionner le contact", "Annuler", null, "Telephone principal", "Telephone secondaire");

                switch (action)
                {
                    case "Annuler":

                        Console.WriteLine("Action: " + action);

                        break;

                    case "Telephone principal":

                        try
                        {
                            if (TEL1_VRP == null)
                                return;

                            Chat.Open(TEL1_VRP, "Bonjour !");

                        }
                        catch (Exception ex)
                        {
                            await Shell.Current.DisplayAlert("Alerte", "Nous sommes actuellemnt dans l'incapacité d'effectuer cette action. Merci de réessayer ulterieurement", "Bien");
                        }

                        break;

                    case "Telephone secondaire":

                        try
                        {
                            if (TEL1_VRP == null)
                                return;

                            Chat.Open(TEL1_VRP, "Bonjour !");

                        }
                        catch (Exception ex)
                        {
                            await Shell.Current.DisplayAlert("Alerte", "Nous sommes actuellemnt dans l'incapacité d'effectuer cette action. Merci de réessayer ulterieurement", "Bien");
                        }
                        break;
                }
            }
        }


        /// <summary>
        /// Fonction pour utiliser la fonction de telephonie 
        /// </summary>
        /// <param name="obj"></param>
        async void OnAppelOptionSelected(object obj)
        {
            if (TEL1_VRP == null && TEL2_VRP == null)
            {
                await Shell.Current.DisplayAlert("Alerte", "Merci de bien vouloir enregistrer un numero de téléphone avant d'utiliser cette fonction", "Bien");
                return;
            }
            else
            {
                string action = await Shell.Current.DisplayActionSheet("Selectionner le contact", "Annuler", null, "Telephone principal", "Telephone secondaire");

                switch (action)
                {
                    case "Annuler":

                        Console.WriteLine("Action: " + action);

                        break;

                    case "Telephone principal":

                        try
                        {
                            if (TEL1_VRP == null)
                                return;

                            PhoneDialer.Open(TEL1_VRP);
                           
                        }
                        catch (Exception ex)
                        {
                            await Shell.Current.DisplayAlert("Alerte", "Nous sommes actuellemnt dans l'incapacité d'effectuer cette action. Merci de réessayer ulterieurement", "Bien");
                        }

                        break;

                    case "Telephone secondaire": 

                        try
                        {
                            if (TEL1_VRP == null)
                                return;

                            PhoneDialer.Open(TEL2_VRP);

                        }
                        catch (Exception ex)
                        {
                            await Shell.Current.DisplayAlert("Alerte", "Nous sommes actuellemnt dans l'incapacité d'effectuer cette action. Merci de réessayer ulterieurement", "Bien");
                        }
                        break;
                }
            }
        }


        /// <summary>
        /// Fonction pour utiliser la fonction de messagerie 
        /// </summary>
        /// <param name="obj"></param>
        async void OnMessageOptionSelected(object obj)
        {

            if (TEL1_VRP == null && TEL2_VRP == null)
            {
                await Shell.Current.DisplayAlert("Alerte", "Merci de bien vouloir enregistrer un numero de téléphone avant d'utiliser cette fonction", "Bien");
                return;
            }
            else
            {
                string action = await Shell.Current.DisplayActionSheet("Selectionner le contact", "Annuler", null, "Telephone principal", "Telephone secondaire");

                switch (action)
                {
                    case "Annuler":

                        Console.WriteLine("Action: " + action);

                        break;

                    case "Telephone principal":

                        try
                        {
                            if (TEL1_VRP == null)
                                return;

                            await Sms.ComposeAsync(new SmsMessage("Bonjour !", TEL1_VRP));

                        }
                        catch (Exception ex)
                        {
                            await Shell.Current.DisplayAlert("Alerte", "Nous sommes actuellemnt dans l'incapacité d'effectuer cette action. Merci de réessayer ulterieurement", "Bien");
                        }

                        break;

                    case "Telephone secondaire":

                        try
                        {
                            if (TEL1_VRP == null)
                                return;

                            await Sms.ComposeAsync(new SmsMessage("Bonjour !", TEL2_VRP));

                        }
                        catch (Exception ex)
                        {
                            await Shell.Current.DisplayAlert("Alerte", "Nous sommes actuellemnt dans l'incapacité d'effectuer cette action. Merci de réessayer ulterieurement", "Bien");
                        }
                        break;
                }
            }
        }


        /// <summary>
        /// Aller vers la page de mise a jour des informations
        /// </summary>
        /// <param name="obj"></param>
        async void AllerAUpdatePage(object obj)
        {
            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(MiseajourVRPPage)}?{nameof(BanqueVrpViewModelMiseajour.ItemId)}={CODE_VRP}");
        }


        //Variable count
        private int count;
        public int Count
        {
            set { SetProperty(ref count, value); }
            get { return count; }
        }


        //Ajout du frmeworkMVVM sur  les elements de classe
        public string CODE_VRP
        {
            get => _codevrp; 
            set => SetProperty(ref _codevrp, value); 
        }

        
        public string NOM_VRP
        {
            get => _nomvrp; 
            set => SetProperty(ref _nomvrp, value); 
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
                ExecuteLoadItemsCommand(value);
            }
        }
        // fin de ligne

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
                PRENOM_VRP = item.PRENOM_VRP;
                E_MAIL_VRP = item.E_MAIL_VRP;
                CODE_VRP = item.CODE_VRP;
                TEL1_VRP = item.TEL1_VRP;
                TEL2_VRP = item.TEL2_VRP;
                ADR1_VRP = item.ADR1_VRP;
                ADR2_VRP = item.ADR2_VRP;
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
                EtsBancaireList = _etsBancaireItemsUnfiltered;
            else
            {
                _etsBancaireItemsFiltered = new ObservableCollection<VRPINTERV_BANQUE>(_etsBancaireItemsUnfiltered
                    .Where(i => (i is VRPINTERV_BANQUE && (((VRPINTERV_BANQUE)i)
                    .BANQUE_NOM.ToLower()
                    .Contains(_searchText.ToLower())))));
                EtsBancaireList = _etsBancaireItemsFiltered;
            }
        }


        /// <summary>
        /// Afficher la liste des banques par vrp
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public async void ExecuteLoadItemsCommand(string itemId)
        {
            IsBusy = true;

            try
            {
                EtsBancaireList.Clear();
                var items = await App.vrpIntervBanqueDataStore.GetElementsById(itemId);
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


        /// <summary>
        /// Fonction de Suppression du vrp
        /// </summary>
        /// <param name="itemId"></param>
        private async void DeleteItemId(object obj)
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
                    await App.BanqueDataStore.DeleteTodoItemAsync(itemId);

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



        //Utilisation du selectedItem 
        public VRPINTERV_BANQUE SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        //fonction agissant sur la selection d'un item dans la liste
        async void OnItemSelected(VRPINTERV_BANQUE obj)
        {
            if (obj == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(RelationVRPPage)}?{nameof(BanqueVrpViewModelListeRelationVrp.ItemId)}={obj.CODE_VRP}&{nameof(BanqueVrpViewModelListeRelationVrp.ItemIdSecond)}={obj.BANQUE_CODE_BCEAO}");
        }



        /// <summary>
        /// Fonction pour signaler a la variable Count si un elemnt a ete ajouter ou supprimé de la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EtsBancaireList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Reset)
            {
                Count = EtsBancaireList.Count;
            }
        }
    }
}
