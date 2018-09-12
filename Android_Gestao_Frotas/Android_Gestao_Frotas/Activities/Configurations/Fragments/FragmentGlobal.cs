using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.CustomControls;
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Models;
using Square.Picasso;

namespace Android_Gestao_Frotas.Activities.Configurations.Fragments
{

    public delegate void OncetNewPasswordConfigurationDefaultChange(string text);
    public delegate void OncetNewPasswordConfirmationConfigurationDefaultChange(string text);

    public delegate void OncetCurrentPasswordConfigurationChange(string text);
    public delegate void OncetNewPasswordConfigurationChange(string text);
    public delegate void OncetNewPasswordConfirmationConfigurationChange(string text);

    public class FragmentGlobal : Android.Support.V4.App.Fragment
    {

        public event OncetNewPasswordConfigurationDefaultChange OncetNewPasswordConfigurationDefaultChange;
        public event OncetNewPasswordConfirmationConfigurationDefaultChange OncetNewPasswordConfirmationConfigurationDefaultChange;

        public event OncetCurrentPasswordConfigurationChange OncetCurrentPasswordConfigurationChange;
        public event OncetNewPasswordConfigurationChange OncetNewPasswordConfigurationChange;
        public event OncetNewPasswordConfirmationConfigurationChange OncetNewPasswordConfirmationConfigurationChange;

        LinearLayout llpassworddefault;

        LinearLayout PasswordDefaultClick;
        LinearLayout llDetailsPasswordDefault;

        LinearLayout PasswordClick;
        LinearLayout llDetailsPassword;

        LinearLayout FotoConfigurationClick;
        LinearLayout llDetailsFoto;
        ImageView ivUserPictureConfiguration;

        TextView cetCurrentPasswordConfigurationDefault;
        ConfirmableEditText cetNewPasswordConfigurationDefault;
        ConfirmableEditText cetNewPasswordConfirmationConfigurationDefault;

        ConfirmableEditText cetCurrentPasswordConfiguration;
        ConfirmableEditText cetNewPasswordConfiguration;
        ConfirmableEditText cetNewPasswordConfirmationConfiguration;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_global, container, false);
            PasswordDefaultClick = view.FindViewById<LinearLayout>(Resource.Id.PasswordDefaultClick);
            llDetailsPasswordDefault = view.FindViewById<LinearLayout>(Resource.Id.llDetailsPasswordDefault);

            PasswordClick = view.FindViewById<LinearLayout>(Resource.Id.PasswordClick);
            llDetailsPassword = view.FindViewById<LinearLayout>(Resource.Id.llDetailsPassword);
            llpassworddefault = view.FindViewById<LinearLayout>(Resource.Id.llpassworddefault);

            FotoConfigurationClick = view.FindViewById<LinearLayout>(Resource.Id.FotoConfigurationClick);
            llDetailsFoto = view.FindViewById<LinearLayout>(Resource.Id.llDetailsFoto);
            ivUserPictureConfiguration = view.FindViewById<ImageView>(Resource.Id.ivUserPictureConfiguration);

            cetCurrentPasswordConfigurationDefault = view.FindViewById<TextView>(Resource.Id.cetCurrentPasswordConfigurationDefault);
            cetNewPasswordConfigurationDefault = view.FindViewById<ConfirmableEditText>(Resource.Id.cetNewPasswordConfigurationDefault);
            cetNewPasswordConfirmationConfigurationDefault = view.FindViewById<ConfirmableEditText>(Resource.Id.cetNewPasswordConfirmationConfigurationDefault);

            cetCurrentPasswordConfiguration = view.FindViewById<ConfirmableEditText>(Resource.Id.cetCurrentPasswordConfiguration);
            cetNewPasswordConfiguration = view.FindViewById<ConfirmableEditText>(Resource.Id.cetNewPasswordConfiguration);
            cetNewPasswordConfirmationConfiguration = view.FindViewById<ConfirmableEditText>(Resource.Id.cetNewPasswordConfirmationConfiguration);

            cetNewPasswordConfigurationDefault.MinimumLenght = 6;
            cetNewPasswordConfigurationDefault.MaximumLenght = 15;

            cetNewPasswordConfirmationConfigurationDefault.MinimumLenght = 6;
            cetNewPasswordConfirmationConfigurationDefault.MaximumLenght = 15;

            cetCurrentPasswordConfiguration.MinimumLenght = 6;
            cetCurrentPasswordConfiguration.MaximumLenght = 15;

            cetNewPasswordConfiguration.MinimumLenght = 6;
            cetNewPasswordConfiguration.MaximumLenght = 15;

            cetNewPasswordConfirmationConfiguration.MinimumLenght = 6;
            cetNewPasswordConfirmationConfiguration.MaximumLenght = 15;

            cetCurrentPasswordConfiguration.ConfirmationText = AllYouCanGet.CurrentUser.Password;
            cetCurrentPasswordConfiguration.ShouldCompareText = true;

            cetNewPasswordConfiguration.ShouldCompareText = false;
            cetNewPasswordConfigurationDefault.ShouldCompareText = false;

            cetNewPasswordConfirmationConfiguration.ConfirmationText = cetNewPasswordConfiguration.Text;
            cetNewPasswordConfirmationConfigurationDefault.ConfirmationText = cetNewPasswordConfigurationDefault.Text;

            cetNewPasswordConfirmationConfiguration.ShouldCompareText = true;
            cetNewPasswordConfirmationConfigurationDefault.ShouldCompareText = true;

            PasswordDefaultClick.Click -= PasswordDefaultClick_Click;
            PasswordDefaultClick.Click += PasswordDefaultClick_Click;

            PasswordClick.Click -= PasswordClick_Click;
            PasswordClick.Click += PasswordClick_Click;

            FotoConfigurationClick.Click -= FotoConfigurationClick_Click;
            FotoConfigurationClick.Click += FotoConfigurationClick_Click;

            cetNewPasswordConfiguration.TextChanged -= CetNewPasswordConfiguration_TextChanged;
            cetNewPasswordConfiguration.TextChanged += CetNewPasswordConfiguration_TextChanged;

            cetNewPasswordConfigurationDefault.TextChanged -= CetNewPasswordConfigurationDefault_TextChanged;
            cetNewPasswordConfigurationDefault.TextChanged += CetNewPasswordConfigurationDefault_TextChanged;

            //cetNewPasswordConfigurationDefault.TextChanged -= CetNewPasswordConfigurationDefault_TextChanged;
            //cetNewPasswordConfigurationDefault.TextChanged += CetNewPasswordConfigurationDefault_TextChanged;

            //cetNewPasswordConfirmationConfigurationDefault.TextChanged -= CetNewPasswordConfirmationConfigurationDefault_TextChanged;
            //cetNewPasswordConfirmationConfigurationDefault.TextChanged += CetNewPasswordConfirmationConfigurationDefault_TextChanged;

            //cetCurrentPasswordConfiguration.TextChanged -= CetCurrentPasswordConfiguration_TextChanged;
            //cetCurrentPasswordConfiguration.TextChanged += CetCurrentPasswordConfiguration_TextChanged;

            //cetNewPasswordConfiguration.TextChanged -= CetNewPasswordConfiguration_TextChanged;
            //cetNewPasswordConfiguration.TextChanged += CetNewPasswordConfiguration_TextChanged;

            //cetNewPasswordConfirmationConfiguration.TextChanged -= CetNewPasswordConfirmationConfiguration_TextChanged;
            //cetNewPasswordConfirmationConfiguration.TextChanged += CetNewPasswordConfirmationConfiguration_TextChanged;

            //CONFIRMATION

            cetCurrentPasswordConfiguration.OnStateChanged -= CetCurrentPasswordConfiguration_OnStateChanged;
            cetCurrentPasswordConfiguration.OnStateChanged += CetCurrentPasswordConfiguration_OnStateChanged;

            cetCurrentPasswordConfiguration.OnTextConfirmed -= CetCurrentPasswordConfiguration_OnTextConfirmed;
            cetCurrentPasswordConfiguration.OnTextConfirmed += CetCurrentPasswordConfiguration_OnTextConfirmed;

            //

            cetNewPasswordConfiguration.OnTextConfirmed -= CetNewPasswordConfiguration_OnTextConfirmed;
            cetNewPasswordConfiguration.OnTextConfirmed += CetNewPasswordConfiguration_OnTextConfirmed;

            //

            cetNewPasswordConfirmationConfiguration.OnTextConfirmed -= CetNewPasswordConfirmationConfiguration_OnTextConfirmed;
            cetNewPasswordConfirmationConfiguration.OnTextConfirmed += CetNewPasswordConfirmationConfiguration_OnTextConfirmed;

            //

            cetNewPasswordConfigurationDefault.OnTextConfirmed -= CetNewPasswordConfigurationDefault_OnTextConfirmed;
            cetNewPasswordConfigurationDefault.OnTextConfirmed += CetNewPasswordConfigurationDefault_OnTextConfirmed;

            //

            cetNewPasswordConfirmationConfigurationDefault.OnTextConfirmed -= CetNewPasswordConfirmationConfigurationDefault_OnTextConfirmed;
            cetNewPasswordConfirmationConfigurationDefault.OnTextConfirmed += CetNewPasswordConfirmationConfigurationDefault_OnTextConfirmed;

            //

            Picasso.With(Context)
            .Load(Resource.Drawable.user_picture_test)
            .Resize(200, 200)
            .CenterCrop()
            .Transform(new CircleTransform(Color.Red, 4))
            .Rotate(-90)
            .Into(ivUserPictureConfiguration);

            if (!AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ConfigDefaultPassword))
            {
                JusthideDefault();
            }

            return view;
        }

        public void JusthideDefault()
        {
            llpassworddefault.Visibility = ViewStates.Gone;
        }

        private void FotoConfigurationClick_Click(object sender, EventArgs e)
        {
            if (llDetailsFoto.Visibility == ViewStates.Gone)
            {
                llDetailsFoto.Visibility = ViewStates.Visible;
            }
            else if (llDetailsFoto.Visibility == ViewStates.Visible)
            {
                llDetailsFoto.Visibility = ViewStates.Gone;
            }
        }

        private void CetNewPasswordConfigurationDefault_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            cetNewPasswordConfirmationConfigurationDefault.ConfirmationText = cetNewPasswordConfigurationDefault.Text;
        }

        private void CetNewPasswordConfiguration_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            cetNewPasswordConfirmationConfiguration.ConfirmationText = cetNewPasswordConfiguration.Text;
        }

        private void CetNewPasswordConfirmationConfigurationDefault_OnTextConfirmed(string text)
        {
            OncetNewPasswordConfirmationConfigurationDefaultChange?.Invoke(text);
        }

        private void CetNewPasswordConfigurationDefault_OnTextConfirmed(string text)
        {
            OncetNewPasswordConfigurationDefaultChange?.Invoke(text);
        }

        private void CetNewPasswordConfirmationConfiguration_OnTextConfirmed(string text)
        {
            OncetNewPasswordConfirmationConfigurationChange?.Invoke(text);
        }

        private void CetNewPasswordConfiguration_OnTextConfirmed(string text)
        {
            OncetNewPasswordConfigurationChange?.Invoke(text);
        }

        private void CetCurrentPasswordConfiguration_OnTextConfirmed(string text)
        {
            OncetCurrentPasswordConfigurationChange?.Invoke(text);
        }

        private void CetCurrentPasswordConfiguration_OnStateChanged(ConfirmationState currentState)
        {
            if (currentState == ConfirmationState.Success)
            {
                cetNewPasswordConfiguration.Enabled = true;
                cetNewPasswordConfirmationConfiguration.Enabled = true;
                cetNewPasswordConfiguration.Confirm();
                cetNewPasswordConfirmationConfiguration.Confirm();
            }
            else
            {
                cetNewPasswordConfiguration.Enabled = false;
                cetNewPasswordConfirmationConfiguration.Enabled = false;
            }
        }

        //private void CetNewPasswordConfirmationConfiguration_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        //{
        //    OncetNewPasswordConfirmationConfigurationChange?.Invoke(cetNewPasswordConfirmationConfiguration.Text);
        //}

        //private void CetNewPasswordConfiguration_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        //{
        //    OncetNewPasswordConfigurationChange?.Invoke(cetNewPasswordConfiguration.Text);
        //}

        //private void CetCurrentPasswordConfiguration_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        //{
        //    OncetCurrentPasswordConfigurationChange?.Invoke(cetCurrentPasswordConfiguration.Text);
        //}

        //private void CetNewPasswordConfirmationConfigurationDefault_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        //{
        //    OncetNewPasswordConfirmationConfigurationDefaultChange?.Invoke(cetNewPasswordConfirmationConfigurationDefault.Text);
        //}

        //private void CetNewPasswordConfigurationDefault_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        //{
        //    OncetNewPasswordConfigurationDefaultChange?.Invoke(cetNewPasswordConfigurationDefault.Text);
        //}

        public void Setdefaultpassword(string text)
        {
            cetCurrentPasswordConfigurationDefault.Text = text;
            cetCurrentPasswordConfigurationDefault.Enabled = false;
        }

        private void PasswordClick_Click(object sender, EventArgs e)
        {
            if (llDetailsPassword.Visibility == ViewStates.Gone)
            {
                llDetailsPassword.Visibility = ViewStates.Visible;
            }else if (llDetailsPassword.Visibility == ViewStates.Visible)
            {
                llDetailsPassword.Visibility = ViewStates.Gone;
            }
        }

        private void PasswordDefaultClick_Click(object sender, EventArgs e)
        {
            if (llDetailsPasswordDefault.Visibility == ViewStates.Gone)
            {
                llDetailsPasswordDefault.Visibility = ViewStates.Visible;
            }else if (llDetailsPasswordDefault.Visibility == ViewStates.Visible)
            {
                llDetailsPasswordDefault.Visibility = ViewStates.Gone;
            }
        }
    }
}