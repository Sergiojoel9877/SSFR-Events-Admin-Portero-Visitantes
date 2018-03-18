using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SSFR_Events.Services;
using SQLiteEntityFramework.cs;
using SSFR_Events.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(DBRepoInstance))]
namespace SSFR_Events.Droid.Services
{
    public class DBRepoInstance : IDBRepoInstance
    {
        DBRepository repo;

        public  IDBRepository getInstance() => 
            
            repo = new DBRepository(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "SSFR_DB.db")        
                
        );

    }
}