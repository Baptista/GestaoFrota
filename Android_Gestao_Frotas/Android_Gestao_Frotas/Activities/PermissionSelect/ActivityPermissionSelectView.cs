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
using Android_Gestao_Frotas.Adapters;
using Core_Gestao_Frotas.Business.Models;

namespace Android_Gestao_Frotas.Activities.PermissionSelect
{

    public delegate void OnTransferPermissionsController(Dictionary<Permission, bool> permissions);

    [Activity(Label = "ActivityPermissionSelectView")]
    public class ActivityPermissionSelectView : ActivityBaseView
    {

        public event OnTransferPermissionsController OnTransferPermissionsController;
        ListView lvPermissionsSelect;

        public ActivityPermissionSelectView(Context context) : base(context)
        {
            LoadView();
        }

        private void LoadView()
        {
            var view = Inflate(Context, Resource.Layout.activity_permissionSelect, this);
            lvPermissionsSelect = view.FindViewById<ListView>(Resource.Id.lvPermissionsSelect);
        }

        public void UpdatePermissionsActive(List<Permission> permissions, Dictionary<Permission, bool> permissionsactive)
        {
            if (permissions != null && permissions.Count > 0)
            {
                var adapter = new PermissionSelectAdapter(Context, permissions, permissionsactive);
                lvPermissionsSelect.Adapter = adapter;
                lvPermissionsSelect.Visibility = ViewStates.Visible;

                adapter.OnTransferPermissions -= Adapter_OnTransferPermissions;
                adapter.OnTransferPermissions += Adapter_OnTransferPermissions;

            }
            else
            {
                lvPermissionsSelect.Visibility = ViewStates.Gone;
                //tvSearchResult.Visibility = ViewStates.Visible;
            }
        }

        private void Adapter_OnTransferPermissions(Dictionary<Permission, bool> permissions)
        {
            OnTransferPermissionsController?.Invoke(permissions);
        }
    }
}