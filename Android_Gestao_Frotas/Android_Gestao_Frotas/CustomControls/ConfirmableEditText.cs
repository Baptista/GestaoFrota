using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace Android_Gestao_Frotas.CustomControls
{
    public delegate void OnStateChangedEvent(ConfirmationState currentState);

    public delegate void OnTextConfirmedEvent(string text);

    public class ConfirmableEditText : EditText
    {
        public event OnStateChangedEvent OnStateChanged;

        public event OnTextConfirmedEvent OnTextConfirmed;

        private string _confirmationText = string.Empty;

        private int _minimumLenght = 0;
        private int _maximumLenght = 999;

        private Drawable _confirmationSuccessDrawable;
        private Drawable _confirmationWrongDrawable;
        private Drawable _confirmationNeutralDrawable;

        private ConfirmationState _confirmationState = ConfirmationState.Neutral;

        private bool _shouldCompareText = true;

        public string ConfirmationText
        {
            get { return _confirmationText; }
            set { _confirmationText = (value == null ? string.Empty : value); }
        }

        public int MinimumLenght
        {
            get { return _minimumLenght; }
            set { _minimumLenght = value; }
        }

        public int MaximumLenght
        {
            get { return _maximumLenght; }
            set { _maximumLenght = value; }
        }

        public ConfirmationState State
        {
            get { return _confirmationState; }
            private set
            {
                _confirmationState = value;
                OnStateChanged?.Invoke(value);
            }
        }

        public Drawable NeutralIcon
        {
            get { return _confirmationNeutralDrawable; }
            set { _confirmationNeutralDrawable = value; }
        }

        public Drawable SuccessIcon
        {
            get { return _confirmationSuccessDrawable; }
            set { _confirmationSuccessDrawable = value; }
        }

        public Drawable WrongIcon
        {
            get { return _confirmationWrongDrawable; }
            set { _confirmationWrongDrawable = value; }
        }

        public bool ShouldCompareText
        {
            get { return _shouldCompareText; }
            set { _shouldCompareText = value; }
        }

        public ConfirmableEditText(Context context) : base(context)
        {
            LoadDrawables();
        }

        public ConfirmableEditText(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            LoadDrawables();
        }

        public ConfirmableEditText(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            LoadDrawables();
        }

        public ConfirmableEditText(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            LoadDrawables();
        }

        protected ConfirmableEditText(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            LoadDrawables();
        }

        private void LoadDrawables()
        {
            NeutralIcon = ContextCompat.GetDrawable(Context, Resource.Drawable.ic_confirmation_neutral);
            SuccessIcon = ContextCompat.GetDrawable(Context, Resource.Drawable.ic_confirmation_success);
            WrongIcon = ContextCompat.GetDrawable(Context, Resource.Drawable.ic_confirmation_wrong);

            UpdateConfirmationDrawable();
        }

        private void UpdateConfirmationDrawable()
        {
            if (State == ConfirmationState.Neutral)
                SetCompoundDrawablesWithIntrinsicBounds(null, null, NeutralIcon, null);
            else if (State == ConfirmationState.Success)
                SetCompoundDrawablesWithIntrinsicBounds(null, null, SuccessIcon, null);
            else if (State == ConfirmationState.Wrong)
                SetCompoundDrawablesWithIntrinsicBounds(null, null, WrongIcon, null);

            Invalidate();
        }

        private bool TryAndConfirm()
        {
            var confirmed = false;

            if (string.IsNullOrEmpty(Text))
            {
                State = ConfirmationState.Neutral;
                confirmed = false;
            }
            else
            {
                if (Text.Length < MinimumLenght || Text.Length > MaximumLenght)
                {
                    State = ConfirmationState.Wrong;
                    confirmed = false;
                }
                else
                {
                    if (Text.Length >= MinimumLenght && Text.Length <= MaximumLenght)
                    {
                        State = ConfirmationState.Success;
                        confirmed = true;
                    }

                    if (ShouldCompareText)
                    {
                        if (Text.Equals(_confirmationText))
                        {
                            State = ConfirmationState.Success;
                            confirmed = true;
                        }
                        else
                        {
                            State = ConfirmationState.Wrong;
                            confirmed = false;
                        }
                    }
                }
            }

            UpdateConfirmationDrawable();
            return confirmed;
        }

        public void Confirm()
        {
            var confirmed = TryAndConfirm();
            if (confirmed)
                OnTextConfirmed?.Invoke(Text);
            else
                OnTextConfirmed?.Invoke(string.Empty);
        }

        protected override void OnTextChanged(ICharSequence text, int start, int lengthBefore, int lengthAfter)
        {
            base.OnTextChanged(text, start, lengthBefore, lengthAfter);
            var confirmed = TryAndConfirm();
            if (confirmed)
                OnTextConfirmed?.Invoke(Text);
            else
                OnTextConfirmed?.Invoke(string.Empty);
        }
    }

    public enum ConfirmationState
    {
        Neutral = 0,
        Success = 1,
        Wrong = 3,
    }
}