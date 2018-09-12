using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Android_Gestao_Frotas.Activities
{
    [Activity(Label = "GestaoFrotas", Theme = "@style/AppTheme", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivityBaseController : AppCompatActivity
    {
        public const string SharedPreferenceName = "SHARED_PREFERENCE_GF";

        public const int EditUserRequestCode = 101;
        public const int NewUserRequestCode = 102;
        public const int EditVehicleRequestCode = 103;
        public const int NewVehicleRequestCode = 104;
        public const int CreateRequestRequestCode = 105;
        public const int GetPhotoRequestCode = 106;
        public const int GetFolderRequestCode = 107;
        public const int AvailableRequestRequestCode = 108;
        public const int EditModelRequestCode = 109;
        public const int NewModelRequestCode = 110;
        public const int ChangePasswordRequestRequestCode = 111;
        public const int SelectVehicleRequestCode = 112;
        public const int NewSessionRequestCode = 113;
        public const int NewProfileCode = 114;
        public const int EditProfileCode = 115;
        public const int ChangeDefaultPasswordRequestCode = 116;
        public const int ComebackRequests = 117;
        public const int SelectPermissions = 118;
        public const int ConfigurationsChange = 119;
        public const int SelectMultipleVehiclesRequestCode = 120;
        public const int GenerateReportsRequestCode = 121;
        public const int SelectMultipleUsersRequestCode = 122;
        public const int ReportSelectedRequestCode = 123;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        public async Task MakeAsync(int sleepTime = 0)
        {
            await Task.Delay(sleepTime);
        }

        private LoadingViewHolder _loadingViewHolder;

        public void SetLoadingView(bool show, bool showChronometer = false, string loadingText = "A carregar, porfavor espere...")
        {
            RunOnUiThread(() => {
                if (_loadingViewHolder == null)
                {
                    var rootView = Window.DecorView.FindViewById<ViewGroup>(Android.Resource.Id.Content);
                    var loadingView = LayoutInflater.Inflate(Resource.Layout.loading_view, rootView);

                    _loadingViewHolder = new LoadingViewHolder();

                    _loadingViewHolder.llLoading = loadingView.FindViewById<LinearLayout>(Resource.Id.llLoading);
                    _loadingViewHolder.pbLoading = loadingView.FindViewById<ProgressBar>(Resource.Id.pbLoading);
                    _loadingViewHolder.tvLoading = loadingView.FindViewById<TextView>(Resource.Id.tvLoading);
                    _loadingViewHolder.chrChronometer = loadingView.FindViewById<Chronometer>(Resource.Id.chrLoading);
                    _loadingViewHolder.tvTimes = loadingView.FindViewById<TextView>(Resource.Id.tvTimes);

                    _loadingViewHolder.chrChronometer.ChronometerTick -= ChrChronometer_ChronometerTick;
                    _loadingViewHolder.chrChronometer.ChronometerTick += ChrChronometer_ChronometerTick;

                    _loadingViewHolder.pbLoading.IndeterminateDrawable.SetColorFilter(Color.White, PorterDuff.Mode.SrcIn);
                }

                if (show)
                {
                    if (showChronometer)
                    {
                        _loadingViewHolder.chrChronometer.Visibility = ViewStates.Visible;
                        _loadingViewHolder.tvTimes.Visibility = ViewStates.Visible;
                        _loadingViewHolder.chrChronometer.Start();
                    }
                    else
                    {
                        _loadingViewHolder.chrChronometer.Visibility = ViewStates.Invisible;
                        _loadingViewHolder.tvTimes.Visibility = ViewStates.Invisible;
                    }

                    _loadingViewHolder.llLoading.Visibility = ViewStates.Visible;
                    _loadingViewHolder.tvLoading.Text = loadingText;
                }
                else
                {
                    _loadingViewHolder.chrChronometer.Stop();
                    _loadingViewHolder.llLoading.Visibility = ViewStates.Gone;
                    _loadingViewHolder.tvLoading.Text = loadingText;
                }
            });
            
        }

        public void SetLoadingMessage(string message)
        {
            RunOnUiThread(() => {
                if (_loadingViewHolder != null)
                {
                    _loadingViewHolder.tvLoading.Text = message;
                }
            });
        }

        public void SaveTime(bool saveAndRestart = false, string tag = "")
        {
            RunOnUiThread(() => {
                if (_loadingViewHolder != null)
                {
                    _loadingViewHolder.tvTimes.Text += $"[{tag}] {_loadingViewHolder.chrChronometer.Text};\n";

                    if (saveAndRestart)
                    {
                        _loadingViewHolder.chrChronometer.Base = SystemClock.ElapsedRealtime();
                        _loadingViewHolder.chrChronometer.Stop();
                        _loadingViewHolder.chrChronometer.Start();
                    }
                }
            });
        }

        private void ChrChronometer_ChronometerTick(object sender, EventArgs e)
        {
            var chronometer = sender as Chronometer;

            if (chronometer == null)
                return;

            var chronometerTime = SystemClock.ElapsedRealtime() - chronometer.Base;

            var hour = (int)(chronometerTime / 3600000);
            var minute = (int)(chronometerTime - hour * 3600000) / 60000;
            var second = (int)(chronometerTime - hour * 3600000 - minute * 60000) / 1000;

            var hh = hour < 10 ? $"0{hour}" : $"{hour}";
            var mm = minute < 10 ? $"0{minute}" : $"{minute}";
            var ss = second < 10 ? $"0{second}" : $"{second}";

            chronometer.Text = $"{hh} : {mm} : {ss}";
        }

        private void CheckInternetStatus()
        {
            //ConnectivityManager connManager = (ConnectivityManager)GetSystemService(Context.ConnectivityService);
            //NetworkInfo mWifi = connManager.GetNetworkInfo(ConnectivityManager.ActionBackgroundDataSettingChanged);

            //if (mWifi.isConnected())
            //{
            //    // Do whatever
            //}

            //if (!Reachability.IsHostReachable("http://google.com"))
            //{
            //    // Put alternative content/message here
            //}
            //else
            //{
            //    // Put Internet Required Code here
            //}

        }

    }

    class LoadingViewHolder
    {
        public LinearLayout llLoading { get; set; }

        public ProgressBar pbLoading { get; set; }
        
        public TextView tvLoading { get; set; }

        public TextView tvTimes { get; set; }

        public Chronometer chrChronometer { get; set; }
    }
}