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
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas.Business.Models;

namespace Android_Gestao_Frotas.Activities.NewRequest
{
    public delegate void OnStartDateClickEvent();
    public delegate void OnStartTimeClickEvent();
    public delegate void OnEndDateClickEvent();
    public delegate void OnEndTimeClickEvent();
    public delegate void OnContinuosCheckChangeEvent(bool check);
    public delegate void OnSelectVehicleClickEvent();
    public delegate void OnChangeVehicleClickEvent();
    public delegate void OnFinishClickEvent();

    public class ActivityNewRequestView : ActivityBaseView
    {
        public event OnStartDateClickEvent OnStartDateClick;
        public event OnStartTimeClickEvent OnStartTimeClick;
        public event OnEndDateClickEvent OnEndDateClick;
        public event OnEndTimeClickEvent OnEndTimeClick;
        public event OnContinuosCheckChangeEvent OnContinuosCheckChange;
        public event OnSelectVehicleClickEvent OnSelectVehicleClick;
        public event OnChangeVehicleClickEvent OnChangeVehicleClick;
        public event OnFinishClickEvent OnFinishClick;

        ScrollView svMainScroll;

        LinearLayout llSelectVehicle;
        LinearLayout llVehicleInfo;
        LinearLayout llScrollChild;
        LinearLayout llFinish;

        ImageView ivVehicleImage;

        TextView tvVehicle;
        TextView tvLicensePlate;
        TextView tvUser;
        TextView tvTypology;
        TextView tvFuel;
        TextView tvKms;
        TextView tvContractsKms;
        TextView tvChangeVehicle;
        TextView tvStartDate;
        TextView tvStartTime;
        TextView tvEndDate;
        TextView tvEndTime;

        CheckBox cbIsContinuos;

        Button btnFinish;

        public ActivityNewRequestView(Context context) : base(context)
        {
            LoadView();
        }

        private void LoadView()
        {
            var view = Inflate(Context, Resource.Layout.activity_newrequest, this);

            svMainScroll = view.FindViewById<ScrollView>(Resource.Id.svMainScroll);

            llSelectVehicle = view.FindViewById<LinearLayout>(Resource.Id.llSelectVehicle);
            llVehicleInfo = view.FindViewById<LinearLayout>(Resource.Id.llVehicleInfo);
            llScrollChild = view.FindViewById<LinearLayout>(Resource.Id.llScrollChild);
            llFinish = view.FindViewById<LinearLayout>(Resource.Id.llFinish);

            ivVehicleImage = view.FindViewById<ImageView>(Resource.Id.ivVehicleImage);

            tvVehicle = view.FindViewById<TextView>(Resource.Id.tvVehicle);
            tvLicensePlate = view.FindViewById<TextView>(Resource.Id.tvLicensePlate);
            tvUser = view.FindViewById<TextView>(Resource.Id.tvUser);
            tvTypology = view.FindViewById<TextView>(Resource.Id.tvTypology);
            tvFuel = view.FindViewById<TextView>(Resource.Id.tvFuel);
            tvKms = view.FindViewById<TextView>(Resource.Id.tvKms);
            tvContractsKms = view.FindViewById<TextView>(Resource.Id.tvContractsKms);
            tvChangeVehicle = view.FindViewById<TextView>(Resource.Id.tvChangeVehicle);
            tvStartDate = view.FindViewById<TextView>(Resource.Id.tvStartDate);
            tvStartTime = view.FindViewById<TextView>(Resource.Id.tvStartTime);
            tvEndDate = view.FindViewById<TextView>(Resource.Id.tvEndDate);
            tvEndTime = view.FindViewById<TextView>(Resource.Id.tvEndTime);

            cbIsContinuos = view.FindViewById<CheckBox>(Resource.Id.cbIsContinuos);

            btnFinish = view.FindViewById<Button>(Resource.Id.btnFinish);

            SetScrollChildHeight();
            SetViewEvents();
        }

        private void SetScrollChildHeight()
        {
            var layoutHelper = new LayoutHelper(Context);
            var screenHeight = layoutHelper.GetScreenHeight();
            var statusBarHeight = layoutHelper.GetStatusBarHeight();
            var toolbarHeight = layoutHelper.GetToolbarHeight();
            var scrollChildLayoutParams = llScrollChild.LayoutParameters;

            scrollChildLayoutParams.Height = screenHeight - (statusBarHeight + toolbarHeight);
            llScrollChild.LayoutParameters = scrollChildLayoutParams;
            llScrollChild.SetMinimumHeight(scrollChildLayoutParams.Height);
            llScrollChild.RequestLayout();
        }

        private void SetViewEvents()
        {
            llSelectVehicle.Click -= llSelectVehicle_Click;
            llSelectVehicle.Click += llSelectVehicle_Click;

            tvChangeVehicle.Click -= tvChangeVehicle_Click;
            tvChangeVehicle.Click += tvChangeVehicle_Click;

            tvStartDate.Click -= tvStartDate_Click;
            tvStartDate.Click += tvStartDate_Click;

            tvStartTime.Click -= tvStartTime_Click;
            tvStartTime.Click += tvStartTime_Click;

            tvEndDate.Click -= tvEndDate_Click;
            tvEndDate.Click += tvEndDate_Click;

            tvEndTime.Click -= tvEndTime_Click;
            tvEndTime.Click += tvEndTime_Click;

            cbIsContinuos.CheckedChange -= cbIsContinuos_CheckedChange;
            cbIsContinuos.CheckedChange += cbIsContinuos_CheckedChange;

            btnFinish.Click -= btnFinish_Click;
            btnFinish.Click += btnFinish_Click;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            OnFinishClick?.Invoke();
        }

        private void cbIsContinuos_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            OnContinuosCheckChange?.Invoke(e.IsChecked);
            if (e.IsChecked)
                SetEndDateTimeEnabled(false);
            else
                SetEndDateTimeEnabled(true);
        }

        private void tvEndTime_Click(object sender, EventArgs e)
        {
            OnEndTimeClick?.Invoke();
        }

        private void tvEndDate_Click(object sender, EventArgs e)
        {
            OnEndDateClick?.Invoke();
        }

        private void tvStartTime_Click(object sender, EventArgs e)
        {
            OnStartTimeClick?.Invoke();
        }

        private void tvStartDate_Click(object sender, EventArgs e)
        {
            OnStartDateClick?.Invoke();
        }

        private void tvChangeVehicle_Click(object sender, EventArgs e)
        {
            OnChangeVehicleClick?.Invoke();
        }

        private void llSelectVehicle_Click(object sender, EventArgs e)
        {
            OnSelectVehicleClick?.Invoke();
        }

        public void SetStartDateText(string date)
        {
            tvStartDate.Text = date;
        }

        public void SetStartTimeText(string time)
        {
            tvStartTime.Text = time;
        }

        public void SetEndDateText(string date)
        {
            tvEndDate.Text = date;
        }

        public void SetEndTimeText(string time)
        {
            tvEndTime.Text = time;
        }

        public void SetEndDateTimeEnabled(bool enabled)
        {
            tvEndDate.Enabled = enabled;
            tvEndTime.Enabled = enabled;
        }

        public void SetSelectedVehicle(Vehicle vehicle)
        {
            if (vehicle.Id == -1)
            {
                llSelectVehicle.Visibility = ViewStates.Visible;
                llVehicleInfo.Visibility = ViewStates.Gone;
            }
            else
            {
                llSelectVehicle.Visibility = ViewStates.Gone;
                llVehicleInfo.Visibility = ViewStates.Visible;

                tvVehicle.Text = $"{vehicle.Model.Brand.Description} - {vehicle.Model.Description}";
                tvLicensePlate.Text = $"{vehicle.LicensePlate}";
                tvUser.Text = $"{vehicle.User.Name} ({vehicle.User.Username})";
                tvTypology.Text = $"{vehicle.Typology.Description}";
                tvFuel.Text = $"{vehicle.Model.Fuel.Description}";
                tvKms.Text = $"{vehicle.StartKms}";
                tvContractsKms.Text = $"{vehicle.ContractKms}";

                SetScrollChildHeight();
            }
        }
    }
}