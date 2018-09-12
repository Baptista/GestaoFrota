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
using Android_Gestao_Frotas.CustomControls;
using Core_Gestao_Frotas;

namespace Android_Gestao_Frotas.Activities.NewPassword
{
    public delegate void OnCurrentPasswordTextChangedEvent(string text);

    public delegate void OnNewPasswordTextChangedEvent(string text);

    public delegate void OnNewPasswordConfirmTextChangedEvent(string text);

    public delegate void OnFinishClickEvent();

    [Activity(Label = "NewPasswordView")]
    public class ActivityNewPasswordView : ActivityBaseView
    {
        public event OnCurrentPasswordTextChangedEvent OnCurrentPasswordTextChanged;

        public event OnNewPasswordTextChangedEvent OnNewPasswordTextChanged;

        public event OnNewPasswordConfirmTextChangedEvent OnNewPasswordConfirmTextChanged;

        public event OnFinishClickEvent OnFinishClick;

        ConfirmableEditText cetCurrentPassword;
        ConfirmableEditText cetNewPassword;
        ConfirmableEditText cetNewPasswordConfirmation;
        EditText cetCurrentPasswordDefault;

        Button btnFinish;

        public ActivityNewPasswordView(Context context) : base(context)
        {
            LoadView();
        }

        private void LoadView()
        {
            var view = Inflate(Context, Resource.Layout.activity_newpassword, this);

            cetCurrentPassword = view.FindViewById<ConfirmableEditText>(Resource.Id.cetCurrentPassword);
            cetNewPassword = view.FindViewById<ConfirmableEditText>(Resource.Id.cetNewPassword);
            cetNewPasswordConfirmation = view.FindViewById<ConfirmableEditText>(Resource.Id.cetNewPasswordConfirmation);
            cetCurrentPasswordDefault = view.FindViewById<EditText>(Resource.Id.cetCurrentPasswordDefault);

            btnFinish = view.FindViewById<Button>(Resource.Id.btnFinish);

            cetCurrentPassword.OnStateChanged -= cetCurrentPassword_OnStateChanged;
            cetCurrentPassword.OnStateChanged += cetCurrentPassword_OnStateChanged;

            cetCurrentPassword.OnTextConfirmed -= cetCurrentPassword_OnTextConfirmed;
            cetCurrentPassword.OnTextConfirmed += cetCurrentPassword_OnTextConfirmed;

            cetCurrentPassword.MinimumLenght = 6;
            cetCurrentPassword.MaximumLenght = 15;
            cetCurrentPassword.ConfirmationText = AllYouCanGet.CurrentUser.Password;
            cetCurrentPassword.ShouldCompareText = true;

            cetNewPassword.OnStateChanged -= cetNewPassword_OnStateChanged;
            cetNewPassword.OnStateChanged += cetNewPassword_OnStateChanged;

            cetNewPassword.OnTextConfirmed -= cetNewPassword_OnTextConfirmed;
            cetNewPassword.OnTextConfirmed += cetNewPassword_OnTextConfirmed;

            cetNewPassword.MinimumLenght = 6;
            cetNewPassword.MaximumLenght = 15;
            cetNewPassword.ShouldCompareText = false;

            cetNewPasswordConfirmation.OnStateChanged -= cetNewPasswordConfirmation_OnStateChanged;
            cetNewPasswordConfirmation.OnStateChanged += cetNewPasswordConfirmation_OnStateChanged;

            cetNewPasswordConfirmation.OnTextConfirmed -= cetNewPasswordConfirmation_OnTextConfirmed;
            cetNewPasswordConfirmation.OnTextConfirmed += cetNewPasswordConfirmation_OnTextConfirmed;

            cetNewPasswordConfirmation.MinimumLenght = 6;
            cetNewPasswordConfirmation.MaximumLenght = 15;
            cetNewPasswordConfirmation.ConfirmationText = cetNewPassword.Text;
            cetNewPasswordConfirmation.ShouldCompareText = true;

            btnFinish.Click -= btnFinish_Click;
            btnFinish.Click += btnFinish_Click;
        }

        public void Defaultchanges(string text)
        {
            cetCurrentPassword.Visibility = ViewStates.Gone;
            cetCurrentPasswordDefault.Visibility = ViewStates.Visible;
            cetCurrentPasswordDefault.Text = text;
            cetCurrentPasswordDefault.Enabled = false;
            cetNewPassword.Enabled = true;
            cetNewPasswordConfirmation.Enabled = true;
        }

        private void cetNewPasswordConfirmation_OnTextConfirmed(string text)
        {
            OnNewPasswordConfirmTextChanged?.Invoke(text);
        }

        private void cetNewPassword_OnTextConfirmed(string text)
        {
            OnNewPasswordTextChanged?.Invoke(text);
            cetNewPasswordConfirmation.ConfirmationText = cetNewPassword.Text;
        }

        private void cetCurrentPassword_OnTextConfirmed(string text)
        {
            OnCurrentPasswordTextChanged?.Invoke(text);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            OnFinishClick?.Invoke();
        }

        private void cetNewPasswordConfirmation_OnStateChanged(ConfirmationState currentState)
        {
            if (currentState == ConfirmationState.Success)
            {
                
            }
            else
            {
                
            }
        }

        private void cetNewPassword_OnStateChanged(ConfirmationState currentState)
        {
            if (currentState == ConfirmationState.Success)
            {
                cetNewPasswordConfirmation.Confirm();
            }
            else
            {
                
            }
        }

        private void cetCurrentPassword_OnStateChanged(ConfirmationState currentState)
        {
            if (currentState == ConfirmationState.Success)
            {
                cetNewPassword.Enabled = true;
                cetNewPasswordConfirmation.Enabled = true;
                cetNewPassword.Confirm();
                cetNewPasswordConfirmation.Confirm();
            }
            else
            {
                cetNewPassword.Enabled = false;
                cetNewPasswordConfirmation.Enabled = false;
            }
        }
    }
}