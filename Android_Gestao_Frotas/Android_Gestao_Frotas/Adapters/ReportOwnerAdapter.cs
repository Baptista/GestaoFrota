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

    class ReportOwnerAdapter : BaseAdapter
    {

        private List<Vehicle> _vehicles;
        private List<VehicleHistory> _vehicleHistory;
        private List<RequestHistory> _requests;
        private Context _context;
        private User _user;
        private DateTime _datestart;
        private DateTime _datefinish;
        private int _type;

        public ReportOwnerAdapter(Context context, IEnumerable<RequestHistory> requests, IEnumerable<VehicleHistory> vehicleHistory, IEnumerable<Vehicle> vehicles, User user,DateTime datainicio, DateTime datafim, int type)
        {
            this._context = context;
            this._vehicles = vehicles.ToList();
            this._vehicleHistory = vehicleHistory.ToList();
            this._requests = requests.ToList();
            this._user = user;
            this._datestart = datainicio;
            this._datefinish = datafim;
            this._type = type;

            _requests.RemoveAll(x => x.User.Id != _user.Id);


           if (_type == 1)
            {
                _requests.RemoveAll(y => y.StartDate < _datestart);
                _requests.RemoveAll(z => z.EndDate > _datefinish);
            }

            //_vehicleHistory.RemoveAll(x => !_requests.Contains(x.RequestHistory));
            _vehicleHistory = _vehicleHistory.Where((c) => 
            {
                return _requests.FirstOrDefault((b) =>
                {
                    return b.Id == c.RequestHistory.Id;
                }) != null;
            }).ToList();

        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return _vehicleHistory[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            ReportOwnerAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as ReportOwnerAdapterViewHolder;

            if (holder == null)
            {
                holder = new ReportOwnerAdapterViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.item_report_owner, parent, false);
                holder.tvVehicleReport = view.FindViewById<TextView>(Resource.Id.tvVehicleReport);
                holder.tvDateStartReport = view.FindViewById<TextView>(Resource.Id.tvDateStartReport);
                holder.tvDateFinishReport = view.FindViewById<TextView>(Resource.Id.tvDateFinishReport);
                holder.tvKmsReport = view.FindViewById<TextView>(Resource.Id.tvKmsReport);
                holder.tvTimeReport = view.FindViewById<TextView>(Resource.Id.tvTimeReport);

                view.Tag = holder;
            }

            RequestHistory requestchosen = _requests.First((r) =>
            {
                return (r.Id == _vehicleHistory[position].RequestHistory.Id);
            });

            Vehicle veiculochosen = _vehicles.First((s) => {
                return (s.Id == requestchosen.Vehicle.Id);
            });

            var hours = (int) ((requestchosen.EndDate - requestchosen.StartDate).TotalHours);

            holder.tvVehicleReport.Text = veiculochosen.ToString();
            holder.tvDateStartReport.Text = "Início: " + requestchosen.StartDate.ToString("dd-MM-yyyy");
            holder.tvDateFinishReport.Text = "Fim: " + requestchosen.EndDate.ToString("dd-MM-yyyy");
            holder.tvKmsReport.Text = "kms: " + _vehicleHistory[position].Kms.ToString();
            holder.tvTimeReport.Text = "Tempo: " + hours.ToString() + " horas";

            return view;
        }

        public override int Count
        {
            get { return _vehicleHistory.Count; }
        }

    }

    class ReportOwnerAdapterViewHolder : Java.Lang.Object
    {
        public TextView tvVehicleReport { get; set; }

        public TextView tvDateStartReport { get; set; }

        public TextView tvDateFinishReport { get; set; }

        public TextView tvKmsReport { get; set; }

        public TextView tvTimeReport { get; set; }
    }
}