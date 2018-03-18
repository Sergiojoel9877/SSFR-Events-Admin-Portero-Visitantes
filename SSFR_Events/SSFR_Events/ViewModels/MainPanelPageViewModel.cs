using SSFR_Events.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SSFR_Events.ViewModels
{
    public class MainPanelPageViewModel : ViewModelBase
    {
        INavigation _navService;

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

        public MainPanelPageViewModel(INavigation navService)
        {
            _navService = navService;
        }
    }
}
