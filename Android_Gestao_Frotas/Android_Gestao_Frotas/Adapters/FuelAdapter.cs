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
using Java.Lang;

namespace Android_Gestao_Frotas.Adapters
{
    class FuelAdapter : BaseAdapter
    {

        private Context _context;

        private List<Fuel> _Fuels;

        public FuelAdapter(Context context, IEnumerable<Fuel> fuels)
        {
            _context = context;
            _Fuels = fuels.ToList();
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return _Fuels[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            FuelsAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as FuelsAdapterViewHolder;

            if (holder == null)
            {
                holder = new FuelsAdapterViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.item_fuel, parent, false);
                holder.tvFuel = view.FindViewById<TextView>(Resource.Id.tvFuel);

                view.Tag = holder;
            }

            holder.tvFuel.Text = $"{_Fuels[position].Description}";

            return view;
        }

        public override int Count
        {
            get { return _Fuels.Count; }
        }

    }

    class FuelsAdapterViewHolder : Java.Lang.Object
    {
        public TextView tvFuel { get; set; }
    }

}