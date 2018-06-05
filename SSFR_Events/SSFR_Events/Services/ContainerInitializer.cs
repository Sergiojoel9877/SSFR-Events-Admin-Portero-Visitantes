
using SSFR_Events.ViewModels;
using CommonServiceLocator;
using Unity;
using Xamarin.Forms;
using Microsoft.EntityFrameworkCore;
using Unity.ServiceLocation;

namespace SSFR_Events.Services
{
    public sealed class ContainerInitializer
    {
        public static void Initialize()
        {
            
            var container = new UnityContainer();

            container.RegisterInstance(typeof(LoginPageViewModel));
            container.RegisterInstance(typeof(AddEventViewModel));
            container.RegisterInstance(typeof(AddGuestViewModel));
            container.RegisterInstance(typeof(MainMasterDetailPageMasterViewModel));
            container.RegisterInstance(typeof(RegisterPageViewModel));
            container.RegisterInstance(typeof(DBRepository));
            container.RegisterInstance(typeof(DBContext));
            container.RegisterType(typeof(DbContextOptionsBuilder));
            container.RegisterType(typeof(DBContext));

            var serviceLocator = new UnityServiceLocator(container);
            
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }
    }
}
