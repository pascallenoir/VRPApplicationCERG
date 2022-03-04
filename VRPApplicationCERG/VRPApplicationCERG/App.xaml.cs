using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VRPApplicationCERG.Services;
using VRPApplicationCERG.Views;
using VRPApplicationCERG.Data;
using Plugin.FirebasePushNotification;

namespace VRPApplicationCERG
{
    public partial class App : Application
    {

        /// <summary>
        /// Declaration de variable static
        /// </summary>
        public static BanqueVrpDataStore BanqueDataStore { get; private set; }
        public static JoinTablesClassDataStore JoinTablesClassData { get; private set; }
        public static EtsBancaireDataStore etsBancaireDataStore { get; private set; }
        public static OrganEtsBancaireDataStore organEtsBancaireDataStore  { get; private set; }
        public static OrganigrammeDataStore organigrammeDataStore { get; private set; }
        public static TypeRelationVrpDataStore typeRelationVrpDataStore { get; private set; }
        public static VrpRelationEtsDataStore vrpRelationEtsDataStore { get; private set; }

        public static VrpIntervBanqueDataStore vrpIntervBanqueDataStore { get; private set; }
        public static RELATIONVRPCLASSDATASTORE RELATIONVRPCLASSDATASTORE { get; private set; }
        public static PaysVrpDataStore paysVrpDataStore { get; private set; }
        public static BankByCountDataStore bankByCountDataStore { get; private set; }
        public static LsPaysVrpIntClassDataStore LsPaysVrpIntClassDataStore { get; private set; }

        public static AuthentificationDataStore authentificationDataStore { get; private set; }

        public App()
        {
            InitializeComponent();

            //fonction api pour banque  vrp
            BanqueDataStore = new BanqueVrpDataStore(new RestServiceBanqueVRP());
            //fonction api pour Jointablesclass
            JoinTablesClassData = new JoinTablesClassDataStore(new RestServiceJointableClass());
            //fonction api pour EtsBancaire
            etsBancaireDataStore = new EtsBancaireDataStore(new RestServiceEtsBancaire());
            //fonction api pour oranetsbancaire
            organEtsBancaireDataStore = new OrganEtsBancaireDataStore(new RestServiceOrganEtsBancaire());
            //fonction api pour organigramme
            organigrammeDataStore = new OrganigrammeDataStore(new RestServiceOrganigramme());
            //fonction api pour type relation
            typeRelationVrpDataStore = new TypeRelationVrpDataStore(new RestServiceTypeRelationVRP());
            //fonction api pour vrp relation ets
            vrpRelationEtsDataStore = new VrpRelationEtsDataStore(new RestServiceVrpRelationEts());
            //fonction api pour vrp interv banque
            vrpIntervBanqueDataStore = new VrpIntervBanqueDataStore(new RestServiceVrpIntervBanque());
            //fonction api pour relation vrp dans banque
            RELATIONVRPCLASSDATASTORE = new RELATIONVRPCLASSDATASTORE(new RestServiceRELATIONVRPCLASS());
            //fonction api pour liste pays
            paysVrpDataStore = new PaysVrpDataStore(new RestServicePaysNational());
            //fonction api pour liste banque par apys
            bankByCountDataStore = new BankByCountDataStore(new RestServiceBankByCountClass());
            //fonction api pour liste vrp par pays et banque
            LsPaysVrpIntClassDataStore = new LsPaysVrpIntClassDataStore(new RestServiceLsPaysVrpIntClass());
            //fonction api pour user vrp
            authentificationDataStore = new AuthentificationDataStore(new RestServiceVRPAuthentification());


            DependencyService.Register<BanqueVrpDataStore>();
            DependencyService.Register<VrpRelationEtsDataStore>();
            DependencyService.Register<MockDataStore>();

            //if (IsFirstTime)
            //{
            //    MainPage = new OnboardingPage();
            //}
            //else
            //{
            //    MainPage = new AppShell();
            //}
            MainPage = new OnBoardingPageVrp();
        }

        protected override void OnStart()
        {

            //Code FCM Push Notification
                // Handle when your app starts
                CrossFirebasePushNotification.Current.Subscribe("general");
                CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
                {
                    System.Diagnostics.Debug.WriteLine($"TOKEN REC: {p.Token}");
                };
                System.Diagnostics.Debug.WriteLine($"TOKEN: {CrossFirebasePushNotification.Current.Token}");

                CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
                {
                    try
                    {
                        System.Diagnostics.Debug.WriteLine("Received");
                        if (p.Data.ContainsKey("body"))
                        {
                            Device.BeginInvokeOnMainThread(() =>
                            {
                               
                            });

                        }
                    }
                    catch (Exception ex)
                    {

                    }

                };

                CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
                {
                    //System.Diagnostics.Debug.WriteLine(p.Identifier);

                    System.Diagnostics.Debug.WriteLine("Opened");
                    foreach (var data in p.Data)
                    {
                        System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
                    }

                    if (!string.IsNullOrEmpty(p.Identifier))
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            //mPage.Message = p.Identifier;
                        });
                    }
                    else if (p.Data.ContainsKey("color"))
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            //mPage.Navigation.PushAsync(new ContentPage()
                            //{
                            //    BackgroundColor = Color.FromHex($"{p.Data["color"]}")

                            //});
                        });

                    }
                    else if (p.Data.ContainsKey("aps.alert.title"))
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            //mPage.Message = $"{p.Data["aps.alert.title"]}";
                        });

                    }
                };

                CrossFirebasePushNotification.Current.OnNotificationAction += (s, p) =>
                {
                    System.Diagnostics.Debug.WriteLine("Action");

                    if (!string.IsNullOrEmpty(p.Identifier))
                    {
                        System.Diagnostics.Debug.WriteLine($"ActionId: {p.Identifier}");
                        foreach (var data in p.Data)
                        {
                            System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
                        }

                    }

                };

                CrossFirebasePushNotification.Current.OnNotificationDeleted += (s, p) =>
                {
                    System.Diagnostics.Debug.WriteLine("Dismissed");
                };

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
