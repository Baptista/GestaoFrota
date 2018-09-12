using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.Activities.Dashboard;
using Android_Gestao_Frotas.Activities.Users;
using Android_Gestao_Frotas.Activities.NewRequestVehicles;
using Android_Gestao_Frotas.Activities.Vehicles;
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Login;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Repositories.Profiles;
using Android_Gestao_Frotas.Helpers;
using Newtonsoft.Json;
using Core_Gestao_Frotas;
using Android_Gestao_Frotas.Activities.NewPassword;

namespace Android_Gestao_Frotas.Activities.Login
{
    [Activity(Label = "Login", Theme = "@style/LoginTheme", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivityLoginController : ActivityBaseController
    {
        ActivityLoginView MainView;

        private IBusinessLogin _businessLogin;
        private bool _stateauto = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ISharedPreferences sharedPref = GetSharedPreferences(SharedPreferenceName, FileCreationMode.Private);
            _stateauto = sharedPref.GetBoolean("loginauto", false);

            _businessLogin = new BusinessLogin();

            LoadView();

            if (_stateauto == true)
            {
                var logintext = sharedPref.GetString("autouser", "error");
                var passwordtext = sharedPref.GetString("autopassword", "error");
                OnLoginClick(logintext, passwordtext);
            }
        }

        private void LoadView()
        {
            MainView = new ActivityLoginView(this);
            SetContentView(MainView);

            MainView.OnLoginClick += OnLoginClick;
        }

        private async void OnLoginClick(string username, string password)
        {
            MainView.IsValidatingLogin(true);
//#if DEBUG
//            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
//            {
//                username = "tiago.marques";
//                password = "testes";
//            }
//#endif

            var loginSuccessful = await _businessLogin.Login(username, password);

            if (loginSuccessful)
            {
                if (!AllYouCanGet.CurrentUser.Active)
                {
                    await new DialogHelper(this).Message($"Este utilizador não está activo.");
                    MainView.IsValidatingLogin(false);
                    return;
                }
                else
                {
                    var isPasswordDefault = await _businessLogin.CheckIfPasswordIsDefault();
                    if (isPasswordDefault)
                    {
                        //MainView.IsValidatingLogin(false);
                        var intent = new Intent(this, typeof(ActivityNewPasswordController));
                        intent.PutExtra("tipo", 0);
                        StartActivityForResult(intent, ChangePasswordRequestRequestCode);
                    }
                    else
                    {
                        StartSession();
                    }
                }
            }
            else
            {
                var cenas = await new DialogHelper(this).Message("Username ou password incorretos, tente outravez.");
                MainView.IsValidatingLogin(false);
            }
        }

        private async void StartSession()
        {
            var loadUsersResult = await _businessLogin.LoadUsers();

            if (loadUsersResult)
            {
                var intent = new Intent(this, typeof(ActivityDashboardController));
                StartActivityForResult(intent, NewSessionRequestCode);
            }
            else
            {
                await new DialogHelper(this).Message($"Não foi possível carregar os dados para a applicação, tente mais tarde.");
                MainView.IsValidatingLogin(false);
            }
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            switch (requestCode)
            {
                case ChangePasswordRequestRequestCode:
                    StartSession();
                    break;
                case NewSessionRequestCode:
                    MainView.IsValidatingLogin(false);
                    MainView.Clearform();
                    break;
            }
        }

    }
}