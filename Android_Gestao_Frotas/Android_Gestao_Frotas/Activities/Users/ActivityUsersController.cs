using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.Activities.ProfileList;
using Android_Gestao_Frotas.Activities.UserInfo;
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Dashboard;
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Business.Users;
using static Android.Support.V7.App.ActionBar;
using static Android_Gestao_Frotas.Helpers.DialogHelper;

namespace Android_Gestao_Frotas.Activities.Users
{
    [Activity(Label = "Utilizadores", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivityUsersController : ActivityBaseController
    {
        Android.Support.V7.Widget.Toolbar Toolbar;

        ActivityUsersView MainView;

        private IBusinessUsers _businessUsers;
        private List<User> _users;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            _businessUsers = new BusinessUsers();

            LoadView();
            LoadDataAsync();
        }

        private void LoadView()
        {
            MainView = new ActivityUsersView(this);
            SetContentView(MainView);

            Toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(Toolbar);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar?.SetHomeButtonEnabled(true);
            Toolbar.NavigationClick += (o, a) => { OnBackPressed(); };

            MainView.OnNewUserClick -= MainView_OnFabClick;
            MainView.OnNewUserClick += MainView_OnFabClick;

            MainView.OnUserEditClick -= MainView_OnUserEditClick;
            MainView.OnUserEditClick += MainView_OnUserEditClick;

            MainView.OnUserChangeStateClick -= MainView_OnUserChangeStateClick;
            MainView.OnUserChangeStateClick += MainView_OnUserChangeStateClick;

            MainView.OnUserResetPasswordClick -= MainView_OnUserResetPasswordClick;
            MainView.OnUserResetPasswordClick += MainView_OnUserResetPasswordClick;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_profile:
                    //Toast.MakeText(this, "It Works!", ToastLength.Short).Show();
                    StartActivity(typeof(ActivityProfileListController));
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ViewProfiles))
            {
                MenuInflater.Inflate(Resource.Menu.users_profile_menu, menu);
            }
            return true;
        }

        private async void MainView_OnUserResetPasswordClick(User user)
        {
            var result = await new DialogHelper(this).Question($"Tem a certeza que pretende repor a password deste utilizador({user.Username})?");
            if (result == DialogResponse.Yes)
            {
                SetLoadingView(true);

                var passReset = await _businessUsers.ResetUserPassword(user);
                if (passReset)
                    await new DialogHelper(this).Message($"Password do utilizador({user.Username}) alterada com sucesso.");
                else
                    await new DialogHelper(this).Message($"Não foi possível repor a password, tente mais tarde.");

                SetLoadingView(false);
            }
        }

        private async void MainView_OnUserChangeStateClick(User user)
        {
            var stateChanged = false;
            if (user.Active)
            {
                var result = await new DialogHelper(this).Question($"Tem a certeza que pretende inativar este utilizador({user.Username})?");
                if (result == DialogResponse.Yes)
                {
                    SetLoadingView(true);
                    stateChanged = await _businessUsers.ChangeUserState(user.Id, !user.Active);
                }
                else
                    return;
            }
            else
            {
                var result = await new DialogHelper(this).Question($"Tem a certeza que pretende ativar este utilizador({user.Username})?");
                if (result == DialogResponse.Yes)
                {
                    SetLoadingView(true);
                    var change = await _businessUsers.CheckUserProfileStatus(user);
                    if (change == true)
                    {
                        SetLoadingView(true);
                        stateChanged = await _businessUsers.ChangeUserState(user.Id, !user.Active);
                    }
                    else
                    {
                        await new DialogHelper(this).Message($"Não é possivel alterar o estado. O perfil do utilizador encontra-se inactivo");
                        return;
                    }
                }
                else
                    return;
            }

            if (stateChanged)
            {
                await new DialogHelper(this).Message($"Estado alterado com sucesso.");
                LoadDataAsync();
            }
            else
            {
                await new DialogHelper(this).Message($"Não foi possível alterar o estado deste utilizador({user.Username}).");
                SetLoadingView(true);
            }
        }

        private void MainView_OnUserEditClick(User user)
        {
            var intent = new Intent(this, typeof(ActivityUserInfoController));
            intent.PutExtra(ActivityUserInfoController.UserIdExtra, user.Id);
            StartActivityForResult(intent, EditUserRequestCode);
        }

        private void MainView_OnFabClick()
        {
            var intent = new Intent(this, typeof(ActivityUserInfoController));
            intent.PutExtra(ActivityUserInfoController.UserIdExtra, BaseModel.Null);
            StartActivityForResult(intent, NewUserRequestCode);
        }

        private async void LoadDataAsync()
        {
            SetLoadingView(true);

            _users = (await _businessUsers.GetUsers()).ToList();
            MainView.UpdateUsers(_users);

            SetLoadingView(false);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            switch (requestCode)
            {
                case EditUserRequestCode:
                    if (resultCode == Result.Ok)
                    {
                        LoadDataAsync();
                    }
                    else
                    {
                        //TODO: something
                    }
                    break;
                case NewUserRequestCode:
                    if (resultCode == Result.Ok)
                    {
                        LoadDataAsync();
                    }
                    else
                    {
                        //TODO: something
                    }
                    break;
            }
        }
    }
}