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

    public delegate void OnTransferPermissions(Dictionary<Permission, bool> permissions);

    class PermissionSelectAdapter : BaseAdapter
    {

        private Context _context;

        private List<Permission> _permissions;
        private Dictionary<Permission, bool> _permissionsuser;
        public event OnTransferPermissions OnTransferPermissions;

        public PermissionSelectAdapter(Context context, IEnumerable<Permission> permissions, Dictionary<Permission, bool> permissionsuser)
        {
            this._context = context;
            this._permissions = permissions.ToList();
            this._permissionsuser = permissionsuser;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return _permissions[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            PermissionSelectAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as PermissionSelectAdapterViewHolder;

            if (holder == null)
            {
                holder = new PermissionSelectAdapterViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.item_permissionSelect, parent, false);
                holder.tvPermissionSelect = view.FindViewById<TextView>(Resource.Id.tvPermissionSelect);
                holder.cbPermission = view.FindViewById<CheckBox>(Resource.Id.cbPermission);

                holder.Position = position;

                if (!holder.HasClickCheck)
                {
                    holder.cbPermission.Click += delegate { OnCheckClick(holder, _permissions[holder.Position]); };
                    holder.HasClickCheck = true;
                }

                view.Tag = holder;
            }

            holder.Position = position;

            holder.tvPermissionSelect.Text = _permissions[position].Description;
            holder.cbPermission.Checked = false;

            foreach (var item in _permissionsuser)
            {
                if (_permissions[position].Id == item.Key.Id)
                {
                    holder.cbPermission.Checked = true;
                }
            }

            return view;
        }

        private void OnCheckClick(PermissionSelectAdapterViewHolder holder, Permission permission)
        {
            if (holder.cbPermission.Checked == false)
            {

                var toRemove = _permissionsuser.Where(pair => pair.Key.Id == permission.Id)
                         .Select(pair => pair.Key)
                         .ToList();

                foreach (var key in toRemove)
                {
                    _permissionsuser.Remove(key);
                }

            }
            else if (holder.cbPermission.Checked == true)
            {
                _permissionsuser.Add(permission, true);
            }
            OnTransferPermissions?.Invoke(_permissionsuser);
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get { return _permissions.Count; }
        }

    }

    class PermissionSelectAdapterViewHolder : Java.Lang.Object
    {
        public PermissionSelectAdapterViewHolder()
        {
            HasClickCheck = false;
        }
        public TextView tvPermissionSelect { get; set; }

        public CheckBox cbPermission { get; set; }

        public bool HasClickCheck { get; set; }

        public int Position { get; set; }
    }
}