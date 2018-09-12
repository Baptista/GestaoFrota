using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.CustomControls;
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas.Business.Models;
using Square.Picasso;

namespace Android_Gestao_Frotas.Adapters
{
    public class ReportVehiclesAdapter : PagerAdapter
    {
        private Context _context;
        private List<Vehicle> _vehicles;

        private int _height = 0;

        public ReportVehiclesAdapter(Context context, List<Vehicle> vehicles)
        {
            _context = context;
            _vehicles = vehicles;
        }

        public override int Count
        {
            get { return _vehicles.Count > 0 ? _vehicles.Count : 1; }
        }

        public override bool IsViewFromObject(View view, Java.Lang.Object obj)
        {
            return view == obj;
        }

        public override Java.Lang.Object InstantiateItem(View container, int position)
        {
            var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
            var view = inflater.Inflate(Resource.Layout.item_reports_vehicle, null, false);

            var ivImage = view.FindViewById<ImageView>(Resource.Id.ivImage);

            var tvVehicle = view.FindViewById<TextView>(Resource.Id.tvVehicle);
            var tvLicensePlate = view.FindViewById<TextView>(Resource.Id.tvLicensePlate);
            var tvUser = view.FindViewById<TextView>(Resource.Id.tvUser);
            var tvTypology = view.FindViewById<TextView>(Resource.Id.tvTypology);
            var tvFuel = view.FindViewById<TextView>(Resource.Id.tvFuel);
            var tvKms = view.FindViewById<TextView>(Resource.Id.tvKms);
            var tvContractsKms = view.FindViewById<TextView>(Resource.Id.tvContractsKms);

            var atvState = view.FindViewById<ActiveTextView>(Resource.Id.atvState);

            var llRoot = view.FindViewById<LinearLayout>(Resource.Id.llRoot);
            var llNoVehicles = view.FindViewById<LinearLayout>(Resource.Id.llNoVehicles);

            if (_vehicles.Any())
            {
                var vehicle = _vehicles[position];

                tvVehicle.Text = $"{vehicle.Model.Brand.Description} - {vehicle.Model.Description}";
                tvLicensePlate.Text = $"{vehicle.LicensePlate}";
                tvUser.Text = $"{vehicle.User.Name} ({vehicle.User.Username})";
                tvTypology.Text = $"{vehicle.Typology.Description}";
                tvFuel.Text = $"{vehicle.Model.Fuel.Description}";
                tvKms.Text = $"{vehicle.StartKms}";
                tvContractsKms.Text = $"{vehicle.ContractKms}";

                atvState.Text = _vehicles[position].Active ? $"Ativo" : $"Inativo";
                atvState.IsActive = _vehicles[position].Active;

                Picasso.With(_context)
                    .Load(Resource.Drawable.car_picture_test)
                    .Placeholder(Resource.Drawable.ic_car_image)
                    .Error(Resource.Drawable.ic_car_image)
                    .Resize(111, 111)
                    .CenterInside()
                    .Transform(new CircleTransform(Color.Red, 2f))
                    .Into(ivImage);

                llRoot.Visibility = ViewStates.Visible;
                llNoVehicles.Visibility = ViewStates.Invisible;

                var viewPager = container.JavaCast<ViewPager>();
                viewPager.AddView(view);

                if (_height == 0)
                {
                    view.Measure(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                    _height = view.MeasuredHeight;
                }

                return view;
            }
            else
            {
                llRoot.Visibility = ViewStates.Invisible;
                llNoVehicles.Visibility = ViewStates.Visible;

                var viewPager = container.JavaCast<ViewPager>();
                viewPager.AddView(view);

                if (_height == 0)
                {
                    view.Measure(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                    _height = view.MeasuredHeight;
                }

                return view;
            }
        }

        public override void DestroyItem(View container, int position, Java.Lang.Object view)
        {
            var viewPager = container.JavaCast<ViewPager>();
            viewPager.RemoveView(view as View);
        }

        public int GetHeight()
        {
            return _height;
        }
    }
}