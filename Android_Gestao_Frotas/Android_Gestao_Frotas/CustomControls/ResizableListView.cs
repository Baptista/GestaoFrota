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

namespace Android_Gestao_Frotas.CustomControls
{
    public class ResizableListView : ListView
    {
        public ResizableListView(Context context) : base(context)
        {
        }

        public ResizableListView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public ResizableListView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public ResizableListView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected ResizableListView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);

            var childHeight = MeasuredHeight - (ListPaddingTop + ListPaddingBottom + VerticalFadingEdgeLength * 2);
            var fullHeight = ListPaddingTop + ListPaddingBottom + childHeight * (Count);

            SetMeasuredDimension(MeasuredWidth, fullHeight);
            Parent?.RequestLayout();
        }
    }
}