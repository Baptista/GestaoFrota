using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.Adapters;
using Android_Gestao_Frotas.CustomControls;
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Business.Requests;
using Square.Picasso;

namespace Android_Gestao_Frotas.Activities.Dashboard
{
    public delegate void OnClickNewPedido();

    public delegate void OnApproveRequestClickEvent(RequestHistory request);
    public delegate void OnCancelRequestClickEvent(RequestHistory request);

    public delegate void OnRefreshRequestClickEvent(RequestHistory request);

    public delegate void OnTerminateRequestClickEvent(RequestHistory request, string justification);

    public delegate void OnMenuOptionClickEvent(MenuOption option);

    public delegate void OnAllForApprovalClickEvent();
    public delegate void OnAllUnavailableClickEvent();
    public delegate void OnAllEncourseClickEvent();

    public class ActivityDashboardView : ActivityBaseView
    {
        public event OnClickNewPedido OnClickNewPedido;
        
        public event OnApproveRequestClickEvent OnApproveRequestClick;
        public event OnCancelRequestClickEvent OnCancelRequestClick;

        public event OnRefreshRequestClickEvent OnRefreshRequestClick;

        public event OnTerminateRequestClickEvent OnTerminateRequestClick;

        public event OnMenuOptionClickEvent OnMenuOptionClick;

        public event OnAllForApprovalClickEvent OnAllForApprovalClick;

        public event OnAllUnavailableClickEvent OnAllUnavailableClick;

        public event OnAllEncourseClickEvent OnAllEncourseClick;

        LinearLayout llRequestsForApproval;
        LinearLayout llRequestsUnavailable;
        LinearLayout llRequestsActive;
        LinearLayout llNoRequestsForApproval;
        LinearLayout llNoRequestsUnavailable;
        LinearLayout llNoRequestsActive;
        LinearLayout llListRequestsForApproval;
        LinearLayout llListRequestsUnavailable;
        LinearLayout llListRequestsActive;

        ResizableListView rlvRequestsForApproval;
        ResizableListView rlvRequestsUnavailable;
        ResizableListView rlvRequestsActive;

        View vMainView;

        TextView tvUsername;
        TextView tvAppVersion;

        TextView tvAllForApproval;
        TextView tvAllUnavailable;
        TextView tvAllEncourse;

        ImageView ivUserPicture;
        ImageView ivUserBackground;

        FloatingActionButton fabNewRequest;

        #region Menu

        LinearLayout llMenuOptionRequests;
        LinearLayout llSubMenuRequests;
        LinearLayout llSubMenuOptionForApproval;
        LinearLayout llSubMenuOptionUnavailable;
        LinearLayout llSubMenuOptionEncourse;
        LinearLayout llSubMenuOptionHistory;
        LinearLayout llMenuOptionVehicles;
        LinearLayout llMenuOptionReports;
        LinearLayout llMenuOptionUsers;
        LinearLayout llMenuOptionSettings;
        LinearLayout llSubMenuSettings;
        LinearLayout llSubMenuOptionGlobal;
        LinearLayout llSubMenuOptionLocal;
        LinearLayout llMenuOptionLogout;

        ImageView ivRequestsSubMenuArrow;
        ImageView ivSettingsSubMenuArrow;

        #endregion

        TextView txtRequestsForApproval;
        View viewRequestsForApproval;
        TextView txtRequestsUnavailable;
        View viewRequestsUnavailable;

        public ActivityDashboardView(Context context) : base(context)
        {
            LoadView();
        }

        private void LoadView()
        {
            vMainView = Inflate(Context, Resource.Layout.activity_dashboard, this);

            llRequestsForApproval = vMainView.FindViewById<LinearLayout>(Resource.Id.llRequestsForApproval);
            llRequestsUnavailable = vMainView.FindViewById<LinearLayout>(Resource.Id.llRequestsUnavailable);
            llRequestsActive = vMainView.FindViewById<LinearLayout>(Resource.Id.llRequestsActive);

            llNoRequestsForApproval = vMainView.FindViewById<LinearLayout>(Resource.Id.llNoRequestsForApproval);
            llNoRequestsUnavailable = vMainView.FindViewById<LinearLayout>(Resource.Id.llNoRequestsUnavailable);
            llNoRequestsActive = vMainView.FindViewById<LinearLayout>(Resource.Id.llNoRequestsActive);

            llListRequestsForApproval = vMainView.FindViewById<LinearLayout>(Resource.Id.llListRequestsForApproval);
            llListRequestsUnavailable = vMainView.FindViewById<LinearLayout>(Resource.Id.llListRequestsUnavailable);
            llListRequestsActive = vMainView.FindViewById<LinearLayout>(Resource.Id.llListRequestsActive);

            rlvRequestsForApproval = vMainView.FindViewById<ResizableListView>(Resource.Id.rlvRequestsForApproval);
            rlvRequestsUnavailable = vMainView.FindViewById<ResizableListView>(Resource.Id.rlvRequestsUnavailable);
            rlvRequestsActive = vMainView.FindViewById<ResizableListView>(Resource.Id.rlvRequestsActive);

            fabNewRequest = vMainView.FindViewById<FloatingActionButton>(Resource.Id.fabNewRequest);

            tvAllForApproval = vMainView.FindViewById<TextView>(Resource.Id.tvAllForApproval);
            tvAllUnavailable = vMainView.FindViewById<TextView>(Resource.Id.tvAllUnavailable);
            tvAllEncourse = vMainView.FindViewById<TextView>(Resource.Id.tvAllEncourse);

            txtRequestsForApproval = vMainView.FindViewById<TextView>(Resource.Id.txtRequestsForApproval);
            viewRequestsForApproval = vMainView.FindViewById<View>(Resource.Id.viewRequestsForApproval);

            txtRequestsUnavailable = vMainView.FindViewById<TextView>(Resource.Id.txtRequestsUnavailable);
            viewRequestsUnavailable = vMainView.FindViewById<View>(Resource.Id.viewRequestsUnavailable);

            tvAllForApproval.Click -= tvAllForApproval_Click;
            tvAllForApproval.Click += tvAllForApproval_Click;

            tvAllUnavailable.Click -= tvAllUnavailable_Click;
            tvAllUnavailable.Click += tvAllUnavailable_Click;

            tvAllEncourse.Click -= tvAllEncourse_Click;
            tvAllEncourse.Click += tvAllEncourse_Click;

            fabNewRequest.Click -= NewRequestClick;
            fabNewRequest.Click += NewRequestClick;

        }

        public void Checkpermissionsdashboard()
        {
            if (!AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ApproveUserRequests))
            {
                llNoRequestsForApproval.Visibility = ViewStates.Gone;
                llListRequestsForApproval.Visibility = ViewStates.Gone;
                txtRequestsForApproval.Visibility = ViewStates.Gone;
                viewRequestsForApproval.Visibility = ViewStates.Gone;
            }
            if (!AllYouCanGet.CurrentUser.Profile.IsActive(Permission.MakeVehicleAvailable))
            {
                llNoRequestsUnavailable.Visibility = ViewStates.Gone;
                llListRequestsUnavailable.Visibility = ViewStates.Gone;
                txtRequestsUnavailable.Visibility = ViewStates.Gone;
                viewRequestsUnavailable.Visibility = ViewStates.Gone;
            }
        }

        private void tvAllEncourse_Click(object sender, EventArgs e)
        {
            OnAllEncourseClick?.Invoke();
        }

        private void tvAllUnavailable_Click(object sender, EventArgs e)
        {
            OnAllUnavailableClick?.Invoke();
        }

        private void tvAllForApproval_Click(object sender, EventArgs e)
        {
            OnAllForApprovalClick?.Invoke();
        }

        private void NewRequestClick(object sender, EventArgs e)
        {
            OnClickNewPedido?.Invoke();
        }

        public void UpdateMenuHeader(User user, string appversion)
        {
            tvUsername = vMainView.FindViewById<TextView>(Resource.Id.tvUsername);
            tvAppVersion = vMainView.FindViewById<TextView>(Resource.Id.tvAppVersion);
            ivUserPicture = vMainView.FindViewById<ImageView>(Resource.Id.ivUserPicture);
            ivUserBackground = vMainView.FindViewById<ImageView>(Resource.Id.ivUserBackground);

            tvUsername.Text = $"{user.Name} ({user.Username})";
            tvAppVersion.Text = appversion;

            Picasso.With(Context)
                .Load(Resource.Drawable.user_picture_test)
                .Resize(ivUserPicture.Width, ivUserPicture.Height)
                .CenterCrop()
                .Transform(new CircleTransform(Color.White, 4))
                .Rotate(-90)
                .Into(ivUserPicture);

            Picasso.With(Context)
                .Load(Resource.Drawable.user_background_test)
                .Resize(ivUserBackground.Width, ivUserBackground.Height)
                .CenterCrop()
                .Into(ivUserBackground);
        }

        public void UpdateRequestsForApproval(List<RequestHistory> requestsForApproval)
        {
            if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ApproveUserRequests))
            {
                if (requestsForApproval != null && requestsForApproval.Count > 0)
                { 
                    var adapter = new DashboardRequestsForApprovalAdapter(Context, requestsForApproval);
                    rlvRequestsForApproval.Adapter = adapter;

                    adapter.OnApproveClick -= RequestsForApproval_OnApproveClick;
                    adapter.OnApproveClick += RequestsForApproval_OnApproveClick;

                    adapter.OnCancelClick -= RequestsForApproval_OnCancelClick;
                    adapter.OnCancelClick += RequestsForApproval_OnCancelClick;

                    llNoRequestsForApproval.Visibility = ViewStates.Gone;
                    llListRequestsForApproval.Visibility = ViewStates.Visible;
                }
                else
                {
                    llNoRequestsForApproval.Visibility = ViewStates.Visible;
                    llListRequestsForApproval.Visibility = ViewStates.Gone;
                }
            }
            else
            {
                llNoRequestsForApproval.Visibility = ViewStates.Gone;
                llListRequestsForApproval.Visibility = ViewStates.Gone;
                txtRequestsForApproval.Visibility = ViewStates.Gone;
                viewRequestsForApproval.Visibility = ViewStates.Gone;
            }
        }

        private async void RequestsForApproval_OnCancelClick(RequestHistory request)
        {
            var response = await new DialogHelper(Context).Question($"Tem a certeza que pretende cancelar o pedido de marcação de {request.User.Name} para o veículo {request.Vehicle.ToString()}?");

            if (response == DialogHelper.DialogResponse.Yes)
                OnCancelRequestClick?.Invoke(request);
        }

        private async void RequestsForApproval_OnApproveClick(RequestHistory request)
        {
            var response = await new DialogHelper(Context).Question($"Tem a certeza que pretende aprovar o pedido de marcação de {request.User.Name} para o veículo {request.Vehicle.ToString()}?");

            if (response == DialogHelper.DialogResponse.Yes)
                OnApproveRequestClick?.Invoke(request);
        }

        public void UpdateRequestsUnavailable(List<RequestHistory> requestsUnavailable)
        {
            if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.MakeVehicleAvailable))
            {
                if (requestsUnavailable != null && requestsUnavailable.Count > 0)
                {
                    var adapter = new DashboardRequestsUnavailableAdapter(Context, requestsUnavailable);
                    rlvRequestsUnavailable.Adapter = adapter;

                    adapter.OnRefreshRequestClick -= RequestsUnavailable_OnRefreshRequestClick;
                    adapter.OnRefreshRequestClick += RequestsUnavailable_OnRefreshRequestClick;

                    llNoRequestsUnavailable.Visibility = ViewStates.Gone;
                    llListRequestsUnavailable.Visibility = ViewStates.Visible;
                }
                else
                {
                    llNoRequestsUnavailable.Visibility = ViewStates.Visible;
                    llListRequestsUnavailable.Visibility = ViewStates.Gone;
                }
            }
            else
            {
                llNoRequestsUnavailable.Visibility = ViewStates.Gone;
                llListRequestsUnavailable.Visibility = ViewStates.Gone;
                txtRequestsUnavailable.Visibility = ViewStates.Gone;
                viewRequestsUnavailable.Visibility = ViewStates.Gone;
            }
        }

        private async void RequestsUnavailable_OnRefreshRequestClick(RequestHistory request)
        {
            var response = await new DialogHelper(Context).Question($"Pretende actualizar o pedido de marcação de {request.User.Name} e disponibilizar o veículo {request.Vehicle.ToString()}?");

            if (response == DialogHelper.DialogResponse.Yes)
                OnRefreshRequestClick?.Invoke(request);
        }

        public void UpdateRequestsEncourse(List<RequestHistory> requestsActive)
        {
            if (requestsActive != null && requestsActive.Count > 0)
            {

                var adapter = new DashboardRequestsActiveAdapter(Context, requestsActive);
                rlvRequestsActive.Adapter = adapter;

                adapter.OnTerminateRequestClick -= RequestsEncourse_OnTerminateRequestClick;
                adapter.OnTerminateRequestClick += RequestsEncourse_OnTerminateRequestClick;
                
                llNoRequestsActive.Visibility = ViewStates.Gone;
                llListRequestsActive.Visibility = ViewStates.Visible;
            }
            else
            {
                llNoRequestsActive.Visibility = ViewStates.Visible;
                llListRequestsActive.Visibility = ViewStates.Gone;
            }
        }

        private async void RequestsEncourse_OnTerminateRequestClick(RequestHistory request)
        {
            var response = await new DialogHelper(Context).Question($"Tem a certeza que pretende terminar o pedido de marcação em curso de {request.User.Name} para o veículo {request.Vehicle.ToString()}");

            if (response == DialogHelper.DialogResponse.Yes)
            {
                var result3 = await new DialogHelper(Context).UserInput($"Justificação para cancelar o pedido:");
                if (result3 != string.Empty && result3 != "")
                {
                    OnTerminateRequestClick?.Invoke(request, result3);
                }
            }
        }

        public void LoadMenu(NavigationView navView)
        {
            llMenuOptionRequests = navView.FindViewById<LinearLayout>(Resource.Id.llMenuOptionRequests);
            llSubMenuRequests = navView.FindViewById<LinearLayout>(Resource.Id.llSubMenuRequests);
            llSubMenuOptionForApproval = navView.FindViewById<LinearLayout>(Resource.Id.llSubMenuOptionForApproval);
            llSubMenuOptionUnavailable = navView.FindViewById<LinearLayout>(Resource.Id.llSubMenuOptionUnavailable);
            llSubMenuOptionEncourse = navView.FindViewById<LinearLayout>(Resource.Id.llSubMenuOptionEncourse);
            llSubMenuOptionHistory = navView.FindViewById<LinearLayout>(Resource.Id.llSubMenuOptionHistory);
            llMenuOptionVehicles = navView.FindViewById<LinearLayout>(Resource.Id.llMenuOptionVehicles);
            llMenuOptionReports = navView.FindViewById<LinearLayout>(Resource.Id.llMenuOptionReports);
            llMenuOptionUsers = navView.FindViewById<LinearLayout>(Resource.Id.llMenuOptionUsers);
            llMenuOptionSettings = navView.FindViewById<LinearLayout>(Resource.Id.llMenuOptionSettings);
            llSubMenuSettings = navView.FindViewById<LinearLayout>(Resource.Id.llSubMenuSettings);
            llSubMenuOptionGlobal = navView.FindViewById<LinearLayout>(Resource.Id.llSubMenuOptionGlobal);
            llSubMenuOptionLocal = navView.FindViewById<LinearLayout>(Resource.Id.llSubMenuOptionLocal);
            llMenuOptionLogout = navView.FindViewById<LinearLayout>(Resource.Id.llMenuOptionLogout);

            if (!AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ViewUsers))
            {
                llMenuOptionUsers.Visibility = ViewStates.Gone;
            }

            if (!AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ApproveUserRequests))
            {
                llSubMenuOptionForApproval.Visibility = ViewStates.Gone;
            }

            if (!AllYouCanGet.CurrentUser.Profile.IsActive(Permission.MakeVehicleAvailable))
            {
                llSubMenuOptionUnavailable.Visibility = ViewStates.Gone;
            }

            var bool1 = AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ViewBrands);
            var bool2 = AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ViewModels);
            var bool3 = AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ViewTypologies);
            var bool4 = AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ViewVehicles);

            if (bool1 == false && bool2 == false && bool3 == false && bool4 == false)
            {
                llMenuOptionVehicles.Visibility = ViewStates.Gone;
            }

            ivRequestsSubMenuArrow = navView.FindViewById<ImageView>(Resource.Id.ivRequestsSubMenuArrow);
            ivSettingsSubMenuArrow = navView.FindViewById<ImageView>(Resource.Id.ivSettingsSubMenuArrow);

            llMenuOptionRequests.Click -= llMenuOptionRequests_Click;
            llMenuOptionRequests.Click += llMenuOptionRequests_Click;

            llSubMenuOptionForApproval.Click -= llSubMenuOptionForApproval_Click;
            llSubMenuOptionForApproval.Click += llSubMenuOptionForApproval_Click;

            llSubMenuOptionUnavailable.Click -= llSubMenuOptionUnavailable_Click;
            llSubMenuOptionUnavailable.Click += llSubMenuOptionUnavailable_Click;

            llSubMenuOptionEncourse.Click -= llSubMenuOptionEncourse_Click;
            llSubMenuOptionEncourse.Click += llSubMenuOptionEncourse_Click;

            llSubMenuOptionHistory.Click -= llSubMenuOptionHistory_Click;
            llSubMenuOptionHistory.Click += llSubMenuOptionHistory_Click;

            llMenuOptionVehicles.Click -= llMenuOptionVehicles_Click;
            llMenuOptionVehicles.Click += llMenuOptionVehicles_Click;

            llMenuOptionReports.Click -= llMenuOptionReports_Click;
            llMenuOptionReports.Click += llMenuOptionReports_Click;

            llMenuOptionUsers.Click -= llMenuOptionUsers_Click;
            llMenuOptionUsers.Click += llMenuOptionUsers_Click;

            llMenuOptionSettings.Click -= llMenuOptionSettings_Click;
            llMenuOptionSettings.Click += llMenuOptionSettings_Click;

            llSubMenuOptionGlobal.Click -= llSubMenuOptionGlobal_Click;
            llSubMenuOptionGlobal.Click += llSubMenuOptionGlobal_Click;

            llSubMenuOptionLocal.Click -= llSubMenuOptionLocal_Click;
            llSubMenuOptionLocal.Click += llSubMenuOptionLocal_Click;

            llMenuOptionLogout.Click -= llMenuOptionLogout_Click;
            llMenuOptionLogout.Click += llMenuOptionLogout_Click;
        }

        private void llMenuOptionLogout_Click(object sender, EventArgs e)
        {
            OnMenuOptionClick?.Invoke(MenuOption.Logout);
        }

        private void llSubMenuOptionLocal_Click(object sender, EventArgs e)
        {
            OnMenuOptionClick?.Invoke(MenuOption.SettingsLocal);
        }

        private void llSubMenuOptionGlobal_Click(object sender, EventArgs e)
        {
            OnMenuOptionClick?.Invoke(MenuOption.SettingsGlobal);
        }

        private void llMenuOptionSettings_Click(object sender, EventArgs e)
        {
            if (llSubMenuSettings.Visibility == ViewStates.Visible)
            {
                llSubMenuSettings.Visibility = ViewStates.Gone;
                ivSettingsSubMenuArrow.SetImageResource(Resource.Drawable.ic_arrow_down);
            }
            else
            {
                llSubMenuSettings.Visibility = ViewStates.Visible;
                ivSettingsSubMenuArrow.SetImageResource(Resource.Drawable.ic_arrow_up);
            }
        }

        private void llMenuOptionUsers_Click(object sender, EventArgs e)
        {
            OnMenuOptionClick?.Invoke(MenuOption.Users);
        }

        private void llMenuOptionReports_Click(object sender, EventArgs e)
        {
            OnMenuOptionClick?.Invoke(MenuOption.Reports);
        }

        private void llMenuOptionVehicles_Click(object sender, EventArgs e)
        {
            OnMenuOptionClick?.Invoke(MenuOption.Vehicles);
        }

        private void llSubMenuOptionHistory_Click(object sender, EventArgs e)
        {
            OnMenuOptionClick?.Invoke(MenuOption.RequestsHistory);
        }

        private void llSubMenuOptionEncourse_Click(object sender, EventArgs e)
        {
            OnMenuOptionClick?.Invoke(MenuOption.RequestsEncourse);
        }

        private void llSubMenuOptionUnavailable_Click(object sender, EventArgs e)
        {
            OnMenuOptionClick?.Invoke(MenuOption.RequestsUnavailable);
        }

        private void llSubMenuOptionForApproval_Click(object sender, EventArgs e)
        {
            OnMenuOptionClick?.Invoke(MenuOption.RequestsForApproval);
        }

        private void llMenuOptionRequests_Click(object sender, EventArgs e)
        {
            if (llSubMenuRequests.Visibility == ViewStates.Visible)
            {
                llSubMenuRequests.Visibility = ViewStates.Gone;
                ivRequestsSubMenuArrow.SetImageResource(Resource.Drawable.ic_arrow_down);
            }
            else
            {
                llSubMenuRequests.Visibility = ViewStates.Visible;
                ivRequestsSubMenuArrow.SetImageResource(Resource.Drawable.ic_arrow_up);
            }
        }
    }

    public enum MenuOption
    {
        RequestsForApproval = 1,
        RequestsUnavailable = 2,
        RequestsEncourse = 3,
        RequestsHistory = 4,
        Vehicles = 5,
        Reports = 6,
        Users = 7,
        SettingsGlobal = 8,
        SettingsLocal = 9,
        Logout = 10,
    }
}