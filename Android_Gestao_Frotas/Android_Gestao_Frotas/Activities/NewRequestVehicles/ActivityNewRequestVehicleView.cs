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

namespace Android_Gestao_Frotas.Activities.NewRequestVehicles
{
    public delegate void OnVehicleClickEvent(Vehicle vehicle);
    
    public class ActivityNewRequestVehiclesView : ActivityBaseView
    {
        public event OnVehicleClickEvent OnVehicleClick;

        ListView lvVehicles;

        public ActivityNewRequestVehiclesView(Context context) : base(context)
        {
            LoadView();
        }

        private void LoadView()
        {
            var view = Inflate(Context, Resource.Layout.activity_newrequestvehicles, this);
            lvVehicles = view.FindViewById<ListView>(Resource.Id.lvVehicles);
        }

        public void UpdateVehicles(List<Vehicle> vehiclelist)
        {
            var adapter = new FragmentVehiclesAdapter(Context, vehiclelist, false);

            adapter.OnVehicleClick -= Adapter_OnVehicleClick;
            adapter.OnVehicleClick += Adapter_OnVehicleClick;

            lvVehicles.Adapter = adapter;
        }

        private void Adapter_OnVehicleClick(Vehicle vehicle)
        {
            OnVehicleClick?.Invoke(vehicle);
        }
    }
}