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
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Models;
using Square.Picasso;

namespace Android_Gestao_Frotas.Adapters
{
    public delegate void OnTerminateRequestClickEvent(RequestHistory request);

    public class DashboardRequestsActiveAdapter : BaseAdapter
    {
        public event OnTerminateRequestClickEvent OnTerminateRequestClick;

        private Context _context;

        private List<RequestHistory> _requestsActive;

        public DashboardRequestsActiveAdapter(Context context, IEnumerable<RequestHistory> requestsActive)
        {
            _context = context;
            _requestsActive = requestsActive.ToList();
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return _requestsActive[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            DashboardRequestsActiveAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as DashboardRequestsActiveAdapterViewHolder;

            if (holder == null)
            {
                holder = new DashboardRequestsActiveAdapterViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.item_dashboard_request_encourse, parent, false);
                holder.ivRequestImage = view.FindViewById<ImageView>(Resource.Id.ivRequestImage);
                holder.tvVehicle = view.FindViewById<TextView>(Resource.Id.tvVehicle);
                holder.tvOwner = view.FindViewById<TextView>(Resource.Id.tvUser);
                holder.tvStartDate = view.FindViewById<TextView>(Resource.Id.tvStartDate);
                holder.tvEndDate = view.FindViewById<TextView>(Resource.Id.tvEndDate);
                holder.imgbtnDontAsk = view.FindViewById<ImageButton>(Resource.Id.imgbtnDontAsk);

                if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.CancelUserRequests))
                {
                    if (!holder.HasEvents)
                    {
                        holder.imgbtnDontAsk.Click += delegate { OnTerminateRequestClick?.Invoke(_requestsActive[position]); };
                    }
                }
                else
                {
                    if (_requestsActive[position].User.Id == AllYouCanGet.CurrentUser.Id)
                    {
                        if (!holder.HasEvents)
                        {
                            holder.imgbtnDontAsk.Click += delegate { OnTerminateRequestClick?.Invoke(_requestsActive[position]); };
                        }
                    }
                    else
                    {
                        holder.imgbtnDontAsk.Visibility = ViewStates.Gone;
                    }
                }

                view.Tag = holder;
            }

            holder.tvVehicle.Text = _requestsActive[position].Vehicle.Model.Brand.Description + /*" - " + _requestsForApproval[position].Vehicle.Model.Description +*/ " - " + _requestsActive[position].Vehicle.LicensePlate;
            holder.tvOwner.Text = $"{_requestsActive[position].User.Name}";
            holder.tvStartDate.Text = $"{_requestsActive[position].StartDate.ToString("dd-MM-yyyy HH:mm")}";
            holder.tvEndDate.Text = $"{_requestsActive[position].EndDate.ToString("dd-MM-yyyy HH:mm")}";
            
            Picasso.With(_context)
                .Load(Resource.Drawable.car_picture_test)
                .Placeholder(Resource.Drawable.ic_car_image)
                .Error(Resource.Drawable.ic_car_image)
                .Resize(111, 111)
                .CenterInside()
                .Transform(new CircleTransform(Color.Red, 2f))
                .Into(holder.ivRequestImage);

            return view;
        }

        public override int Count
        {
            get { return _requestsActive.Count; }
        }

    }

    class DashboardRequestsActiveAdapterViewHolder : Java.Lang.Object
    {
        public DashboardRequestsActiveAdapterViewHolder()
        {
            HasEvents = false;
        }

        public ImageView ivRequestImage { get; set; }

        public TextView tvVehicle { get; set; }

        public TextView tvOwner { get; set; }

        public TextView tvStartDate { get; set; }

        public TextView tvEndDate { get; set; }

        public ImageButton imgbtnDontAsk { get; set; }

        public bool HasEvents { get; set; }

        public int Position { get; set; }
    }
}