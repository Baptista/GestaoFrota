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
using Android_Gestao_Frotas.Adapters;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Models;

namespace Android_Gestao_Frotas.Activities.ProfileList
{

    public delegate void OnProfileClickController(Profile profile);
    public delegate void OnNewProfile();
    public delegate void OnChangeProfileStateController(Profile profile);

    [Activity(Label = "ActivityProfileListView")]
    public class ActivityProfileListView : ActivityBaseView
    {

        ListView lvProfiles;
        TextView tvNoProfilesToShow;
        FloatingActionButton fabNewProfile;
        public event OnNewProfile OnNewProfile;
        public event OnProfileClickController OnProfileClickController;
        public event OnChangeProfileStateController OnChangeProfileStateController;
        ProfileAdapter adapter;

        public ActivityProfileListView(Context context) : base(context)
        {
            LoadView();
        }

        private void LoadView()
        {
            var view = Inflate(Context, Resource.Layout.activity_profilelist, this);
            lvProfiles = view.FindViewById<ListView>(Resource.Id.lvProfiles);
            tvNoProfilesToShow = view.FindViewById<TextView>(Resource.Id.tvNoProfilesToShow);
            fabNewProfile = view.FindViewById<FloatingActionButton>(Resource.Id.fabNewProfile);

            fabNewProfile.Click -= FabNewProfile_Click;
            fabNewProfile.Click += FabNewProfile_Click;

            if (!AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ManageProfiles))
            {
                fabNewProfile.Visibility = ViewStates.Gone;
            }

        }

        private void FabNewProfile_Click(object sender, EventArgs e)
        {
            OnNewProfile?.Invoke();
        }

        public void UpdateProfiles(List<Profile> profiles)
        {
            if (profiles != null && profiles.Count > 0)
            {
                tvNoProfilesToShow.Visibility = ViewStates.Gone;
                lvProfiles.Visibility = ViewStates.Visible;

                adapter = new ProfileAdapter(Context, profiles);
                lvProfiles.Adapter = adapter;

                adapter.OnProfileClick -= Adapter_OnProfileClick;
                adapter.OnProfileClick += Adapter_OnProfileClick;

                adapter.OnChangeProfileState -= Adapter_OnChangeProfileState;
                adapter.OnChangeProfileState += Adapter_OnChangeProfileState;

            }
            else
            {
                lvProfiles.Visibility = ViewStates.Gone;
                tvNoProfilesToShow.Visibility = ViewStates.Visible;
            }
        }

        private void Adapter_OnChangeProfileState(Profile profile)
        {
            OnChangeProfileStateController?.Invoke(profile);
        }

        private void Adapter_OnProfileClick(Profile profile)
        {
            OnProfileClickController?.Invoke(profile);
        }
    }
}