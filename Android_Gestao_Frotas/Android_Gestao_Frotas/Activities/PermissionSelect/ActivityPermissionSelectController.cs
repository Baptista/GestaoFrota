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
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Business.Profiles;

namespace Android_Gestao_Frotas.Activities.PermissionSelect
{
    [Activity(Label = "Permissões", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivityPermissionSelectController : ActivityBaseController
    {

        ActivityPermissionSelectView MainView;
        Android.Support.V7.Widget.Toolbar Toolbar;
        private List<Permission> _permissions;
        IBusinessProfile BusinessProfile = new BusinessProfile();
        private Dictionary<Permission, bool> tempPermissions;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            LoadView();
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            SetLoadingView(true, false, "A carregar Permissões...");
            tempPermissions = new Dictionary<Permission, bool>(AllYouCanGet.editprofile.CurrentPermissions);
            _permissions = (await BusinessProfile.GetPermissions()).ToList();
            MainView.UpdatePermissionsActive(_permissions, tempPermissions);
            SetLoadingView(false);
        }

        private void LoadView()
        {
            MainView = new ActivityPermissionSelectView(this);
            SetContentView(MainView);

            Toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(Toolbar);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar?.SetHomeButtonEnabled(true);
            Toolbar.NavigationClick += (o, a) => { OnBackPressed(); };

            MainView.OnTransferPermissionsController -= MainView_OnTransferPermissionsController;
            MainView.OnTransferPermissionsController += MainView_OnTransferPermissionsController;
        }

        private void MainView_OnTransferPermissionsController(Dictionary<Permission, bool> permissions)
        {
            tempPermissions = permissions;
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
                    AllYouCanGet.editprofile.CurrentPermissions = tempPermissions;
                    SetResult(Result.Ok);
                    Finish();
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }

    }
}