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

namespace Android_Gestao_Frotas.Activities.UserInfo
{
    public delegate void OnFinishButtonClickEvent();

    public delegate void OnProfileClickEvent();

    public delegate void OnNameTextChangedEvent(string name);
    public delegate void OnUsernameTextChangedEvent(string username);
    public delegate void OnPasswordTextChangedEvent(string password);

    public delegate void OnStateCheckedChangedEvent(bool state);

    public class ActivityUserInfoView : ActivityBaseView
    {
        public event OnFinishButtonClickEvent OnFinishButtonClick;

        public event OnProfileClickEvent OnProfileClick;

        public event OnNameTextChangedEvent OnNameTextChanged;
        public event OnUsernameTextChangedEvent OnUsernameTextChanged;
        public event OnPasswordTextChangedEvent OnPasswordTextChanged;

        public event OnStateCheckedChangedEvent OnStateCheckedChanged;

        ImageView ivUserImage;

        EditText etName;
        EditText etUsername;
        EditText etPassword;

        Switch swState;

        TextView tvProfile;

        Button btnFinish;

        private bool _isUpdating = true;

        public ActivityUserInfoView(Context context) : base(context)
        {
            LoadView();
        }

        private void LoadView()
        {
            var view = Inflate(Context, Resource.Layout.activity_userinfo, this);

            ivUserImage = view.FindViewById<ImageView>(Resource.Id.ivUserImage);

            etName = view.FindViewById<EditText>(Resource.Id.etName);
            etUsername = view.FindViewById<EditText>(Resource.Id.etUsername);
            etPassword = view.FindViewById<EditText>(Resource.Id.etPassword);

            swState = view.FindViewById<Switch>(Resource.Id.swState);

            tvProfile = view.FindViewById<TextView>(Resource.Id.tvProfile);

            btnFinish = view.FindViewById<Button>(Resource.Id.btnFinish);

            ivUserImage.Click -= IvUserImage_Click;
            ivUserImage.Click += IvUserImage_Click;

            swState.CheckedChange -= SwState_CheckedChange;
            swState.CheckedChange += SwState_CheckedChange;

            tvProfile.Click -= TvProfile_Click;
            tvProfile.Click += TvProfile_Click;

            btnFinish.Click -= BtnFinish_Click;
            btnFinish.Click += BtnFinish_Click;

            etName.TextChanged -= EtName_TextChanged;
            etName.TextChanged += EtName_TextChanged;

            etUsername.TextChanged -= EtUsername_TextChanged;
            etUsername.TextChanged += EtUsername_TextChanged;

            etPassword.TextChanged -= EtPassword_TextChanged;
            etPassword.TextChanged += EtPassword_TextChanged;
        }

        private void EtPassword_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            OnPasswordTextChanged?.Invoke(etPassword.Text);
        }

        private void EtUsername_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            OnUsernameTextChanged?.Invoke(etUsername.Text);
        }

        private void EtName_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            OnNameTextChanged?.Invoke(etName.Text);
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            OnFinishButtonClick?.Invoke();
        }

        private void TvProfile_Click(object sender, EventArgs e)
        {
            OnProfileClick?.Invoke();
        }

        private void SwState_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            OnStateCheckedChanged?.Invoke(e.IsChecked);
        }

        private void IvUserImage_Click(object sender, EventArgs e)
        {
            Toast.MakeText(Context, "Esta funcionalidade ainda não foi implementada", ToastLength.Short).Show();
        }

        public void UpdateUserInfo(User user, bool isNew)
        {
            if (isNew)
            {
                etPassword.Text = user.Password;
                swState.Checked = user.Active;
                swState.Enabled = false;
            }
            else
            {
                etName.Text = user.Name;
                etUsername.Text = user.Username;
                etPassword.Text = user.Password;
                swState.Checked = user.Active;
                swState.Enabled = true;
                tvProfile.Text = user.Profile?.Description;
            }
        }

        public void SetProfileText(string profile)
        {
            tvProfile.Text = profile;
        }
    }
}