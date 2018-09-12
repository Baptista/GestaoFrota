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

    class PerfilAdapter : BaseAdapter<Profile>
    {
        private Context _context;
        private List<Profile> _profiles;

        public PerfilAdapter(Context context, IEnumerable<Profile> profiles)
        {
            _context = context;
            _profiles = profiles.ToList();
        }

        public override Profile this[int position] => throw new NotImplementedException();

        public override int Count
        {
            get { return _profiles.Count; }
        }

        public override long GetItemId(int position)
        {
            return _profiles[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            ProfileAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as ProfileAdapterViewHolder;

            if (holder == null)
            {
                holder = new ProfileAdapterViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.item_perfil, parent, false);
                holder.tvDescription = view.FindViewById<TextView>(Resource.Id.tvType);

                view.Tag = holder;
            }

            holder.tvDescription.Text = $"{_profiles[holder.Position].Description}";

            holder.Position = position;

            return view;
        }

    }



    class ProfileAdapterViewHolder : Java.Lang.Object
    {
        public TextView tvId { get; set; }
        public TextView tvDescription { get; set; }

        public int Position { get; set; }
    }

}