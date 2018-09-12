using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.Activities.ProfileInfo;
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Business.Profiles;
using Newtonsoft.Json;

namespace Android_Gestao_Frotas.Activities.ProfileList
{
    [Activity(Label = "Lista de Perfis", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivityProfileListController : ActivityBaseController
    {

        Android.Support.V7.Widget.Toolbar Toolbar;

        ActivityProfileListView MainView;
        List<Profile> _profiles;
        IBusinessProfile BusinessProfile = new BusinessProfile();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            LoadView();
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            SetLoadingView(true);
            _profiles = (await BusinessProfile.GetProfiles()).ToList();
            MainView.UpdateProfiles(_profiles);
            SetLoadingView(false);
        }

        private async void LoadDataAsyncNew(string mensagem)
        {
            _profiles = new List<Profile>();
            var dialogResult = await new DialogHelper(this).Message(mensagem);
            SetLoadingView(true);
            _profiles = (await BusinessProfile.GetProfilesNew()).ToList();
            MainView.UpdateProfiles(_profiles);
            SetLoadingView(false);
        }

        private void LoadView()
        {
            MainView = new ActivityProfileListView(this);
            SetContentView(MainView);

            Toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(Toolbar);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar?.SetHomeButtonEnabled(true);
            Toolbar.NavigationClick += (o, a) => { OnBackPressed(); };

            MainView.OnNewProfile -= MainView_OnNewProfile;
            MainView.OnNewProfile += MainView_OnNewProfile;

            MainView.OnProfileClickController -= MainView_OnProfileClickController;
            MainView.OnProfileClickController += MainView_OnProfileClickController;

            MainView.OnChangeProfileStateController -= MainView_OnChangeProfileStateController;
            MainView.OnChangeProfileStateController += MainView_OnChangeProfileStateController;

        }

        private async void MainView_OnChangeProfileStateController(Profile profile)
        {
            SetLoadingView(true);
            var ready = 0;
            if (profile.Active == true)
            {
                ready = await BusinessProfile.CheckUserStatusProfile(profile);
            }

            var result = false;
            if (ready == 0)
            {
                result = await BusinessProfile.UpdateProfileState(profile);
            }
            else
            {
                var dialogResult = await new DialogHelper(this).Message("Não é possível inativar o perfil. Existem utilizadores, ativos com o perfil associado.");
                int index = _profiles.FindIndex(a => a == profile);
            }
            SetLoadingView(false);

            if (result == true)
            {
                var dialog = string.Empty;

                if (profile.Active == true)
                {
                    dialog = "O perfil foi desactivado com sucesso.";
                }
                else if (profile.Active == false)
                {
                    dialog = "O perfil foi ativado com sucesso.";
                }
                LoadDataAsyncNew(dialog);
            }
        }

        private void MainView_OnProfileClickController(Profile profile)
        {
            //Toast.MakeText(this, profile.Description, ToastLength.Long).Show();
            var intent = new Intent(this, typeof(ActivityProfileInfoController));
            //var profiletosend = profile;
            //var dictionarytosend = profile.Permissions;
            //profiletosend.Permissions = new Dictionary<Permission, bool>();
            intent.PutExtra("profile", profile.Id);
            intent.PutExtra("tipo", 1);
            StartActivityForResult(intent, EditProfileCode);
        }

        private void MainView_OnNewProfile()
        {
            var intent = new Intent(this, typeof(ActivityProfileInfoController));
            intent.PutExtra("tipo", 0);
            StartActivityForResult(intent, NewProfileCode);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            switch (requestCode)
            {
                case NewProfileCode:
                    if (resultCode == Result.Ok)
                    {
                        LoadDataAsyncNew("Criação de perfil realizada com sucesso.");
                    }
                    break;
                case EditProfileCode:
                    if (resultCode == Result.Ok)
                    {
                        LoadDataAsyncNew("Alteração aos detalhes do perfil realizada com sucesso.");
                    }
                    break;
            }

        }

    }
}