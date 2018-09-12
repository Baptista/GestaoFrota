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
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using V4Fragment = Android.Support.V4.App.Fragment;
using V4FragmentManager = Android.Support.V4.App.FragmentManager;
using Android_Gestao_Frotas.Activities.Vehicles.Fragments;
using Android.Animation;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Dashboard;
using Android_Gestao_Frotas.Adapters;
using Core_Gestao_Frotas.Business.Users;
using System.Threading.Tasks;
using Android_Gestao_Frotas.Activities.VehicleInfo;
using Android_Gestao_Frotas.Helpers;
using Android_Gestao_Frotas.Activities.ModelInfo;
using Core_Gestao_Frotas;

namespace Android_Gestao_Frotas.Activities.Vehicles
{
    [Activity(Label = "Gestão de Veículos", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivityVehiclesController : ActivityBaseController
    {
        ActivityVehiclesView MainView;
        V7Toolbar Toolbar;

        private IBusinessVeiculos _businessVehicles;

        private List<Brand> _brands;
        private List<Fuel> _fuels;

        FragmentVehicles _fragmentVehicles;
        FragmentBrands _fragmentBrands;
        FragmentModels _fragmentModels;
        FragmentTypologies _fragmentTypologies;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _businessVehicles = new BusinessVeiculos();

            LoadView();
            LoadDataAsync();
        }

        private void LoadView()
        {
            MainView = new ActivityVehiclesView(this);
            SetContentView(MainView);

            Toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(Toolbar);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar?.SetHomeButtonEnabled(true);
            Toolbar.NavigationClick += (o, a) => { OnBackPressed(); };

            MainView.OnNewModelClick -= MainView_OnNewModelClick;
            MainView.OnNewModelClick += MainView_OnNewModelClick;

            MainView.OnNewTypologyClick -= MainView_OnNewTypologyClick;
            MainView.OnNewTypologyClick += MainView_OnNewTypologyClick;

            MainView.OnNewBrandClick -= MainView_OnNewBrandClick;
            MainView.OnNewBrandClick += MainView_OnNewBrandClick;

            MainView.OnNewVehicleClick -= MainView_OnNewVehicleClick;
            MainView.OnNewVehicleClick += MainView_OnNewVehicleClick;

            _fragmentVehicles = new FragmentVehicles();
            _fragmentModels = new FragmentModels();
            _fragmentBrands = new FragmentBrands();
            _fragmentTypologies = new FragmentTypologies();

            _fragmentVehicles.OnEditVehicleClick -= FragmentVehicles_OnEditVehicleClick;
            _fragmentVehicles.OnEditVehicleClick += FragmentVehicles_OnEditVehicleClick;

            _fragmentBrands.OnUpdateBrandsRequest -= FragmentBrands_OnUpdateBrandsRequestAsync;
            _fragmentBrands.OnUpdateBrandsRequest += FragmentBrands_OnUpdateBrandsRequestAsync;

            _fragmentModels.OnModelStateChangedClick -= FragmentModels_OnModelStateChangedClickAsync;
            _fragmentModels.OnModelStateChangedClick += FragmentModels_OnModelStateChangedClickAsync;

            _fragmentModels.OnModelUpdateClick -= FragmentModels_OnModelUpdateClick;
            _fragmentModels.OnModelUpdateClick += FragmentModels_OnModelUpdateClick;

            _fragmentTypologies.OnTypologyUpdateClick -= FragmentTypologies_OnTypologyUpdateClick;
            _fragmentTypologies.OnTypologyUpdateClick += FragmentTypologies_OnTypologyUpdateClick;

            _fragmentTypologies.OnTypologyChangeStateClick -= FragmentTypologies_OnTypologyChangeStateClick;
            _fragmentTypologies.OnTypologyChangeStateClick += FragmentTypologies_OnTypologyChangeStateClick;

            var adapter = new VehiclesFragmentsAdapter(SupportFragmentManager);
            adapter.AddFragment(_fragmentVehicles, "Veículos");
            adapter.AddFragment(_fragmentBrands, "Marcas");
            adapter.AddFragment(_fragmentModels, "Modelos");
            adapter.AddFragment(_fragmentTypologies, "Tipologias");

            MainView.SetupViewPager(adapter);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_refresh:
                    LoadDataAsync();
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.dashboard_options_menu, menu);
            return true;
        }

        private async void LoadDataAsync(bool usePersistence = false)
        {
            SetLoadingView(true);

            var fuels = await _businessVehicles.GetFuels(usePersistence);
            var brands = await _businessVehicles.GetBrands(usePersistence);
            var models = await _businessVehicles.GetModels(usePersistence);
            var typologies = await _businessVehicles.GetTypologies(usePersistence);
            var vehicles = await _businessVehicles.GetVehicles(usePersistence);
            
            _fragmentVehicles.UpdateVehicles(vehicles.ToList());
            _fragmentBrands.UpdateBrands(brands.ToList());
            _fragmentModels.UpdateModels(models.ToList(), brands.ToList(), fuels.ToList());
            _fragmentTypologies.UpdateTypologies(typologies.ToList());

            SetLoadingView(false);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            switch (requestCode)
            {
                case EditVehicleRequestCode:
                    if (resultCode == Result.Ok)
                    {
                        LoadDataAsync(true);
                    }
                    else
                    {
                        //does nothing, operation was canceled
                    }
                    break;
                case NewVehicleRequestCode:
                    if (resultCode == Result.Ok)
                    {
                        LoadDataAsync(true);
                    }
                    else
                    {
                        //does nothing, operation was canceled
                    }
                    break;
                case EditModelRequestCode:
                    if (resultCode == Result.Ok)
                    {
                        LoadDataAsync(true);
                    }
                    else
                    {
                        //does nothing, operation was canceled
                    }
                    break;
                case NewModelRequestCode:
                    if (resultCode == Result.Ok)
                    {
                        LoadDataAsync(true);
                    }
                    else
                    {
                        //does nothing, operation was canceled
                    }
                    break;
            }
        }

        private async void FragmentTypologies_OnTypologyChangeStateClick(Typology typology)
        {
            var response = await new DialogHelper(this).Question($"Tem a certeza que pretende alterar o estado da tipologia {typology.Description}?");
            if (response == DialogHelper.DialogResponse.Yes)
            {
                SetLoadingView(true);

                var success = await _businessVehicles.ChangeTypologyState(typology);
                if (success)
                {
                    await new DialogHelper(this).Message($"Estadp alterado com sucesso.");
                    UpdateTypologies();
                }
                else
                {
                    await new DialogHelper(this).Message($"Não foi possivel alterar o estado desta tipologia, tente mais tarde.");
                    SetLoadingView(false);
                }
            }
        }

        private async void FragmentTypologies_OnTypologyUpdateClick(Typology typology)
        {
            var typologyName = await new DialogHelper(this).UserInput($"", $"{typology.Description}", $"Tipologia");

            if (!string.IsNullOrEmpty(typologyName))
            {
                SetLoadingView(true);

                typology.Description = typologyName;
                var success = await _businessVehicles.UpdateTypology(typology);
                if (success)
                {
                    var dialogResult = await new DialogHelper(this).Message($"Tipologia alterada com sucesso.");
                    UpdateTypologies();
                }
                else
                {
                    var dialogResult = await new DialogHelper(this).Message($"Não foi possível alterar esta tipologia, tente mais tarde.");
                    SetLoadingView(false);
                }
            }
            else if (typologyName != null && typologyName.Equals(string.Empty))
            {
                var dialogResult = await new DialogHelper(this).Message($"Nome de tipologia inválido.");
            }
        }

        private void FragmentVehicles_OnEditVehicleClick(Vehicle vehicle)
        {
            var intent = new Intent(this, typeof(ActivityVehicleInfoController));
            intent.PutExtra(ActivityVehicleInfoController.VehicleIdExtra, vehicle.Id);
            StartActivityForResult(intent, EditVehicleRequestCode);
        }

        private async void FragmentBrands_OnUpdateBrandsRequestAsync()
        {
            SetLoadingView(true);

            var brands = await _businessVehicles.GetBrands(true);
            _fragmentBrands.UpdateBrands(brands.ToList());

            SetLoadingView(false);
        }

        private void FragmentModels_OnModelUpdateClick(Model model)
        {
            var intent = new Intent(this, typeof(ActivityModelInfoController));
            intent.PutExtra(ActivityModelInfoController.ModelIdExtra, model.Id);
            StartActivityForResult(intent, EditModelRequestCode);
        }

        private async void FragmentModels_OnModelStateChangedClickAsync(Model model)
        {
            var response = await new DialogHelper(this).Question($"Tem a certeza que pretende alterar o estado do modelo {model.Brand.Description} - {model.Description} para {(model.Active ? "Inactivo" : "Activo")}?");
            if (response == DialogHelper.DialogResponse.Yes)
            {
                SetLoadingView(true);

                var success = await _businessVehicles.ChangeModelState(model);
                if (success)
                {
                    await new DialogHelper(this).Message($"Estado do modelo {model.Brand.Description} - {model.Description} alterado com sucesso.");
                    LoadDataAsync(true);
                }
                else
                {
                    await new DialogHelper(this).Message($"Não foi possível alterar o estado do modelo {model.Brand.Description} - {model.Description}, tente mais tarde.");
                    SetLoadingView(false);
                }
            }
        }

        private async void MainView_OnNewVehicleClick()
        {
            if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ManageVehicles))
            {
                var intent = new Intent(this, typeof(ActivityVehicleInfoController));
                intent.PutExtra(ActivityVehicleInfoController.VehicleIdExtra, BaseModel.Null);
                StartActivityForResult(intent, NewVehicleRequestCode);
            }
            else
            {
                var dialogResult = await new DialogHelper(this).Message("Não tem permissões para efetuar esta tarefa!");
            }
        }

        private async void MainView_OnNewModelClick()
        {
            if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ManageModels))
            {
                var intent = new Intent(this, typeof(ActivityModelInfoController));
                intent.PutExtra(ActivityModelInfoController.ModelIdExtra, BaseModel.Null);
                StartActivityForResult(intent, NewModelRequestCode);
            }
            else
            {
                var dialogResult = await new DialogHelper(this).Message("Não tem permissões para efetuar esta tarefa!");
            }
        }
        
        private async void MainView_OnNewBrandClick()
        {
            if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ManageBrands))
            {
                var brandName = await new DialogHelper(this).UserInput($"", $"", $"Marca");

                if (!string.IsNullOrEmpty(brandName))
                {
                    SetLoadingView(true);

                    var brand = new Brand() { Description = brandName, Active = true };
                    var success = await _businessVehicles.InsertMarca(brand);
                    if (success)
                    {
                        var dialogResult = await new DialogHelper(this).Message($"Marca criada com sucesso.");
                        FragmentBrands_OnUpdateBrandsRequestAsync();
                    }
                    else
                    {
                        var dialogResult = await new DialogHelper(this).Message($"Não foi possível criar esta marca, tente mais tarde.");
                        SetLoadingView(false);
                    }
                }
                else if (brandName != null && brandName.Equals(string.Empty))
                {
                    var dialogResult = await new DialogHelper(this).Message($"Nome de marca inválido.");
                }
            }
            else
            {
                var dialogResult = await new DialogHelper(this).Message("Não tem permissões para efetuar esta tarefa!");
            }
        }

        private async void MainView_OnNewTypologyClick()
        {
            if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ManageTypologies))
            {
                var typologyName = await new DialogHelper(this).UserInput($"", $"", $"Tipologia");

                if (!string.IsNullOrEmpty(typologyName))
                {
                    SetLoadingView(true);

                    var typology = new Typology() { Description = typologyName, Active = true };
                    var success = await _businessVehicles.InsertTypology(typology);
                    if (success)
                    {
                        var dialogResult = await new DialogHelper(this).Message($"Tipologia criada com sucesso.");
                        UpdateTypologies();
                    }
                    else
                    {
                        var dialogResult = await new DialogHelper(this).Message($"Não foi possível criar esta tipologia, tente mais tarde.");
                        SetLoadingView(false);
                    }
                }
                else if (typologyName != null && typologyName.Equals(string.Empty))
                {
                    var dialogResult = await new DialogHelper(this).Message($"Nome de tipologia inválido.");
                }
            }
            else
            {
                var dialogResult = await new DialogHelper(this).Message("Não tem permissões para efetuar esta tarefa!");
            }
        }

        private async void UpdateTypologies()
        {
            SetLoadingView(true);

            var typologies = await _businessVehicles.GetTypologies(true);
            _fragmentTypologies.UpdateTypologies(typologies.ToList());

            SetLoadingView(false);
        }
    }
}