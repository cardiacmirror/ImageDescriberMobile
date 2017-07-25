using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace Tabs
{
    public class AzureManager
    {

        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<ImageDescriberModel> imageDescriberTable;

        private AzureManager()
        {
            this.client = new MobileServiceClient("https://imagedescribermobile.azurewebsites.net");
            this.imageDescriberTable = this.client.GetTable<ImageDescriberModel>();
        }

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static AzureManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }
        public async Task<List<ImageDescriberModel>> GetImageInformation()
        {
            return await this.imageDescriberTable.ToListAsync();
        }
        public async Task PostImageInformation(ImageDescriberModel imageModel)
        {
            await this.imageDescriberTable.InsertAsync(imageModel);
        }

    }
}
