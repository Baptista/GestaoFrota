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
    public delegate void OnApproveClickEvent(RequestHistory requestHistory);

    public delegate void OnCancelClickEvent(RequestHistory requestHistory);

    public class DashboardRequestsForApprovalAdapter : BaseAdapter
    {
        public event OnApproveClickEvent OnApproveClick;
        public event OnCancelClickEvent OnCancelClick;

        private Context _context;

        private List<RequestHistory> _requestsForApproval;

        public DashboardRequestsForApprovalAdapter(Context context, IEnumerable<RequestHistory> requestsForApproval)
        {
            _context = context;
            _requestsForApproval = requestsForApproval.ToList();
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return _requestsForApproval[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            DashboardRequestsForApprovalAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as DashboardRequestsForApprovalAdapterViewHolder;

            if (holder == null)
            {
                holder = new DashboardRequestsForApprovalAdapterViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.item_dashboard_request_for_approval, parent, false);

                holder.ivRequestImage = view.FindViewById<ImageView>(Resource.Id.ivRequestImage);
                holder.tvVehicle = view.FindViewById<TextView>(Resource.Id.tvVehicle);
                holder.tvOwner = view.FindViewById<TextView>(Resource.Id.tvUser);
                holder.tvStartDate = view.FindViewById<TextView>(Resource.Id.tvStartDate);
                holder.tvEndDate = view.FindViewById<TextView>(Resource.Id.tvEndDate);
                holder.imgbtnCancel = view.FindViewById<ImageButton>(Resource.Id.imgbtnCancel);
                holder.imgbtnApprove = view.FindViewById<ImageButton>(Resource.Id.imgbtnApprove);

                if (!holder.HasEvents)
                {
                    holder.imgbtnApprove.Click += delegate { OnImageButtonApproveClicked(position); };
                    holder.imgbtnCancel.Click += delegate { OnImageButtonCancelClicked(position); };

                    holder.HasEvents = true;
                }

                view.Tag = holder;
            }

            holder.tvVehicle.Text = _requestsForApproval[position].Vehicle.ToString();//_requestsForApproval[position].Vehicle.Model.Brand.Description + " - " + _requestsForApproval[position].Vehicle.Model.Description + " - " + _requestsForApproval[position].Vehicle.LicensePlate;
            holder.tvOwner.Text = $"{_requestsForApproval[position].User.Name}";
            holder.tvStartDate.Text = $"{_requestsForApproval[position].StartDate.ToString("dd-MM-yyyy HH:mm")}";
            holder.tvEndDate.Text = $"{_requestsForApproval[position].EndDate.ToString("dd-MM-yyyy HH:mm")}";

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
            get { return _requestsForApproval.Count; }
        }

        private void OnImageButtonApproveClicked(int position)
        {
            var request = _requestsForApproval[position];
            OnApproveClick?.Invoke(request);
        }

        private void OnImageButtonCancelClicked(int position)
        {
            var request = _requestsForApproval[position];
            OnCancelClick?.Invoke(request);
        }
    }

    class DashboardRequestsForApprovalAdapterViewHolder : Java.Lang.Object
    {

        public DashboardRequestsForApprovalAdapterViewHolder()
        {
            HasEvents = false;
        }

        public ImageView ivRequestImage { get; set; }

        public TextView tvVehicle { get; set; }

        public TextView tvOwner { get; set; }

        public TextView tvStartDate { get; set; }

        public TextView tvEndDate { get; set; }

        public ImageButton imgbtnCancel { get; set; }

        public ImageButton imgbtnApprove { get; set; }

        public bool HasEvents { get; set; }

        public int Position { get; set; }
    }
}