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
using Android_Gestao_Frotas.Activities.MultiSelectVehicles;
using Android_Gestao_Frotas.Activities.ReportsList;
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Dashboard;
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Business.Reports;
using Newtonsoft.Json;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Android_Gestao_Frotas.Activities.Reports
{
    [Activity(Label = "Relatórios", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivityReportGeneratorController : ActivityBaseController
    {
        ActivityReportGeneratorView MainView;
        V7Toolbar Toolbar;

        private List<User> _allUsers;

        private IBusinessReports _businessReports;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _businessReports = new BusinessReports();

            LoadView();
            LoadDataAsync(true);

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.userinfo_options_menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_finish:
                    MainView_OnContinueClick();
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void LoadView()
        {
            MainView = new ActivityReportGeneratorView(this);
            SetContentView(MainView);

            Toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(Toolbar);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar?.SetHomeButtonEnabled(true);
            Toolbar.NavigationClick += (o, a) => { OnBackPressed(); };

            MainView.OnUserClick -= MainView_OnUserClickAsync;
            MainView.OnUserClick += MainView_OnUserClickAsync;

            MainView.OnStartDateClick -= MainView_OnStartDateClickAsync;
            MainView.OnStartDateClick += MainView_OnStartDateClickAsync;

            MainView.OnEndDateClick -= MainView_OnEndDateClickAsync;
            MainView.OnEndDateClick += MainView_OnEndDateClickAsync;

            MainView.OnAddVehiclesClick -= MainView_OnAddVehiclesClick;
            MainView.OnAddVehiclesClick += MainView_OnAddVehiclesClick;

            MainView.OnAddUsersClick -= MainView_OnAddUsersClick;
            MainView.OnAddUsersClick += MainView_OnAddUsersClick;

            MainView.OnContinueClick -= MainView_OnContinueClick;
            MainView.OnContinueClick += MainView_OnContinueClick;
        }

        private async void LoadDataAsync(bool clearReportProcess)
        {
            SetLoadingView(true);

            if (clearReportProcess || _allUsers == null)
                _allUsers = await _businessReports.GetSelectableUsers();

            if (AllYouCanGet.ReportProcess == null || clearReportProcess)
                StartReportProcess();

            if (!AllYouCanGet.CurrentUser.Profile.IsActive(Permission.GenerateUserReport))
            {
                List<User> UtilizadorSolo = new List<User>();
                UtilizadorSolo.Add(AllYouCanGet.CurrentUser);
                AllYouCanGet.ReportProcess.SelectedUsers = new List<User>(UtilizadorSolo);
            }

            //MainView.SetUserEnabled(AllYouCanGet.CurrentUser.Profile.IsActive(Permission.GenerateUserReport));
            //MainView.SetUserText(AllYouCanGet.ReportProcess.SelectedUser.ToString());
            MainView.SetStartDateText(DateTimeToString(AllYouCanGet.ReportProcess.StartDateTime));
            MainView.SetEndDateText(DateTimeToString(AllYouCanGet.ReportProcess.EndDateTime));
            MainView.SetVehiclesAdapter(AllYouCanGet.ReportProcess.SelectedVehicles);
            MainView.SetUsersAdapter(AllYouCanGet.ReportProcess.SelectedUsers);

            SetLoadingView(false);
        }

        private void StartReportProcess()
        {
            AllYouCanGet.ReportProcess = new ReportProcessData();

            //AllYouCanGet.ReportProcess.SelectedUser = AllYouCanGet.CurrentUser;
            AllYouCanGet.ReportProcess.StartDateTime = DateTime.MinValue;
            AllYouCanGet.ReportProcess.EndDateTime = DateTime.MaxValue;
            AllYouCanGet.ReportProcess.SelectedVehicles = new List<Vehicle>();
            AllYouCanGet.ReportProcess.SelectedUsers = new List<User>();
        }

        private string DateTimeToString(DateTime date)
        {
            if (date == DateTime.MinValue || date == DateTime.MaxValue)
                return "--/--/----";
            else
                return date.ToString("dd/MM/yyyy");
        }

        private void MainView_OnAddVehiclesClick()
        {
            var intent = new Intent(this, typeof(ActivityMultiSelectVehiclesController));
            intent.PutExtra(ActivityMultiSelectVehiclesController.ExtraIsToSelectVehicles, true);
            StartActivityForResult(intent, SelectMultipleVehiclesRequestCode);
        }

        private void MainView_OnAddUsersClick()
        {
            var intent = new Intent(this, typeof(ActivityMultiSelectVehiclesController));
            intent.PutExtra(ActivityMultiSelectVehiclesController.ExtraIsToSelectVehicles, false);
            StartActivityForResult(intent, SelectMultipleUsersRequestCode);
        }

        private async void MainView_OnEndDateClickAsync()
        {
            var date = await new DialogHelper(this).PickDate();
            if (date != null)
                AllYouCanGet.ReportProcess.EndDateTime = date;
            else
                AllYouCanGet.ReportProcess.EndDateTime = DateTime.MaxValue;

            MainView.SetEndDateText(DateTimeToString(AllYouCanGet.ReportProcess.EndDateTime));
        }

        private async void MainView_OnStartDateClickAsync()
        {
            var date = await new DialogHelper(this).PickDate();
            if (date != null)
                AllYouCanGet.ReportProcess.StartDateTime = date;
            else
                AllYouCanGet.ReportProcess.StartDateTime = DateTime.MinValue;

            MainView.SetStartDateText(DateTimeToString(AllYouCanGet.ReportProcess.StartDateTime));
        }

        private async void MainView_OnUserClickAsync()
        {
            if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.GenerateUserReport))
            {
                var user = await new DialogHelper(this).Pick(_allUsers);
                if (user != null)
                {
                    //AllYouCanGet.ReportProcess.SelectedUser = user;
                    //MainView.SetUserText(AllYouCanGet.ReportProcess.SelectedUser.ToString());
                }
            }
            else
            {
                //AllYouCanGet.ReportProcess.SelectedUser = AllYouCanGet.CurrentUser;
                //MainView.SetUserText(AllYouCanGet.ReportProcess.SelectedUser.ToString());
            }
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == SelectMultipleVehiclesRequestCode)
            {
                if (resultCode == Result.Ok)
                {
                    LoadDataAsync(false);
                }
            }
            else if (requestCode == GenerateReportsRequestCode)
            {
                if (resultCode == Result.Ok)
                {
                    SetResult(Result.Ok);
                    Finish();
                }
            }
            else if (requestCode == SelectMultipleUsersRequestCode)
            {
                if (resultCode == Result.Ok)
                {
                    LoadDataAsync(false);
                }
            }
        }

        private async void MainView_OnContinueClick()
        {
            var valid = await IsReportProcessValid();

            if (valid)
            {
                SetLoadingView(true);

                var question = GetConfirmationQuestionText();
                var response = await new DialogHelper(this, false).Question(question);

                if(response == DialogHelper.DialogResponse.Yes)
                {
                    var intent = new Intent(this, typeof(ActivityReportsController));
                    StartActivityForResult(intent, GenerateReportsRequestCode);
                }

                SetLoadingView(false);
            }

            return;
        }

        private async Task<bool> IsReportProcessValid()
        {
            if (AllYouCanGet.ReportProcess.StartDateTime >= AllYouCanGet.ReportProcess.EndDateTime)
            {
                await new DialogHelper(this).Message($"A data de início não pode ser maior nem iqual à data de fim.");
                return false;
            }

            return true;
        }

        private string GetConfirmationQuestionText()
        {
            var question = $"Têm a certeza que pretende gerar relatórios da actividade de {DateTimeToString(AllYouCanGet.ReportProcess.StartDateTime)} até {DateTimeToString(AllYouCanGet.ReportProcess.EndDateTime)} para os utilizadores:\n";

            foreach (var user in AllYouCanGet.ReportProcess.SelectedUsers)
                question += $"\n   - {user.ToString()};";

            question += $"\n\nE para os veículos:\n";

            foreach (var vehicle in AllYouCanGet.ReportProcess.SelectedVehicles)
                question += $"\n   - {vehicle.IdToString()};";

            return question;
        }
    }
}