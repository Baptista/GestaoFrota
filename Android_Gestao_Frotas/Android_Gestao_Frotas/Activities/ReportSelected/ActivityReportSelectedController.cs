using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace Android_Gestao_Frotas.Activities.ReportSelected
{
    [Activity(Label = "Relatório")]
    public class ActivityReportSelectedController : ActivityBaseController
    {

        ActivityReportSelectedView MainView;
        Android.Support.V7.Widget.Toolbar Toolbar;
        private int _typeconsult;
        private List<VehicleHistory> _list = new List<VehicleHistory>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            LoadView();
            LoadDataAsync();
        }

        private void LoadDataAsync()
        {
            SetLoadingView(true);
            _typeconsult = AllYouCanGet.ReportProcess.TypeConsult;
            _list = AllYouCanGet.ReportProcess.ListaFiltrada;

            if (_typeconsult == 0)
            {
                MainView.ChangeModel(ModelOne());
                GraphToSvg(ModelOne());
            }
            else if (_typeconsult == 1)
            {
                MainView.ChangeModel(ModelTwo());
                GraphToSvg(ModelTwo());
            }
            else if (_typeconsult == 2)
            {
                MainView.ChangeModel(ModelThree());
                GraphToSvg(ModelThree());
            }
            else if (_typeconsult == 3)
            {
                MainView.ChangeModel(ModelFour());
                GraphToSvg(ModelFour());
            }
            else if (_typeconsult == 4)
            {
                MainView.ChangeModel(ModelFive());
                GraphToSvg(ModelFive());
            }

            SetLoadingView(false);
        }

        private void GraphToSvg(PlotModel plotModel)
        {

            string documentsPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var filename = "reportSVG - " + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            string path = Path.Combine(documentsPath, filename + ".svg");

            using (var stream = File.Create(path))
            {
                var exporter = new SvgExporter { Width = 600, Height = 400 };
                exporter.Export(plotModel, stream);
            }
        }

        private PlotModel ModelOne()
        {
            var model = new PlotModel
            {
                Title = "Owner/Veículo",
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };

            var s1 = new BarSeries { Title = "Kms", StrokeColor = OxyColors.Black, StrokeThickness = 1, FillColor = OxyColors.Red };
            for (int i = 0; i < _list.Count; i++)
            {
                int km = Convert.ToInt32(_list[i].Kms);
                s1.Items.Add(new BarItem { Value = km });
            }

            var s2 = new BarSeries { Title = "Nº de Horas", StrokeColor = OxyColors.Black, StrokeThickness = 1, FillColor = OxyColors.Gray };
            for (int i = 0; i < _list.Count; i++)
            {
                var hour = (_list[i].RequestHistory.EndDate - _list[i].RequestHistory.StartDate).TotalHours;
                s2.Items.Add(new BarItem { Value = hour });
            }

            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
            categoryAxis.Zoom(-1, 5);

            for (int i = 0; i < _list.Count; i++)
            {
                string datarange = _list[i].RequestHistory.StartDate.ToShortDateString().ToString() + " a " + _list[i].RequestHistory.EndDate.ToShortDateString().ToString();
                categoryAxis.Labels.Add(datarange);
            }

            var valueAxis = new LinearAxis { Position = AxisPosition.Bottom, MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0 };
            model.Series.Add(s1);
            model.Series.Add(s2);
            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);

            return model;
        }

        private PlotModel ModelTwo()
        {

            var tuple = new List<(int, string, int, double)>{};

            for (int i = 0; i < _list.Count; i++)
            {
                if (tuple.Any(x=> x.Item1 == _list[i].RequestHistory.User.Id) == false)
                {
                    tuple.Add((_list[i].RequestHistory.User.Id,_list[i].RequestHistory.User.ToString(),Convert.ToInt32(_list[i].Kms), (_list[i].RequestHistory.EndDate - _list[i].RequestHistory.StartDate).TotalHours));
                }
                else
                {
                    var a = tuple.FindIndex(x => x.Item1 == _list[i].RequestHistory.User.Id);
                    tuple[a] = (tuple[a].Item1, tuple[a].Item2, tuple[a].Item3 + Convert.ToInt32(_list[i].Kms), tuple[a].Item4 + (_list[i].RequestHistory.EndDate - _list[i].RequestHistory.StartDate).TotalHours);
                }
            }

            var model = new PlotModel
            {
                Title = "Owners do Veículo",
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };

            var s1 = new BarSeries { Title = "Kms", StrokeColor = OxyColors.Black, StrokeThickness = 1, FillColor = OxyColors.Red };
            for (int i = 0; i < tuple.Count; i++)
            {
                s1.Items.Add(new BarItem { Value = tuple[i].Item3 });
            }

            var s2 = new BarSeries { Title = "Nº de Horas", StrokeColor = OxyColors.Black, StrokeThickness = 1, FillColor = OxyColors.Gray };
            for (int i = 0; i < tuple.Count; i++)
            {
                s2.Items.Add(new BarItem { Value = tuple[i].Item4 });
            }

            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
            categoryAxis.Zoom(-1, 5);
            for (int i = 0; i < tuple.Count; i++)
            {
                categoryAxis.Labels.Add(tuple[i].Item2);
            }

            var valueAxis = new LinearAxis { Position = AxisPosition.Bottom, MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0 };
            model.Series.Add(s1);
            model.Series.Add(s2);
            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);
            return model;
        }

        private PlotModel ModelThree()
        {

            var tuple = new List<(int, string, int, double)> { };

            for (int i = 0; i < _list.Count; i++)
            {
                if (tuple.Any(x => x.Item1 == _list[i].RequestHistory.Vehicle.Id) == false)
                {
                    tuple.Add((_list[i].RequestHistory.Vehicle.Id, _list[i].RequestHistory.Vehicle.ToString(), Convert.ToInt32(_list[i].Kms), (_list[i].RequestHistory.EndDate - _list[i].RequestHistory.StartDate).TotalHours));
                }
                else
                {
                    var a = tuple.FindIndex(x => x.Item1 == _list[i].RequestHistory.Vehicle.Id);
                    tuple[a] = (tuple[a].Item1, tuple[a].Item2, tuple[a].Item3 + Convert.ToInt32(_list[i].Kms), tuple[a].Item4 + (_list[i].RequestHistory.EndDate - _list[i].RequestHistory.StartDate).TotalHours);
                }
            }

            var model = new PlotModel
            {
                Title = "Veículos do Owner",
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };

            var s1 = new BarSeries { Title = "Kms", StrokeColor = OxyColors.Black, StrokeThickness = 1, FillColor = OxyColors.Red };
            for (int i = 0; i < tuple.Count; i++)
            {
                s1.Items.Add(new BarItem { Value = tuple[i].Item3 });
            }

            var s2 = new BarSeries { Title = "Nº de Horas", StrokeColor = OxyColors.Black, StrokeThickness = 1, FillColor = OxyColors.Gray };
            for (int i = 0; i < tuple.Count; i++)
            {
                s2.Items.Add(new BarItem { Value = tuple[i].Item4 });
            }

            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
            categoryAxis.Zoom(-1, 5);
            for (int i = 0; i < tuple.Count; i++)
            {
                categoryAxis.Labels.Add(tuple[i].Item2);
            }

            var valueAxis = new LinearAxis { Position = AxisPosition.Bottom, MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0 };
            model.Series.Add(s1);
            model.Series.Add(s2);
            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);
            return model;
        }

        private PlotModel ModelFour()
        {

            var tuple = new List<(int, string, int, double)> { };

            for (int i = 0; i < _list.Count; i++)
            {
                if (tuple.Any(x => x.Item1 == _list[i].RequestHistory.Vehicle.Id) == false)
                {
                    tuple.Add((_list[i].RequestHistory.Vehicle.Id, _list[i].RequestHistory.Vehicle.ToString(), Convert.ToInt32(_list[i].Kms), (_list[i].RequestHistory.EndDate - _list[i].RequestHistory.StartDate).TotalHours));
                }
                else
                {
                    var a = tuple.FindIndex(x => x.Item1 == _list[i].RequestHistory.Vehicle.Id);
                    tuple[a] = (tuple[a].Item1, tuple[a].Item2, tuple[a].Item3 + Convert.ToInt32(_list[i].Kms), tuple[a].Item4 + (_list[i].RequestHistory.EndDate - _list[i].RequestHistory.StartDate).TotalHours);
                }
            }

            var model = new PlotModel
            {
                Title = "Todos os Veículos",
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };

            var s1 = new BarSeries { Title = "Kms", StrokeColor = OxyColors.Black, StrokeThickness = 1, FillColor = OxyColors.Red };
            for (int i = 0; i < tuple.Count; i++)
            {
                s1.Items.Add(new BarItem { Value = tuple[i].Item3 });
            }

            var s2 = new BarSeries { Title = "Nº de Horas", StrokeColor = OxyColors.Black, StrokeThickness = 1, FillColor = OxyColors.Gray };
            for (int i = 0; i < tuple.Count; i++)
            {
                s2.Items.Add(new BarItem { Value = tuple[i].Item4 });
            }

            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
            categoryAxis.Zoom(-1, 5);
            for (int i = 0; i < tuple.Count; i++)
            {
                categoryAxis.Labels.Add(tuple[i].Item2);
            }

            var valueAxis = new LinearAxis { Position = AxisPosition.Bottom, MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0 };
            model.Series.Add(s1);
            model.Series.Add(s2);
            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);
            return model;
        }

        private PlotModel ModelFive()
        {

            var tuple = new List<(int, string, int, double)> { };

            for (int i = 0; i < _list.Count; i++)
            {
                if (tuple.Any(x => x.Item1 == _list[i].RequestHistory.User.Id) == false)
                {
                    tuple.Add((_list[i].RequestHistory.User.Id, _list[i].RequestHistory.User.ToString(), Convert.ToInt32(_list[i].Kms), (_list[i].RequestHistory.EndDate - _list[i].RequestHistory.StartDate).TotalHours));
                }
                else
                {
                    var a = tuple.FindIndex(x => x.Item1 == _list[i].RequestHistory.User.Id);
                    tuple[a] = (tuple[a].Item1, tuple[a].Item2, tuple[a].Item3 + Convert.ToInt32(_list[i].Kms), tuple[a].Item4 + (_list[i].RequestHistory.EndDate - _list[i].RequestHistory.StartDate).TotalHours);
                }
            }

            var model = new PlotModel
            {
                Title = "Todos os Owners",
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };

            var s1 = new BarSeries { Title = "Kms", StrokeColor = OxyColors.Black, StrokeThickness = 1, FillColor = OxyColors.Red };
            for (int i = 0; i < tuple.Count; i++)
            {
                s1.Items.Add(new BarItem { Value = tuple[i].Item3 });
            }

            var s2 = new BarSeries { Title = "Nº de Horas", StrokeColor = OxyColors.Black, StrokeThickness = 1, FillColor = OxyColors.Gray };
            for (int i = 0; i < tuple.Count; i++)
            {
                s2.Items.Add(new BarItem { Value = tuple[i].Item4 });
            }

            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
            categoryAxis.Zoom(-1, 5);
            for (int i = 0; i < tuple.Count; i++)
            {
                categoryAxis.Labels.Add(tuple[i].Item2);
            }

            var valueAxis = new LinearAxis { Position = AxisPosition.Bottom, MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0 };
            model.Series.Add(s1);
            model.Series.Add(s2);
            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);
            return model;
        }

        private void LoadView()
        {
            MainView = new ActivityReportSelectedView(this);
            SetContentView(MainView);

            Toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(Toolbar);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar?.SetHomeButtonEnabled(true);
            Toolbar.NavigationClick += (o, a) => { OnBackPressed(); };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.report_menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_export:
                    SaveData();
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void SaveData()
        {
            if (_typeconsult == 0)
            {
                LoadPdfOne();
            }else if (_typeconsult == 1)
            {
                LoadPdfTwo(0);
            }else if (_typeconsult == 2)
            {
                LoadPdfThree(0);
            }
            else if (_typeconsult == 3)
            {
                LoadPdfThree(1);
            }
            else if (_typeconsult == 4)
            {
                LoadPdfTwo(1);
            }

        }

        private void LoadPdfOne()
        {

            string documentsPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var filename = "report - " + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            string path = Path.Combine(documentsPath, filename + ".pdf");

            Drawable d = GetDrawable(Resource.Drawable.logoparapdf); // the drawable (Captain Obvious, to the rescue!!!)
            var bitmap = ((BitmapDrawable)d).Bitmap;
            MemoryStream stream = new MemoryStream();
            bitmap.Compress(Android.Graphics.Bitmap.CompressFormat.Png, 100, stream);
            byte[] bitmapdata = stream.ToArray();
            var fs = new FileStream(path, FileMode.Create);
            var dbFolder = new Java.IO.File(documentsPath);
            Document document = new Document(iTextSharp.text.PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            document.Open();

            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(bitmapdata);

            //TOPBAR
            ColumnText ct2 = new ColumnText(writer.DirectContent);
            ct2.SetSimpleColumn(1300, 800, 30, 50);
            ct2.AddElement(new Paragraph("Veículo\n" + AllYouCanGet.ReportProcess.selectedtarget.RequestHistory.Vehicle.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.GRAY)));
            ct2.Go();

            ColumnText ct3 = new ColumnText(writer.DirectContent);
            ct3.SetSimpleColumn(1300, 800, 230, 50);
            ct3.AddElement(new Paragraph("Owner\n" + AllYouCanGet.ReportProcess.selectedtarget.RequestHistory.User.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.GRAY)));
            ct3.Go();

            var sd = AllYouCanGet.ReportProcess.StartDateTime;
            var ed = AllYouCanGet.ReportProcess.EndDateTime;
            var sds = "";
            var eds = "";
            if (sd == DateTime.MinValue)
            {
                sds = "Sem inicio";
            }
            else
            {
                sds = sd.ToShortDateString();
            }
            if (ed == DateTime.MaxValue)
            {
                eds = "Sem fim";
            }
            else
            {
                eds = ed.ToShortDateString();
            }

            ColumnText ct4 = new ColumnText(writer.DirectContent);
            ct4.SetSimpleColumn(1300, 800, 460, 50);
            ct4.AddElement(new Paragraph("Período\n" + sds + "\na\n" + eds, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.GRAY)));
            ct4.Go();

            ColumnText ct = new ColumnText(writer.DirectContent);
            ct.SetSimpleColumn(1300, 730, 230, 50);
            ct.AddElement(new Paragraph("Gestão de Frotas", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.RED)));
            ct.Go();
            //TOPBAR

            PdfPTable table = new PdfPTable(3);
            table.TotalWidth = 455f;
            table.HorizontalAlignment = 1;

            PdfPCell cell = new PdfPCell(new Phrase("Owner/Veículo", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 10f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK)));
            cell.Colspan = 3;
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            PdfPCell cell2 = new PdfPCell(new Phrase("Período", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.RED)));
            cell2.HorizontalAlignment = 1;

            PdfPCell cell3 = new PdfPCell(new Phrase("Kms", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.RED)));
            cell3.HorizontalAlignment = 1;

            PdfPCell cell4 = new PdfPCell(new Phrase("Nº Horas", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.RED)));
            cell4.HorizontalAlignment = 1;

            table.AddCell(cell2);
            table.AddCell(cell3);
            table.AddCell(cell4);

            //table.AddCell("Col 1 Row 2");
            //table.AddCell("Col 2 Row 2");
            //table.AddCell("Col 3 Row 2");

            //table.AddCell("Col 1 Row 3");
            //table.AddCell("Col 2 Row 3");
            //table.AddCell("Col 3 Row 3");

            var totalKM = 0;
            var totalHOUR = 0;

            if (_list.Count < 30)
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    var km = Convert.ToInt32(_list[i].Kms);
                    var hour = Convert.ToInt32((_list[i].RequestHistory.EndDate - _list[i].RequestHistory.StartDate).TotalHours);

                    table.AddCell(_list[i].RequestHistory.StartDate.ToShortDateString() + " a " + _list[i].RequestHistory.EndDate.ToShortDateString());
                    table.AddCell(km.ToString());
                    table.AddCell(hour.ToString());
                    totalKM = totalKM + km;
                    totalHOUR = totalHOUR + hour;
                }
            }
            else
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    var km = Convert.ToInt32(_list[i].Kms);
                    var hour = Convert.ToInt32((_list[i].RequestHistory.EndDate - _list[i].RequestHistory.StartDate).TotalHours);
                    totalKM = totalKM + km;
                    totalHOUR = totalHOUR + hour;
                }
                for (int i = 0; i < 30; i++)
                {
                    var km = Convert.ToInt32(_list[i].Kms);
                    var hour = Convert.ToInt32((_list[i].RequestHistory.EndDate - _list[i].RequestHistory.StartDate).TotalHours);

                    table.AddCell(_list[i].RequestHistory.StartDate.ToShortDateString() + " a " + _list[i].RequestHistory.EndDate.ToShortDateString());
                    table.AddCell(km.ToString());
                    table.AddCell(hour.ToString());
                }
                table.AddCell("...");
                table.AddCell("...");
                table.AddCell("...");
            }

            PdfPCell cell5 = new PdfPCell(new Phrase(totalKM.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.RED)));
            cell5.HorizontalAlignment = 1;
            PdfPCell cell6 = new PdfPCell(new Phrase(totalHOUR.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.RED)));
            cell6.HorizontalAlignment = 1;
            table.AddCell("");
            table.AddCell(cell5);
            table.AddCell(cell6);

            image.SetAbsolutePosition(230, 30);
            image.ScaleToFit(100, 100);

            document.Add(image);

            PdfContentByte cb = writer.DirectContent;
            table.WriteSelectedRows(0, -1, 50, 670, cb);

            // Close the document
            //document.Add(table);
            document.Close();
            // Close the writer instance

            writer.Close();
            // Always close open file handles explicitly
            fs.Close();

            OpenFile(path, filename);

        }

        private void LoadPdfTwo(int tipo)
        {

            var _phrase = "";
            if (tipo == 0)
            {
                _phrase = "Owners do Veículo";
            }
            else if (tipo == 1)
            {
                _phrase = "Todos os Owners";
            }

            string documentsPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var filename = "report - " + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            string path = Path.Combine(documentsPath, filename + ".pdf");

            Drawable d = GetDrawable(Resource.Drawable.logoparapdf); // the drawable (Captain Obvious, to the rescue!!!)
            var bitmap = ((BitmapDrawable)d).Bitmap;
            MemoryStream stream = new MemoryStream();
            bitmap.Compress(Android.Graphics.Bitmap.CompressFormat.Png, 100, stream);
            byte[] bitmapdata = stream.ToArray();
            var fs = new FileStream(path, FileMode.Create);
            var dbFolder = new Java.IO.File(documentsPath);
            Document document = new Document(iTextSharp.text.PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            document.Open();

            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(bitmapdata);

            //TOPBAR

            var sd = AllYouCanGet.ReportProcess.StartDateTime;
            var ed = AllYouCanGet.ReportProcess.EndDateTime;
            var sds = "";
            var eds = "";
            if (sd == DateTime.MinValue)
            {
                sds = "Sem inicio";
            }
            else
            {
                sds = sd.ToShortDateString();
            }
            if (ed == DateTime.MaxValue)
            {
                eds = "Sem fim";
            }
            else
            {
                eds = ed.ToShortDateString();
            }

            if (tipo == 0)
            {
                ColumnText ct2 = new ColumnText(writer.DirectContent);
                ct2.SetSimpleColumn(1300, 800, 30, 50);
                ct2.AddElement(new Paragraph("Veículo\n" + AllYouCanGet.ReportProcess.selectedtarget.RequestHistory.Vehicle.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.GRAY)));
                ct2.Go();

                ColumnText ct3 = new ColumnText(writer.DirectContent);
                ct3.SetSimpleColumn(1300, 800, 230, 50);
                ct3.AddElement(new Paragraph("Período\n" + sds + " a " + eds, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.GRAY)));
                ct3.Go();
            }
            else if (tipo == 1)
            {
                ColumnText ct2 = new ColumnText(writer.DirectContent);
                ct2.SetSimpleColumn(1300, 800, 30, 50);
                ct2.AddElement(new Paragraph("Período\n" + sds + " a " + eds, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.GRAY)));
                ct2.Go();
            }

            ColumnText ct = new ColumnText(writer.DirectContent);
            ct.SetSimpleColumn(1300, 730, 230, 50);
            ct.AddElement(new Paragraph("Gestão de Frotas", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.RED)));
            ct.Go();
            //TOPBAR

            PdfPTable table = new PdfPTable(3);
            table.TotalWidth = 455f;
            table.HorizontalAlignment = 1;

            PdfPCell cell = new PdfPCell(new Phrase(_phrase, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 10f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK)));
            cell.Colspan = 3;
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            PdfPCell cell2 = new PdfPCell(new Phrase("Owner", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.RED)));
            cell2.HorizontalAlignment = 1;

            PdfPCell cell3 = new PdfPCell(new Phrase("Kms", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.RED)));
            cell3.HorizontalAlignment = 1;

            PdfPCell cell4 = new PdfPCell(new Phrase("Nº Horas", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.RED)));
            cell4.HorizontalAlignment = 1;

            table.AddCell(cell2);
            table.AddCell(cell3);
            table.AddCell(cell4);

            //table.AddCell("Col 1 Row 2");
            //table.AddCell("Col 2 Row 2");
            //table.AddCell("Col 3 Row 2");

            //table.AddCell("Col 1 Row 3");
            //table.AddCell("Col 2 Row 3");
            //table.AddCell("Col 3 Row 3");

            var tuple = new List<(int, string, int, double)> { };

            for (int i = 0; i < _list.Count; i++)
            {
                if (tuple.Any(x => x.Item1 == _list[i].RequestHistory.User.Id) == false)
                {
                    tuple.Add((_list[i].RequestHistory.User.Id, _list[i].RequestHistory.User.ToString(), Convert.ToInt32(_list[i].Kms), (_list[i].RequestHistory.EndDate - _list[i].RequestHistory.StartDate).TotalHours));
                }
                else
                {
                    var a = tuple.FindIndex(x => x.Item1 == _list[i].RequestHistory.User.Id);
                    tuple[a] = (tuple[a].Item1, tuple[a].Item2, tuple[a].Item3 + Convert.ToInt32(_list[i].Kms), tuple[a].Item4 + (_list[i].RequestHistory.EndDate - _list[i].RequestHistory.StartDate).TotalHours);
                }
            }

            var totalKM = 0;
            var totalHOUR = 0;

            if (tuple.Count < 30)
            {
                for (int i = 0; i < tuple.Count; i++)
                {
                    var km = Convert.ToInt32(tuple[i].Item3);
                    var hour = Convert.ToInt32(tuple[i].Item4);

                    table.AddCell(tuple[i].Item2);
                    table.AddCell(km.ToString());
                    table.AddCell(hour.ToString());
                    totalKM = totalKM + km;
                    totalHOUR = totalHOUR + hour;
                }
            }
            else
            {
                for (int i = 0; i < tuple.Count; i++)
                {
                    var km = Convert.ToInt32(tuple[i].Item3);
                    var hour = Convert.ToInt32(tuple[i].Item4);
                    totalKM = totalKM + km;
                    totalHOUR = totalHOUR + hour;
                }
                for (int i = 0; i < 30; i++)
                {
                    var km = Convert.ToInt32(tuple[i].Item3);
                    var hour = Convert.ToInt32(tuple[i].Item4);

                    table.AddCell(tuple[i].Item2);
                    table.AddCell(km.ToString());
                    table.AddCell(hour.ToString());
                }
                table.AddCell("...");
                table.AddCell("...");
                table.AddCell("...");
            }

            PdfPCell cell5 = new PdfPCell(new Phrase(totalKM.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.RED)));
            cell5.HorizontalAlignment = 1;
            PdfPCell cell6 = new PdfPCell(new Phrase(totalHOUR.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.RED)));
            cell6.HorizontalAlignment = 1;
            table.AddCell("");
            table.AddCell(cell5);
            table.AddCell(cell6);

            image.SetAbsolutePosition(230, 30);
            image.ScaleToFit(100, 100);

            document.Add(image);

            PdfContentByte cb = writer.DirectContent;
            table.WriteSelectedRows(0, -1, 50, 670, cb);

            // Close the document
            //document.Add(table);
            document.Close();
            // Close the writer instance

            writer.Close();
            // Always close open file handles explicitly
            fs.Close();

            OpenFile(path, filename);

        }

        private void LoadPdfThree(int tipo)
        {

            var _phrase = "";
            if (tipo == 0)
            {
                _phrase = "Veículos do Owner";
            }
            else if (tipo == 1)
            {
                _phrase = "Todos os Owners";
            }

            string documentsPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var filename = "report - " + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            string path = Path.Combine(documentsPath, filename + ".pdf");

            Drawable d = GetDrawable(Resource.Drawable.logoparapdf); // the drawable (Captain Obvious, to the rescue!!!)
            var bitmap = ((BitmapDrawable)d).Bitmap;
            MemoryStream stream = new MemoryStream();
            bitmap.Compress(Android.Graphics.Bitmap.CompressFormat.Png, 100, stream);
            byte[] bitmapdata = stream.ToArray();
            var fs = new FileStream(path, FileMode.Create);
            var dbFolder = new Java.IO.File(documentsPath);
            Document document = new Document(iTextSharp.text.PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            document.Open();

            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(bitmapdata);

            //TOPBAR

            var sd = AllYouCanGet.ReportProcess.StartDateTime;
            var ed = AllYouCanGet.ReportProcess.EndDateTime;
            var sds = "";
            var eds = "";
            if (sd == DateTime.MinValue)
            {
                sds = "Sem inicio";
            }
            else
            {
                sds = sd.ToShortDateString();
            }
            if (ed == DateTime.MaxValue)
            {
                eds = "Sem fim";
            }
            else
            {
                eds = ed.ToShortDateString();
            }

            if (tipo == 0)
            {
                ColumnText ct2 = new ColumnText(writer.DirectContent);
                ct2.SetSimpleColumn(1300, 800, 30, 50);
                ct2.AddElement(new Paragraph("Owner\n" + AllYouCanGet.ReportProcess.selectedtarget.RequestHistory.User.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.GRAY)));
                ct2.Go();

                ColumnText ct3 = new ColumnText(writer.DirectContent);
                ct3.SetSimpleColumn(1300, 800, 230, 50);
                ct3.AddElement(new Paragraph("Período\n" + sds + " a " + eds, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.GRAY)));
                ct3.Go();
            }
            else if (tipo == 1)
            {
                ColumnText ct2 = new ColumnText(writer.DirectContent);
                ct2.SetSimpleColumn(1300, 800, 30, 50);
                ct2.AddElement(new Paragraph("Período\n" + sds + " a " + eds, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.GRAY)));
                ct2.Go();
            }

            ColumnText ct = new ColumnText(writer.DirectContent);
            ct.SetSimpleColumn(1300, 730, 230, 50);
            ct.AddElement(new Paragraph("Gestão de Frotas", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.RED)));
            ct.Go();
            //TOPBAR

            PdfPTable table = new PdfPTable(3);
            table.TotalWidth = 455f;
            table.HorizontalAlignment = 1;

            PdfPCell cell = new PdfPCell(new Phrase(_phrase, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 10f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK)));
            cell.Colspan = 3;
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            PdfPCell cell2 = new PdfPCell(new Phrase("Veículo", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.RED)));
            cell2.HorizontalAlignment = 1;

            PdfPCell cell3 = new PdfPCell(new Phrase("Kms", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.RED)));
            cell3.HorizontalAlignment = 1;

            PdfPCell cell4 = new PdfPCell(new Phrase("Nº Horas", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.RED)));
            cell4.HorizontalAlignment = 1;

            table.AddCell(cell2);
            table.AddCell(cell3);
            table.AddCell(cell4);

            //table.AddCell("Col 1 Row 2");
            //table.AddCell("Col 2 Row 2");
            //table.AddCell("Col 3 Row 2");

            //table.AddCell("Col 1 Row 3");
            //table.AddCell("Col 2 Row 3");
            //table.AddCell("Col 3 Row 3");

            var tuple = new List<(int, string, int, double)> { };

            for (int i = 0; i < _list.Count; i++)
            {
                if (tuple.Any(x => x.Item1 == _list[i].RequestHistory.Vehicle.Id) == false)
                {
                    tuple.Add((_list[i].RequestHistory.Vehicle.Id, _list[i].RequestHistory.Vehicle.ToString(), Convert.ToInt32(_list[i].Kms), (_list[i].RequestHistory.EndDate - _list[i].RequestHistory.StartDate).TotalHours));
                }
                else
                {
                    var a = tuple.FindIndex(x => x.Item1 == _list[i].RequestHistory.Vehicle.Id);
                    tuple[a] = (tuple[a].Item1, tuple[a].Item2, tuple[a].Item3 + Convert.ToInt32(_list[i].Kms), tuple[a].Item4 + (_list[i].RequestHistory.EndDate - _list[i].RequestHistory.StartDate).TotalHours);
                }
            }

            var totalKM = 0;
            var totalHOUR = 0;

            if (tuple.Count < 30)
            {
                for (int i = 0; i < tuple.Count; i++)
                {
                    var km = Convert.ToInt32(tuple[i].Item3);
                    var hour = Convert.ToInt32(tuple[i].Item4);

                    table.AddCell(tuple[i].Item2);
                    table.AddCell(km.ToString());
                    table.AddCell(hour.ToString());
                    totalKM = totalKM + km;
                    totalHOUR = totalHOUR + hour;
                }
            }
            else
            {
                for (int i = 0; i < tuple.Count; i++)
                {
                    var km = Convert.ToInt32(tuple[i].Item3);
                    var hour = Convert.ToInt32(tuple[i].Item4);
                    totalKM = totalKM + km;
                    totalHOUR = totalHOUR + hour;
                }
                for (int i = 0; i < 30; i++)
                {
                    var km = Convert.ToInt32(tuple[i].Item3);
                    var hour = Convert.ToInt32(tuple[i].Item4);

                    table.AddCell(tuple[i].Item2);
                    table.AddCell(km.ToString());
                    table.AddCell(hour.ToString());
                }
                table.AddCell("...");
                table.AddCell("...");
                table.AddCell("...");
            }

            PdfPCell cell5 = new PdfPCell(new Phrase(totalKM.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.RED)));
            cell5.HorizontalAlignment = 1;
            PdfPCell cell6 = new PdfPCell(new Phrase(totalHOUR.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 8f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.RED)));
            cell6.HorizontalAlignment = 1;
            table.AddCell("");
            table.AddCell(cell5);
            table.AddCell(cell6);

            image.SetAbsolutePosition(230, 30);
            image.ScaleToFit(100, 100);

            document.Add(image);

            PdfContentByte cb = writer.DirectContent;
            table.WriteSelectedRows(0, -1, 50, 670, cb);

            // Close the document
            //document.Add(table);
            document.Close();
            // Close the writer instance

            writer.Close();
            // Always close open file handles explicitly
            fs.Close();

            OpenFile(path, filename);

        }

        public void OpenFile(string filePath, string filename)
        {

            var bytes = System.IO.File.ReadAllBytes(filePath);

            //Copy the private file's data to the EXTERNAL PUBLIC location
            string externalStorageState = global::Android.OS.Environment.ExternalStorageState;
            string application = "";

            string extension = System.IO.Path.GetExtension(filePath);

            switch (extension.ToLower())
            {
                case ".doc":
                case ".docx":
                    application = "application/msword";
                    break;
                case ".pdf":
                    application = "application/pdf";
                    break;
                case ".xls":
                case ".xlsx":
                    application = "application/vnd.ms-excel";
                    break;
                case ".jpg":
                case ".jpeg":
                case ".png":
                    application = "image/jpeg";
                    break;
                default:
                    application = "*/*";
                    break;
            }
            var externalPath = global::Android.OS.Environment.ExternalStorageDirectory.Path + "/" + filename + extension;
            System.IO.File.WriteAllBytes(externalPath, bytes);

            Java.IO.File file = new Java.IO.File(externalPath);
            file.SetReadable(true);
            //Android.Net.Uri uri = Android.Net.Uri.Parse("file://" + filePath);
            Android.Net.Uri uri = Android.Net.Uri.FromFile(file);

            StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder();
            StrictMode.SetVmPolicy(builder.Build());

            Intent intent = new Intent(Intent.ActionView);
            intent.SetDataAndType(uri, application);
            intent.SetFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask | ActivityFlags.GrantReadUriPermission);

            try
            {
                StartActivity(intent);
            }
            catch (Exception)
            {
                Toast.MakeText(this, "Sem aplicação para abrir o PDF!", ToastLength.Short).Show();
            }
        }

    }
}