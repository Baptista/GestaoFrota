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
    public delegate void OnModelUpdateClickEvent(Model model);

    public delegate void OnModelStateChangedClickEvent(Model model);

    public class FragmentModels : Android.Support.V4.App.Fragment
    {
        public event OnModelUpdateClickEvent OnModelUpdateClick;

        public event OnModelStateChangedClickEvent OnModelStateChangedClick;
        
        private List<Model> _models;
        private List<Fuel> _fuels;
        private List<Brand> _brands;

        ListView lvModels;

        TextView Txterrorpermissionmodel;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_models, container, false);

            lvModels = view.FindViewById<ListView>(Resource.Id.lvModels);
            Txterrorpermissionmodel = view.FindViewById<TextView>(Resource.Id.txterrorpermissionmodel);

            if (!AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ViewModels))
            {
                lvModels.Visibility = ViewStates.Gone;
                Txterrorpermissionmodel.Visibility = ViewStates.Visible;
            }

            return view;
        }

        public void UpdateModels(List<Model> models, List<Brand> brands, List<Fuel> fuels)
        {
            _models = models;
            _brands = brands;
            _fuels = fuels;

            var adapter = new FragmentModelsAdapter(Context, models);

            adapter.OnUpdateModel -= Adapter_OnUpdateModel;
            adapter.OnUpdateModel += Adapter_OnUpdateModel;

            adapter.OnUpdateModelState -= Adapter_OnUpdateModelState;
            adapter.OnUpdateModelState += Adapter_OnUpdateModelState;

            lvModels.Adapter = adapter;
        }

        private void Adapter_OnUpdateModelState(Model model)
        {
            //var modelStateChangeResult = await _businessVehicles.ChangeModelState(model);
            //if (modelStateChangeResult == true)
            //{
            //    var dialogResult = await new DialogHelper(Context).Message($"Modelo Atualizado com sucesso.");
            //}
            //else
            //{
            //    var dialogResult = await new DialogHelper(Context).Message($"Não foi possível Atualizar este Modelo, tente mais tarde.");
            //}

            OnModelStateChangedClick?.Invoke(model);
        }

        private void Adapter_OnUpdateModel(Model model)
        {
            //var updateModelResult = await _businessVehicles.UpdateModel(model);
            //if (updateModelResult == true)
            //{
            //    var dialogResult = await new DialogHelper(Context).Message($"Modelo Atualizado com sucesso.");
            //}
            //else
            //{
            //    var dialogResult = await new DialogHelper(Context).Message($"Não foi possível Atualizar este Modelo, tente mais tarde.");
            //}

            OnModelUpdateClick?.Invoke(model);
        }
    }
}