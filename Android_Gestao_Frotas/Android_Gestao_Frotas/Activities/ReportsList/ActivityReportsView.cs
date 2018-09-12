using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.Adapters;
using Core_Gestao_Frotas.Business.Models;

namespace Android_Gestao_Frotas.Activities.ReportsList
{

    public delegate void OnFiltroReportClick();
    public delegate void OnAllReportClick(int TypeConsult);
    public delegate void OnReportClickController(VehicleHistory report, int TypeConsult);

    public class ActivityReportsView : ActivityBaseView
    {

        public event OnFiltroReportClick OnFiltroReportClick;
        public event OnAllReportClick OnAllReportClick;
        public event OnReportClickController OnReportClickController;

        LinearLayout FiltroReportClick;
        TextView txtFiltroReport;
        ListView lvReports;
        LinearLayout llNoReports;

        LinearLayout llAllReport;
        TextView txtAllReport;

        ReportListAdapter adapter;
        private int _clickTypeKnow;

        public ActivityReportsView(Context context) : base(context)
        {
            LoadView();

            llAllReport.Click -= LlAllReport_Click;
            llAllReport.Click += LlAllReport_Click;
        }

        private void LlAllReport_Click(object sender, EventArgs e)
        {
            OnAllReportClick?.Invoke(_clickTypeKnow);
        }

        public void AllStats(bool confirmed, int typeresult)
        {

            _clickTypeKnow = typeresult;

            if (typeresult == 3)
            {
                txtAllReport.Text = "Todos os Veículos";
            }else if (typeresult == 4)
            {
                txtAllReport.Text = "Todos os Owners";
            }

            if (confirmed == true)
            {
                lvReports.Visibility = ViewStates.Gone;
                llNoReports.Visibility = ViewStates.Gone;
                llAllReport.Visibility = ViewStates.Visible;
            }
            else
            {
                lvReports.Visibility = ViewStates.Gone;
                llNoReports.Visibility = ViewStates.Visible;
                llAllReport.Visibility = ViewStates.Gone;
            }

        }

        public void UpdateReports(List<VehicleHistory> vehiclehistorylist, int typeconsult)
        {
            if (vehiclehistorylist.Count > 0)
            {
                adapter = new ReportListAdapter(Context, vehiclehistorylist, typeconsult);
                lvReports.Adapter = adapter;
                lvReports.Visibility = ViewStates.Visible;
                llNoReports.Visibility = ViewStates.Gone;
                llAllReport.Visibility = ViewStates.Gone;

                adapter.OnReportClick -= Adapter_OnReportClick;
                adapter.OnReportClick += Adapter_OnReportClick;

            }
            else
            {
                lvReports.Visibility = ViewStates.Gone;
                llNoReports.Visibility = ViewStates.Visible;
                llAllReport.Visibility = ViewStates.Gone;
            }

        }

        private void Adapter_OnReportClick(VehicleHistory report, int TypeConsult)
        {
            OnReportClickController?.Invoke(report, TypeConsult);
        }

        private void LoadView()
        {
            var view = Inflate(Context, Resource.Layout.activity_reports, this);

            FiltroReportClick = view.FindViewById<LinearLayout>(Resource.Id.FiltroReportClick);
            txtFiltroReport = view.FindViewById<TextView>(Resource.Id.txtFiltroReport);
            lvReports = view.FindViewById<ListView>(Resource.Id.lvReports);
            llNoReports = view.FindViewById<LinearLayout>(Resource.Id.llNoReports);

            llAllReport = view.FindViewById<LinearLayout>(Resource.Id.llAllReport);
            txtAllReport = view.FindViewById<TextView>(Resource.Id.txtAllReport);

            FiltroReportClick.Click -= FiltroReportClick_Click;
            FiltroReportClick.Click += FiltroReportClick_Click;
        }

        public void ChangeFiltro(string texto)
        {
            txtFiltroReport.Text = texto;
        }

        private void FiltroReportClick_Click(object sender, EventArgs e)
        {
            OnFiltroReportClick?.Invoke();
        }

    }
}