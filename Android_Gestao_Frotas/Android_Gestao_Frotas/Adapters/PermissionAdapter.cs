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

    public delegate void OnChangePermissionState(int pos);
    public delegate void OnDeletePermission(int pos);

    class PermissionAdapter : BaseAdapter
    {

        public event OnChangePermissionState OnChangePermissionState;
        public event OnDeletePermission OnDeletePermission;

        private Context _context;
        private List<KeyValuePair<Permission,bool>> _permissions;
        private int _type;

        public PermissionAdapter(Context context, Dictionary<Permission, bool> permissions, int type)
        {
            this._context = context;
            this._permissions = permissions.ToList();
            this._type = type;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return _permissions[position].Key.Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            PermissionAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as PermissionAdapterViewHolder;

            if (holder == null)
            {
                holder = new PermissionAdapterViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.item_permission, parent, false);

                holder.tvPermission = view.FindViewById<TextView>(Resource.Id.tvPermission);
                holder.swStatePermission = view.FindViewById<Switch>(Resource.Id.swStatePermission);

                view.Tag = holder;
            }

            holder.tvPermission.Text = _permissions[position].Key.Description;
            holder.swStatePermission.Checked = _permissions[position].Value;

            if (_type == 0)
            {
                holder.swStatePermission.Visibility = ViewStates.Gone;

            }
            else
            {
                holder.swStatePermission.Visibility = ViewStates.Visible;
            }

            if (!holder.HasSwitchMenu)
            {

                holder.swStatePermission.Click += delegate
                {
                    OnChangePermissionState?.Invoke(holder.Position);
                };

                holder.HasSwitchMenu = true;
            }

            if (!holder.HasDeleteMenu)
            {
                view.Click += delegate
                {
                    OnDeletePermission?.Invoke(holder.Position);
                };

                holder.HasDeleteMenu = true;
            }

            holder.Position = position;

            return view;
        }

        public override int Count
        {
            get { return _permissions.Count; }
        }

    }

    class PermissionAdapterViewHolder : Java.Lang.Object
    {

        public PermissionAdapterViewHolder()
        {
            HasSwitchMenu = false;
            HasDeleteMenu = false;
        }

        public TextView tvPermission { get; set; }

        public Switch swStatePermission { get; set; }

        public int Position { get; set; }

        public bool HasSwitchMenu { get; set; }

        public bool HasDeleteMenu { get; set; }
    }
}