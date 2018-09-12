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
using Android_Gestao_Frotas.Activities.ReportSelected;
using Android_Gestao_Frotas.Adapters;
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Dashboard;
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Business.Reports;
using Newtonsoft.Json;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Android_Gestao_Frotas.Activities.ReportsList
{
    [Activity(Label = "Relatórios Gerados", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivityReportsController : ActivityBaseController
    {
        V7Toolbar Toolbar;
        ActivityReportsView MainView;

        private IBusinessReports _businessReports;

        private List<User> _users;
        private List<Vehicle> _vehicles;
        private DateTime _datestart;
        private DateTime _datefinish;

        private List<VehicleHistory> _vehicleHistory;
        List<VehicleHistory> listafiltro = new List<VehicleHistory>();

        List<string> FiltroList = new List<string> { "Owner/Veículo",
            "Todos os Owners do Veículo",
            "Todos os Veículos do Owner",
            "Relatorio de Todos os Veículos",
            "Relatorio de Todos os Owners"};
        private int _SelectedFiltroOption = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            LoadView();
            LoadDataAsync();

        }

        private void LoadView()
        {
            MainView = new ActivityReportsView(this);
            SetContentView(MainView);

            _businessReports = new BusinessReports();

            Toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(Toolbar);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar?.SetHomeButtonEnabled(true);
            Toolbar.NavigationClick += (o, a) => { SetResult(Result.Canceled); Finish(); };

            _users = AllYouCanGet.ReportProcess.SelectedUsers;
            _vehicles = AllYouCanGet.ReportProcess.SelectedVehicles;
            _datestart = AllYouCanGet.ReportProcess.StartDateTime;
            _datefinish = AllYouCanGet.ReportProcess.EndDateTime;

            MainView.OnFiltroReportClick -= MainView_OnFiltroReportClick;
            MainView.OnFiltroReportClick += MainView_OnFiltroReportClick;

            MainView.OnAllReportClick -= MainView_OnAllReportClick;
            MainView.OnAllReportClick += MainView_OnAllReportClick;

            MainView.OnReportClickController -= MainView_OnReportClickController;
            MainView.OnReportClickController += MainView_OnReportClickController;
        }

        private void MainView_OnReportClickController(VehicleHistory report, int TypeConsult)
        {

            AllYouCanGet.ReportProcess.selectedtarget = new VehicleHistory();
            AllYouCanGet.ReportProcess.selectedtarget = report;

            if (TypeConsult == 0)
            {
                var ListaFiltroThree = listafiltro.Where(x => (x.RequestHistory.Vehicle.Id == report.RequestHistory.Vehicle.Id) && (x.RequestHistory.User.Id == report.RequestHistory.User.Id));
                SendReport(ListaFiltroThree.ToList(), TypeConsult);
            }else if (TypeConsult == 1)
            {
                var ListaFiltroThree = listafiltro.Where(x => (x.RequestHistory.Vehicle.Id == report.RequestHistory.Vehicle.Id));
                SendReport(ListaFiltroThree.ToList(), TypeConsult);
            }
            else if (TypeConsult == 2)
            {
                var ListaFiltroThree = listafiltro.Where(x => (x.RequestHistory.User.Id == report.RequestHistory.User.Id));
                SendReport(ListaFiltroThree.ToList(), TypeConsult);
            }
        }

        private void MainView_OnAllReportClick(int TypeConsult)
        {
            SendReport(listafiltro, TypeConsult);
        }

        private void SendReport(List<VehicleHistory> lista, int TypeConsult)
        {
            AllYouCanGet.ReportProcess.TypeConsult = TypeConsult;
            AllYouCanGet.ReportProcess.ListaFiltrada = new List<VehicleHistory>(lista);

            var intent = new Intent(this, typeof(ActivityReportSelectedController));
            StartActivityForResult(intent, ReportSelectedRequestCode);

        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == ReportSelectedRequestCode)
            {
                if (resultCode == Result.Ok)
                {
                    SetResult(Result.Ok);
                    Finish();
                }
            }
        }

        private async void MainView_OnFiltroReportClick()
        {
            var selected = await new DialogHelper(this).Pick(FiltroList);
            _SelectedFiltroOption = FiltroList.FindIndex(a => a == selected);
            MainView.ChangeFiltro(FiltroList[_SelectedFiltroOption]);
            LoadReports();
        }

        private void LoadReports()
        {
            SetLoadingView(true);

            listafiltro.Clear();

            for (int p = 0; p < _vehicleHistory.Count; p++)
            {
                for (int i = 0; i < _users.Count; i++)
                {
                    for (int o = 0; o < _vehicles.Count; o++)
                    {
                        if (_vehicleHistory[p].RequestHistory.Vehicle.Id == _vehicles[o].Id && _vehicleHistory[p].RequestHistory.User.Id == _users[i].Id && _vehicleHistory[p].RequestHistory.EndDate <= _datefinish && _vehicleHistory[p].RequestHistory.StartDate >= _datestart)
                        {
                            listafiltro.Add(_vehicleHistory[p]);
                        }
                    }
                }
            }
            //CHECK REAL
            if (_SelectedFiltroOption == 0)
            {
                List<VehicleHistory> listafiltroTwo = new List<VehicleHistory>();

                for (int i = 0; i < listafiltro.Count; i++)
                {
                    if (listafiltroTwo.Any(x => (x.RequestHistory.Vehicle.Id == listafiltro[i].RequestHistory.Vehicle.Id) && (x.RequestHistory.User.Id == listafiltro[i].RequestHistory.User.Id)) == false)
                    {
                        listafiltroTwo.Add(listafiltro[i]);
                    }
                }

                MainView.UpdateReports(listafiltroTwo, 0);

            }
            else if (_SelectedFiltroOption == 1)
            {

                List<VehicleHistory> listafiltroTwo = new List<VehicleHistory>();

                for (int i = 0; i < listafiltro.Count; i++)
                {
                    if (listafiltroTwo.Any(x => (x.RequestHistory.Vehicle.Id == listafiltro[i].RequestHistory.Vehicle.Id)) == false)
                    {
                        listafiltroTwo.Add(listafiltro[i]);
                    }
                }

                MainView.UpdateReports(listafiltroTwo, 1);

            }
            else if (_SelectedFiltroOption == 2)
            {

                List<VehicleHistory> listafiltroTwo = new List<VehicleHistory>();

                for (int i = 0; i < listafiltro.Count; i++)
                {
                    if (listafiltroTwo.Any(x => (x.RequestHistory.User.Id == listafiltro[i].RequestHistory.User.Id)) == false)
                    {
                        listafiltroTwo.Add(listafiltro[i]);
                    }
                }

                MainView.UpdateReports(listafiltroTwo, 2);

            }
            else if (_SelectedFiltroOption == 3)
            {
                if (listafiltro.Count > 0)
                {
                    MainView.AllStats(true, 3);
                }
                else
                {
                    MainView.AllStats(false, 3);
                }
            }else if (_SelectedFiltroOption == 4)
            {
                if (listafiltro.Count > 0)
                {
                    MainView.AllStats(true, 4);
                }
                else
                {
                    MainView.AllStats(false, 4);
                }
            }
            SetLoadingView(false);
        }

        private async void LoadDataAsync()
        {
            SetLoadingView(true);

            _vehicleHistory = (await _businessReports.GetAllVehicleHistory()).ToList();

            if (_users.Count == 0)
            {
                _users = (await _businessReports.GetSelectableUsers()).ToList();
            }
            if (_vehicles.Count == 0)
            {
                _vehicles = (await _businessReports.GetAllActiveVehicles()).ToList();
            }
            //_vehicles = (await _BusinessDashboard.GetVehiclesRepository()).ToList();
            //_vehiclehistorys = (await _BusinessDashboard.GetVehicleHistory()).ToList();
            //_requesthistorys = (await _BusinessDashboard.GetRequestsActiveAll()).ToList();
            //_fragmentOwner.UpdateOwner(_requesthistorys, _vehiclehistorys, _vehicles, _userget, _datainicioget, _datafimget, _typeget);

            MainView.ChangeFiltro(FiltroList[0]);
            LoadReports();

            SetLoadingView(false);
        }

    }
}