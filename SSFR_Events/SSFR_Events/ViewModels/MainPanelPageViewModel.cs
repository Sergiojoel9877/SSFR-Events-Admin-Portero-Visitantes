﻿using Plugin.Connectivity;
using SSFR_Events.Models;
using SSFR_Events.Services;
using SSFR_Events.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SSFR_Events.Helpers;
using System.Text;
using Xamarin.Forms;

namespace SSFR_Events.ViewModels
{
    public class MainPanelPageViewModel : ViewModelBase
    {
        INavigation _navService;

        private string eventType;
        public string EventType
        {
            get => eventType;

            set => SetProperty(ref eventType, value);
        }

        #region Images

        private ImageSource aniversaryImage = "aniversario.png";
        public ImageSource AniversaryImage
        {
            get => aniversaryImage;

            set => SetProperty(ref aniversaryImage, value);
        }

        private ImageSource marryageImage = "boda.png";
        public ImageSource MarryageImage
        {
            get => marryageImage;

            set => SetProperty(ref marryageImage, value);
        }

        private ImageSource birthdayImage = "cumpleanos.png";
        public ImageSource BirthdayImage
        {
            get => birthdayImage;

            set => SetProperty(ref birthdayImage, value);
        }

        private ImageSource funeralImage = "velatorio.png";
        public ImageSource FuneralImage
        {
            get => funeralImage;

            set => SetProperty(ref funeralImage, value);
        }

        private ImageSource personalizedImage = "cruz.png";
        public ImageSource PersonalizedImage
        {
            get => personalizedImage;

            set => SetProperty(ref personalizedImage, value);
        }

        #endregion 

        #region Command Methods

        private Command aniversaryLayoutTapped;
        public Command AniversaryLayoutTapped
        {
            get => aniversaryLayoutTapped ?? (aniversaryLayoutTapped = new Command(() => {

                if (!CrossConnectivity.Current.IsConnected)
                {
                    DependencyService.Get<IAlert>().Alert("Error", "Al parecer no tienes acceso a intenet.");
                    return;
                }

                EventType = "Aniversario";

                //MessagingCenter.Send(this, "EventType", EventType);

                Settings.EventType = EventType;

                _navService.PushAsync(new AddEventPage());
               
            }));
        }

        private Command marriageLayoutTapped;
        public Command MarriageLayoutTapped
        {
            get => marriageLayoutTapped ?? (marriageLayoutTapped = new Command(() => {

                if (!CrossConnectivity.Current.IsConnected)
                {
                    DependencyService.Get<IAlert>().Alert("Error", "Al parecer no tienes acceso a intenet.");
                    return;
                }

                EventType = "Boda";

                //MessagingCenter.Send(this, "EventType", EventType);

                Settings.EventType = EventType;

                _navService.PushAsync(new AddEventPage());

            }));
        }

        private Command birthdayLayoutTapped;
        public Command BirthdayLayoutTapped
        {
            get => birthdayLayoutTapped ?? (birthdayLayoutTapped = new Command( () => {

                if (!CrossConnectivity.Current.IsConnected)
                {
                    DependencyService.Get<IAlert>().Alert("Error", "Al parecer no tienes acceso a intenet.");
                    return;
                }

                EventType = "Cumpleaños";

                //MessagingCenter.Send(this, "EventType", EventType);

                Settings.EventType = EventType;

                _navService.PushAsync(new AddEventPage());
                
            }));
        }

        private Command funeralLayoutTapped;
        public Command FuneralLayoutTapped
        {
            get => funeralLayoutTapped ?? (funeralLayoutTapped = new Command( () => {

                if (!CrossConnectivity.Current.IsConnected)
                {
                    DependencyService.Get<IAlert>().Alert("Error", "Al parecer no tienes acceso a intenet.");
                    return;
                }

                EventType = "Funeral";

                //MessagingCenter.Send(this, "EventType", EventType);

                Settings.EventType = EventType;

                _navService.PushAsync(new AddEventPage());

            }));
        }

        private Command personalizedLayoutTapped;
        public Command PersonalizedLayoutTapped
        {
            get => personalizedLayoutTapped ?? (personalizedLayoutTapped = new Command( () => {

                if (!CrossConnectivity.Current.IsConnected)
                {
                    DependencyService.Get<IAlert>().Alert("Error", "Al parecer no tienes acceso a intenet.");
                    return;
                }

                EventType = "Personalizado";

                //MessagingCenter.Send(this, "EventType", EventType);

                Settings.EventType = EventType;

                _navService.PushAsync(new AddEventPage());
                
            }));
        }
       
        #endregion

        public MainPanelPageViewModel(INavigation navService)
        {
            _navService = navService;
        }
    }
}
