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
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Business.Reports;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Android_Gestao_Frotas.Activities.MultiSelectVehicles
{
    [Activity(Label = "Veículos", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivityMultiSelectVehiclesController : ActivityBaseController
    {
        public const string ExtraIsToSelectVehicles = "EXTRA_IS_TO_SELECT_VEHICLE";
        public const bool ToSelectVehicle = true;

        ActivityMultiSelectVehiclesView MainView;
        V7Toolbar Toolbar;

        private IBusinessReports _businessReports;

        private List<Vehicle> _vehicles;
        private List<User> _users;

        private bool _isToSelectVehicle;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _businessReports = new BusinessReports();

            LoadView();
            LoadData();
        }

        private void LoadView()
        {
            MainView = new ActivityMultiSelectVehiclesView(this);
            SetContentView(MainView);

            Toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(Toolbar);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar?.SetHomeButtonEnabled(true);
            Toolbar.NavigationClick += (o, a) => { OnBackPressed(); };
        }

        private async void LoadData()
        {
            _isToSelectVehicle = Intent.GetBooleanExtra(ExtraIsToSelectVehicles, ToSelectVehicle);

            if (_isToSelectVehicle)
            {
                SetLoadingView(true, false, $"A carregar veículos...");
            }
            else
            {
                SetLoadingView(true, false, $"A carregar utilizadores...");
            }

            if (_isToSelectVehicle)
            {
                _vehicles = await _businessReports.GetAllActiveVehicles();// (AllYouCanGet.ReportProcess.SelectedUser.Id, false);
                MainView.SetVehicles(_vehicles, GetSelectedVehicleIds());
                this.Title = "Veículos";
            }
            else
            {
                _users = await _businessReports.GetSelectableUsers();
                MainView.SetUsers(_users, GetSelectedUserIds());
                this.Title = "Utilizadores";
            }

            SetLoadingView(false);
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
                    SaveSelectedItems();
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }

        private async void SaveSelectedItems()
        {
            await MakeAsync();

            SetLoadingView(true, false, $"A carregar veículos seleccionados...");

            if (_isToSelectVehicle)
            {
                var selectedVehicleIds = MainView.GetSelectedVehiclesFromListAdapter();
                var selectedVehicles = GetSelectedVehicles(selectedVehicleIds);
                AllYouCanGet.ReportProcess.SelectedVehicles = new List<Vehicle>(selectedVehicles);
            }
            else
            {
                var selectedUserIds = MainView.GetSelectedUsersFromListAdapter();
                var selectedUsers = GetSelectedUsers(selectedUserIds);
                AllYouCanGet.ReportProcess.SelectedUsers = new List<User>(selectedUsers);
            }

            
            SetResult(Result.Ok);

            Finish();
        }

        private List<Vehicle> GetSelectedVehicles(List<int> selectedIds)
        {
            if (selectedIds.Any())
            {
                var selectedVehicles = new List<Vehicle>();
                foreach (var vehicleId in selectedIds)
                {
                    var vehicle = _vehicles.FirstOrDefault(v => v.Id == vehicleId);
                    if (vehicle != null)
                        selectedVehicles.Add(vehicle);
                }

                return selectedVehicles;
            }
            else
            {
                return new List<Vehicle>();
            }
        }

        private List<User> GetSelectedUsers(List<int> selectedIds)
        {
            if (selectedIds.Any())
            {
                var selectedUsers = new List<User>();
                foreach (var userId in selectedIds)
                {
                    var user = _users.FirstOrDefault(v => v.Id == userId);
                    if (user != null)
                        selectedUsers.Add(user);
                }

                return selectedUsers;
            }
            else
            {
                return new List<User>();
            }
        }

        private List<int> GetSelectedVehicleIds()
        {
            var selectedVehicles = AllYouCanGet.ReportProcess.SelectedVehicles;
            var selectedIds = new List<int>();
            if (selectedVehicles != null)
            {
                foreach (var vehicle in selectedVehicles)
                    selectedIds.Add(vehicle.Id);
            }

            return selectedIds;
        }

        private List<int> GetSelectedUserIds()
        {
            var selectedUser = AllYouCanGet.ReportProcess.SelectedUsers;
            var selectedIds = new List<int>();
            if (selectedUser != null)
            {
                foreach (var vehicle in selectedUser)
                    selectedIds.Add(vehicle.Id);
            }

            return selectedIds;
        }
    }
}