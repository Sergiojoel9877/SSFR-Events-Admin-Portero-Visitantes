using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace SSFR_Events.Droid.Services
{
    public partial class AzureManager
    {

        static AzureManager azureManager = new AzureManager();

        MobileServiceClient client;

        public AzureManager()
        {
            this.client = new MobileServiceClient(Constants.ApplicationURL);
        }

        public static AzureManager _azureManager
        {
            get => azureManager;
            private set => azureManager = value;
        }

        public MobileServiceClient CurrentClient
        {
            get => client;
        }

    }
}
