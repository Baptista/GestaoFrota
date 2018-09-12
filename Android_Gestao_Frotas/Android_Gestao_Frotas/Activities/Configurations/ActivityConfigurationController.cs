using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.Activities.Configurations.Fragments;
using Android_Gestao_Frotas.Activities.NewPassword;
using Android_Gestao_Frotas.Activities.Splash;
using Android_Gestao_Frotas.Adapters;
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Business.NewPassword;
using Newtonsoft.Json;

namespace Android_Gestao_Frotas.Activities.Configurations
{
    [Activity(Label = "Configurações", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivityConfigurationController : ActivityBaseController
    {

        ActivityConfigurationView MainView;
        Android.Support.V7.Widget.Toolbar Toolbar;

        FragmentGlobal _fragmentGlobal;
        FragmentLocal _fragmentLocal;

        public const string ConfigurationExtraTest = "CONFIGURATION_EXTRA";

        private string _currentPasswordDefault = string.Empty;
        private string _newPasswordDefault = string.Empty;
        private string _confirmNewPasswordDefault = string.Empty;

        private string _currentPassword = string.Empty;
        private string _newPassword = string.Empty;
        private string _confirmNewPassword = string.Empty;
        private bool _stateauto = false;

        private int _launchconfigurations = 0;

        IBusinessNewPassword _businessNewPassword = new BusinessNewPassword();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            LoadView();

            Toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(Toolbar);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar?.SetHomeButtonEnabled(true);
            Toolbar.NavigationClick += (o, a) => { OnBackPressed(); };

            _launchconfigurations = Intent.GetIntExtra(ConfigurationExtraTest, 0);

            _fragmentGlobal = new FragmentGlobal();
            _fragmentLocal = new FragmentLocal();

            var adapter = new ConfigurationsFragmentsAdapter(SupportFragmentManager);
            adapter.AddFragment(_fragmentGlobal, "Globais");
            adapter.AddFragment(_fragmentLocal, "Locais");

            MainView.SetupViewPager(adapter);

            LoadDefaultPassword();

            if (_launchconfigurations == 1)
            {
                MainView.MudartabLocal();
            }

            _fragmentGlobal.OncetNewPasswordConfigurationDefaultChange -= _fragmentGlobal_OncetNewPasswordConfigurationDefaultChange;
            _fragmentGlobal.OncetNewPasswordConfigurationDefaultChange += _fragmentGlobal_OncetNewPasswordConfigurationDefaultChange;

            _fragmentGlobal.OncetNewPasswordConfirmationConfigurationDefaultChange -= _fragmentGlobal_OncetNewPasswordConfirmationConfigurationDefaultChange;
            _fragmentGlobal.OncetNewPasswordConfirmationConfigurationDefaultChange += _fragmentGlobal_OncetNewPasswordConfirmationConfigurationDefaultChange;

            _fragmentGlobal.OncetCurrentPasswordConfigurationChange -= _fragmentGlobal_OncetCurrentPasswordConfigurationChange;
            _fragmentGlobal.OncetCurrentPasswordConfigurationChange += _fragmentGlobal_OncetCurrentPasswordConfigurationChange;

            _fragmentGlobal.OncetNewPasswordConfigurationChange -= _fragmentGlobal_OncetNewPasswordConfigurationChange;
            _fragmentGlobal.OncetNewPasswordConfigurationChange += _fragmentGlobal_OncetNewPasswordConfigurationChange;

            _fragmentGlobal.OncetNewPasswordConfirmationConfigurationChange -= _fragmentGlobal_OncetNewPasswordConfirmationConfigurationChange;
            _fragmentGlobal.OncetNewPasswordConfirmationConfigurationChange += _fragmentGlobal_OncetNewPasswordConfirmationConfigurationChange;

            _fragmentLocal.OnLoginAutomaticoClick -= _fragmentLocal_OnLoginAutomaticoClick;
            _fragmentLocal.OnLoginAutomaticoClick += _fragmentLocal_OnLoginAutomaticoClick;

            _fragmentLocal.OnResetApplicationClick -= _fragmentLocal_OnResetApplicationClick;
            _fragmentLocal.OnResetApplicationClick += _fragmentLocal_OnResetApplicationClick;
            //MainView.OnConfigurationClickController -= MainView_OnConfigurationClickController;
            //MainView.OnConfigurationClickController += MainView_OnConfigurationClickController;

            //ISharedPreferences sharedPref = GetPreferences(FileCreationMode.Private);
            //ISharedPreferencesEditor editor = sharedPref.Edit();
            //editor.PutBoolean("loginauto", true);
            //editor.PutString("autouser", AllYouCanGet.CurrentUser.Username);
            //editor.PutString("autopassword", AllYouCanGet.CurrentUser.Password);
            //editor.Commit();

        }

        private async void _fragmentLocal_OnResetApplicationClick()
        {
            var response = await new DialogHelper(this).Question("Tem a certeza que deseja limpar completamente os seus dados?");
            if (response == DialogHelper.DialogResponse.Yes)
            {
                ISharedPreferences sharedPref = GetSharedPreferences(SharedPreferenceName, FileCreationMode.Private);
                ISharedPreferencesEditor editor = sharedPref.Edit();
                editor.Clear().Commit();
                var dbFolder = new Java.IO.File(App.DBFolder);
                //dbFolder.Delete();
                DeleteDirectory(dbFolder.ToString());

                Intent intent = new Intent(this, typeof(ActivitySplashController));
                intent.SetFlags(ActivityFlags.NewTask|ActivityFlags.ClearTop|ActivityFlags.ClearTask);
                StartActivity(intent);

            }
        }

        public static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }

        private void _fragmentLocal_OnLoginAutomaticoClick()
        {
            ISharedPreferences sharedPref = GetSharedPreferences(SharedPreferenceName, FileCreationMode.Private);
            ISharedPreferencesEditor editor = sharedPref.Edit();

            if (_stateauto == false)
            {
                _stateauto = true;
                editor.PutBoolean("loginauto", _stateauto);
                editor.PutString("autouser", AllYouCanGet.CurrentUser.Username);
                editor.PutString("autopassword", AllYouCanGet.CurrentUser.Password);
            }
            else if (_stateauto == true)
            {
                _stateauto = false;
                editor.PutBoolean("loginauto", _stateauto);
            }

            editor.Commit();
            _fragmentLocal.ChangeAutoLoginStatus(_stateauto);

        }

        private void _fragmentGlobal_OncetNewPasswordConfirmationConfigurationChange(string text)
        {
            _confirmNewPassword = text;
        }

        private void _fragmentGlobal_OncetNewPasswordConfigurationChange(string text)
        {
            _newPassword = text;
        }

        private void _fragmentGlobal_OncetCurrentPasswordConfigurationChange(string text)
        {
            _currentPassword = text;
        }

        private void _fragmentGlobal_OncetNewPasswordConfirmationConfigurationDefaultChange(string text)
        {
            _confirmNewPasswordDefault = text;
        }

        private void _fragmentGlobal_OncetNewPasswordConfigurationDefaultChange(string text)
        {
            _newPasswordDefault = text;
        }

        public async override void OnBackPressed()
        {
            if (_currentPassword == string.Empty && _newPassword == string.Empty && _confirmNewPassword == string.Empty && _newPasswordDefault == string.Empty && _confirmNewPasswordDefault == string.Empty)
            {
                base.OnBackPressed();
            }
            else
            {
                var response = await new DialogHelper(this).Question("Tem alterações não guardadas, deseja sair?");
                if (response == DialogHelper.DialogResponse.Yes)
                {
                    base.OnBackPressed();
                }
            }

        }

        private async void LoadDefaultPassword()
        {
            SetLoadingView(true);
            var passwordget = await _businessNewPassword.GetDefaultPassword();
            await Task.Delay(2000);
            _currentPasswordDefault = passwordget;
            _fragmentGlobal.Setdefaultpassword(passwordget);

            ISharedPreferences sharedPref = GetSharedPreferences(SharedPreferenceName, FileCreationMode.Private);
            _stateauto = sharedPref.GetBoolean("loginauto", false);
            _fragmentLocal.ChangeAutoLoginStatus(_stateauto);

            SetLoadingView(false);
        }

        //private void MainView_OnConfigurationClickController(Configurationoption configuration)
        //{
        //    if (configuration == Configurationoption.change_password)
        //    {
        //        var intent = new Intent(this, typeof(ActivityNewPasswordController));
        //        intent.PutExtra("user", JsonConvert.SerializeObject(AllYouCanGet.CurrentUser));
        //        intent.PutExtra(ActivityNewPasswordController.ExtraActionType, 0);
        //        StartActivityForResult(intent, ChangePasswordRequestRequestCode);
        //    }
        //    else if (configuration == Configurationoption.change_default_password)
        //    {
        //        var intent = new Intent(this, typeof(ActivityNewPasswordController));
        //        intent.PutExtra("user", JsonConvert.SerializeObject(AllYouCanGet.CurrentUser));
        //        intent.PutExtra(ActivityNewPasswordController.ExtraActionType, 1);
        //        StartActivityForResult(intent, ChangeDefaultPasswordRequestCode);
        //    }
        //}

        private void LoadView()
        {
            MainView = new ActivityConfigurationView(this);
            SetContentView(MainView);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.configuration_menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_configuration_accept:
                    SaveDataAsync();
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }

        private async void SaveDataAsync()
        {
            bool correct1 = true;
            bool correct2 = true;

            SetLoadingView(true);
            if (_currentPassword != string.Empty && _newPassword != string.Empty && _confirmNewPassword != string.Empty)
            {
                correct1 = await ChangePassword();
            }
            if (_currentPasswordDefault != string.Empty && _newPasswordDefault != string.Empty && _confirmNewPasswordDefault != string.Empty)
            {
                correct2 = await ChangePasswordDefault();
            }
            SetLoadingView(false);
            if (correct1 == true && correct2 == true)
            {
                SetResult(Result.Ok);
                Finish();
            }
        }

        private async Task<bool> ChangePasswordDefault()
        {
            var a = false;

            var isNewPasswordValid = await _businessNewPassword.ValidateNewPassword(_newPasswordDefault, _confirmNewPasswordDefault);
            if (isNewPasswordValid)
            {
                var passwordChangedSuccessfully = await _businessNewPassword.TryChangePasswordDefault(_newPasswordDefault);
                if (passwordChangedSuccessfully)
                {
                    var response = await new DialogHelper(this).Message($"Password Default alterada com successo!");
                    a = passwordChangedSuccessfully;
                }
                else
                {
                    var response = await new DialogHelper(this).Message($"Não foi possível alterar a password, tente mais tarde.");
                    a = false;
                }
            }
            else
            {
                var response = await new DialogHelper(this).Message($"A nova password ou a sua confirmação estão inválidas, tente outra vez.");
                a = false;
            }

            return a;
        }

        private async Task<bool> ChangePassword()
        {
            bool a = false;
            var isCurrentPassword = await _businessNewPassword.IsCurrentPassword(_currentPassword);
            if (isCurrentPassword)
            {
                var isNewPasswordValid = await _businessNewPassword.ValidateNewPassword(_newPassword, _confirmNewPassword);
                if (isNewPasswordValid)
                {
                    var passwordChangedSuccessfully = await _businessNewPassword.TryChangePassword(_newPassword);
                    if (passwordChangedSuccessfully)
                    {
                        var response = await new DialogHelper(this).Message($"Password alterada com successo!");
                        a = passwordChangedSuccessfully;
                    }
                    else
                    {
                        var response = await new DialogHelper(this).Message($"Não foi possível alterar a password, tente mais tarde.");
                        a = false;
                    }
                }
                else
                {
                    var response = await new DialogHelper(this).Message($"A nova password ou a sua confirmação estão inválidas, tente outra vez.");
                    a = false;
                }
            }
            else
            {
                var response = await new DialogHelper(this).Message($"A password actual que inseriu não corresponde com a sua password actual.");
                a = false;
            }
            return a;
        }
    }
}