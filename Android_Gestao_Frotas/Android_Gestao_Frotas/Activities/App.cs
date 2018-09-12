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
using Core_Gestao_Frotas.Persistence;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;

namespace Android_Gestao_Frotas.Activities
{
    [Application]
    public class App : Application
    {
        public static string DBPath { get {
                return Path.Combine(DBFolder, DBName);
            } }

        public static string DBFolder
        {
            get
            {
                string documentsPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
                return Path.Combine(documentsPath, "GestaoFrotasFolder/");
            }
        }

        public static string DBName { get {
                return "GestaoFrota.db3";
            } }

        public App(IntPtr handle, JniHandleOwnership ownerShip) : base(handle, ownerShip)
        {

        }

        public override void OnCreate()
        {
            base.OnCreate();
        }
    }
}