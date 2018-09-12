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
    public delegate void OnTypologyUpdateClickEvent(Typology typology);

    public delegate void OnTypologyChangeStateClickEvent(Typology typology);

    public class FragmentTypologies : Android.Support.V4.App.Fragment
    {
        public event OnTypologyUpdateClickEvent OnTypologyUpdateClick;

        public event OnTypologyChangeStateClickEvent OnTypologyChangeStateClick;

        ListView lvTypologies;

        TextView Txterrorpermissiontypology;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_typologies, container, false);

            lvTypologies = view.FindViewById<ListView>(Resource.Id.lvTypology);
            Txterrorpermissiontypology = view.FindViewById<TextView>(Resource.Id.txterrorpermissiontypology);

            if (!AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ViewTypologies))
            {
                lvTypologies.Visibility = ViewStates.Gone;
                Txterrorpermissiontypology.Visibility = ViewStates.Visible;
            }

            return view;
        }

        public void UpdateTypologies(List<Typology> typologies)
        {
            var adapter = new FragmentTypologiesAdapter(Context, typologies);

            adapter.OnUpdateTypology -= Adapter_OnUpdateTypology;
            adapter.OnUpdateTypology += Adapter_OnUpdateTypology;

            adapter.OnUpdateTypologyState -= Adapter_OnUpdateTypologyState;
            adapter.OnUpdateTypologyState += Adapter_OnUpdateTypologyState;

            lvTypologies.Adapter = adapter;
        }

        private void Adapter_OnUpdateTypologyState(Typology typology)
        {
            OnTypologyChangeStateClick?.Invoke(typology);
        }

        private void Adapter_OnUpdateTypology(Typology typology)
        {
            OnTypologyUpdateClick?.Invoke(typology);
        }
    }
}