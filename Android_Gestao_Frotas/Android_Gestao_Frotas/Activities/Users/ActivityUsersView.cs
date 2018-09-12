using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.Adapters;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Models;

namespace Android_Gestao_Frotas.Activities.Users
{
    public delegate void OnNewUserClickEvent();

    public delegate void OnUserEditClickEvent(User user);

    public delegate void OnUserResetPasswordClickEvent(User user);

    public delegate void OnUserChangeStateClickEvent(User user);

    public class ActivityUsersView : ActivityBaseView
    {
        public event OnNewUserClickEvent OnNewUserClick;

        public event OnUserEditClickEvent OnUserEditClick;

        public event OnUserChangeStateClickEvent OnUserChangeStateClick;

        public event OnUserResetPasswordClickEvent OnUserResetPasswordClick;

        FloatingActionButton fabNewUser;

        ListView lvUsers;

        TextView tvNoUsersToShow;

        public ActivityUsersView(Context context) : base(context)
        {
            LoadView();
        }

        private void LoadView()
        {
            var view = Inflate(Context, Resource.Layout.activity_users, this);

            fabNewUser = view.FindViewById<FloatingActionButton>(Resource.Id.fabNewUser);
            tvNoUsersToShow = view.FindViewById<TextView>(Resource.Id.tvNoUsersToShow);
            lvUsers = view.FindViewById<ListView>(Resource.Id.lvUsers);

            if (!AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ManageUsers))
            {
                fabNewUser.Visibility = ViewStates.Gone;
            }

            fabNewUser.Click -= FabNewUserClick;
            fabNewUser.Click += FabNewUserClick;
        }

        private void FabNewUserClick(object sender, EventArgs e)
        {
            OnNewUserClick?.Invoke();
        }

        public void UpdateUsers(List<User> users)
        {
            if (users != null && users.Count > 0)
            {
                var adapter = new UsersAdapter(Context, users);
                adapter.OnUserOptionClick -= AdapterOnUserOptionClick;
                adapter.OnUserOptionClick += AdapterOnUserOptionClick;

                lvUsers.Adapter = adapter;
                
                tvNoUsersToShow.Visibility = ViewStates.Gone;
                lvUsers.Visibility = ViewStates.Visible;
            }
            else
            {
                tvNoUsersToShow.Visibility = ViewStates.Visible;
                lvUsers.Visibility = ViewStates.Gone;
            }
        }

        private void AdapterOnUserOptionClick(User user, OptionType option)
        {
            if (option == OptionType.Edit)
                OnUserEditClick?.Invoke(user);
            else if (option == OptionType.ChangeState)
                OnUserChangeStateClick?.Invoke(user);
            else if (option == OptionType.ResetPassword)
                OnUserResetPasswordClick?.Invoke(user);
        }
    }
}