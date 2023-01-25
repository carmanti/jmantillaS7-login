using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using jmantillaS7.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
[assembly: Xamarin.Forms.Dependency(typeof(SqlCliente))]

namespace jmantillaS7.Droid
{
    public class SqlCliente : Database
    {
        public SQLiteAsyncConnection GetConnnection()
        {
            var docPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(docPath, "uisrael.db3");
                return new SQLiteAsyncConnection(path);
        }
    }
}