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
using GetRekt = Android.Graphics.Rect;

namespace Android_Gestao_Frotas.Helpers
{
    public class LayoutHelper
    {
        private Context _context;

        public LayoutHelper(Context context)
        {
            _context = context;
        }

        public int GetStatusBarHeight()
        {
            var statusBarHeight = 0;
            var resourceId = _context.Resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (resourceId > 0)
                statusBarHeight = _context.Resources.GetDimensionPixelSize(resourceId);

            return statusBarHeight;
        }

        public int GetToolbarHeight()
        {
            var actionBarHeight = 0;
            var typedValue = new TypedValue();
            if (_context.Theme.ResolveAttribute(Android.Resource.Attribute.ActionBarSize, typedValue, true))
                actionBarHeight = TypedValue.ComplexToDimensionPixelSize(typedValue.Data, _context.Resources.DisplayMetrics);

            return actionBarHeight;
        }

        public int GetScreenHeight()
        {
            var windowManager = _context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
            var display = windowManager.DefaultDisplay;
            var point = new Point();

            display.GetSize(point);
            int screenHeight = point.Y;

            return screenHeight;
        }

        public int GetScreenWidth()
        {
            var windowManager = (IWindowManager)_context.GetSystemService(Context.WindowService);
            var display = windowManager.DefaultDisplay;
            var point = new Point();

            display.GetSize(point);
            int screenWidth = point.X;

            return screenWidth;
        }
    }
}