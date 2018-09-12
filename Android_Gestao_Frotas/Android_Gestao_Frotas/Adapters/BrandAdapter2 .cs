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
    class BrandAdapter2 : BaseAdapter
    {
        private Context _context;

        private List<Brand> _brands;

        public BrandAdapter2(Context context, IEnumerable<Brand> brands)
        {
            _context = context;
            _brands = brands.ToList();
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return _brands[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            BrandsAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as BrandsAdapterViewHolder;

            if (holder == null)
            {
                holder = new BrandsAdapterViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.item_brand2, parent, false);
                holder.tvBrand = view.FindViewById<TextView>(Resource.Id.tvBrand);

                view.Tag = holder;
            }

            holder.tvBrand.Text = $"{_brands[position].Description}";

            return view;
        }

        public override int Count
        {
            get { return _brands.Count; }
        }
    }

}