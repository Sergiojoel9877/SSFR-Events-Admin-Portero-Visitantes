﻿using Rg.Plugins.Popup.Services;
using SSFR_Events.Data;
using SSFR_Events.Models;
using SSFR_Events.Services;
using SSFR_Events.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SSFR_Events.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddGuestPage : ContentPage
	{
        AddGuestViewModel ViewModel;

		public AddGuestPage (SSFR_Events.Services.Events evnt)
		{
			InitializeComponent ();

            ViewModel = ((ViewModelLocator)Application.Current.Resources["Locator"]).AddGuestViewModel;

            ViewModel.SendedEvent = evnt;

            BindingContext = ViewModel;
            
		}

        public AddGuestPage()
        {
                
        }
    }
}