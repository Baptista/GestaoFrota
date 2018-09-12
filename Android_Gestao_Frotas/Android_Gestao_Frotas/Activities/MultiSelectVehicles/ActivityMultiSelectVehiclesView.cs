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

namespace Android_Gestao_Frotas.Activities.MultiSelectVehicles
{
    public class ActivityMultiSelectVehiclesView : ActivityBaseView
    {
        ListView lvVehicles;

        public ActivityMultiSelectVehiclesView(Context context) : base(context)
        {
            LoadView();
        }

        private void LoadView()
        {
            var view = Inflate(Context, Resource.Layout.activity_multiselectvehicles, this);

            lvVehicles = view.FindViewById<ListView>(Resource.Id.lvVehicles);
        }

        public void SetVehicles(List<Vehicle> vehicles, List<int> selected)
        {
            if (lvVehicles.Adapter != null)
                lvVehicles.Adapter = null;

            var adapter = new ReportMultiSelectVehiclesAdapter(Context, vehicles, selected);
            
            lvVehicles.Adapter = adapter;
        }

        public void SetUsers(List<User> users, List<int> selected)
        {
            if (lvVehicles.Adapter != null)
                lvVehicles.Adapter = null;

            var adapter = new ReportMultiSelectUsersAdapter(Context, users, selected);

            lvVehicles.Adapter = adapter;
        }

        public List<int> GetSelectedVehiclesFromListAdapter()
        {
            var adapter = (lvVehicles.Adapter as ReportMultiSelectVehiclesAdapter);
            if (adapter != null)
                return adapter.GetSelectedVehicleIds();
            else
                return new List<int>();
        }

        public List<int> GetSelectedUsersFromListAdapter()
        {
            var adapter = (lvVehicles.Adapter as ReportMultiSelectUsersAdapter);
            if (adapter != null)
                return adapter.GetSelectedUserIds();
            else
                return new List<int>();
        }
    }
}