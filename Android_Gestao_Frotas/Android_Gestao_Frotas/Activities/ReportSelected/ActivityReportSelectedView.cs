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
using OxyPlot;
using OxyPlot.Xamarin.Android;

namespace Android_Gestao_Frotas.Activities.ReportSelected
{
    [Activity(Label = "ActivityReportSelectedView")]
    public class ActivityReportSelectedView : ActivityBaseView
    {

        PlotView ReportGraphic;

        public ActivityReportSelectedView(Context context) : base(context)
        {
            LoadView();
        }

        public void ChangeModel(PlotModel model)
        {
            ReportGraphic.Model = model;
        }

        private void LoadView()
        {
            var view = Inflate(Context, Resource.Layout.activity_report_selected, this);
            ReportGraphic = FindViewById<PlotView>(Resource.Id.reportgraphic);

        }
    }
}