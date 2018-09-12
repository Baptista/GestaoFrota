using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.Activities.Login;
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Splash;
using Core_Gestao_Frotas.Persistence;
using Core_Gestao_Frotas.Persistence.Repositories;
using Core_Gestao_Frotas.Services.Splash;
using SQLite.Net.Platform.XamarinAndroid;

namespace Android_Gestao_Frotas.Activities.Splash
{
    [Activity(Label = "Gestão de Frotas", MainLauncher = true, Theme = "@style/SplashTheme", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivitySplashController : ActivityBaseController
    {
        private string[] AllPermissions = {
            Manifest.Permission.Camera,
            Manifest.Permission.WriteExternalStorage };

        private const int PermissionsRequestCode = 111;

        ActivitySplashView MainView;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RunOnUiThread(() => { LoadView(); });

            if (!IsAllPermissionsGranted())
            {
                await new DialogHelper(this).Message("Para utilizar esta aplicação terá que autorizar as seguintes permissões:\n\n   - Camera;\n   - External Storage;\n\n", "Permissões");
                LoadPermissions();
            }
            else
            {
                Navigate();
            }
        }

        private void LoadView()
        {
            MainView = new ActivitySplashView(this);
            SetContentView(MainView);

            MainView.ShowLoading();
        }

        private void LoadPermissions()
        {
            foreach (var permission in AllPermissions)
            {
                if (!IsPermissionGranted(permission))
                {
                    RequestPermission(permission);
                    return;
                }
            }

            Navigate();
        }

        private async Task LoadApp()
        {
            var dbFolder = new Java.IO.File(App.DBFolder);
            if (!dbFolder.Exists() || !dbFolder.IsDirectory)
                dbFolder.Mkdir();

            var basePersistence = new BaseRepository();
            var resultPersistence = await basePersistence.Create(App.DBPath, new SQLitePlatformAndroidN());

            if (!resultPersistence)
                await basePersistence.Reset(App.DBPath, new SQLitePlatformAndroidN());

            IBusinessSplash businessSplash = new BusinessSplash();
            var result = await businessSplash.LoadAppSettingsAndConfigurations();

            return;
        }

        private void RequestPermission(string permission)
        {
            ActivityCompat.RequestPermissions(this, new string[] { permission }, PermissionsRequestCode);
        }

        private bool IsPermissionGranted(string permission)
        {
            if (ContextCompat.CheckSelfPermission(this, permission) != Permission.Granted)
                return false;

            return true;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            switch (requestCode)
            {
                case PermissionsRequestCode:
                    if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                    {
                        if (!IsAllPermissionsGranted())
                            LoadPermissions();
                        else
                            Navigate();
                    }
                    else
                    {
                        Process.KillProcess(Process.MyPid());
                    }

                    break;
            }
        }

        private bool IsAllPermissionsGranted()
        {
            foreach (var permission in AllPermissions)            
                if (!IsPermissionGranted(permission))
                    return false;

            return true;
        }

        private async void Navigate()
        {
            await LoadApp();
            StartActivity(typeof(ActivityLoginController));
        }
    }
}