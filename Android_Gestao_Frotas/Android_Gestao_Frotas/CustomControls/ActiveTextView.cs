using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Android_Gestao_Frotas.CustomControls
{
    public class ActiveTextView : TextView
    {
        public Color ActiveColor = new Color(27, 183, 16);
        public Color InactiveColor = new Color(229, 16, 16);

        public ActiveTextView(Context context) : base(context)
        {
        }

        public ActiveTextView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public ActiveTextView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public ActiveTextView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected ActiveTextView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        private bool _isActive;

        public bool IsActive
        {
            get
            {
                return _isActive;
            }

            set
            {
                _isActive = value;

                if (value)
                {
                    SetTextColor(ActiveColor);
                }
                else
                {
                    SetTextColor(InactiveColor);
                }
            }
        }
    }
}