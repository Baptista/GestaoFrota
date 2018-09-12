using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.Adapters;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Models;
using DK.Ostebaronen.Droid.ViewPagerIndicator;

namespace Android_Gestao_Frotas.Activities.Reports
{
    public delegate void OnStartDateClickEvent();

    public delegate void OnEndDateClickEvent();

    public delegate void OnUserClickEvent();

    public delegate void OnAddVehiclesClickEvent();

    public delegate void OnAddUsersClickEvent();

    public delegate void OnContinueClickEvent();
    
    public class ActivityReportGeneratorView : ActivityBaseView
    {
        public event OnStartDateClickEvent OnStartDateClick;

        public event OnEndDateClickEvent OnEndDateClick;

        public event OnUserClickEvent OnUserClick;

        public event OnAddVehiclesClickEvent OnAddVehiclesClick;

        public event OnAddUsersClickEvent OnAddUsersClick;

        public event OnContinueClickEvent OnContinueClick;

        TextView tvUser;
        TextView tvStartDate;
        TextView tvEndDate;

        ImageButton imgbtnAddVehicles;
        ImageButton imgbtnAddUser;

        LinearLayout llVehicles;
        LinearLayout llNoVehicles;
        LinearLayout llUsers;
        LinearLayout llNoUsers;

        ViewPager vpVehicles;
        ViewPager vpUsers;

        CirclePageIndicator cpiVehicles;
        CirclePageIndicator cpiUsers;

        Button btnFinish;

        public ActivityReportGeneratorView(Context context) : base(context)
        {
            LoadView();
        }

        private void LoadView()
        {
            var view = Inflate(Context, Resource.Layout.activity_report_generator, this);

            tvUser = view.FindViewById<TextView>(Resource.Id.tvUser);
            tvStartDate = view.FindViewById<TextView>(Resource.Id.tvStartDate);
            tvEndDate = view.FindViewById<TextView>(Resource.Id.tvEndDate);
            imgbtnAddVehicles = view.FindViewById<ImageButton>(Resource.Id.imgbtnAddVehicles);
            imgbtnAddUser = view.FindViewById<ImageButton>(Resource.Id.imgbtnAddUser);
            llVehicles = view.FindViewById<LinearLayout>(Resource.Id.llVehicles);
            vpVehicles = view.FindViewById<ViewPager>(Resource.Id.vpVehicles);
            cpiVehicles = view.FindViewById<CirclePageIndicator>(Resource.Id.cpiVehicles);
            llUsers = view.FindViewById<LinearLayout>(Resource.Id.llUsers);
            vpUsers = view.FindViewById<ViewPager>(Resource.Id.vpUsers);
            cpiUsers = view.FindViewById<CirclePageIndicator>(Resource.Id.cpiUsers);
            btnFinish = view.FindViewById<Button>(Resource.Id.btnFinish);
            llNoVehicles = view.FindViewById<LinearLayout>(Resource.Id.llNoVehicles);
            llNoUsers = view.FindViewById<LinearLayout>(Resource.Id.llNoUsers);

            //tvUser.Click -= tvUser_Click;
            //tvUser.Click += tvUser_Click;

            tvStartDate.Click -= tvStartDate_Click;
            tvStartDate.Click += tvStartDate_Click;

            tvEndDate.Click -= tvEndDate_Click;
            tvEndDate.Click += tvEndDate_Click;

            imgbtnAddVehicles.Click -= imgbtnAddVehicles_Click;
            imgbtnAddVehicles.Click += imgbtnAddVehicles_Click;

            imgbtnAddUser.Click -= imgbtnAddUser_Click;
            imgbtnAddUser.Click += imgbtnAddUser_Click;

            //btnFinish.Click -= btnFinish_Click;
            //btnFinish.Click += btnFinish_Click;

            if (!AllYouCanGet.CurrentUser.Profile.IsActive(Permission.GenerateUserReport))
            {
                imgbtnAddUser.Visibility = ViewStates.Gone;
            }

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            OnContinueClick?.Invoke();
        }

        private void imgbtnAddVehicles_Click(object sender, EventArgs e)
        {
            OnAddVehiclesClick?.Invoke();
        }

        private void imgbtnAddUser_Click(object sender, EventArgs e)
        {
            OnAddUsersClick?.Invoke();
        }

        private void tvEndDate_Click(object sender, EventArgs e)
        {
            OnEndDateClick?.Invoke();
        }

        private void tvStartDate_Click(object sender, EventArgs e)
        {
            OnStartDateClick?.Invoke();
        }

        private void tvUser_Click(object sender, EventArgs e)
        {
            OnUserClick?.Invoke();
        }

        public void SetUserText(string text)
        {
            tvUser.Text = text;
        }

        public void SetUserEnabled(bool enabled)
        {
            tvUser.Enabled = enabled;
        }

        public void SetStartDateText(string text)
        {
            tvStartDate.Text = text;
        }

        public void SetEndDateText(string text)
        {
            tvEndDate.Text = text;
        }

        public void SetVehiclesAdapter(List<Vehicle> vehicles)
        {
            var adapter = new ReportVehiclesAdapter(Context, vehicles);

            if (vpVehicles.Adapter != null)
                vpVehicles.Adapter = null;

            vpVehicles.Adapter = adapter;
            cpiVehicles.SetViewPager(vpVehicles);

            //if (vehicles.Any())
            //{
            llNoVehicles.Visibility = ViewStates.Gone;
            llVehicles.Visibility = ViewStates.Visible;
            vpVehicles.Invalidate();
            vpVehicles.LayoutParameters.Height = adapter.GetHeight();
            //}
            //else
            //{
            //    llNoVehicles.Visibility = ViewStates.Visible;
            //    llVehicles.Visibility = ViewStates.Gone;
            //}
        }

        public void SetUsersAdapter(List<User> users)
        {
            var adapter = new ReportUsersAdapter(Context, users);

            if (vpUsers.Adapter != null)
                vpUsers.Adapter = null;

            vpUsers.Adapter = adapter;
            cpiUsers.SetViewPager(vpUsers);

            //if (users.Any())
            //{
                llNoUsers.Visibility = ViewStates.Gone;
                llUsers.Visibility = ViewStates.Visible;
                vpUsers.Invalidate();
                vpUsers.LayoutParameters.Height = adapter.GetHeight();
            //}
            //else
            //{
            //    llNoUsers.Visibility = ViewStates.Visible;
            //    llUsers.Visibility = ViewStates.Gone;
            //}
        }
    }
}