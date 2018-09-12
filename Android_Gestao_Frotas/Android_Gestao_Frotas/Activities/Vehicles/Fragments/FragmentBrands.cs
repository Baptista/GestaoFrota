using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.Adapters;
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Dashboard;
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;

namespace Android_Gestao_Frotas.Activities.Vehicles.Fragments
{
    public delegate void OnUpdateBrandsRequestEvent();

    public class FragmentBrands : Android.Support.V4.App.Fragment
    {
        public event OnUpdateBrandsRequestEvent OnUpdateBrandsRequest;

        private IBusinessVeiculos _businessVehicles;
        private List<Brand> _brands;

        ListView lvBrands;
        TextView Txterrorpermissionbrand;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_brands, container, false);

            lvBrands = view.FindViewById<ListView>(Resource.Id.lvBrands);
            Txterrorpermissionbrand = view.FindViewById<TextView>(Resource.Id.txterrorpermissionbrand);

            _businessVehicles = new BusinessVeiculos();
            
            if (!AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ViewBrands))
            {
                lvBrands.Visibility = ViewStates.Gone;
                Txterrorpermissionbrand.Visibility = ViewStates.Visible;
            }

            return view;
        }

        //public async void LoadDataAsync()
        //{
        //    _businessVehicles = new BusinessVeiculos();

        //    OnLoadStart?.Invoke();
        //    _brands = (await _businessVehicles.GetMarcas()).ToList();
        //    UpdateMarcas(_brands);
        //}

        public void UpdateBrands(List<Brand> brands)
        {
            _brands = brands;
            var adapter = new FragmentBrandsAdapter(Context, brands);
                
            adapter.OnUpdateBrand -= Adapter_OnUpdateBrand;
            adapter.OnUpdateBrand += Adapter_OnUpdateBrand;

            adapter.OnUpdateBrandState -= Adapter_OnUpdateBrandState;
            adapter.OnUpdateBrandState += Adapter_OnUpdateBrandState;

            lvBrands.Adapter = adapter;
        }

        private async void Adapter_OnUpdateBrandState(Brand brand)
        {
            (Activity as ActivityBaseController).SetLoadingView(true);

            var brandStateResult = await _businessVehicles.ChangeMarcaState(brand);
            var modelsUpdateResult = await _businessVehicles.UpdateAllModel(brand);

            if (brandStateResult == true && modelsUpdateResult == true)
            {
                var dialogResult = await new DialogHelper(Context).Message($"Marca Atualizada com sucesso.");

                OnUpdateBrandsRequest?.Invoke();
            }
            else
            {
                var dialogResult = await new DialogHelper(Context).Message($"Não foi possível Atualizar esta Marca, tente mais tarde.");
                (Activity as ActivityBaseController).SetLoadingView(false);
            }
        }

        private async void Adapter_OnUpdateBrand(Brand brand)
        {
            (Activity as ActivityBaseController).SetLoadingView(true);

            var brandUpdateResult = await _businessVehicles.UpdateMarca(brand);

            if (brandUpdateResult == true)
            {
                var dialogResult = await new DialogHelper(Context).Message($"Marca Atualizada com sucesso.");

                OnUpdateBrandsRequest?.Invoke();
            }
            else
            {
                var dialogResult = await new DialogHelper(Context).Message($"Não foi possível Atualizar esta Marca, tente mais tarde.");
                (Activity as ActivityBaseController).SetLoadingView(false);
            }
        }
    }
}