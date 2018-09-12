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
using Android_Gestao_Frotas.CustomControls;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Models;

namespace Android_Gestao_Frotas.Adapters
{

    public delegate void OnProfileClick(Profile profile);
    public delegate void OnChangeProfileState(Profile profile);

    class ProfileAdapter : BaseAdapter
    {

        public event OnProfileClick OnProfileClick;
        public event OnChangeProfileState OnChangeProfileState;
        private Context _context;

        private List<Profile> _profiles;

        public ProfileAdapter(Context context, IEnumerable<Profile> profiles)
        {
            this._context = context;
            this._profiles = profiles.ToList();
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return _profiles[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            ProfileViewAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as ProfileViewAdapterViewHolder;

            if (holder == null)
            {
                holder = new ProfileViewAdapterViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.item_profile, parent, false);

                holder.tvProfiletxt = view.FindViewById<TextView>(Resource.Id.tvProfiletxt);
                holder.tvpermissionstxt = view.FindViewById<TextView>(Resource.Id.tvpermissionstxt);
                //holder.swStateProfile = view.FindViewById<Switch>(Resource.Id.swStateProfile);
                holder.tvStateProfile = view.FindViewById<ActiveTextView>(Resource.Id.tvStateProfile);
                holder.imgbtnOptionsProfile = view.FindViewById<ImageButton>(Resource.Id.imgbtnOptionsProfile);

                view.Tag = holder;
            }

            var counted = 0;
            foreach (var item in _profiles[position].Permissions)
            {
                if (item.Value == true)
                {
                    counted = counted + 1;
                }
            }

            //holder.swStateProfile.Checked = _profiles[position].Active;
            holder.tvProfiletxt.Text = _profiles[position].Description;
            holder.tvpermissionstxt.Text = "Permissões: " + _profiles[position].Permissions.Count.ToString() + " ( " +counted + " ativas)";
            holder.tvStateProfile.Text = $"Estado: " + (_profiles[position].Active ? $"Ativo" : $"Inativo");
            holder.tvStateProfile.IsActive = _profiles[position].Active;

            if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ManageProfiles))
            {
                if (!holder.HasOptionMenu)
                {
                    holder.imgbtnOptionsProfile.Click += delegate { OnOptionsClick(holder); };
                    holder.HasOptionMenu = true;
                }
            }
            else
            {
                holder.imgbtnOptionsProfile.Visibility = ViewStates.Gone;
            }

            //if (!holder.HasClick)
            //{

            //    view.Click += delegate
            //    {
            //        OnProfileClick?.Invoke(_profiles[holder.Position]);
            //    };

            //    holder.HasClick = true;
            //}

            //if (!holder.HasSwitchClick)
            //{

            //    holder.swStateProfile.Click += delegate
            //    {
            //        OnChangeProfileState?.Invoke(_profiles[holder.Position]);
            //        if (holder.swStateProfile.Checked == false)
            //        {
            //            holder.swStateProfile.Checked = true;
            //        }
            //    };

            //    holder.HasSwitchClick = true;
            //}

            holder.Position = position;

            return view;
        }

        private void OnOptionsClick(ProfileViewAdapterViewHolder holder)
        {
            var popupMenu = new PopupMenu(_context, holder.imgbtnOptionsProfile, GravityFlags.AxisClip);
            popupMenu.MenuInflater.Inflate(Resource.Menu.options_menu, popupMenu.Menu);
            popupMenu.MenuItemClick += async (sender, args) =>
            {
                switch (args.Item.ItemId)
                {
                    case Resource.Id.nav_change:
                        OnProfileClick?.Invoke(_profiles[holder.Position]);
                        break;
                    case Resource.Id.nav_active:
                        OnChangeProfileState?.Invoke(_profiles[holder.Position]);
                        break;
                }
            };
            popupMenu.Show();
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get { return _profiles.Count; }
        }

    }

    class ProfileViewAdapterViewHolder : Java.Lang.Object
    {

        public ProfileViewAdapterViewHolder()
        {
            HasOptionMenu = false;
        }

        public TextView tvProfiletxt { get; set; }

        public TextView tvpermissionstxt { get; set; }

        public ActiveTextView tvStateProfile { get; set; }

        public ImageButton imgbtnOptionsProfile { get; set; }

        public int Position { get; set; }

        public bool HasOptionMenu { get; set; }
    }
}