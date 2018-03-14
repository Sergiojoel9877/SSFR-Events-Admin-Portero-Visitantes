using SSFR_Events.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SSFR_Events.Models
{

    public class MainMasterDetailPageMenuItem
    {
        public MainMasterDetailPageMenuItem()
        {
            TargetType = typeof(MainMasterDetailPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public Type TargetType { get; set; } 
        public ImageSource ImageSource { get; set; } 
    }
}