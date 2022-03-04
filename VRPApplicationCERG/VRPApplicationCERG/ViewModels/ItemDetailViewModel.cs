using System;
using System.Diagnostics;
using System.Threading.Tasks;
using VRPApplicationCERG.Models;
using VRPApplicationCERG.ViewModels.BANQUE_VRP_VIEWMODEL;
using VRPApplicationCERG.ViewModels.FRAMEWORKMVVM;
using Xamarin.Forms;

namespace VRPApplicationCERG.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {



        private string itemId;
        //private string text;
        //private string description;
        //public string Id { get; set; }

        //public string Text
        //{
        //    get => text;
        //    set => SetProperty(ref text, value);
        //}

        //public string Description
        //{
        //    get => description;
        //    set => SetProperty(ref description, value);
        //}

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

        //public new string _codevrp;

        

        //async Task FetchVRPDetailsAsync()
        //{
        //    try
        //    {
        //        var list = await App.BanqueDataStore.GetTasksAsync(ItemId);
                


        //    }
        //    catch (Exception)
        //    {
        //        Debug.WriteLine("Failed to Load Item");
        //    }
        //}


        public async void LoadItemId(string _codevrp)
        {
            try
            {
                //var item = await DataStore.GetItemAsync(itemId);
                var item = await App.BanqueDataStore.GetTasksAsync(_codevrp);
               
                //Text = item.Text;
                //Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
