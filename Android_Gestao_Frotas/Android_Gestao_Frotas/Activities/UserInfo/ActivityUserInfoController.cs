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
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas.Business.Dashboard;
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Business.UserInfo;
using Core_Gestao_Frotas.Business.Users;

namespace Android_Gestao_Frotas.Activities.UserInfo
{
    [Activity(Label = "Informação de Utilizador", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivityUserInfoController : ActivityBaseController
    {
        public const string UserIdExtra = "USER_ID_EXTRA";

        ActivityUserInfoView MainView;
        Android.Support.V7.Widget.Toolbar Toolbar;

        private List<Profile> _profiles;

        private IBusinessUserInfo _businessUserInfo;

        private User _user;

        private bool _isNewUser = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _businessUserInfo = new BusinessUserInfo();

            LoadView();
            LoadDataAsync();
        }

        private void LoadView()
        {
            MainView = new ActivityUserInfoView(this);
            SetContentView(MainView);

            Toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(Toolbar);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar?.SetHomeButtonEnabled(true);
            Toolbar.NavigationClick += (o, a) => { OnBackPressed(); };

            MainView.OnFinishButtonClick -= MainView_OnFinishButtonClick;
            MainView.OnFinishButtonClick += MainView_OnFinishButtonClick;

            MainView.OnProfileClick -= MainView_OnProfileClick;
            MainView.OnProfileClick += MainView_OnProfileClick;

            MainView.OnStateCheckedChanged -= MainView_OnStateCheckedChanged;
            MainView.OnStateCheckedChanged += MainView_OnStateCheckedChanged;

            MainView.OnNameTextChanged -= MainView_OnNameTextChanged;
            MainView.OnNameTextChanged += MainView_OnNameTextChanged;

            MainView.OnUsernameTextChanged -= MainView_OnUsernameTextChanged;
            MainView.OnUsernameTextChanged += MainView_OnUsernameTextChanged;

            MainView.OnPasswordTextChanged -= MainView_OnPasswordTextChanged;
            MainView.OnPasswordTextChanged += MainView_OnPasswordTextChanged;
        }

        private void MainView_OnPasswordTextChanged(string password)
        {
            _user.Password = password;
        }

        private void MainView_OnUsernameTextChanged(string username)
        {
            _user.Username = username;
        }

        private void MainView_OnNameTextChanged(string name)
        {
            _user.Name = name;
        }

        private void MainView_OnStateCheckedChanged(bool state)
        {
            _user.Active = state;
        }

        private async void MainView_OnProfileClick()
        {
            var profile = await new DialogHelper(this).Pick(_profiles);
            if (profile != null)
                _user.Profile = profile;

            MainView.SetProfileText(profile.Description);
        }

        private async void MainView_OnFinishButtonClick()
        {
            SetLoadingView(true);

            if (_isNewUser)
            {
                var canContinue = ValidateUserInfo();
                if (!canContinue)
                {
                    await new DialogHelper(this).Message($"Ainda existem campos por preencher ou seleccionar.");
                    SetLoadingView(false);
                    return;
                }
                
                var createUserResult = await _businessUserInfo.CreateUser(_user);

                if (createUserResult)
                {
                    var dialogResult = await new DialogHelper(this).Message($"Utilizador criado com sucesso."); 
                    SetResult(Result.Ok);
                    Finish();
                }
                else
                {
                    var dialogResult = await new DialogHelper(this).Message($"Não foi possível criar este utilizador, tente mais tarde.");
                }
            }
            else
            {
                var updateUserResult = await _businessUserInfo.UpdateUser(_user);

                if (updateUserResult)
                {
                    var dialogResult = await new DialogHelper(this).Message($"Utilizador modificado com sucesso.");
                }
                else
                {
                    var dialogResult = await new DialogHelper(this).Message($"Não foi possível modificar este utilizador, tente mais tarde.");
                }
            }

            SetLoadingView(false);
        }

        private bool ValidateUserInfo()
        {
            return !string.IsNullOrEmpty(_user.Name) && 
                !string.IsNullOrEmpty(_user.Username) && 
                _user.Profile != null && 
                _user.Profile.IsIncomplete != true && 
                _user.Profile.Id != BaseModel.Null;
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
                    MainView_OnFinishButtonClick();
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }

        private async void LoadDataAsync()
        {
            SetLoadingView(true);

            var userId = Intent.GetIntExtra(UserIdExtra, BaseModel.Null);

            if (_profiles == null || _profiles.Count == 0)
                _profiles = await _businessUserInfo.GetProfiles();

            if (userId == BaseModel.Null)
            {
                _isNewUser = true;
                _user = new User() { Active = true, Password = await _businessUserInfo.GetDefaultPassword() };
                MainView.UpdateUserInfo(_user, true);
            }
            else
            {
                _isNewUser = false;
                _user = await _businessUserInfo.GetUser(userId);
                MainView.UpdateUserInfo(_user, false);
            }

            SetLoadingView(false);
        }

    }
}