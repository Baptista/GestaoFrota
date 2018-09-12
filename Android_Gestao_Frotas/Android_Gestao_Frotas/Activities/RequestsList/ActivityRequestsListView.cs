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
using Android_Gestao_Frotas.Adapters;
using Core_Gestao_Frotas.Business.Models;

namespace Android_Gestao_Frotas.Activities.RequestsList
{

    public delegate void OnUserTextViewClick();
    public delegate void OnVehicleTextViewClick();

    public delegate void OnFiltroClick();
    public delegate void OnChangeDateStartClick();
    public delegate void OnChangeDateFinishClick();
    public delegate void OnChangeStateClick();
    public delegate void OnCleanClick();
    public delegate void OnApplyClick();

    public delegate void RequestAvailableVehicleController(RequestHistory request);
    public delegate void AcceptRequestController(RequestHistory request);
    public delegate void CancelRequestController(RequestHistory request, string justification);

    [Activity(Label = "ActivityRequestsListView")]
    public class ActivityRequestsListView : ActivityBaseView
    {

        public event OnUserTextViewClick OnUserTextViewClick;
        public event OnVehicleTextViewClick OnVehicleTextViewClick;

        public event RequestAvailableVehicleController RequestAvailableVehicleController;
        public event AcceptRequestController AcceptRequestController;
        public event CancelRequestController CancelRequestController;

        public event OnFiltroClick OnFiltroClick;
        public event OnChangeDateStartClick OnChangeDateStartClick;
        public event OnChangeDateFinishClick OnChangeDateFinishClick;
        public event OnChangeStateClick OnChangeStateClick;
        public event OnCleanClick OnCleanClick;
        public event OnApplyClick OnApplyClick;

        ListView lvRequests;

        LinearLayout FiltroClick;
        LinearLayout llOptions;

        TextView changeuser;
        TextView changevehicle;

        TextView tvDateStartOption;
        TextView tvDateFinishOption;
        TextView tvStateOption;
        TextView tvCleanOption;
        TextView TvApplyOption;

        public ActivityRequestsListView(Context context) : base(context)
        {
            LoadView();
        }

        public void LockUser()
        {
            changeuser.Enabled = false;
        }

        public void ChangeStateAtStart(int type)
        {
            if (type == 1)
            {
                tvStateOption.Text = "Aprovado";
            }
            else if (type == 2)
            {
                tvStateOption.Text = "Pendente";
            }else if (type == 5)
            {
                tvStateOption.Text = "Aprovado(Para Disponibilizar)";
            }

        }

        private void LoadView()
        {
            var view = Inflate(Context, Resource.Layout.activity_requestslist, this);
            lvRequests = view.FindViewById<ListView>(Resource.Id.lvRequests);

            llOptions = view.FindViewById<LinearLayout>(Resource.Id.llDetailsOption);
            FiltroClick = view.FindViewById<LinearLayout>(Resource.Id.FiltroClick);

            changeuser = view.FindViewById<TextView>(Resource.Id.tvUtilizadorOption);
            changevehicle = view.FindViewById<TextView>(Resource.Id.tvVeiculoOption);

            tvDateStartOption = view.FindViewById<TextView>(Resource.Id.tvDateStartOption);
            tvDateFinishOption = view.FindViewById<TextView>(Resource.Id.tvDateFinishOption);
            tvStateOption = view.FindViewById<TextView>(Resource.Id.tvStateOption);

            tvCleanOption = view.FindViewById<TextView>(Resource.Id.tvCleanOption);
            TvApplyOption = view.FindViewById<TextView>(Resource.Id.TvApplyOption);

            changevehicle.Click -= Changevehicle_Click;
            changevehicle.Click += Changevehicle_Click;
            changeuser.Click -= Changeuser_Click;
            changeuser.Click += Changeuser_Click;

            FiltroClick.Click -= FiltroClick_Click;
            FiltroClick.Click += FiltroClick_Click;

            tvDateStartOption.Click -= TvDateStartOption_Click;
            tvDateStartOption.Click += TvDateStartOption_Click;

            tvDateFinishOption.Click -= TvDateFinishOption_Click;
            tvDateFinishOption.Click += TvDateFinishOption_Click;

            tvStateOption.Click -= TvStateOption_Click;
            tvStateOption.Click += TvStateOption_Click;

            tvCleanOption.Click -= TvCleanOption_Click;
            tvCleanOption.Click += TvCleanOption_Click;

            TvApplyOption.Click -= TvApplyOption_Click;
            TvApplyOption.Click += TvApplyOption_Click;

        }

        public void ClearAllText(int tipo)
        {
            tvDateStartOption.Text = "De: --/--/----";
            tvDateFinishOption.Text = "Até: --/--/----";
            if (tipo == 0)
            {
                changeuser.Text = "Utilizador...";
            }
            changevehicle.Text = "Veiculo...";
            tvStateOption.Text = "Estado";
        }

        public void ChangeUserText(string text)
        {
            changeuser.Text = text;
        }

        public void ChangeVehicleText(string text)
        {
            changevehicle.Text = text;
        }

        private void TvApplyOption_Click(object sender, EventArgs e)
        {
            OnApplyClick?.Invoke();
        }

        private void TvCleanOption_Click(object sender, EventArgs e)
        {
            OnCleanClick?.Invoke();
        }

        private void TvStateOption_Click(object sender, EventArgs e)
        {
            OnChangeStateClick?.Invoke();
        }

        public void ChangeStateText(string text)
        {
            tvStateOption.Text = text;
        }

        private void TvDateFinishOption_Click(object sender, EventArgs e)
        {
            OnChangeDateFinishClick?.Invoke();
        }

        private void TvDateStartOption_Click(object sender, EventArgs e)
        {
            OnChangeDateStartClick?.Invoke();
        }

        public void ChangeDateStartText(string text)
        {
            tvDateStartOption.Text = text;
        }

        public void ChangeDateFinishText(string text)
        {
            tvDateFinishOption.Text = text;
        }

        private void FiltroClick_Click(object sender, EventArgs e)
        {
            OnFiltroClick?.Invoke();
        }

        private void Changevehicle_Click(object sender, EventArgs e)
        {
            OnVehicleTextViewClick?.Invoke();
        }

        private void Changeuser_Click(object sender, EventArgs e)
        {
            OnUserTextViewClick?.Invoke();
        }

        public void changeopenmenu(int state)
        {
            if (state == 0)
            {
                llOptions.Visibility = ViewStates.Gone;
            }else if (state == 1)
            {
                llOptions.Visibility = ViewStates.Visible;
            }
        }

        public void UpdateRequestsActive(List<RequestHistory> requestsActive)
        {
            if (requestsActive != null && requestsActive.Count > 0)
            {
                var adapter = new RequestsSearchAdapter(Context, requestsActive);
                lvRequests.Adapter = adapter;
                lvRequests.Visibility = ViewStates.Visible;
                //tvSearchResult.Visibility = ViewStates.Gone;

                adapter.AcceptRequest -= Adapter_AcceptRequest;
                adapter.AcceptRequest += Adapter_AcceptRequest;

                adapter.CancelRequest -= Adapter_CancelRequest;
                adapter.CancelRequest += Adapter_CancelRequest;

                adapter.RequestAvailableVehicle -= Adapter_RequestAvailableVehicle;
                adapter.RequestAvailableVehicle += Adapter_RequestAvailableVehicle;
            }
            else
            {
                lvRequests.Visibility = ViewStates.Gone;
                //tvSearchResult.Visibility = ViewStates.Visible;
            }
        }

        private void Adapter_RequestAvailableVehicle(RequestHistory request)
        {
            RequestAvailableVehicleController?.Invoke(request);
        }

        private void Adapter_CancelRequest(RequestHistory request, string justification)
        {
            CancelRequestController?.Invoke(request, justification);
        }

        private void Adapter_AcceptRequest(RequestHistory request)
        {
            AcceptRequestController?.Invoke(request);
        }

        public void Changeusertext(User user)
        {
            changeuser.Text = user.Name;
        }


        public void Changevehicletext(Vehicle vehicle)
        {
            changevehicle.Text = vehicle.LicensePlate;
        }

        public void ClearText()
        {
            changeuser.Text = "Utilizador...";
            changevehicle.Text = "Veículo...";
        }

        public void ClearTextVehicle()
        {
            changevehicle.Text = "Veículo...";
        }

    }
}