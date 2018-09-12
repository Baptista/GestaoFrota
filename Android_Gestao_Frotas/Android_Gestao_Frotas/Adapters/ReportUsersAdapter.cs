using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.CustomControls;
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas.Business.Models;
using Square.Picasso;

namespace Android_Gestao_Frotas.Adapters
{
    public class ReportUsersAdapter : PagerAdapter
    {
        private Context _context;
        private List<User> _user;

        private int _height = 0;

        public ReportUsersAdapter(Context context, List<User> user)
        {
            _context = context;
            _user = user;
        }

        public override int Count
        {
            get { return _user.Count > 0 ? _user.Count : 1; }
        }

        public override bool IsViewFromObject(View view, Java.Lang.Object obj)
        {
            return view == obj;
        }

        public override Java.Lang.Object InstantiateItem(View container, int position)
        {
            var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
            var view = inflater.Inflate(Resource.Layout.item_users_user,  null, false);

            var ivUserImage = view.FindViewById<ImageView>(Resource.Id.ivUserImage);

            var tvUsername = view.FindViewById<TextView>(Resource.Id.tvUsername);
            var tvProfile = view.FindViewById<TextView>(Resource.Id.tvProfile);
            var tvState = view.FindViewById<ActiveTextView>(Resource.Id.tvState);
            var ibtnOptions = view.FindViewById<ImageButton>(Resource.Id.ibtnOptions);

            var llContent = view.FindViewById<LinearLayout>(Resource.Id.llContent);
            var llNoUsers = view.FindViewById<LinearLayout>(Resource.Id.llNoUsers);

            if (_user.Any())
            {
                var user = _user[position];

                tvUsername.Text = $"{user.ToString()}";
                tvProfile.Visibility = ViewStates.Gone;
                //tvProfile.Text = $"{user.Profile.Description}";

                tvState.Text = _user[position].Active ? $"Ativo" : $"Inativo";
                tvState.IsActive = _user[position].Active;
                ibtnOptions.Visibility = ViewStates.Gone;

                Picasso.With(_context)
                    .Load(Resource.Drawable.user_picture_test)
                    .Placeholder(Resource.Drawable.ic_user)
                    .Error(Resource.Drawable.ic_user)
                    .Resize(111, 111)
                    .CenterInside()
                    .Transform(new CircleTransform(Color.Red, 1f))
                    .Into(ivUserImage);

                llContent.Visibility = ViewStates.Visible;
                llNoUsers.Visibility = ViewStates.Invisible;

                var viewPager = container.JavaCast<ViewPager>();
                viewPager.AddView(view);

                if (_height == 0)
                {
                    view.Measure(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                    _height = view.MeasuredHeight;
                }

                return view;
            }
            else
            {
                llContent.Visibility = ViewStates.Invisible;
                llNoUsers.Visibility = ViewStates.Visible;

                var viewPager = container.JavaCast<ViewPager>();
                viewPager.AddView(view);

                if (_height == 0)
                {
                    view.Measure(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                    _height = view.MeasuredHeight;
                }

                return view;
            }            
        }

        public override void DestroyItem(View container, int position, Java.Lang.Object view)
        {
            var viewPager = container.JavaCast<ViewPager>();
            viewPager.RemoveView(view as View);
        }

        public int GetHeight()
        {
            return _height;
        }
    }
}