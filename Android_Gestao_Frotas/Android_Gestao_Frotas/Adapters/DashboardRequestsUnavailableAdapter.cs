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

    public delegate void OnRefreshRequestClickEvent(RequestHistory requestHistory);

    public class DashboardRequestsUnavailableAdapter : BaseAdapter
    {
        public event OnRefreshRequestClickEvent OnRefreshRequestClick;

        private Context _context;

        private List<RequestHistory> _requestsUnavailable;

        public DashboardRequestsUnavailableAdapter(Context context, IEnumerable<RequestHistory> requestsUnavailable)
        {
            _context = context;
            _requestsUnavailable = requestsUnavailable.ToList();
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return _requestsUnavailable[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            DashboardRequestsUnavailableAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as DashboardRequestsUnavailableAdapterViewHolder;

            if (holder == null)
            {
                holder = new DashboardRequestsUnavailableAdapterViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.item_dashboard_request_unavailable, parent, false);
                holder.ivRequestImage = view.FindViewById<ImageView>(Resource.Id.ivRequestImage);
                holder.tvVehicle = view.FindViewById<TextView>(Resource.Id.tvVehicle);
                holder.tvOwner = view.FindViewById<TextView>(Resource.Id.tvUser);
                holder.tvKms = view.FindViewById<TextView>(Resource.Id.tvKms);
                holder.tvKmsContract = view.FindViewById<TextView>(Resource.Id.tvKmsContract);
                holder.imgbtnRefresh = view.FindViewById<ImageButton>(Resource.Id.imgbtnRefresh);

                if (!holder.HasEvents)
                {
                    holder.imgbtnRefresh.Click += delegate { OnRefreshRequestClick?.Invoke(_requestsUnavailable[holder.Position]); };
                    holder.HasEvents = true;
                }

                view.Tag = holder;
            }

            holder.tvVehicle.Text = _requestsUnavailable[position].Vehicle.ToString();//_requestsUnavailable[position].Vehicle.Model.Brand.Description + /*" - " + _requestsForApproval[position].Vehicle.Model.Description +*/ " - " + _requestsUnavailable[position].Vehicle.LicensePlate;
            holder.tvOwner.Text = $"{_requestsUnavailable[position].User.Name}";
            holder.tvKms.Text = $"{_requestsUnavailable[position].Vehicle.StartKms}";
            holder.tvKmsContract.Text = $"{_requestsUnavailable[position].Vehicle.ContractKms}";

            Picasso.With(_context)
                .Load(Resource.Drawable.car_picture_test)
                .Placeholder(Resource.Drawable.ic_car_image)
                .Error(Resource.Drawable.ic_car_image)
                .Resize(111, 111)
                .CenterInside()
                .Transform(new CircleTransform(Color.Red, 2f))
                .Into(holder.ivRequestImage);

            holder.Position = position;

            return view;
        }

        public override int Count
        {
            get { return _requestsUnavailable.Count; }
        }
    }

    class DashboardRequestsUnavailableAdapterViewHolder : Java.Lang.Object
    {
        public DashboardRequestsUnavailableAdapterViewHolder()
        {
            HasEvents = false;
        }

        public ImageView ivRequestImage { get; set; }

        public TextView tvVehicle { get; set; }

        public TextView tvOwner { get; set; }

        public TextView tvKms { get; set; }

        public TextView tvKmsContract { get; set; }

        public ImageButton imgbtnRefresh { get; set; }

        public bool HasEvents { get; set; }

        public int Position { get; set; }
    }
}