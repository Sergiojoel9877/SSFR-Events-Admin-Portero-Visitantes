using CommonServiceLocator;
using SSFR_Events.Services;
using SSFR_Events.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSFR_Events.Data
{
    public class ViewModelLocator
    {

        //static ViewModelLocator()
        //{
        //    ContainerInitializer.Initialize();
        //}

        public AddEventViewModel AddEventViewModel
        {
            get => ServiceLocator.Current.GetInstance<AddEventViewModel>();
        }

        public AddGuestViewModel AddGuestViewModel
        {
            get => ServiceLocator.Current.GetInstance<AddGuestViewModel>();
        }

        public LoginPageViewModel LoginViewModel
        {
            get => ServiceLocator.Current.GetInstance<LoginPageViewModel>();
        }

        public MainMasterDetailPageMasterViewModel MainMasterDetailPageViewModel
        {
            get => ServiceLocator.Current.GetInstance<MainMasterDetailPageMasterViewModel>();
        }

        public RegisterPageViewModel RegisterPageViewModel
        {
            get => ServiceLocator.Current.GetInstance<RegisterPageViewModel>();
        }
    }
}
