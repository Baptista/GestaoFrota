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
using Square.Picasso;
using static Android.Graphics.Paint;

namespace Android_Gestao_Frotas.Helpers
{
    public class CircleTransform : Java.Lang.Object, ITransformation
    {
        private Color _borderColor;

        private float _borderSize;
        private float _borderPadding;

        public CircleTransform(Color borderColor, float borderSize = 0.0f, float borderPadding = 0.0f)
        {
            _borderColor = borderColor;
            _borderSize = borderSize;
            _borderPadding = borderPadding;
        }

        public string Key => $"CircleTransform({_borderColor.ToString()}, {_borderSize})";

        public Bitmap Transform(Bitmap source)
        {
            int size = Math.Min(source.Width, source.Height);

            int x = (source.Width - size) / 2;
            int y = (source.Height - size) / 2;

            Bitmap squaredBitmap = Bitmap.CreateBitmap(source, x, y, size, size);
            if (squaredBitmap != source)
            {
                source.Recycle();
            }

            Bitmap bitmap = Bitmap.CreateBitmap(size, size, source.GetConfig());

            Canvas canvas = new Canvas(bitmap);
            Paint paint = new Paint();
            BitmapShader shader = new BitmapShader(squaredBitmap, BitmapShader.TileMode.Clamp, BitmapShader.TileMode.Clamp);
            paint.SetShader(shader);
            paint.AntiAlias = true;

            float r = size / 2f;
            canvas.DrawCircle(r, r, r, paint);

            Paint borderPaint = new Paint();
            borderPaint.Color = _borderColor;
            borderPaint.SetStyle(Style.Stroke);
            borderPaint.AntiAlias = true;
            borderPaint.StrokeWidth = _borderSize;
            canvas.DrawCircle(r, r, (r - (_borderSize/2)), borderPaint);

            squaredBitmap.Recycle();
            return bitmap;
        }
    }
}