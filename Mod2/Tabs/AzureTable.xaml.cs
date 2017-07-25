using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tabs.Models;
using Xamarin.Forms;

namespace Tabs
{
    public partial class AzureTable : ContentPage
    {
        MobileServiceClient client = AzureManager.AzureManagerInstance.AzureClient;
        public AzureTable()
        {
            InitializeComponent();
        }
        async void Handle_ClickedAsync(object sender, System.EventArgs e)
        {
            loading.IsRunning = true;
            List<ImageDescriberModel> ImageInformation = await AzureManager.AzureManagerInstance.GetImageInformation();

            ImageList.ItemsSource = ImageInformation;
            loading.IsRunning = false;
        }
    }

}
