using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Content.PM;

using Newtonsoft.Json;

using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Dashboard;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Business.Requests;
using Core_Gestao_Frotas;
using Android_Gestao_Frotas.Activities.Users;
using Android_Gestao_Frotas.Activities.Vehicles;
using Android_Gestao_Frotas.Activities.UserInfo;
using Android_Gestao_Frotas.Activities.NewPassword;
using Android_Gestao_Frotas.Activities.NewRequestVehicles;
using Android_Gestao_Frotas.Activities.NewRequest;
using Android_Gestao_Frotas.Helpers;
using Android_Gestao_Frotas.Activities.Reports;
using Android_Gestao_Frotas.Activities.Damage;
using Android_Gestao_Frotas.Activities.RequestsList;
using Android_Gestao_Frotas.Activities.ProfileList;

using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Square.Picasso;
using Android.Graphics;
using Android_Gestao_Frotas.Activities.Configurations;

namespace Android_Gestao_Frotas.Activities.Dashboard
{
    [Activity(Label = "Gestão de Frotas", Theme = "@style/AppTheme", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ActivityDashboardController : ActivityBaseController
    {
        ActivityDashboardView MainView;
        DrawerLayout DrawerLayout;
        NavigationView NavigationView;
        V7Toolbar Toolbar;

        private IBusinessDashboard _businessDashboard;

        private List<RequestHistory> _requestsForApproval;
        private List<RequestHistory> _requestsUnavailable;
        private List<RequestHistory> _requestsActive;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _businessDashboard = new BusinessDashboard();

            LoadView();
            MainView.Checkpermissionsdashboard();
            LoadDataAsync();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    DrawerLayout.OpenDrawer(GravityCompat.Start);
                    break;
                case Resource.Id.action_refresh:
                    RefreshRequests();
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.dashboard_options_menu, menu);
            return true;
        }

        protected async override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == CreateRequestRequestCode)
            {
                if (resultCode == Result.Ok)
                {
                    SetLoadingView(true, false, $"A actualizar pedidos de marcação...");
                    await LoadRequestsForApproval();
                    SetLoadingView(false);
                }
            }
            else if (requestCode == AvailableRequestRequestCode)
            {
                if (resultCode == Result.Ok)
                {
                    var dialogResult = await new DialogHelper(this).Message($"Veículo foi disponibilizado com sucesso.");

                    SetLoadingView(true, false, $"A actualizar pedidos de marcação...");
                    await LoadRequestsUnavailable();
                    SetLoadingView(false);
                }
            }
            else if (requestCode == ChangePasswordRequestRequestCode)
            {
                if (resultCode == Result.Ok)
                {
                    var dialogResult = await new DialogHelper(this).Message($"Password alterada com sucesso.");
                    SetLoadingView(true);
                    //AllYouCanGet.CurrentUser =  await _dashboardBusiness.GetNewUser(AllYouCanGet.CurrentUser);
                    SetLoadingView(false);
                }
            }
            else if (requestCode == ComebackRequests)
            {
                await LoadRequestsForApproval();
                await LoadRequestsUnavailable();
                await LoadRequestsEncourse();
            }
            else if (requestCode == ConfigurationsChange)
            {
                if (resultCode == Result.Ok)
                {
                    var dialogResult = await new DialogHelper(this).Message("Alterações Guardadas com sucesso.");
                }
            }else if (requestCode == CreateRequestRequestCode)
            {
                if (resultCode == Result.Ok)
                {
                    await LoadRequestsForApproval();
                }
            }
        }

        #region Methods

        private void LoadView()
        {
            MainView = new ActivityDashboardView(this);
            SetContentView(MainView);

            Toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(Toolbar);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar?.SetHomeButtonEnabled(true);

            DrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            NavigationView = FindViewById<NavigationView>(Resource.Id.navigationView);

            SupportActionBar?.SetHomeAsUpIndicator(Resource.Drawable.ic_dashboard_menu);

            MainView.LoadMenu(NavigationView);

            MainView.OnMenuOptionClick -= MainView_OnMenuOptionClick;
            MainView.OnMenuOptionClick += MainView_OnMenuOptionClick;

            MainView.OnClickNewPedido -= MainView_OnClickNewPedido;
            MainView.OnClickNewPedido += MainView_OnClickNewPedido;

            MainView.OnApproveRequestClick -= MainView_OnApproveRequestClick;
            MainView.OnApproveRequestClick += MainView_OnApproveRequestClick;

            MainView.OnCancelRequestClick -= MainView_OnCancelRequestClick;
            MainView.OnCancelRequestClick += MainView_OnCancelRequestClick;

            MainView.OnRefreshRequestClick -= MainView_OnRefreshRequestClick;
            MainView.OnRefreshRequestClick += MainView_OnRefreshRequestClick;

            MainView.OnTerminateRequestClick -= MainView_OnTerminateRequestClick;
            MainView.OnTerminateRequestClick += MainView_OnTerminateRequestClick;

            //TODO: add a requestsactivity for approval, unavailable & encourse gtfo

            MainView.OnAllEncourseClick -= MainView_OnAllEncourseClick;
            MainView.OnAllEncourseClick += MainView_OnAllEncourseClick;

            MainView.OnAllForApprovalClick -= MainView_OnAllForApprovalClick;
            MainView.OnAllForApprovalClick += MainView_OnAllForApprovalClick;

            MainView.OnAllUnavailableClick -= MainView_OnAllUnavailableClick;
            MainView.OnAllUnavailableClick += MainView_OnAllUnavailableClick;

        }

        private void MainView_OnAllUnavailableClick()
        {
            var intent5 = new Intent(this, typeof(ActivityRequestsListController));
            intent5.PutExtra("user", JsonConvert.SerializeObject(AllYouCanGet.CurrentUser));
            intent5.PutExtra(ActivityRequestsListController.RequestsExtraType, 1);
            StartActivityForResult(intent5, ComebackRequests);
        }

        private void MainView_OnAllForApprovalClick()
        {
            var intent6 = new Intent(this, typeof(ActivityRequestsListController));
            intent6.PutExtra("user", JsonConvert.SerializeObject(AllYouCanGet.CurrentUser));
            intent6.PutExtra(ActivityRequestsListController.RequestsExtraType, 2);
            StartActivityForResult(intent6, ComebackRequests);
        }

        private void MainView_OnAllEncourseClick()
        {
            var intent7 = new Intent(this, typeof(ActivityRequestsListController));
            intent7.PutExtra("user", JsonConvert.SerializeObject(AllYouCanGet.CurrentUser));
            intent7.PutExtra(ActivityRequestsListController.RequestsExtraType, 3);
            StartActivityForResult(intent7, ComebackRequests);
        }

        private async void LoadDataAsync()
        {
            SetLoadingView(true, false, $"A carregar veículos e pedidos de marcação...");

            var loadVehiclesSuccess = await _businessDashboard.LoadVehicles();
            var loadRequestsSuccess = await _businessDashboard.LoadRequests();

            if (loadVehiclesSuccess && loadRequestsSuccess)
            {
                SaveTime(true, $"LoadVehicles&Requests");
                SetLoadingMessage($"A carregar pedidos por aprovar...");

                await LoadRequestsForApproval();

                SaveTime(true, $"LoadRequestsForApproval");
                SetLoadingMessage($"A carregar pedidos por disponíbilizar...");

                await LoadRequestsUnavailable();

                SaveTime(true, $"LoadRequestsUnavailable");
                SetLoadingMessage($"A carregar pedidos em curso...");

                await LoadRequestsEncourse();

                SaveTime(true, $"LoadRequestsEncourse");
                //MainView.Checkpermissionsdashboard();
            }
            else
            {
                var response = await new DialogHelper(this).Message($"Não foi possível carregar os dados necessários para a aplicação funcionar correctamente, verifique a conecção à internet e tente mais tarde.");
                //TODO: maybe logout?
            }

            try
            {
                var packageInfo = PackageManager.GetPackageInfo(PackageName, 0);
                var appversion = packageInfo.VersionName;
                MainView.UpdateMenuHeader(AllYouCanGet.CurrentUser, $"v{appversion}");
            }
            catch (PackageManager.NameNotFoundException e)
            {
                e.PrintStackTrace();
                MainView.UpdateMenuHeader(AllYouCanGet.CurrentUser, "v0.0.0.0");
            }

            SetLoadingView(false);
        }

        private void RefreshRequests()
        {
            //SetLoadingView(true, false, $"A actualizar pedidos...");

            //await LoadRequestsForApproval();

            //await LoadRequestsUnavailable();

            //await LoadRequestsEncourse();

            LoadDataAsync();

            //SetLoadingView(false);
        }

        private async Task LoadRequestsForApproval()
        {
            _requestsForApproval = (await _businessDashboard.GetRequestsForApproval()).ToList();
            MainView.UpdateRequestsForApproval(_requestsForApproval);
        }

        private async Task LoadRequestsUnavailable()
        {
            _requestsUnavailable = (await _businessDashboard.GetRequestsUnavailable()).ToList();
            MainView.UpdateRequestsUnavailable(_requestsUnavailable);
        }

        private async Task LoadRequestsEncourse()
        {
            _requestsActive = (await _businessDashboard.GetRequestsEncourse()).ToList();
            MainView.UpdateRequestsEncourse(_requestsActive);
        }

        #endregion

        #region Events

        private void MainView_OnMenuOptionClick(MenuOption option)
        {
            switch (option)
            {
                case MenuOption.RequestsEncourse:
                    var intent7 = new Intent(this, typeof(ActivityRequestsListController));
                    intent7.PutExtra("user", JsonConvert.SerializeObject(AllYouCanGet.CurrentUser));
                    intent7.PutExtra(ActivityRequestsListController.RequestsExtraType, 3);
                    StartActivityForResult(intent7, ComebackRequests);
                    break;
                case MenuOption.RequestsForApproval:
                    var intent6 = new Intent(this, typeof(ActivityRequestsListController));
                    intent6.PutExtra("user", JsonConvert.SerializeObject(AllYouCanGet.CurrentUser));
                    intent6.PutExtra(ActivityRequestsListController.RequestsExtraType, 2);
                    StartActivityForResult(intent6, ComebackRequests);
                    break;
                case MenuOption.RequestsUnavailable:
                    var intent5 = new Intent(this, typeof(ActivityRequestsListController));
                    intent5.PutExtra("user", JsonConvert.SerializeObject(AllYouCanGet.CurrentUser));
                    intent5.PutExtra(ActivityRequestsListController.RequestsExtraType, 1);
                    StartActivityForResult(intent5, ComebackRequests);
                    break;
                case MenuOption.RequestsHistory:
                    var intent = new Intent(this, typeof(ActivityRequestsListController));
                    intent.PutExtra("user", JsonConvert.SerializeObject(AllYouCanGet.CurrentUser));
                    intent.PutExtra(ActivityRequestsListController.RequestsExtraType, 0);
                    StartActivityForResult(intent, ComebackRequests);
                    break;
                case MenuOption.Vehicles:
                    StartActivity(typeof(ActivityVehiclesController));
                    break;
                case MenuOption.Reports:
                    var intent2 = new Intent(this, typeof(ActivityReportGeneratorController));
                    intent2.PutExtra("user", JsonConvert.SerializeObject(AllYouCanGet.CurrentUser));
                    StartActivity(intent2);
                    break;
                case MenuOption.Users:
                    StartActivity(typeof(ActivityUsersController));
                    break;
                case MenuOption.SettingsGlobal:
                    var intent3 = new Intent(this, typeof(ActivityConfigurationController));
                    intent3.PutExtra(ActivityConfigurationController.ConfigurationExtraTest, 0);
                    StartActivity(intent3);
                    break;
                case MenuOption.SettingsLocal:
                    var intent4 = new Intent(this, typeof(ActivityConfigurationController));
                    intent4.PutExtra(ActivityConfigurationController.ConfigurationExtraTest, 1);
                    StartActivity(intent4);
                    break;
                case MenuOption.Logout:
                    SetResult(Result.Ok);
                    Finish();
                    break;
            }

            DrawerLayout.CloseDrawers();
        }

        private async void MainView_OnTerminateRequestClick(RequestHistory request, string justification)
        {
            RequestJustification justificationSend = new RequestJustification
            {
                Id = -1,
                IsIncomplete = false,
                Justification = justification,
                Request = request.Request,
                RequestJustificationType = new RequestJustificationType { Id = 2, Description = "Pedido de cancelamento", IsIncomplete = false },
            };

            SetLoadingView(true, false, "A cancelar o pedido...");
            var result = await _businessDashboard.AddJustification(justificationSend, request.Request.Id);
            var result2 = await _businessDashboard.CancelRequest(request);
            SetLoadingView(false);

            if (result == true && result2 == true)
            {
                var result3 = await new DialogHelper(this).Message($"Pedido Cancelado.");
            }

            await LoadRequestsForApproval();
            await LoadRequestsUnavailable();
            await LoadRequestsEncourse();

        }

        private async void MainView_OnCancelRequestClick(RequestHistory request)
        {
            SetLoadingView(true, false, $"A cancelar pedido de marcação...");

            var resultSuccess = await _businessDashboard.CancelRequest(request);

            if (resultSuccess)
            {
                await new DialogHelper(this).Message($"Pedido cancelado com sucesso.");

                SetLoadingMessage($"A actualizar pedidos de marcação por aprovar...");
                await LoadRequestsForApproval();
            }
            else
            {
                await new DialogHelper(this).Message($"Não foi possível concluir a operação, tente mais tarde.");
            }

            SetLoadingView(false);
        }

        private async void MainView_OnApproveRequestClick(RequestHistory request)
        {
            SetLoadingView(true, true, $"A aprovar pedido de marcação...");

            var resultSuccess = await _businessDashboard.ApproveRequest(request);

            if (resultSuccess)
            {
                await new DialogHelper(this).Message($"Pedido aceite com sucesso.");

                SetLoadingMessage($"A actualizar pedidos de marcação por aprovar...");
                await LoadRequestsForApproval();
                await LoadRequestsEncourse();
            }
            else
            {
                await new DialogHelper(this).Message($"Não foi possível concluir a operação, tente mais tarde.");
            }

            SetLoadingView(false);
        }

        private void MainView_OnRefreshRequestClick(RequestHistory requestHistory)
        {
            AllYouCanGet.CurrentRequest = requestHistory;

            var intent = new Intent(this, typeof(ActivityDamageController));
            StartActivityForResult(intent, AvailableRequestRequestCode);
        }

        private async void MainView_OnClickNewPedido()
        {
            //var request = await _businessDashboard.GetRequestHistory(86);
            //AllYouCanGet.CurrentRequest = request;
            //StartActivity(typeof(ActivityDamageController));

            var intent = new Intent(this, typeof(ActivityNewRequestController));
            intent.PutExtra("user", JsonConvert.SerializeObject(AllYouCanGet.CurrentUser));
            StartActivityForResult(intent, CreateRequestRequestCode);
        }

        #endregion
    }
}