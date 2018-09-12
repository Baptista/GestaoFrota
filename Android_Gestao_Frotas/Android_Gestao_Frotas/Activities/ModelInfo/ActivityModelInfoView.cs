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
using Core_Gestao_Frotas.Business.Models;

namespace Android_Gestao_Frotas.Activities.ModelInfo
{
    public delegate void OnNameChangedEvent(string name);

    public delegate void OnStateChangedEvent(bool active);

    public delegate void OnBrandClickEvent();

    public delegate void OnFuelClickEvent();

    public delegate void OnFinishClickEvent();

    public class ActivityModelInfoView : ActivityBaseView
    {
        public event OnNameChangedEvent OnNameChanged;

        public event OnStateChangedEvent OnStateChanged;

        public event OnBrandClickEvent OnBrandClick;

        public event OnFuelClickEvent OnFuelClick;

        public event OnFinishClickEvent OnFinishClick;

        ImageView ivImage;

        EditText etName;

        Switch swState;

        TextView tvBrand;
        TextView tvFuel;

        Button btnFinish;

        public ActivityModelInfoView(Context context) : base(context)
        {
            LoadView();
        }

        private void LoadView()
        {
            var view = Inflate(Context, Resource.Layout.activity_modelinfo, this);

            ivImage = view.FindViewById<ImageView>(Resource.Id.ivImage);
            etName = view.FindViewById<EditText>(Resource.Id.etName);
            swState = view.FindViewById<Switch>(Resource.Id.swState);
            tvBrand = view.FindViewById<TextView>(Resource.Id.tvBrand);
            tvFuel = view.FindViewById<TextView>(Resource.Id.tvFuel);
            btnFinish = view.FindViewById<Button>(Resource.Id.btnFinish);

            etName.TextChanged -= EtName_TextChanged;
            etName.TextChanged += EtName_TextChanged;

            swState.CheckedChange -= SwState_CheckedChange;
            swState.CheckedChange += SwState_CheckedChange;

            tvBrand.Click -= TvBrand_Click;
            tvBrand.Click += TvBrand_Click;

            tvFuel.Click -= TvFuel_Click;
            tvFuel.Click += TvFuel_Click;

            btnFinish.Click -= BtnFinish_Click;
            btnFinish.Click += BtnFinish_Click;
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            OnFinishClick?.Invoke();
        }

        private void TvFuel_Click(object sender, EventArgs e)
        {
            OnFuelClick?.Invoke();
        }

        private void TvBrand_Click(object sender, EventArgs e)
        {
            OnBrandClick?.Invoke();
        }

        private void SwState_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            OnStateChanged?.Invoke(e.IsChecked);
        }

        private void EtName_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            OnNameChanged?.Invoke(e.Text.ToString());
        }

        public void SetStateEnabled(bool enabled)
        {
            swState.Enabled = enabled;
        }

        public void SetModelInfo(Model model)
        {
            if (model != null && !model.IsIncomplete)
            {
                etName.Text = model.Description;
                tvBrand.Text = model.Brand.Description;
                tvFuel.Text = model.Fuel.Description;
                swState.Checked = model.Active;
            }
        }

        public void SetFuelText(string description)
        {
            tvFuel.Text = description;
        }

        public void SetBrandText(string description)
        {
            tvBrand.Text = description;
        }
    }
}