using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text.Format;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.Activities.NewRequestVehicles;
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Dashboard;
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Business.NewRequest;
using Newtonsoft.Json;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Android_Gestao_Frotas.Activities.NewRequest
{
    [Activity(Label = "Novo Pedido", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivityNewRequestController : ActivityBaseController
    {
        public const string SelectedVehicleIdExtra = "SELECTED_VEHICLE_ID_EXTRA";

        ActivityNewRequestView MainView;
        V7Toolbar Toolbar;

        IBusinessNewRequest _businessNewRequest;
        IBusinessDashboard _businessDashboard;

        private DateTime _startDateTime;
        private DateTime _endDateTime;
        Vehicle vehicle;

        private bool _isContinuos = false;

        private Vehicle _selectedVehicle = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _businessNewRequest = new BusinessNewRequest();
            _businessDashboard = new BusinessDashboard();

            LoadView();
        }

        private void LoadView()
        {
            MainView = new ActivityNewRequestView(this);
            SetContentView(MainView);

            Toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(Toolbar);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar?.SetHomeButtonEnabled(true);
            Toolbar.NavigationClick += (o, a) => { OnBackPressed(); };

            MainView.OnStartDateClick -= MainView_OnStartDateClick;
            MainView.OnStartDateClick += MainView_OnStartDateClick;

            MainView.OnStartTimeClick -= MainView_OnStartTimeClick;
            MainView.OnStartTimeClick += MainView_OnStartTimeClick;

            MainView.OnEndDateClick -= MainView_OnEndDateClick;
            MainView.OnEndDateClick += MainView_OnEndDateClick;

            MainView.OnEndTimeClick -= MainView_OnEndTimeClick;
            MainView.OnEndTimeClick += MainView_OnEndTimeClick;

            MainView.OnContinuosCheckChange -= MainView_OnContinuosCheckChange;
            MainView.OnContinuosCheckChange += MainView_OnContinuosCheckChange;

            MainView.OnSelectVehicleClick -= MainView_OnSelectVehicleClick;
            MainView.OnSelectVehicleClick += MainView_OnSelectVehicleClick;

            MainView.OnFinishClick -= MainView_OnFinishClick;
            MainView.OnFinishClick += MainView_OnFinishClick;

            MainView.OnChangeVehicleClick -= MainView_OnChangeVehicleClick;
            MainView.OnChangeVehicleClick += MainView_OnChangeVehicleClick;
        }

        private void MainView_OnChangeVehicleClick()
        {
            VehicleSet();
        }

        private void VehicleSet()
        {
            if (_isContinuos == false)
            {
                if (_endDateTime != null && _startDateTime != null && _endDateTime != DateTime.MinValue && _startDateTime != DateTime.MinValue && _endDateTime > _startDateTime)
                {
                    var intent = new Intent(this, typeof(ActivityNewRequestVehiclesController));
                    intent.PutExtra(ActivityNewRequestVehiclesController.ExtraStartDateTimeInBinary, _startDateTime.ToBinary());
                    intent.PutExtra(ActivityNewRequestVehiclesController.ExtraEndDateTimeInBinary, _endDateTime.ToBinary());
                    intent.PutExtra(ActivityNewRequestVehiclesController.ExtraIsContinuos, _isContinuos);
                    StartActivityForResult(intent, SelectVehicleRequestCode);
                }
            }
            else if (_isContinuos == true)
            {
                if (_startDateTime != null && _startDateTime != DateTime.MinValue)
                {
                    var intent = new Intent(this, typeof(ActivityNewRequestVehiclesController));
                    intent.PutExtra(ActivityNewRequestVehiclesController.ExtraStartDateTimeInBinary, _startDateTime.ToBinary());
                    intent.PutExtra(ActivityNewRequestVehiclesController.ExtraEndDateTimeInBinary, _endDateTime.ToBinary());
                    intent.PutExtra(ActivityNewRequestVehiclesController.ExtraIsContinuos, _isContinuos);
                    StartActivityForResult(intent, SelectVehicleRequestCode);
                }
            }
        }

        private void MainView_OnSelectVehicleClick()
        {
            VehicleSet();
        }

        private void MainView_OnContinuosCheckChange(bool check)
        {
            _isContinuos = check;
            if (_isContinuos == false)
            {
                _endDateTime = DateTime.MinValue;
            }
        }

        private async void MainView_OnEndTimeClick()
        {
            var endTime = await new DialogHelper(this).PickTime();
            if (endTime != DateTime.MinValue)
            {
                if (_endDateTime == null)
                    _endDateTime = new DateTime();

                _endDateTime = new DateTime(_endDateTime.Year, 
                                _endDateTime.Month, 
                                _endDateTime.Day, 
                                endTime.Hour, 
                                endTime.Minute, 
                                endTime.Second);

                MainView.SetEndTimeText(endTime.ToShortTimeString());

                Littlefix();

            }
        }

        private void Littlefix()
        {
            vehicle = null;
            var vehiclexd = new Vehicle { Id = -1 };
            MainView.SetSelectedVehicle(vehiclexd);
        }

        private async void MainView_OnEndDateClick()
        {
            var endDate = await new DialogHelper(this).PickDate();
            if (endDate != DateTime.MinValue)
            {
                if (_endDateTime == null)
                    _endDateTime = new DateTime();

                _endDateTime = new DateTime(endDate.Year,
                                endDate.Month,
                                endDate.Day,
                                _endDateTime.Hour,
                                _endDateTime.Minute,
                                _endDateTime.Second);

                MainView.SetEndDateText(endDate.ToShortDateString());

                Littlefix();
            }
        }

        private async void MainView_OnStartTimeClick()
        {
            var startTime = await new DialogHelper(this).PickTime();
            if (startTime != DateTime.MinValue)
            {
                if (_startDateTime == null)
                    _startDateTime = new DateTime();

                _startDateTime = new DateTime(_startDateTime.Year,
                                _startDateTime.Month,
                                _startDateTime.Day,
                                startTime.Hour,
                                startTime.Minute,
                                startTime.Second);

                MainView.SetStartTimeText(startTime.ToShortTimeString());

                Littlefix();
            }
        }

        private async void MainView_OnStartDateClick()
        {
            var startDate = await new DialogHelper(this).PickDate();
            if (startDate != DateTime.MinValue)
            {
                if (_startDateTime == null)
                    _startDateTime = new DateTime();

                _startDateTime = new DateTime(startDate.Year,
                                startDate.Month,
                                startDate.Day,
                                _startDateTime.Hour,
                                _startDateTime.Minute,
                                _startDateTime.Second);

                MainView.SetStartDateText(startDate.ToShortDateString());

                Littlefix();
            }
        }

        private async void MainView_OnFinishClick()
        {
            SetLoadingView(true, false, $"A registar novo pedido de marcação...");
            if (vehicle != null)
            {
                if (_isContinuos)
                    _endDateTime = DateTime.MaxValue.ToUniversalTime();

                var sobreposicao = await _businessNewRequest.ExisteSobreposicao(AllYouCanGet.CurrentUser.Id, _startDateTime, _endDateTime);
                if (sobreposicao.Id == -1)
                {
                    var sucess = await _businessNewRequest.NewRequest(AllYouCanGet.CurrentUser, DateTime.Now, _selectedVehicle, _startDateTime, _endDateTime);
                    if (sucess)
                    {
                        await new DialogHelper(this).Message($"Pedido de marcação criado com sucesso.");
                        SetResult(Result.Ok);
                        Finish();
                    }
                    else
                    {
                        await new DialogHelper(this).Message($"Não foi possível registar o seu pedido de marcação, tente mais tarde.");
                    }
                }
                else
                {
                    sobreposicao.Vehicle = await _businessNewRequest.GetVehicle(sobreposicao.Vehicle.Id);
                    var result3 = await new DialogHelper(this).UserInput("Existe Sobreposição com o Veículo:\n" + sobreposicao.Vehicle.ToString() + "\nInsira Justificação:");
                    if (result3 != string.Empty && result3 != "")
                    {

                        var sucess = await _businessNewRequest.NewRequest(AllYouCanGet.CurrentUser, DateTime.Now, _selectedVehicle, _startDateTime, _endDateTime);
                        var requestlast = await _businessNewRequest.GetlastRequestHistory();
                        RequestJustification justificationSend = new RequestJustification
                        {
                            Id = -1,
                            IsIncomplete = false,
                            Justification = result3,
                            Request = requestlast.Request,
                            RequestJustificationType = new RequestJustificationType { Id = 1, Description = "Pedido de Marcação", IsIncomplete = false },
                        };

                        var sucess2 = await _businessDashboard.AddJustification(justificationSend, sobreposicao.Request.Id);
                        if (sucess)
                        {
                            await new DialogHelper(this).Message($"Pedido de marcação criado com sucesso.");
                            SetResult(Result.Ok);
                            Finish();
                        }
                        else
                        {
                            await new DialogHelper(this).Message($"Não foi possível registar o seu pedido de marcação, tente mais tarde.");
                        }
                    }
                }
            }
            else
            {
                await new DialogHelper(this).Message("Selecione um Veiculo!");
            }

            SetLoadingView(false);
        }

        private async void GetSelectedVehicle(int vehicleId)
        {
            SetLoadingView(true);

            vehicle = await _businessNewRequest.GetVehicle(vehicleId);
            _selectedVehicle = vehicle;

            MainView.SetSelectedVehicle(_selectedVehicle);

            SetLoadingView(false);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            switch (requestCode)
            {
                case SelectVehicleRequestCode:
                    if (resultCode == Result.Ok)
                    {
                        var vehicleId = data.GetIntExtra(SelectedVehicleIdExtra, BaseModel.Null);
                        if (vehicleId != BaseModel.Null)
                        {
                            GetSelectedVehicle(vehicleId);
                        }
                    }
                    else
                    {
                        //does nothing, operation was canceled
                    }
                    break;
            }
        }
    }
}