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

namespace Android_Gestao_Frotas.Activities.Splash
{
    public class ActivitySplashView : ActivityBaseView
    {
        LinearLayout llLoadingInfo;

        ProgressBar pbLoadingProgress;

        TextView tvLoadingText;

        public ActivitySplashView(Context context) : base(context)
        {
            LoadView();
        }

        private void LoadView()
        {
            var view = Inflate(Context, Resource.Layout.activity_splash, this);

            llLoadingInfo = view.FindViewById<LinearLayout>(Resource.Id.llLoadingInfo);
            pbLoadingProgress = view.FindViewById<ProgressBar>(Resource.Id.pbLoadingProgress);
            tvLoadingText = view.FindViewById<TextView>(Resource.Id.tvLoadingText);

            var progressDrawable = pbLoadingProgress.IndeterminateDrawable.Mutate();
            progressDrawable.SetColorFilter(Color.White, PorterDuff.Mode.SrcIn);
            pbLoadingProgress.ProgressDrawable = progressDrawable;
        }

        public void ShowLoading(string loadingText = "A carregar, porfavor espere...")
        {
            tvLoadingText.Text = loadingText;
            llLoadingInfo.Visibility = ViewStates.Visible;
        }

        public void HideLoading()
        {
            llLoadingInfo.Visibility = ViewStates.Invisible;
        }

        public void ChangeLoadingText(string loadingText = "A carregar, porfavor espere...")
        {
            tvLoadingText.Text = loadingText;
        }
    }
}