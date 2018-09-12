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

namespace Android_Gestao_Frotas.Activities.ProfileInfo
{
    public delegate void OnDeletePermissionController(int pos);
    public delegate void OnChangePermissionStateController(int pos);
    public delegate void OnStateChangeProfile(bool state);

    public delegate void OnProfileNameChange(string name);
    public delegate void AddPermissao();

    [Activity(Label = "ActivityProfileInfoView")]
    public class ActivityProfileInfoView : ActivityBaseView
    {

        public event OnDeletePermissionController OnDeletePermissionController;
        public event OnChangePermissionStateController OnChangePermissionStateController;

        public event OnProfileNameChange OnProfileNameChange;
        public event AddPermissao AddPermissao;
        ImageButton btnAddPermission;
        ListView lvPermissions;
        TextView profilename;
        public event OnStateChangeProfile OnStateChangeProfile;

        LinearLayout statehidden;
        Switch swStateProfile;

        public ActivityProfileInfoView(Context context) : base(context)
        {
            LoadView();
        }

        private void LoadView()
        {
            var view = Inflate(Context, Resource.Layout.activity_profileinfo, this);
            btnAddPermission = view.FindViewById<ImageButton>(Resource.Id.btnAddPermission);
            lvPermissions = view.FindViewById<ListView>(Resource.Id.lvPermissions);
            profilename = view.FindViewById<TextView>(Resource.Id.etNamePerfil);
            statehidden = view.FindViewById<LinearLayout>(Resource.Id.statehidden);
            swStateProfile = view.FindViewById<Switch>(Resource.Id.swStateProfile);

            btnAddPermission.Click -= BtnAddPermission_Click;
            btnAddPermission.Click += BtnAddPermission_Click;

            profilename.TextChanged -= Profilename_TextChanged;
            profilename.TextChanged += Profilename_TextChanged;

            swStateProfile.Click -= SwStateProfile_Click;
            swStateProfile.Click += SwStateProfile_Click;

        }

        private void SwStateProfile_Click(object sender, EventArgs e)
        {
            OnStateChangeProfile(swStateProfile.Checked);
        }

        public void ChangeProfileStateStart(bool estado)
        {
            swStateProfile.Checked = estado;
        }

        public void ChangeLayoutState(bool estado)
        {
            if (estado == true)
            {
                statehidden.Visibility = ViewStates.Visible;
            }else if (estado == false)
            {
                statehidden.Visibility = ViewStates.Gone;
            }
        }

        private void Profilename_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            OnProfileNameChange?.Invoke(profilename.Text);
        }

        private void BtnAddPermission_Click(object sender, EventArgs e)
        {
            AddPermissao?.Invoke();
        }

        public void UpdatePermissionsProfile(Dictionary<Permission, bool> permissions, int tipo)
        {
            if (permissions != null && permissions.Count > 0)
            {
                lvPermissions.Visibility = ViewStates.Visible;

                var adapter = new PermissionAdapter(Context, permissions, tipo);
                lvPermissions.Adapter = adapter;

                adapter.OnDeletePermission -= Adapter_OnDeletePermission;
                adapter.OnDeletePermission += Adapter_OnDeletePermission;

                adapter.OnChangePermissionState -= Adapter_OnChangePermissionState;
                adapter.OnChangePermissionState += Adapter_OnChangePermissionState;

            }
            else
            {
                lvPermissions.Visibility = ViewStates.Gone;
            }
        }

        private void Adapter_OnDeletePermission(int pos)
        {
            OnDeletePermissionController?.Invoke(pos);
        }

        private void Adapter_OnChangePermissionState(int pos)
        {
            OnChangePermissionStateController?.Invoke(pos);
        }

        public void Changeprofiletext(string name)
        {
            profilename.Text = name;
        }

    }
}