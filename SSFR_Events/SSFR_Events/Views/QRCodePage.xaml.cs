using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SSFR_Events.ViewModels;

namespace SSFR_Events.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QRCodePage : PopupPage
	{

        QRCodeViewModel vm;

		public QRCodePage ()
		{
			InitializeComponent ();

            vm = new QRCodeViewModel();

            BindingContext = vm;
		}
	}
}