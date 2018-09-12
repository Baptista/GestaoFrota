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
using Core_Gestao_Frotas.Business.Dashboard;
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Business.Users;
using Core_Gestao_Frotas.Business.VehicleInfo;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Android_Gestao_Frotas.Activities.VehicleInfo
{
    [Activity(Label = "Informação do Veículo", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivityVehicleInfoController : ActivityBaseController
    {
        public const string VehicleIdExtra = "VEHICLE_ID_EXTRA";

        ActivityVehicleInfoView MainView;
        V7Toolbar Toolbar;

        IBusinessVehicleInfo _businessVehicleInfo;

        private List<Typology> _typologies;
        private List<Model> _models;
        private List<User> _users;
        private List<Brand> _brands;
        private List<Fuel> _fuels;

        private Vehicle _vehicle;

        private bool _isNewVehicle = false;
        private bool _toChangeState = false;

        private Brand _selectedBrand;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _businessVehicleInfo = new BusinessVehicleInfo();

            LoadView();
            LoadDataAsync();
        }

        private void LoadView()
        {
            MainView = new ActivityVehicleInfoView(this);
            SetContentView(MainView);

            Toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(Toolbar);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar?.SetHomeButtonEnabled(true);
            Toolbar.NavigationClick += (o, a) => { OnBackPressed(); };

            MainView.OnBrandsClick -= MainView_OnBrandsClick;
            MainView.OnBrandsClick += MainView_OnBrandsClick;

            MainView.OnModelsClick -= MainView_OnModelsClick;
            MainView.OnModelsClick += MainView_OnModelsClick;

            MainView.OnFuelsClick -= MainView_OnFuelsClick;
            MainView.OnFuelsClick += MainView_OnFuelsClick;

            MainView.OnUsersClick -= MainView_OnUsersClick;
            MainView.OnUsersClick += MainView_OnUsersClick;

            MainView.OnTypologiesClick -= MainView_OnTypologiesClick;
            MainView.OnTypologiesClick += MainView_OnTypologiesClick;

            MainView.OnStateChanged -= MainView_OnStateChanged;
            MainView.OnStateChanged += MainView_OnStateChanged;

            MainView.OnFinishClick -= MainView_OnFinishClick;
            MainView.OnFinishClick += MainView_OnFinishClick;

            MainView.OnLicensePlateChanged -= MainView_OnLicensePlateChanged;
            MainView.OnLicensePlateChanged += MainView_OnLicensePlateChanged;

            MainView.OnKmsChanged -= MainView_OnKmsChanged;
            MainView.OnKmsChanged += MainView_OnKmsChanged;

            MainView.OnKmsContractChanged -= MainView_OnKmsContractChanged;
            MainView.OnKmsContractChanged += MainView_OnKmsContractChanged;
        }

        public override void OnBackPressed()
        {
            SetResult(Result.Canceled);

            base.OnBackPressed();
        }

        private async void LoadDataAsync()
        {
            SetLoadingView(true);

            _vehicle = new Vehicle() {
                Id = Intent.GetIntExtra(VehicleIdExtra, BaseModel.Null),
                IsIncomplete = true };

            if (_vehicle.Id == BaseModel.Null)
            {
                _isNewVehicle = true;
                MainView.SetStateEnabled(false);
            }
            else
            {
                _vehicle = await _businessVehicleInfo.GetVehicle(_vehicle.Id);
                MainView.SetVehicleInfo(_vehicle);
                MainView.SetStateEnabled(true);
                MainView.SetModelEnabled(true);
                MainView.SetFuelEnabled(true);
            }

            _brands = (await _businessVehicleInfo.GetBrands()).ToList();
            _models = (await _businessVehicleInfo.GetModels()).ToList();
            _fuels = (await _businessVehicleInfo.GetFuels()).ToList();
            _typologies = (await _businessVehicleInfo.GetTypologies()).ToList();
            _users = (await _businessVehicleInfo.GetUsers()).ToList();

            SetLoadingView(false);
        }

        private async void MainView_OnTypologiesClick()
        {
            var typology = await new DialogHelper(this).Pick(_typologies);
            if (typology != null)
            {
                _vehicle.Typology = typology;
                MainView.SetTypologyText(typology.Description);
            }
        }

        private async void MainView_OnUsersClick()
        {
            var user = await new DialogHelper(this).Pick(_users);
            if (user != null)
            {
                _vehicle.User = user;
                MainView.SetUserText($"{user.Name} ({user.Username})");
            }
        }

        private async void MainView_OnFuelsClick()
        {
            var fuels = _fuels.Where(f => { return f.Id == _vehicle.Model.Fuel.Id; }).ToList();
            var fuel = await new DialogHelper(this, true).Pick(fuels);
            if (fuel != null)
            {
                _vehicle.Model.Fuel = fuel;
                MainView.SetFuelText(fuel.Description);
            }
        }

        private async void MainView_OnModelsClick()
        {
            var models = _models.Where(m => { return m.Brand.Id == _selectedBrand.Id; }).ToList();
            var model = await new DialogHelper(this, true).Pick(models);
            if (model != null)
            {
                _vehicle.Model = model;
                _vehicle.Model.Brand = _selectedBrand;
                MainView.SetModelText(model.Description);
                MainView.SetModelPicked();
            }
        }

        private async void MainView_OnBrandsClick()
        {
            var brand = await new DialogHelper(this, true).Pick(_brands);
            if (brand != null)
            {
                _selectedBrand = brand;
                MainView.SetBrandText(brand.Description);
                MainView.SetBrandPicked();
            }
        }

        private async void MainView_OnFinishClick()
        {
            SetLoadingView(true);

            if (_isNewVehicle)
            {
                var isVehicleValid = ValidateVehicleInfo();
                if (isVehicleValid)
                {
                    var success = await _businessVehicleInfo.NewVehicle(_vehicle);
                    if (success)
                    {
                        await new DialogHelper(this).Message($"Novo veículo criado com successo.");
                        SetResult(Result.Ok);
                        Finish();
                    }
                    else
                    {
                        await new DialogHelper(this).Message($"Não foi possível criar um novo veículo, tente mais tarde.");
                    }
                }
                else
                {
                    await new DialogHelper(this).Message($"Não foi possível criar um novo veículo, a informação fornecida no formulário está inválida.");
                }
            }
            else
            {
                var isVehicleValid = ValidateVehicleInfo();
                if (isVehicleValid)
                {
                    var success = await _businessVehicleInfo.UpdateVehicle(_vehicle);
                    if (success)
                    {
                        await new DialogHelper(this).Message($"Veículo editado com successo.");
                        SetResult(Result.Ok);
                        Finish();
                    }
                    else
                    {
                        await new DialogHelper(this).Message($"Não foi possível editar o veículo, tente mais tarde.");
                    }
                }
                else
                {
                    await new DialogHelper(this).Message($"Não foi possível editar o veículo, a informação fornecida no formulário está inválida.");
                }

                if (_toChangeState)
                {
                    await _businessVehicleInfo.ChangeVehicleState(_vehicle);
                }
            }

            SetLoadingView(false);
        }

        private void MainView_OnStateChanged(bool active)
        {
            if (active != _vehicle.Active)
                _toChangeState = true;
            else
                _toChangeState = false;
        }

        private void MainView_OnKmsContractChanged(string kmsContract)
        {
            var value = (float) 0;
            var success = float.TryParse(kmsContract, out value);
            if (success)
            {
                _vehicle.ContractKms = value;
            }
            else
            {
                _vehicle.ContractKms = -1;
            }
        }

        private void MainView_OnKmsChanged(string kms)
        {
            var value = (float) 0;
            var success = float.TryParse(kms, out value);
            if (success)
            {
                _vehicle.StartKms = value;
            }
            else
            {
                _vehicle.StartKms = -1;
            }
        }
        
        private void MainView_OnLicensePlateChanged(string licensePlate)
        {
            if (licensePlate.Length == 2 || licensePlate.Length == 5)
            {
                licensePlate += "-";
                _vehicle.LicensePlate = licensePlate;
                MainView.SetLicensePlate(licensePlate);
            }
            else
            {
                _vehicle.LicensePlate = licensePlate;
            }
        }

        private bool ValidateVehicleInfo()
        {
            if (_vehicle.LicensePlate.Length == 8)
                if (_vehicle.Model != null && !_vehicle.Model.IsIncomplete)
                    if (_vehicle.Model.Brand != null && !_vehicle.Model.Brand.IsIncomplete)
                        if (_vehicle.Model.Fuel != null && !_vehicle.Model.Fuel.IsIncomplete)
                            if (_vehicle.User != null && !_vehicle.User.IsIncomplete)
                                if (_vehicle.Typology != null && !_vehicle.Typology.IsIncomplete)
                                    if (_vehicle.StartKms != -1 && _vehicle.ContractKms != -1)
                                        return true;

            return false;
        }
    }
}