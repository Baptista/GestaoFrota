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
using Android_Gestao_Frotas.Activities.Damage;
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Dashboard;
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Business.Requests;
using Core_Gestao_Frotas.Business.VehicleInfo;
using Newtonsoft.Json;

namespace Android_Gestao_Frotas.Activities.RequestsList
{
    [Activity(Label = "Lista de Marcações", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivityRequestsListController : ActivityBaseController
    {

        Android.Support.V7.Widget.Toolbar Toolbar;
        ActivityRequestsListView MainView;
        int openoptionsmenu = 0;
        private List<RequestHistory> _requestsbase;
        private User userget;
        private List<User> _users;
        private List<Vehicle> _vehicles;

        private List<Model> _models;

        private User _userselected;
        private Vehicle _vehicleselected;

        private int _menurequestype;

        public const string RequestsExtraType = "REQUESTS_EXTRA_TYPE";

        private DateTime _datainicio = DateTime.MinValue;
        private DateTime _datafim = DateTime.MinValue;

        private RequestState _state;

        IBusinessDashboard _dashboardBusiness = new BusinessDashboard();
        IBusinessVeiculos _veiculosBusiness = new BusinessVeiculos();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _menurequestype = Intent.GetIntExtra(RequestsExtraType, 0);

            LoadView();

        }

        private void LoadView()
        {
            MainView = new ActivityRequestsListView(this);
            SetContentView(MainView);

            //userget = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra("user"));
            userget = AllYouCanGet.CurrentUser;

            Toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(Toolbar);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar?.SetHomeButtonEnabled(true);
            Toolbar.NavigationClick += (o, a) => { OnBackPressed(); };

            if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ViewUserRequests))
            {
                LoadDataAsyncAll();
            }
            else {
                _userselected = userget;
                LoadFix();
                MainView.ChangeUserText(_userselected.ToString());
                MainView.LockUser();
                //LoadDataAsyncFiltro();
                //LoadDataAsyncUser(userget);
            }

            MainView.OnUserTextViewClick -= MainView_OnUserTextViewClick;
            MainView.OnUserTextViewClick += MainView_OnUserTextViewClick;

            MainView.OnVehicleTextViewClick -= MainView_OnVehicleTextViewClick;
            MainView.OnVehicleTextViewClick += MainView_OnVehicleTextViewClick;

            MainView.CancelRequestController -= MainView_CancelRequestController;
            MainView.CancelRequestController += MainView_CancelRequestController;

            MainView.AcceptRequestController -= MainView_AcceptRequestController;
            MainView.AcceptRequestController += MainView_AcceptRequestController;

            MainView.OnFiltroClick -= MainView_OnFiltroClick;
            MainView.OnFiltroClick += MainView_OnFiltroClick;

            MainView.OnChangeDateStartClick -= MainView_OnChangeDateStartClick;
            MainView.OnChangeDateStartClick += MainView_OnChangeDateStartClick;

            MainView.OnChangeDateFinishClick -= MainView_OnChangeDateFinishClick;
            MainView.OnChangeDateFinishClick += MainView_OnChangeDateFinishClick;

            MainView.OnChangeStateClick -= MainView_OnChangeStateClick;
            MainView.OnChangeStateClick += MainView_OnChangeStateClick;

            MainView.OnCleanClick -= MainView_OnCleanClick;
            MainView.OnCleanClick += MainView_OnCleanClick;

            MainView.OnApplyClick -= MainView_OnApplyClick;
            MainView.OnApplyClick += MainView_OnApplyClick;

            MainView.RequestAvailableVehicleController += MainView_RequestAvailableVehicleController;
        }

        private void MainView_RequestAvailableVehicleController(RequestHistory request)
        {
            AllYouCanGet.CurrentRequest = request;

            var intent = new Intent(this, typeof(ActivityDamageController));
            StartActivityForResult(intent, AvailableRequestRequestCode);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == AvailableRequestRequestCode)
            {
                if (resultCode == Result.Ok)
                {
                    if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ViewUserRequests))
                    {
                        LoadDataAsyncAll();
                    }
                    else
                    {
                        _userselected = userget;
                        LoadFix();
                        MainView.ChangeUserText(_userselected.ToString());
                        MainView.LockUser();
                    }
                }
            }
        }

        private async void LoadFix()
        {
            SetLoadingView(true);
            _models = (await _veiculosBusiness.GetModels(false)).ToList();
            _requestsbase = (await _dashboardBusiness.GetRequestsActiveAll()).ToList();
            FixRequests();
            _users = (await _dashboardBusiness.GetUsersRepository()).ToList();
            _vehicles = (await _dashboardBusiness.GetVehiclesRepository()).ToList();
            MainView.UpdateRequestsActive(_requestsbase);
            SetLoadingView(false);

            LoadDataAsyncFiltro();
        }

        private void MainView_OnCleanClick()
        {
            _datainicio = DateTime.MinValue;
            _datafim = DateTime.MinValue;
            _state = null;

            if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ViewUserRequests))
            {
               _userselected = null;
                MainView.ClearAllText(0);
            }
            else
            {
                MainView.ClearAllText(1);
            }

            _vehicleselected = null;

            openoptionsmenu = 0;
            MainView.changeopenmenu(openoptionsmenu);
            SetLoadingView(true);
            if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ViewUserRequests))
            {
                MainView.UpdateRequestsActive(_requestsbase);
            }
            else
            {
                LoadFix();
            }
            SetLoadingView(false);
        }

        private void MainView_OnApplyClick()
        {
            LoadDataAsyncFiltro();
            openoptionsmenu = 0;
            MainView.changeopenmenu(openoptionsmenu);
        }

        private async void MainView_OnChangeStateClick()
        {
            List<RequestState> mylist = new List<RequestState>();
            if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ViewUserRequestsEncourse))
            {
                mylist.Add(new RequestState
                {
                    Id = 1,
                    Description = "Aprovado",
                    IsIncomplete = false
                });
                mylist.Add(new RequestState
                {
                    Id = 5,
                    Description = "Aprovado (Para Disponibilizar)",
                    IsIncomplete = false
                });
            }
            mylist.Add(new RequestState
            {
                Id = 2,
                Description = "Pendente",
                IsIncomplete = false
            });
            mylist.Add(new RequestState
            {
                Id = 3,
                Description = "Cancelado",
                IsIncomplete = false
            });
            mylist.Add(new RequestState
            {
                Id = 4,
                Description = "Terminado",
                IsIncomplete = false
            });
            _state = await new DialogHelper(this).Pick(mylist);
            if (_state != null)
            {
                MainView.ChangeStateText(_state.Description);
            }
        }

        private async void MainView_OnChangeDateFinishClick()
        {
            _datafim = await new DialogHelper(this).PickDate();
            if (_datafim != DateTime.MinValue)
            {
                MainView.ChangeDateFinishText(_datafim.ToShortDateString());
            }
        }

        private async void MainView_OnChangeDateStartClick()
        {

            _datainicio = await new DialogHelper(this).PickDate();
            if (_datainicio != DateTime.MinValue)
            {
                MainView.ChangeDateStartText(_datainicio.ToShortDateString());
            }

        }

        private void MainView_OnFiltroClick()
        {
            if (openoptionsmenu == 0)
            {
                openoptionsmenu = 1;
                MainView.changeopenmenu(openoptionsmenu);
            }
            else
            {
                openoptionsmenu = 0;
                MainView.changeopenmenu(openoptionsmenu);
                //LoadDataAsyncAll();
                //MainView.ClearText();
                //_userselected = null;
                //_vehicleselected = null;
            }
        }

        private async void MainView_CancelRequestController(RequestHistory request, string justification)
        {
            RequestJustification justificationSend = new RequestJustification {
                Id = -1,
                IsIncomplete = false,
                Justification = justification,
                Request = request.Request,
                RequestJustificationType = new RequestJustificationType { Id = 2, Description = "Pedido de cancelamento", IsIncomplete = false },
            };

            SetLoadingView(true,false, "A cancelar o pedido...");
            var result = await _dashboardBusiness.AddJustification(justificationSend, request.Request.Id);
            var result2 = await _dashboardBusiness.CancelRequest(request);
            SetLoadingView(false);

            if (result == true && result2 == true)
            {
                var result3 = await new DialogHelper(this).Message($"Pedido Cancelado.");
            }
              LoadDataAsyncAll();
        }

        private async void MainView_AcceptRequestController(RequestHistory request)
        {
            IBusinessRequests businessRequests = new BusinessRequests();

            SetLoadingView(true);
            var result = await businessRequests.AproveRequest(request);
            SetLoadingView(false);
            if (result == true)
            {
                var dialogResult = await new DialogHelper(this).Message($"Pedido Aceite.");
                LoadDataAsyncAll();
            }
        }

        private async void MainView_OnVehicleTextViewClick()
        {
            if (_userselected != null)
            {
                var requests = _requestsbase.Where(f => { return f.User.Id == _userselected.Id; }).ToList();
                var vehicles = new List<Vehicle>();
                //var allvehicles = new Vehicle
                //{
                //    LicensePlate = "Todos",
                //    IsIncomplete = true
                //};
                //vehicles.Add(allvehicles);
                for (int i = 0; i < requests.Count; i++)
                {
                    for (int o = 0; o < _vehicles.Count; o++)
                    {
                        if (requests[i].Vehicle.Id == _vehicles[o].Id)
                        {
                            if (!vehicles.Contains(_vehicles[o]))
                            {
                                vehicles.Add(_vehicles[o]);
                            }
                        }
                    }
                }
                _vehicleselected = await new DialogHelper(this).Pick(vehicles);
                if (_vehicleselected != null)
                {
                    MainView.ChangeVehicleText(_vehicleselected.ToString());
                }

            }
            else
            {
                _vehicleselected = await new DialogHelper(this).Pick(_vehicles);
                if (_vehicleselected != null)
                {
                    MainView.ChangeVehicleText(_vehicleselected.ToString());
                }
            }
        }

        private async void MainView_OnUserTextViewClick()
        {
            _userselected = await new DialogHelper(this).Pick(_users);
            if (_userselected != null)
            {
                MainView.ChangeUserText(_userselected.ToString());
                _vehicleselected = null;
                MainView.ChangeVehicleText("Veiculo...");
            }
            //LoadDataAsyncUser(_userselected);
        }

        private void FixRequests()
        {
            for (int i = 0; i < _requestsbase.Count; i++)
            {
                for (int o = 0; o < _models.Count; o++)
                {
                    if (_requestsbase[i].Vehicle.Model.Id == _models[o].Id)
                    {
                        _requestsbase[i].Vehicle.Model = _models[o];
                    }
                }
            }
        }

        private void LoadDataAsyncFiltro()
        {
            SetLoadingView(true);
            var _requestsquery = new List<RequestHistory>(_requestsbase);
            if (_userselected != null)
            {
                _requestsquery = _requestsquery.Where(x => x.User.Id == _userselected.Id).ToList();
            }
            if (_vehicleselected != null)
            {
                _requestsquery = _requestsquery.Where(x => x.Vehicle.Id == _vehicleselected.Id).ToList();
            }
            if (_datainicio != DateTime.MinValue && _datafim != DateTime.MinValue)
            {
                if (_datainicio < _datafim)
                {
                    _requestsquery = _requestsquery.Where(x => x.StartDate > _datainicio).ToList();
                    _requestsquery = _requestsquery.Where(x => x.EndDate < _datafim).ToList();
                }
            }

            if (_menurequestype == 1)
            {
                _state = new RequestState
                {
                    Id = 1,
                    Description = "Aprovado",
                    IsIncomplete = false
                };
                MainView.ChangeStateAtStart(_menurequestype);
                _menurequestype = 0;
            }
            else if (_menurequestype == 2)
            {
                _state = new RequestState
                {
                    Id = 2,
                    Description = "Pendente",
                    IsIncomplete = false
                };
                MainView.ChangeStateAtStart(_menurequestype);
                _menurequestype = 0;
            }
            else if (_menurequestype == 3)
            {
                _state = new RequestState
                {
                    Id = 1,
                    Description = "Aprovado",
                    IsIncomplete = false
                };
                MainView.ChangeStateAtStart(_menurequestype);
                _menurequestype = 0;
            }

            if (_state != null)
            {
                if (_state.Id < 5)
                {
                    _requestsquery = _requestsquery.Where(x => x.RequestState.Id == _state.Id).ToList();
                }else if (_state.Id == 5)
                {
                    _requestsquery = _requestsquery.Where(x => x.RequestState.Id == 1).ToList();
                    _requestsquery = _requestsquery.Where(x => x.EndDate < DateTime.Now).ToList();
                }
            }
            MainView.UpdateRequestsActive(_requestsquery);
            SetLoadingView(false);

        }

        private async void LoadDataAsyncAll()
        {
            SetLoadingView(true);
            _models = (await _veiculosBusiness.GetModels(false)).ToList();
            _requestsbase = (await _dashboardBusiness.GetRequestsActiveAll()).ToList();
            FixRequests();
            _users = (await _dashboardBusiness.GetUsersRepository()).ToList();
            _vehicles = (await _dashboardBusiness.GetVehiclesRepository()).ToList();
            MainView.UpdateRequestsActive(_requestsbase);
            SetLoadingView(false);

            _menurequestype = Intent.GetIntExtra(RequestsExtraType, 0);
            if (_menurequestype == 1)
            {
                _state = new RequestState
                {
                    Id = 5,
                    Description = "Aprovado (Para Disponibilizar)",
                    IsIncomplete = false
                };
                _menurequestype = _state.Id;
                MainView.ChangeStateAtStart(_menurequestype);
                LoadDataAsyncFiltro();
                _menurequestype = 0;
            }
            else if (_menurequestype == 2)
            {
                _state = new RequestState
                {
                    Id = 2,
                    Description = "Pendente",
                    IsIncomplete = false
                };
                _menurequestype = _state.Id;
                MainView.ChangeStateAtStart(_menurequestype);
                LoadDataAsyncFiltro();
                _menurequestype = 0;
            }
            else if (_menurequestype == 3)
            {
                _state = new RequestState
                {
                    Id = 1,
                    Description = "Aprovado",
                    IsIncomplete = false
                };
                _menurequestype = _state.Id;
                MainView.ChangeStateAtStart(_menurequestype);
                LoadDataAsyncFiltro();
                _menurequestype = 0;
            }

            MainView.ChangeStateAtStart(_menurequestype);
            _menurequestype = 0;

        }

        //private async void LoadDataAsyncUser(User user)
        //{
        //    MainView.ClearTextVehicle();
        //    MainView.Changeusertext(user);
        //    SetLoadingView(true);
        //    _requestsbase = (await _dashboardBusiness.GetRequestsActiveUser(user)).ToList();
        //    MainView.UpdateRequestsActive(_requestsbase);
        //    SetLoadingView(false);
        //}

        //private async void LoadDataAsyncUserVehicle(User user, Vehicle vehicle)
        //{
        //    MainView.Changeusertext(user);
        //    MainView.Changevehicletext(vehicle);
        //    SetLoadingView(true);
        //    var _requestsbase2 = (await _dashboardBusiness.GetRequestsActiveUserVehicle(user, vehicle)).ToList();
        //    MainView.UpdateRequestsActive(_requestsbase2);
        //    SetLoadingView(false);
        //}

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            if (userget.Profile.Id == 1)
            {
                MenuInflater.Inflate(Resource.Menu.search_menu, menu);
            }
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_search:
                    _datainicio = DateTime.MinValue;
                    _datafim = DateTime.MinValue;
                    _state = null;
                    _vehicleselected = null;

                    if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ViewUserRequests))
                    {
                        _userselected = null;
                        MainView.ClearAllText(0);
                    }
                    else
                    {
                        MainView.ClearAllText(1);
                    }

                    openoptionsmenu = 0;
                    MainView.changeopenmenu(openoptionsmenu);
                    LoadDataAsyncAll();
                    //Toast.MakeText(this, "It Works!", ToastLength.Short).Show();
                    //if (openoptionsmenu == 0)
                    //{
                    //    openoptionsmenu = 1;
                    //    MainView.changeopenmenu(openoptionsmenu);
                    //}
                    //else
                    //{
                    //    openoptionsmenu = 0;
                    //    MainView.changeopenmenu(openoptionsmenu);
                    //    LoadDataAsyncAll();
                    //    MainView.ClearText();
                    //    _userselected = null;
                    //    _vehicleselected = null;
                    //}
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }

    }
}