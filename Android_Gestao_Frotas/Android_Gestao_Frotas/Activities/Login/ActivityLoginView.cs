using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Android_Gestao_Frotas.Activities.Login
{
    public delegate void OnLoginButtonClickEvent(string username, string password);

    public class ActivityLoginView : ActivityBaseView
    {
        public event OnLoginButtonClickEvent OnLoginClick;

        EditText etUsername;
        EditText etPassword;

        Button btnLogin;

        ProgressBar pbValidatingLogin;

        public ActivityLoginView(Context context) : base(context)
        {
            LoadView();
        }

        public void Clearform()
        {
            etUsername.Text = "";
            etPassword.Text = "";
        }

        private void LoadView()
        {
            var view = Inflate(Context, Resource.Layout.activity_login, this);

            etUsername = view.FindViewById<EditText>(Resource.Id.etUsername);
            etPassword = view.FindViewById<EditText>(Resource.Id.etPassword);
            btnLogin = view.FindViewById<Button>(Resource.Id.btnLogin);
            pbValidatingLogin = view.FindViewById<ProgressBar>(Resource.Id.pbValidatingLogin);

            pbValidatingLogin.IndeterminateDrawable.SetColorFilter(Color.White, PorterDuff.Mode.SrcIn);

            btnLogin.Click += BtnLogin_Click;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            OnLoginClick?.Invoke(etUsername.Text, etPassword.Text);
        }

        public void IsValidatingLogin(bool validating)
        {
            if (validating)
            {
                etUsername.Enabled = false;
                etPassword.Enabled = false;
                etUsername.Visibility = ViewStates.Gone;
                etPassword.Visibility = ViewStates.Gone;
                btnLogin.Visibility = ViewStates.Gone;
                pbValidatingLogin.Visibility = ViewStates.Visible;
            }
            else
            {
                etUsername.Enabled = true;
                etPassword.Enabled = true;
                etUsername.Visibility = ViewStates.Visible;
                etPassword.Visibility = ViewStates.Visible;
                btnLogin.Visibility = ViewStates.Visible;
                pbValidatingLogin.Visibility = ViewStates.Gone;
            }
        }
    }
}