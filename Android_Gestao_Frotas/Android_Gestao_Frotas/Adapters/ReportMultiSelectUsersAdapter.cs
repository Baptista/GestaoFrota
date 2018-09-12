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
using Core_Gestao_Frotas.Business.Models;
using Square.Picasso;

namespace Android_Gestao_Frotas.Adapters
{
    public class ReportMultiSelectUsersAdapter : BaseAdapter
    {
        private Context _context;

        private List<User> _users;
        private List<int> _selectedUserIds;

        public ReportMultiSelectUsersAdapter(Context context, List<User> users, List<int> selectedUserIds)
        {
            _context = context;
            _users = users;
            _selectedUserIds = selectedUserIds;
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
            ReportMultiSelectUsersAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as ReportMultiSelectUsersAdapterViewHolder;

            if (holder == null)
            {
                holder = new ReportMultiSelectUsersAdapterViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.item_multiselectusers, parent, false);

                holder.llRoot = view.FindViewById<LinearLayout>(Resource.Id.llRoot);

                holder.ivUserImage = view.FindViewById<ImageView>(Resource.Id.ivImage);

                holder.tvUsername = view.FindViewById<TextView>(Resource.Id.tvUser);
                holder.tvProfile = view.FindViewById<TextView>(Resource.Id.tvProfile);
                holder.tvState = view.FindViewById<ActiveTextView>(Resource.Id.tvState);

                holder.chkUser = view.FindViewById<CheckBox>(Resource.Id.chkUser);

                holder.Position = position;

                if (!holder.HasEvents)
                {
                    holder.llRoot.Click += delegate { holder.chkUser.Checked = !holder.chkUser.Checked; };

                    holder.chkUser.CheckedChange += delegate { UserClick(holder); };

                    holder.HasEvents = true;
                }

                view.Tag = holder;
            }

            holder.Position = position;

            var user = _users[holder.Position];

            holder.tvUsername.Text = $"{user.ToString()}";
            holder.tvProfile.Text = $"{user.Profile.Description}";
            holder.tvState.Text = user.Active ? $"Ativo" : $"Inativo";
            holder.tvState.IsActive = user.Active;

            Picasso.With(_context)
                .Load(Resource.Drawable.user_picture_test)
                .Placeholder(Resource.Drawable.ic_user)
                .Error(Resource.Drawable.ic_user)
                .Resize(111, 111)
                .CenterInside()
                .Transform(new CircleTransform(Color.Red, 2f))
                .Into(holder.ivUserImage);

            holder.chkUser.Checked = _selectedUserIds.Contains(user.Id);

            return view;
        }

        public override int Count
        {
            get { return _users.Count; }
        }

        private void UserClick(ReportMultiSelectUsersAdapterViewHolder holder)
        {
            var user = _users[holder.Position];

            holder.IsChecked = holder.chkUser.Checked;
            if (holder.IsChecked)
            {
                if (!_selectedUserIds.Contains(user.Id))
                    _selectedUserIds.Add(user.Id);
            }
            else
            {
                if (_selectedUserIds.Contains(user.Id))
                    _selectedUserIds.Remove(_selectedUserIds.First(v => v == user.Id));
            }

            NotifyDataSetChanged();
        }

        public List<int> GetSelectedUserIds()
        {
            return _selectedUserIds;
        }
    }

    class ReportMultiSelectUsersAdapterViewHolder : Java.Lang.Object
    {
        public ReportMultiSelectUsersAdapterViewHolder()
        {
            IsChecked = false;
            HasEvents = false;
        }

        public LinearLayout llRoot { get; set; }

        public ImageView ivUserImage { get; set; }

        public TextView tvUsername { get; set; }

        public TextView tvProfile { get; set; }

        public ActiveTextView tvState { get; set; }

        public CheckBox chkUser { get; set; }

        public int Position { get; set; }

        public bool IsChecked { get; set; }

        public bool HasEvents { get; set; }
    }
}