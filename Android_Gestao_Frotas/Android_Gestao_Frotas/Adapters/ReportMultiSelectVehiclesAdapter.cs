using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas.Business.Models;
using Square.Picasso;

namespace Android_Gestao_Frotas.Adapters
{
    public class ReportMultiSelectVehiclesAdapter : BaseAdapter
    {
        private Context _context;

        private List<Vehicle> _vehicles;
        private List<int> _selectedVehicleIds;

        public ReportMultiSelectVehiclesAdapter(Context context, List<Vehicle> vehicles, List<int> selectedVehicleIds)
        {
            _context = context;
            _vehicles = vehicles;
            _selectedVehicleIds = selectedVehicleIds;
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
            ReportMultiSelectVehiclesAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as ReportMultiSelectVehiclesAdapterViewHolder;

            if (holder == null)
            {
                holder = new ReportMultiSelectVehiclesAdapterViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                
                view = inflater.Inflate(Resource.Layout.item_multiselectvehicles, parent, false);

                holder.llRoot = view.FindViewById<LinearLayout>(Resource.Id.llRoot);

                holder.ivImage = view.FindViewById<ImageView>(Resource.Id.ivImage);

                holder.tvVehicle = view.FindViewById<TextView>(Resource.Id.tvVehicle);
                holder.tvLicensePlate = view.FindViewById<TextView>(Resource.Id.tvLicensePlate);
                holder.tvUser = view.FindViewById<TextView>(Resource.Id.tvUser);

                holder.chkVehicle = view.FindViewById<CheckBox>(Resource.Id.chkVehicle);

                holder.Position = position;

                if (!holder.HasEvents)
                {
                    holder.llRoot.Click += delegate { holder.chkVehicle.Checked = !holder.chkVehicle.Checked; };

                    holder.chkVehicle.CheckedChange += delegate { VehicleClick(holder); };

                    holder.HasEvents = true;
                }

                view.Tag = holder;
            }

            holder.Position = position;

            var vehicle = _vehicles[holder.Position];

            holder.tvVehicle.Text = $"{vehicle.Model.Brand.Description} - {vehicle.Model.Description}";
            holder.tvLicensePlate.Text = $"{vehicle.LicensePlate}";
            holder.tvUser.Text = $"{vehicle.User}";

            Picasso.With(_context)
                .Load(Resource.Drawable.car_picture_test)
                .Placeholder(Resource.Drawable.ic_car_image)
                .Error(Resource.Drawable.ic_car_image)
                .Resize(111, 111 )
                .CenterInside()
                .Transform(new CircleTransform(Color.Red, 2f))
                .Into(holder.ivImage);

            holder.chkVehicle.Checked = _selectedVehicleIds.Contains(vehicle.Id);

            return view;
        }

        public override int Count
        {
            get { return _vehicles.Count; }
        }

        private void VehicleClick(ReportMultiSelectVehiclesAdapterViewHolder holder)
        {
            var vehicle = _vehicles[holder.Position];

            holder.IsChecked = holder.chkVehicle.Checked;
            if (holder.IsChecked)
            {
                if (!_selectedVehicleIds.Contains(vehicle.Id))
                    _selectedVehicleIds.Add(vehicle.Id);
            }
            else
            {
                if (_selectedVehicleIds.Contains(vehicle.Id))
                    _selectedVehicleIds.Remove(_selectedVehicleIds.First(v => v == vehicle.Id));
            }

            NotifyDataSetChanged();
        }

        public List<int> GetSelectedVehicleIds()
        {
            return  _selectedVehicleIds;
        }
    }

    class ReportMultiSelectVehiclesAdapterViewHolder : Java.Lang.Object
    {
        public ReportMultiSelectVehiclesAdapterViewHolder()
        {
            IsChecked = false;
            HasEvents = false;
        }

        public LinearLayout llRoot { get; set; }

        public ImageView ivImage { get; set; }

        public TextView tvVehicle { get; set; }

        public TextView tvLicensePlate { get; set; }

        public TextView tvUser { get; set; }

        public CheckBox chkVehicle { get; set; }

        public int Position { get; set; }

        public bool IsChecked { get; set; }

        public bool HasEvents { get; set; }
    }
}