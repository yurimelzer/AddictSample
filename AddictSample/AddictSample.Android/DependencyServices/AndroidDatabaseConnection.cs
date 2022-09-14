using AddictSample.PlatformServices;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(AddictSample.Droid.DependencyServices.AndroidDatabaseConnection))]
namespace AddictSample.Droid.DependencyServices
{
    public class AndroidDatabaseConnection : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            string dbName = "AddictDB.db3";
            string documentFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return new SQLiteConnection(Path.Combine(documentFolder, dbName));
        }
    }
}