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
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;

namespace Android_Gestao_Frotas.Activities.VehicleInfo
{
    public delegate void OnBrandsClickEvent();

    public delegate void OnModelsClickEvent();

    public delegate void OnFuelsClickEvent();

    public delegate void OnUsersClickEvent();

    public delegate void OnTypologiesClickEvent();

    public delegate void OnLicensePlateChangedEvent(string licensePlate);

    public delegate void OnKmsChangedEvent(string kms);

    public delegate void OnKmsContractChangedEvent(string kmsContract);

    public delegate void OnStateChangedEvent(bool active);

    public delegate void OnFinishClickEvent();

    [Activity(Label = "ActivityNewVehicleView")]
    public class ActivityVehicleInfoView : ActivityBaseView
    {
        public event OnBrandsClickEvent OnBrandsClick;
        
        public event OnModelsClickEvent OnModelsClick;
        
        public event OnFuelsClickEvent OnFuelsClick;
        
        public event OnUsersClickEvent OnUsersClick;
        
        public event OnTypologiesClickEvent OnTypologiesClick;

        public event OnLicensePlateChangedEvent OnLicensePlateChanged;

        public event OnKmsChangedEvent OnKmsChanged;

        public event OnKmsContractChangedEvent OnKmsContractChanged;

        public event OnStateChangedEvent OnStateChanged;

        public event OnFinishClickEvent OnFinishClick;

        ImageView ivImage;

        TextView tvBrand;
        TextView tvModel;
        TextView tvFuel;
        TextView tvUser;
        TextView tvTypology;

        Switch swState;

        EditText etLicensePlate;
        EditText etKms;
        EditText etKmsContract;

        Button btnFinish;

        public ActivityVehicleInfoView(Context context) : base(context)
        {
            LoadView();
        }

        private void LoadView()
        {
            var view = Inflate(Context, Resource.Layout.activity_vehicleinfo, this);

            ivImage = view.FindViewById<ImageView>(Resource.Id.ivImage);

            tvBrand = view.FindViewById<TextView>(Resource.Id.tvBrand);
            tvModel = view.FindViewById<TextView>(Resource.Id.tvModel);
            tvFuel = view.FindViewById<TextView>(Resource.Id.tvFuel);
            tvUser = view.FindViewById<TextView>(Resource.Id.tvUser);
            tvTypology = view.FindViewById<TextView>(Resource.Id.tvTypology);

            swState = view.FindViewById<Switch>(Resource.Id.swState);

            etLicensePlate = view.FindViewById<EditText>(Resource.Id.etLicensePlate);
            etKms = view.FindViewById<EditText>(Resource.Id.etKms);
            etKmsContract = view.FindViewById<EditText>(Resource.Id.etKmsContract);

            btnFinish = view.FindViewById<Button>(Resource.Id.btnFinish);

            tvBrand.Click -= TvBrand_Click;
            tvBrand.Click += TvBrand_Click;

            tvModel.Click -= TvModel_Click;
            tvModel.Click += TvModel_Click;

            tvFuel.Click -= TvFuel_Click;
            tvFuel.Click += TvFuel_Click;

            tvTypology.Click -= TvTypology_Click;
            tvTypology.Click += TvTypology_Click;

            tvUser.Click -= TvUser_Click;
            tvUser.Click += TvUser_Click;

            etLicensePlate.TextChanged -= EtLicensePlate_TextChanged;
            etLicensePlate.TextChanged += EtLicensePlate_TextChanged;

            etKms.TextChanged -= EtKms_TextChanged;
            etKms.TextChanged += EtKms_TextChanged;

            etKmsContract.TextChanged -= EtKmsContract_TextChanged;
            etKmsContract.TextChanged += EtKmsContract_TextChanged;

            swState.CheckedChange -= SwState_CheckedChange;
            swState.CheckedChange += SwState_CheckedChange;

            btnFinish.Click -= BtnFinish_Click;
            btnFinish.Click += BtnFinish_Click;
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            OnFinishClick?.Invoke();
        }

        private void SwState_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            OnStateChanged?.Invoke(e.IsChecked);
        }

        private void EtKmsContract_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            OnKmsContractChanged?.Invoke(e.Text.ToString());
        }

        private void EtKms_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            OnKmsChanged?.Invoke(e.Text.ToString());
        }

        private void EtLicensePlate_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            OnLicensePlateChanged?.Invoke(e.Text.ToString());
        }

        private void TvUser_Click(object sender, EventArgs e)
        {
            OnUsersClick?.Invoke();
        }

        private void TvFuel_Click(object sender, EventArgs e)
        {
            if (tvFuel.Enabled)
                OnFuelsClick?.Invoke();
        }

        private void TvBrand_Click(object sender, EventArgs e)
        {
            OnBrandsClick?.Invoke();
        }

        private void TvTypology_Click(object sender, EventArgs e)
        {
            OnTypologiesClick?.Invoke();
        }

        private void TvModel_Click(object sender, EventArgs e)
        {
            if (tvModel.Enabled)
                OnModelsClick?.Invoke();
        }

        public void SetBrandText(string brand)
        {
            tvBrand.Text = brand;
        }

        public void SetModelText(string model)
        {
            tvModel.Text = model;
        }

        public void SetFuelText(string fuel)
        {
            tvFuel.Text = fuel;
        }

        public void SetUserText(string user)
        {
            tvUser.Text = user;
        }

        public void SetTypologyText(string typology)
        {
            tvTypology.Text = typology;
        }

        public void SetModelEnabled(bool enabled)
        {
            tvModel.Enabled = enabled;
        }

        public void SetFuelEnabled(bool enabled)
        {
            tvFuel.Enabled = enabled;
        }

        public void SetStateEnabled(bool enabled)
        {
            swState.Enabled = enabled;
        }

        public void SetVehicleInfo(Vehicle vehicle)
        {
            tvBrand.Text = vehicle.Model.Brand.Description;
            tvModel.Text = vehicle.Model.Description;
            tvFuel.Text = vehicle.Model.Fuel.Description;
            tvUser.Text = $"{vehicle.User.Name} ({vehicle.User.Username})";
            tvTypology.Text = vehicle.Typology.Description;

            etLicensePlate.Text = vehicle.LicensePlate;
            etKms.Text = vehicle.StartKms.ToString();
            etKmsContract.Text = vehicle.ContractKms.ToString();

            swState.Checked = vehicle.Active;
        }

        public void SetBrandPicked()
        {
            SetFuelText($"Seleccione um Combustível...");
            SetModelText($"Seleccione um Modelo...");
            SetFuelEnabled(false);
            SetModelEnabled(true);
        }

        public void SetModelPicked()
        {
            SetFuelText($"Seleccione um Combustível...");
            SetFuelEnabled(true);
        }

        public void SetLicensePlate(string licensePlate)
        {
            etLicensePlate.Text = licensePlate;
            etLicensePlate.SetSelection(etLicensePlate.Text.Length);
        }
    }
}