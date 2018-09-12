using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.Activities.UserInfo;
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas.Business.Dashboard;
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Business.NewPassword;
using Newtonsoft.Json;

using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Android_Gestao_Frotas.Activities.NewPassword
{
    [Activity(Label = "Gestão da Password", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivityNewPasswordController : ActivityBaseController
    {
        public const string ExtraActionType = "EXTRA_ACTION_TYPE";

        ActivityNewPasswordView MainView;
        V7Toolbar Toolbar;

        private string _currentPassword = string.Empty;
        private string _newPassword = string.Empty;
        private string _confirmNewPassword = string.Empty;
        private int _typeget;

        IBusinessNewPassword _businessNewPassword;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _businessNewPassword = new BusinessNewPassword();

            LoadView();

            LoadType();
        }

        private async void LoadType()
        {
            _typeget = Intent.GetIntExtra(ExtraActionType, 0);

            if (_typeget == 1)
            {
                MainView.Defaultchanges(await _businessNewPassword.GetDefaultPassword());
            }

        }

        public override void OnBackPressed()
        {
            SetResult(Result.Canceled);
            base.OnBackPressed();
        }

        private void LoadView()
        {
            MainView = new ActivityNewPasswordView(this);
            SetContentView(MainView);

            Toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(Toolbar);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar?.SetHomeButtonEnabled(true);
            Toolbar.NavigationClick += (o, a) => { OnBackPressed(); };

            MainView.OnCurrentPasswordTextChanged -= MainView_OnCurrentPasswordChange;
            MainView.OnCurrentPasswordTextChanged += MainView_OnCurrentPasswordChange;

            MainView.OnNewPasswordTextChanged -= MainView_OnNewPasswordChange;
            MainView.OnNewPasswordTextChanged += MainView_OnNewPasswordChange;

            MainView.OnNewPasswordConfirmTextChanged -= MainView_OnNewPasswordConfirmChange;
            MainView.OnNewPasswordConfirmTextChanged += MainView_OnNewPasswordConfirmChange;

            MainView.OnFinishClick -= MainView_OnFinishClick;
            MainView.OnFinishClick += MainView_OnFinishClick;
        }

        private void MainView_OnFinishClick()
        {
            ChangePassword();
        }

        private void MainView_OnNewPasswordConfirmChange(string password)
        {
            _confirmNewPassword = password;
        }

        private void MainView_OnNewPasswordChange(string password)
        {
            _newPassword = password;
        }

        private void MainView_OnCurrentPasswordChange(string password)
        {
            _currentPassword = password;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.userinfo_options_menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_finish:
                    ChangePassword();
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }

        private async void ChangePassword()
        {
            SetLoadingView(true);

            if (_typeget == 0)
            {
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
                            SetResult(Result.Ok);
                            Finish();
                        }
                        else
                        {
                            var response = await new DialogHelper(this).Message($"Não foi possível alterar a password, tente mais tarde.");
                        }
                    }
                    else
                    {
                        var response = await new DialogHelper(this).Message($"A nova password ou a sua confirmação estão inválidas, tente outra vez.");
                    }
                }
                else
                {
                    var response = await new DialogHelper(this).Message($"A password actual que inseriu não corresponde com a sua password actual.");
                }
            }
            else
            {
                var isNewPasswordValid = await _businessNewPassword.ValidateNewPassword(_newPassword, _confirmNewPassword);
                if (isNewPasswordValid)
                {
                    var passwordChangedSuccessfully = await _businessNewPassword.TryChangePasswordDefault(_newPassword);
                    if (passwordChangedSuccessfully)
                    {
                        var response = await new DialogHelper(this).Message($"Password alterada com successo!");
                        SetResult(Result.Ok);
                        Finish();
                    }
                    else
                    {
                        var response = await new DialogHelper(this).Message($"Não foi possível alterar a password, tente mais tarde.");
                    }
                }
                else
                {
                    var response = await new DialogHelper(this).Message($"A nova password ou a sua confirmação estão inválidas, tente outra vez.");
                }
            }

            SetLoadingView(false);
        }
    }

}