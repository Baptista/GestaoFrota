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
using Android_Gestao_Frotas.Activities.NewRequest;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Dashboard;
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Business.NewRequest;
using Core_Gestao_Frotas.Business.Requests;
using Newtonsoft.Json;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Android_Gestao_Frotas.Activities.NewRequestVehicles
{
    [Activity(Label = "Veículos", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivityNewRequestVehiclesController : ActivityBaseController
    {
        public const string ExtraStartDateTimeInBinary = "EXTRA_START_DATE_TIME_BINARY";
        public const string ExtraEndDateTimeInBinary = "EXTRA_END_DATE_TIME_BINARY";
        public const string ExtraIsContinuos = "EXTRA_IS_CONTINUOS";

        ActivityNewRequestVehiclesView MainView;
        V7Toolbar Toolbar;

        private IBusinessNewRequest _businessNewRequest;

        private List<Vehicle> _vehicles;

        private DateTime _startDate;
        private DateTime _endDate;

        private bool _isContinuos;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _businessNewRequest = new BusinessNewRequest();

            LoadView();
            LoadDataAsync();
        }

        private void LoadView()
        {
            MainView = new ActivityNewRequestVehiclesView(this);
            SetContentView(MainView);

            Toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(Toolbar);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar?.SetHomeButtonEnabled(true);
            Toolbar.NavigationClick += (o, a) => { OnBackPressed(); };

            MainView.OnVehicleClick -= MainView_OnVehicleClick;
            MainView.OnVehicleClick += MainView_OnVehicleClick;
        }

        private async void LoadDataAsync()
        {
            SetLoadingView(true);

            _startDate = new DateTime(Intent.GetLongExtra(ExtraStartDateTimeInBinary, 0));
            _endDate = new DateTime(Intent.GetLongExtra(ExtraEndDateTimeInBinary, 0));
            _isContinuos = Intent.GetBooleanExtra(ExtraIsContinuos, false);

            if (_isContinuos)
            {
                _vehicles = await _businessNewRequest.GetAvailableVehicles(_startDate, DateTime.MaxValue);
                MainView.UpdateVehicles(_vehicles);
            }
            else
            {
                _vehicles = await _businessNewRequest.GetAvailableVehicles(_startDate, _endDate);
                MainView.UpdateVehicles(_vehicles);
            }

            SetLoadingView(false);
        }

        private void MainView_OnVehicleClick(Vehicle vehicle)
        {
            var intent = new Intent();
            intent.PutExtra(ActivityNewRequestController.SelectedVehicleIdExtra, vehicle.Id);
            SetResult(Result.Ok, intent);
            Finish();
        }
    }
}