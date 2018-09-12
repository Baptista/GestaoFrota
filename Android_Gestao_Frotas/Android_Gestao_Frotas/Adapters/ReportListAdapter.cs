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
using Core_Gestao_Frotas.Business.Models;

namespace Android_Gestao_Frotas.Adapters
{

    public delegate void OnReportClick(VehicleHistory report, int TypeConsult);

    class ReportListAdapter : BaseAdapter
    {

        private Context _context;
        private List<VehicleHistory> _vehicleHistories;
        private int _typeconsult = 0;

        public event OnReportClick OnReportClick;

        public ReportListAdapter(Context context, IEnumerable<VehicleHistory> requestHistories,int typeconsult)
        {
            this._context = context;
            _vehicleHistories = requestHistories.ToList();
            _typeconsult = typeconsult;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return _vehicleHistories[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            ReportListAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as ReportListAdapterViewHolder;

            if (holder == null)
            {
                holder = new ReportListAdapterViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.item_report, parent, false);
                holder.tvreporttext = view.FindViewById<TextView>(Resource.Id.tvreporttext);
                holder.imgReport = view.FindViewById<ImageButton>(Resource.Id.imgReport);

                holder.Position = position;

                if (!holder.HasClick)
                    {
                        holder.imgReport.Click += delegate { OnReportClickCell(_vehicleHistories[position]); };
                        holder.HasClick = true;
                    }


                view.Tag = holder;
            }

            holder.Position = position;

            if (_typeconsult == 0)
            {
                holder.tvreporttext.Text = _vehicleHistories[position].RequestHistory.User.ToString() + "\n" + _vehicleHistories[position].RequestHistory.Vehicle.ToString();
            }else if (_typeconsult == 1)
            {
                holder.tvreporttext.Text = _vehicleHistories[position].RequestHistory.Vehicle.ToString();
            }else if (_typeconsult == 2)
            {
                holder.tvreporttext.Text = _vehicleHistories[position].RequestHistory.User.ToString();
            }

            return view;
        }

        private void OnReportClickCell(VehicleHistory vehicleHistory)
        {
            OnReportClick?.Invoke(vehicleHistory, _typeconsult);
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get { return _vehicleHistories.Count; }
        }

    }

    class ReportListAdapterViewHolder : Java.Lang.Object
    {
        public ReportListAdapterViewHolder()
        {
            HasClick = false;
        }

        public TextView tvreporttext { get; set; }

        public ImageButton imgReport { get; set; }

        public bool HasClick { get; set; }

        public int Position { get; set; }
    }
}