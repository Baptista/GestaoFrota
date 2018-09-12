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
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.ModelInfo;
using Core_Gestao_Frotas.Business.Models;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Android_Gestao_Frotas.Activities.ModelInfo
{
    [Activity(Label = "Informação do Modelo", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivityModelInfoController : ActivityBaseController
    {
        public const string ModelIdExtra = "MODEL_ID_EXTRA";

        ActivityModelInfoView MainView;
        V7Toolbar Toolbar;

        private IBusinessModelInfo _businessModelInfo;

        private Model _model;

        private bool _isNewModel = false;
        private bool _toChangeState = false;

        private List<Brand> _brands;
        private List<Fuel> _fuels;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _businessModelInfo = new BusinessModelInfo();

            LoadView();
            LoadDataAsync();
        }

        private void LoadView()
        {
            MainView = new ActivityModelInfoView(this);
            SetContentView(MainView);

            Toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(Toolbar);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar?.SetHomeButtonEnabled(true);
            Toolbar.NavigationClick += (o, a) => { OnBackPressed(); };

            MainView.OnNameChanged -= MainView_OnNameChanged;
            MainView.OnNameChanged += MainView_OnNameChanged;

            MainView.OnStateChanged -= MainView_OnStateChanged;
            MainView.OnStateChanged += MainView_OnStateChanged;

            MainView.OnBrandClick -= MainView_OnBrandClick;
            MainView.OnBrandClick += MainView_OnBrandClick;

            MainView.OnFuelClick -= MainView_OnFuelClick;
            MainView.OnFuelClick += MainView_OnFuelClick;

            MainView.OnFinishClick -= MainView_OnFinishClick;
            MainView.OnFinishClick += MainView_OnFinishClick;
        }

        private async void LoadDataAsync()
        {
            SetLoadingView(true);

            _model = new Model() {
                Id = Intent.GetIntExtra(ModelIdExtra, BaseModel.Null),
                IsIncomplete = true
            };

            if (_model.Id == BaseModel.Null)
            {
                _isNewModel = true;
                MainView.SetStateEnabled(false);
            }
            else
            {
                _model = await _businessModelInfo.GetModelAsync(_model.Id);
                MainView.SetModelInfo(_model);
                MainView.SetStateEnabled(true);
            }

            _brands = await _businessModelInfo.GetAllActiveBrandsAsync();
            _fuels = await _businessModelInfo.GetAllActiveFuelsAsync();

            SetLoadingView(false);
        }

        public override void OnBackPressed()
        {
            SetResult(Result.Canceled);

            base.OnBackPressed();
        }

        private async void MainView_OnFinishClick()
        {
            SetLoadingView(true);

            if (_isNewModel)
            {
                var isModelValid = ValidateModelInfo();
                if (isModelValid)
                {
                    var success = await _businessModelInfo.NewModelAsync(_model);
                    if (success)
                    {
                        await new DialogHelper(this).Message($"Novo modelo criado com successo.");
                        SetResult(Result.Ok);
                        Finish();
                    }
                    else
                    {
                        await new DialogHelper(this).Message($"Não foi possível criar um novo modelo, tente mais tarde.");

                    }
                }
                else
                {
                    await new DialogHelper(this).Message($"Não foi possível criar um novo modelo, a informação fornecida no formulário está inválida.");
                }
            }
            else
            {
                var isModelValid = ValidateModelInfo();
                if (isModelValid)
                {
                    var success = await _businessModelInfo.UpdateModelAsync(_model, _toChangeState);
                    if (success)
                    {
                        await new DialogHelper(this).Message($"Modelo editado com successo.");
                        SetResult(Result.Ok);
                        Finish();
                    }
                    else
                    {
                        await new DialogHelper(this).Message($"Não foi possível editar o modelo, tente mais tarde.");
                    }
                }
                else
                {
                    await new DialogHelper(this).Message($"Não foi possível editar o modelo, a informação fornecida no formulário está inválida.");
                }
            }

            SetLoadingView(false);
        }

        private async void MainView_OnFuelClick()
        {
            var fuel = await new DialogHelper(this).Pick(_fuels);
            if (fuel != null)
            {
                _model.Fuel = fuel;
                MainView.SetFuelText(fuel.Description);
            }
        }

        private async void MainView_OnBrandClick()
        {
            var brand = await new DialogHelper(this).Pick(_brands);
            if (brand != null)
            {
                _model.Brand = brand;
                MainView.SetBrandText(brand.Description);
            }
        }

        private void MainView_OnStateChanged(bool active)
        {
            if (active != _model.Active)
                _toChangeState = true;
            else
                _toChangeState = false;
        }

        private void MainView_OnNameChanged(string name)
        {
            _model.Description = name;
        }

        private bool ValidateModelInfo()
        {
            if (!string.IsNullOrEmpty(_model.Description))
                if (_model.Brand != null && !_model.Brand.IsIncomplete)
                    if (_model.Fuel != null && !_model.Fuel.IsIncomplete)
                        return true;

            return false;
        }
    }
}