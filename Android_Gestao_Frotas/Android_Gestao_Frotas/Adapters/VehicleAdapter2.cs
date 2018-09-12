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
using Android_Gestao_Frotas.Activities.NewRequestVehicles;
using Android_Gestao_Frotas.CustomControls;
using Core_Gestao_Frotas.Business.Models;
using Newtonsoft.Json;

namespace Android_Gestao_Frotas.Adapters
{

    public delegate void OnInsertRequest(Vehicle vehicle);

    class VehicleAdapter2 : BaseAdapter
    {

        public event OnInsertRequest OnInsertRequest;

        private Context _context;
        private List<Vehicle> _vehicles;

        public VehicleAdapter2(Context context, IEnumerable<Vehicle> vehicles)
        {
            _context = context;
            _vehicles = vehicles.ToList();
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return _vehicles[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            VehicleAdapterViewHolder2 holder = null;

            if (view != null)
                holder = view.Tag as VehicleAdapterViewHolder2;

            if (holder == null)
            {
                holder = new VehicleAdapterViewHolder2();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.item_vehicle2, parent, false);
                holder.tvTitulo = view.FindViewById<TextView>(Resource.Id.tvTitulo);
                holder.tvMatricula = view.FindViewById<TextView>(Resource.Id.tvMatricula);

                view.Click += (o, e) => { Clickvehicle(_vehicles[position]); };

                view.Tag = holder;
            }

            holder.tvTitulo.Text = $"{_vehicles[position].Model.Brand.Description} - {_vehicles[position].Model.Description}";
            holder.tvMatricula.Text = $"{_vehicles[position].LicensePlate}";

            return view;
        }

        private void Clickvehicle(Vehicle vehicle)
        {
            OnInsertRequest?.Invoke(vehicle);
        }

        public override int Count
        {
            get { return _vehicles.Count; }
        }

    }

    class VehicleAdapterViewHolder2 : Java.Lang.Object
    {

        public VehicleAdapterViewHolder2()
        {
            HasOptionMenu = false;
        }

        public ActiveTextView tvState { get; set; }
        public ImageButton ibtnOptions { get; set; }
        public TextView tvTitulo { get; set; }
        public TextView tvMatricula { get; set; }
        public bool HasOptionMenu { get; set; }
        public int Position { get; set; }
    }

}
