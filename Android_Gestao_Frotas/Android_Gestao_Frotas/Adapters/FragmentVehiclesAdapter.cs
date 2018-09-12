using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.CustomControls;
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Models;
using Java.Lang;
using Square.Picasso;

namespace Android_Gestao_Frotas.Adapters
{
    public delegate void OnEditVehicleClickEvent(Vehicle vehicle);

    public delegate void OnVehicleClickEvent(Vehicle vehicle);

    public class FragmentVehiclesAdapter : BaseAdapter
    {
        public event OnEditVehicleClickEvent OnEditVehicleClick;

        public event OnVehicleClickEvent OnVehicleClick;

        private Context _context;

        private List<Vehicle> _vehicles;
        private List<int> _positionsWithOpenDetails;

        private bool _canEdit;

        public FragmentVehiclesAdapter(Context context, IEnumerable<Vehicle> vehicles, bool canEdit = true)
        {
            _context = context;
            _vehicles = vehicles.ToList();
            _positionsWithOpenDetails = new List<int>();
            _canEdit = canEdit;
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
            VehicleViewHolder holder = null;

            if (view != null)
                holder = view.Tag as VehicleViewHolder;

            if (holder == null)
            {
                holder = new VehicleViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.item_fragment_vehicles_vehicle, parent, false);

                holder.tvVehicle = view.FindViewById<TextView>(Resource.Id.tvVehicle);
                holder.tvLicensePlate = view.FindViewById<TextView>(Resource.Id.tvLicensePlate);
                holder.tvUser = view.FindViewById<TextView>(Resource.Id.tvUser);
                holder.tvTypology = view.FindViewById<TextView>(Resource.Id.tvTypology);
                holder.tvFuel = view.FindViewById<TextView>(Resource.Id.tvFuel);
                holder.tvKms = view.FindViewById<TextView>(Resource.Id.tvKms);
                holder.tvContractsKms = view.FindViewById<TextView>(Resource.Id.tvContractsKms);
                holder.tvEdit = view.FindViewById<TextView>(Resource.Id.tvEdit);

                holder.atvState = view.FindViewById<ActiveTextView>(Resource.Id.atvState);

                holder.imgbtnDetails = view.FindViewById<ImageButton>(Resource.Id.imgbtnDetails);

                holder.ivImage = view.FindViewById<ImageView>(Resource.Id.ivImage);

                holder.llDetails = view.FindViewById<LinearLayout>(Resource.Id.llDetails);
                holder.llRoot = view.FindViewById<LinearLayout>(Resource.Id.llRoot);

                if (!holder.HasEvents)
                {
                    holder.imgbtnDetails.Click += delegate {
                        if (holder.IsDetailsOpen)
                        {
                            _positionsWithOpenDetails.Remove(holder.Position);
                            holder.llDetails.Visibility = ViewStates.Gone;
                            holder.IsDetailsOpen = false;
                            holder.imgbtnDetails.SetImageDrawable(ContextCompat.GetDrawable(_context, Resource.Drawable.ic_arrow_down));
                        }
                        else
                        {
                            _positionsWithOpenDetails.Add(holder.Position);
                            holder.llDetails.Visibility = ViewStates.Visible;
                            holder.IsDetailsOpen = true;
                            holder.imgbtnDetails.SetImageDrawable(ContextCompat.GetDrawable(_context, Resource.Drawable.ic_arrow_up));
                        }
                    };


                    if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ManageVehicles))
                       {
                          holder.tvEdit.Click += delegate
                          {
                             OnEditVehicleClick?.Invoke(_vehicles[holder.Position]);
                          };
                       }else{
                            holder.imgbtnDetails.Visibility = ViewStates.Gone;
                        }

                        holder.llRoot.Click += delegate {
                        OnVehicleClick?.Invoke(_vehicles[holder.Position]);
                    };

                    holder.HasEvents = true;
                }

                holder.Position = position;

                view.Tag = holder;
            }
            else if (holder.Position != position)
            {
                holder.Position = position;
                holder.IsDetailsOpen = _positionsWithOpenDetails.Where((pos) => { return pos == holder.Position; }).Any();
            }

            var vehicle = _vehicles[position];

            holder.tvVehicle.Text = $"{vehicle.Model.Brand.Description} - {vehicle.Model.Description}";
            holder.tvLicensePlate.Text = $"{vehicle.LicensePlate}";
            holder.tvUser.Text = $"{vehicle.User.Name} ({vehicle.User.Username})";
            holder.tvTypology.Text = $"{vehicle.Typology.Description}";
            holder.tvFuel.Text = $"{vehicle.Model.Fuel.Description}";
            holder.tvKms.Text = $"{vehicle.StartKms}";
            holder.tvContractsKms.Text = $"{vehicle.ContractKms}";

            holder.atvState.Text = _vehicles[position].Active ? $"Ativo" : $"Inativo";
            holder.atvState.IsActive = _vehicles[position].Active;

            Picasso.With(_context)
                .Load(Resource.Drawable.car_picture_test)
                .Placeholder(Resource.Drawable.ic_car_image)
                .Error(Resource.Drawable.ic_car_image)
                .Resize(111, 111)
                .CenterInside()
                .Transform(new CircleTransform(Color.Red, 2f))
                .Into(holder.ivImage);

            if (holder.IsDetailsOpen)
            {
                holder.llDetails.Visibility = ViewStates.Visible;
                holder.imgbtnDetails.SetImageDrawable(ContextCompat.GetDrawable(_context, Resource.Drawable.ic_arrow_up));
            }
            else
            {
                holder.llDetails.Visibility = ViewStates.Gone;
                holder.imgbtnDetails.SetImageDrawable(ContextCompat.GetDrawable(_context, Resource.Drawable.ic_arrow_down));
            }

            if (_canEdit)
                holder.tvEdit.Visibility = ViewStates.Visible;
            else
                holder.tvEdit.Visibility = ViewStates.Invisible;

            return view;
        }
        
        public override int Count
        {
            get { return _vehicles.Count; }
        }
    }

    class VehicleViewHolder : Java.Lang.Object
    {
        public VehicleViewHolder()
        {
            IsDetailsOpen = false;
            HasEvents = false;
        }

        public ImageView ivImage { get; set; }

        public TextView tvVehicle { get; set; }

        public TextView tvLicensePlate { get; set; }

        public TextView tvUser { get; set; }

        public TextView tvTypology { get; set; }

        public TextView tvFuel { get; set; }

        public TextView tvKms { get; set; }

        public TextView tvContractsKms { get; set; }

        public TextView tvEdit { get; set; }

        public ImageButton imgbtnDetails { get; set; }

        public LinearLayout llDetails { get; set; }

        public LinearLayout llRoot { get; set; }

        public ActiveTextView atvState { get; set; }

        public bool IsDetailsOpen { get; set; }

        public bool HasEvents { get; set; }

        public int Position { get; set; }
    }

}