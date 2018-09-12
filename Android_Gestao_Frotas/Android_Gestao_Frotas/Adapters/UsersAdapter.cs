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
using Android_Gestao_Frotas.CustomControls;
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Models;
using Square.Picasso;

namespace Android_Gestao_Frotas.Adapters
{
    public delegate void OnUserOptionClickEvent(User user, OptionType option);

    public enum OptionType
    {
        ResetPassword = 0,
        ChangeState = 1,
        Edit = 2
    }

    public class UsersAdapter : BaseAdapter
    {
        public event OnUserOptionClickEvent OnUserOptionClick;

        private Context _context;

        private List<User> _users;

        public UsersAdapter(Context context, IEnumerable<User> users)
        {
            _context = context;
            _users = users.ToList();
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return _users[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            UserAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as UserAdapterViewHolder;

            if (holder == null)
            {
                holder = new UserAdapterViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.item_users_user, parent, false);

                holder.ivUserImage = view.FindViewById<ImageView>(Resource.Id.ivUserImage);
                holder.tvUsername = view.FindViewById<TextView>(Resource.Id.tvUsername);
                holder.tvProfile = view.FindViewById<TextView>(Resource.Id.tvProfile);
                holder.tvState = view.FindViewById<ActiveTextView>(Resource.Id.tvState);
                holder.ibtnOptions = view.FindViewById<ImageButton>(Resource.Id.ibtnOptions);

                view.Tag = holder;
            }

            holder.tvUsername.Text = $"Username: {_users[position].Username}";
            holder.tvProfile.Text = $"Perfil: {_users[position].Profile.Description}";
            holder.tvState.Text = $"Estado: " + (_users[position].Active ? $"Ativo" : $"Inativo");

            holder.tvState.IsActive = _users[position].Active;

            Picasso.With(_context)
                .Load(Resource.Drawable.user_picture_test)
                .Placeholder(Resource.Drawable.ic_user)
                .Error(Resource.Drawable.ic_user)
                .Resize(111, 111)
                .CenterInside()
                .Transform(new CircleTransform(Color.Red, 2f))
                .Into(holder.ivUserImage);

            if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ManageUsers))
            {
                if (!holder.HasOptionMenu)
                {
                    holder.ibtnOptions.Click += delegate {
                        var popupMenu = new PopupMenu(_context, holder.ibtnOptions, GravityFlags.AxisClip);
                        popupMenu.MenuInflater.Inflate(Resource.Menu.users_item_options_menu, popupMenu.Menu);
                        popupMenu.MenuItemClick += (sender, args) => {
                            switch (args.Item.ItemId)
                            {
                                case Resource.Id.option_edit:
                                    OnUserOptionClick?.Invoke(_users[holder.Position], OptionType.Edit);
                                    break;
                                case Resource.Id.option_reset_password:
                                    OnUserOptionClick?.Invoke(_users[holder.Position], OptionType.ResetPassword);
                                    break;
                                case Resource.Id.option_change_state:
                                    OnUserOptionClick?.Invoke(_users[holder.Position], OptionType.ChangeState);
                                    break;
                            }
                        };
                        popupMenu.Show();
                    };

                    holder.HasOptionMenu = true;
                }
            }
            else
            {
                holder.ibtnOptions.Visibility = ViewStates.Gone;
            }

            holder.Position = position;

            return view;
        }

        private void IbtnOptionsClick(object sender, EventArgs e)
        {
            var popupMenu = new PopupMenu(_context, sender as View, GravityFlags.AxisClip);
            popupMenu.MenuInflater.Inflate(Resource.Menu.users_item_options_menu, popupMenu.Menu);
            popupMenu.Show();
        }

        public override int Count
        {
            get { return _users.Count; }
        }

    }

    class UserAdapterViewHolder : Java.Lang.Object
    {
        public UserAdapterViewHolder()
        {
            HasOptionMenu = false;
        }

        public ImageView ivUserImage { get; set; }

        public TextView tvUsername { get; set; }

        public TextView tvProfile { get; set; }

        public ActiveTextView tvState { get; set; }

        public ImageButton ibtnOptions { get; set; }

        public bool HasOptionMenu { get; set; }

        public int Position { get; set; }
    }
}
