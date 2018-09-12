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
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.Adapters;

namespace Android_Gestao_Frotas.Activities.Vehicles
{
    public delegate void OnNewTypologyClickEvent();

    public delegate void OnNewModelClickEvent();

    public delegate void OnNewBrandClickEvent();

    public delegate void OnNewVehicleClickEvent();

    public class ActivityVehiclesView : ActivityBaseView
    {
        private static bool _isFabOpen;

        public event OnNewTypologyClickEvent OnNewTypologyClick;

        public event OnNewModelClickEvent OnNewModelClick;

        public event OnNewBrandClickEvent OnNewBrandClick;

        public event OnNewVehicleClickEvent OnNewVehicleClick;

        TabLayout tlVehicles;

        ViewPager vpVehicles;

        View vFabBackground;

        FloatingActionButton fabTypology;
        FloatingActionButton fabModel;
        FloatingActionButton fabBrand;
        FloatingActionButton fabVehicle;
        FloatingActionButton fabMain;

        public ActivityVehiclesView(Context context) : base(context)
        {
            LoadView();
        }

        private void LoadView()
        {
            var view = Inflate(Context, Resource.Layout.activity_vehicles, this);

            tlVehicles = view.FindViewById<TabLayout>(Resource.Id.tlVehicles);

            vpVehicles = view.FindViewById<ViewPager>(Resource.Id.vpVehicles);

            vFabBackground = view.FindViewById<View>(Resource.Id.vFabBackground);

            fabTypology = view.FindViewById<FloatingActionButton>(Resource.Id.fabTypology);
            fabModel = view.FindViewById<FloatingActionButton>(Resource.Id.fabModel);
            fabBrand = view.FindViewById<FloatingActionButton>(Resource.Id.fabBrand);
            fabVehicle = view.FindViewById<FloatingActionButton>(Resource.Id.fabVehicle);
            fabMain = view.FindViewById<FloatingActionButton>(Resource.Id.fabMain);

            tlVehicles.SetupWithViewPager(vpVehicles);

            vFabBackground.Click -= VFabBackground_Click;
            vFabBackground.Click += VFabBackground_Click;

            fabTypology.Click -= FabTypology_Click;
            fabTypology.Click += FabTypology_Click;

            fabModel.Click -= FabModel_Click;
            fabModel.Click += FabModel_Click;

            fabBrand.Click -= FabBrand_Click;
            fabBrand.Click += FabBrand_Click;

            fabVehicle.Click -= FabVehicle_Click;
            fabVehicle.Click += FabVehicle_Click;

            fabMain.Click -= FabMain_Click;
            fabMain.Click += FabMain_Click;
        }

        private void FabMain_Click(object sender, EventArgs e)
        {
            if (!_isFabOpen)
                OpenFabMenu();
            else
                CloseFabMenu();
        }

        private void FabVehicle_Click(object sender, EventArgs e)
        {
            CloseFabMenu();
            OnNewVehicleClick?.Invoke();
        }

        private void FabBrand_Click(object sender, EventArgs e)
        {
            CloseFabMenu();
            OnNewBrandClick?.Invoke();
        }

        private void FabModel_Click(object sender, EventArgs e)
        {
            CloseFabMenu();
            OnNewModelClick?.Invoke();
        }

        private void FabTypology_Click(object sender, EventArgs e)
        {
            CloseFabMenu();
            OnNewTypologyClick?.Invoke();
        }

        private void VFabBackground_Click(object sender, EventArgs e)
        {
            CloseFabMenu();
        }

        public void OpenFabMenu()
        {
            _isFabOpen = true;
            fabTypology.Visibility = ViewStates.Visible;
            fabModel.Visibility = ViewStates.Visible;
            fabBrand.Visibility = ViewStates.Visible;
            fabVehicle.Visibility = ViewStates.Visible;
            vFabBackground.Visibility = ViewStates.Visible;

            fabMain.Animate().Rotation(135f);
            vFabBackground.Animate().Alpha(1f);

            fabTypology.Animate()
                .TranslationY(-Resources.GetDimension(Resource.Dimension.standard_190))
                .Rotation(0f);
            fabModel.Animate()
                .TranslationY(-Resources.GetDimension(Resource.Dimension.standard_145))
                .Rotation(0f);
            fabBrand.Animate()
                .TranslationY(-Resources.GetDimension(Resource.Dimension.standard_100))
                .Rotation(0f);
            fabVehicle.Animate()
                .TranslationY(-Resources.GetDimension(Resource.Dimension.standard_55))
                .Rotation(0f);
        }

        public void CloseFabMenu()
        {
            _isFabOpen = false;

            fabMain.Animate().Rotation(0f);
            vFabBackground.Animate().Alpha(0f);

            fabTypology.Animate()
                .TranslationY(0f)
                .Rotation(90f);
            fabModel.Animate()
                .TranslationY(0f)
                .Rotation(90f);
            fabBrand.Animate()
                .TranslationY(0f)
                .Rotation(90f);
            fabVehicle.Animate()
                .TranslationY(0f)
                .Rotation(90f)
                .SetListener(new FabAnimatorListener(vFabBackground, fabVehicle, fabBrand, fabModel, fabTypology));
        }

        public void SetupViewPager(VehiclesFragmentsAdapter fragmentManagerAdapter)
        {
            vpVehicles.Adapter = fragmentManagerAdapter;
            vpVehicles.Adapter.NotifyDataSetChanged();
            vpVehicles.OffscreenPageLimit = 4;
        }

        class FabAnimatorListener : Java.Lang.Object, Animator.IAnimatorListener
        {
            View[] viewsToHide;

            public FabAnimatorListener(params View[] viewsToHide)
            {
                this.viewsToHide = viewsToHide;
            }

            public void OnAnimationCancel(Animator animation)
            {

            }

            public void OnAnimationEnd(Animator animation)
            {
                if (!_isFabOpen)
                    foreach (var view in viewsToHide)
                        view.Visibility = ViewStates.Gone;
            }

            public void OnAnimationRepeat(Animator animation)
            {

            }

            public void OnAnimationStart(Animator animation)
            {

            }
        }
    }
}