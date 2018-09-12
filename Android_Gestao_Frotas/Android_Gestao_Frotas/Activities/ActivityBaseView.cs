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

namespace Android_Gestao_Frotas.Activities
{
    public class ActivityBaseView : LinearLayout
    {
        public ActivityBaseView(Context context) : base(context)
        {
            PrepareView();
        }

        public ActivityBaseView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            PrepareView();
        }

        public ActivityBaseView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            PrepareView();
        }

        public ActivityBaseView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            PrepareView();
        }

        protected ActivityBaseView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            PrepareView();
        }

        public virtual void PrepareView()
        {

        }
    }
}