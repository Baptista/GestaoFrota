using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.Adapters;

namespace Android_Gestao_Frotas.Activities.Configurations
{

    //public delegate void OnConfigurationClickController(Configurationoption configuration);

    [Activity(Label = "ActivityConfigurationView")]
    public class ActivityConfigurationView : ActivityBaseView
    {

        //LinearLayout bttmudarpassword;
        //LinearLayout bttmudarpassworddefault;
        TabLayout tlConfigurations;
        ViewPager vpConfigurations;
        //public event OnConfigurationClickController OnConfigurationClickController;

        public ActivityConfigurationView(Context context) : base(context)
        {
            LoadView();
        }

        public void MudartabLocal()
        {
            TabLayout.Tab tab = tlConfigurations.GetTabAt(1);
            tab.Select();
        }

        private void LoadView()
        {
            var view = Inflate(Context, Resource.Layout.activity_configurations, this);

            tlConfigurations = view.FindViewById<TabLayout>(Resource.Id.tlConfigurations);
            vpConfigurations = view.FindViewById<ViewPager>(Resource.Id.vpConfigurations);

            tlConfigurations.SetupWithViewPager(vpConfigurations);
            //bttmudarpassword = FindViewById<LinearLayout>(Resource.Id.bttmudarpassword);
            //bttmudarpassworddefault = FindViewById<LinearLayout>(Resource.Id.bttmudarpassworddefault);

            //bttmudarpassword.Click -= Bttmudarpassword_Click;
            //bttmudarpassword.Click += Bttmudarpassword_Click;

            //bttmudarpassworddefault.Click -= Bttmudarpassworddefault_Click;
            //bttmudarpassworddefault.Click += Bttmudarpassworddefault_Click;


        }

        public void SetupViewPager(ConfigurationsFragmentsAdapter fragmentManagerAdapter)
        {
            vpConfigurations.Adapter = fragmentManagerAdapter;
            vpConfigurations.Adapter.NotifyDataSetChanged();
            vpConfigurations.OffscreenPageLimit = 2;
        }

        //private void Bttmudarpassworddefault_Click(object sender, EventArgs e)
        //{
        //    OnConfigurationClickController(Configurationoption.change_default_password);
        //}

        //private void Bttmudarpassword_Click(object sender, EventArgs e)
        //{
        //    OnConfigurationClickController(Configurationoption.change_password);
        //}
    }
}

//public enum Configurationoption
//{
//    change_password = 1,
//    change_default_password = 2
//}