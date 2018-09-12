using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.Adapters;
using Android_Gestao_Frotas.CustomControls;
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Dashboard;
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;

namespace Android_Gestao_Frotas.Activities.Vehicles.Fragments
{
    public delegate void OnEditVehicleClickEvent(Vehicle vehicle);

    public class FragmentVehicles : Android.Support.V4.App.Fragment
    {
        public event OnEditVehicleClickEvent OnEditVehicleClick;
        
        private List<Vehicle> _vehicles;

        ListView lvVehicles;

        TextView Txterrorpermissionvehicle;

        public FragmentVehicles()
        {

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_vehicles, container, false);

            lvVehicles = view.FindViewById<ListView>(Resource.Id.lvVehicles);
            Txterrorpermissionvehicle = view.FindViewById<TextView>(Resource.Id.txterrorpermissionvehicle);

            if (!AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ViewVehicles))
            {
                lvVehicles.Visibility = ViewStates.Gone;
                Txterrorpermissionvehicle.Visibility = ViewStates.Visible;
            }

            return view;
        }

        public void UpdateVehicles(List<Vehicle> vehicles)
        {
            _vehicles = vehicles;
            var adapter = new FragmentVehiclesAdapter(Context, _vehicles);

            adapter.OnEditVehicleClick -= Adapter_OnEditVehicleClick;
            adapter.OnEditVehicleClick += Adapter_OnEditVehicleClick;

            if (lvVehicles.Adapter != null)
                lvVehicles.Adapter.Dispose();

            lvVehicles.Adapter = adapter;
        }

        private async void Adapter_OnEditVehicleClick(Vehicle vehicle)
        {
            var response = await new DialogHelper(Context).Question($"Pretende editar o veículo {vehicle.Model.Brand.Description} - {vehicle.Model.Description} com a matrícula {vehicle.LicensePlate} pertencente ao utilizador {vehicle.User.Name} ({vehicle.User.Username})?");
            if (response == DialogHelper.DialogResponse.Yes)
                OnEditVehicleClick?.Invoke(vehicle);
        }
    }
}