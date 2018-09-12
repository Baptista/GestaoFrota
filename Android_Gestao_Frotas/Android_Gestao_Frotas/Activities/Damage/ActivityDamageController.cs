using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Damage;
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Business.Requests;
using Java.IO;
using Newtonsoft.Json;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Android_Gestao_Frotas.Activities.Damage
{
    [Activity(Label = "Disponibilizar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivityDamageController : ActivityBaseController
    {

        RequestHistory requesthistoryget;
        private List<DamageVehicle> _damagevehicles = new List<DamageVehicle>();
        private List<DamageVehicleDocument> _damagevehiclesDocuments = new List<DamageVehicleDocument>();
        private List<Byte[]> picdata = new List<byte[]>();

        IBusinessDamage _businessDamage = new BusinessDamage();

        ActivityDamageView MainView;
        V7Toolbar Toolbar;

        int globalposition = 0;
        string kmtotal = "";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            LoadView();
        }

        private void LoadView()
        {
            MainView = new ActivityDamageView(this);
            SetContentView(MainView);


            Toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(Toolbar);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar?.SetHomeButtonEnabled(true);
            Toolbar.NavigationClick += (o, a) => { OnBackPressed(); };

            //requesthistoryget = JsonConvert.DeserializeObject<RequestHistory>(Intent.GetStringExtra("request"));
            requesthistoryget = AllYouCanGet.CurrentRequest;

            MainView.OnAddDamageClickEvent -= MainView_OnAddDamageClickEvent;
            MainView.OnAddDamageClickEvent += MainView_OnAddDamageClickEvent;

            MainView.OnRemoveDamageClickController -= MainView_OnRemoveDamageClickController;
            MainView.OnRemoveDamageClickController += MainView_OnRemoveDamageClickController;

            MainView.OnUpdateDescriptionController -= MainView_OnUpdateDescriptionController;
            MainView.OnUpdateDescriptionController += MainView_OnUpdateDescriptionController;

            MainView.OnPhotoClickController -= MainView_OnPhotoClickController;
            MainView.OnPhotoClickController += MainView_OnPhotoClickController;

            MainView.OnFolderClickController -= MainView_OnFolderClickController;
            MainView.OnFolderClickController += MainView_OnFolderClickController;

            MainView.OnTextKmsChange -= MainView_OnTextKmsChange;
            MainView.OnTextKmsChange += MainView_OnTextKmsChange;

        }

        private void MainView_OnTextKmsChange(string kms)
        {
            kmtotal = kms;
        }

        private void MainView_OnFolderClickController(int position)
        {
            globalposition = position;
            var imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(imageIntent, "Select photo"), GetFolderRequestCode);
        }

        private void MainView_OnPhotoClickController(int position)
        {
            globalposition = position;
            //var intent = new Intent(MediaStore.ActionImageCapture);
            //var file = new Java.IO.File(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, string.Format("myPhoto_{0}.png", position));
            //intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(file));
            //StartActivityForResult(intent, GetPhotoRequestCode);


            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, GetPhotoRequestCode);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == GetPhotoRequestCode)
            {
                if (resultCode == Result.Ok)
                {
                    Bitmap bitmap = (Bitmap)data.Extras.Get("data");
                    bitmap = ResizeBitmap(bitmap);

                    MemoryStream memStream = new MemoryStream();
                    var success = bitmap.Compress(Bitmap.CompressFormat.Png, 10, memStream);
                    picdata[globalposition] = memStream.ToArray();

                    _damagevehiclesDocuments[globalposition].Document = picdata[globalposition]; //ImageToBase64(bitmap);
                    _damagevehiclesDocuments[globalposition].DocumentFormat = ".png"; //ImageToBase64(bitmap);
                    _damagevehiclesDocuments[globalposition].DocumentName = "crazy_stuff";
                    //_damagevehiclesDocuments[globalposition].Document = ImageToBase64(ResizeBitmap(bitmap));
                    //_damagevehiclesDocuments[globalposition].Document = Lel(ResizeBitmap(bitmap)).ToString();
                    MainView.UpdateDamage(_damagevehicles, _damagevehiclesDocuments);
                }
            }
            else if (requestCode == GetFolderRequestCode)
            {
                if (resultCode == Result.Ok)
                {
                    Bitmap bitmap = NGetBitmap(data.Data);

                    MemoryStream memStream = new MemoryStream();
                    bitmap.Compress(Bitmap.CompressFormat.Webp, 100, memStream);
                    picdata[globalposition] = memStream.ToArray();

                    //_damagevehiclesDocuments[globalposition].Document = ImageToBase64(bitmap);
                    //_damagevehiclesDocuments[globalposition].Document = ImageToBase64(ResizeBitmap(bitmap));
                    //_damagevehiclesDocuments[globalposition].Document = Lel(ResizeBitmap(bitmap)).ToString();
                    MainView.UpdateDamage(_damagevehicles, _damagevehiclesDocuments);
                }
            }
        }

        private Bitmap NGetBitmap(Android.Net.Uri uriImage)
        {
            Bitmap mBitmap = null;
            mBitmap = MediaStore.Images.Media.GetBitmap(this.ContentResolver, uriImage);
            return mBitmap;
        }

        private void MainView_OnUpdateDescriptionController(List<DamageVehicle> DamageVehicles)
        {
            _damagevehicles = DamageVehicles;
        }

        private void MainView_OnRemoveDamageClickController(int position)
        {
            _damagevehicles.RemoveAt(position);
            _damagevehiclesDocuments.RemoveAt(position);
            picdata.RemoveAt(position);
            MainView.UpdateDamage(_damagevehicles,_damagevehiclesDocuments);
        }

        private void MainView_OnAddDamageClickEvent()
        {
            _damagevehicles.Add(new DamageVehicle
            {
                Id = _damagevehicles.Count + 1,
                Description = "",
                Active = true,
                Date = DateTime.Now,
                IsIncomplete = false,
                RequestHistory = requesthistoryget,
                Vehicle = requesthistoryget.Vehicle
            });
            _damagevehiclesDocuments.Add(new DamageVehicleDocument
            {
                Id = _damagevehiclesDocuments.Count + 1,
                Active = true,
                Date = DateTime.Now,
                DamageVehicle = _damagevehicles[_damagevehicles.Count  - 1],
                //Document = 1,
                IsIncomplete = true
            });
            picdata.Add(new byte[0]);
            MainView.UpdateDamage(_damagevehicles, _damagevehiclesDocuments);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.userinfo_options_menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_finish:
                    if(kmtotal != "")
                    {
                        DisponibilizarVeiculo();
                    }
                    else
                    {
                        Toast.MakeText(this, "Preencha os Quilômetros!", ToastLength.Short).Show();
                    }
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }

        private async void DisponibilizarVeiculo()
        {
            SetLoadingView(true);
            var result = await _businessDamage.TerminaPedido(requesthistoryget);
            var vehiclehistoryadd = new VehicleHistory
            {
                Date = DateTime.Now,
                Kms = Convert.ToDecimal(kmtotal),
                Id = -1,
                IsIncomplete = false,
                RequestHistory = requesthistoryget
            };
            var result2 = await _businessDamage.AddVeiculoHistorico(vehiclehistoryadd);

            if(_damagevehicles.Count > 0)
            {
                for (int i = 0; i <= _damagevehicles.Count - 1; i++)
                {
                    var damagevehicleadd = new DamageVehicle
                    {
                        Id = -1,
                        Active = true,
                        Date = DateTime.Now,
                        Description = _damagevehicles[i].Description,
                        IsIncomplete = false,
                        RequestHistory = requesthistoryget,
                        Vehicle = requesthistoryget.Vehicle
                    };
                    var result3 = await _businessDamage.AddDano(damagevehicleadd);

                    var damagevehicledocumentadd = new DamageVehicleDocument
                    {
                        Active = true,
                        Date = DateTime.Now,
                        Document = _damagevehiclesDocuments[i].Document,//Convert.ToBase64String(picdata[i]),
                        DocumentName = _damagevehiclesDocuments[i].DocumentName, //requesthistoryget.Vehicle.LicensePlate + " - Foto " + _damagevehiclesDocuments[i].Id,
                        DocumentFormat = _damagevehiclesDocuments[i].DocumentFormat,
                        DamageVehicle = new DamageVehicle
                        {
                            IsIncomplete = true,
                            Id = result3,
                            RequestHistory = requesthistoryget,
                            Vehicle = requesthistoryget.Vehicle,
                            Date = DateTime.Now,
                            Active = true
                        }
                    };
                    var result4 = await _businessDamage.AddDanoComprovativo(damagevehicledocumentadd);
                }
            }

            SetLoadingView(false);
            SetResult(Result.Ok);
            Finish();
        }

        public string ImageToBase64(Bitmap image)
        {
            using (var stream = new MemoryStream())
            {
                image.Compress(Bitmap.CompressFormat.Png, 100, stream);

                var bytes = stream.ToArray();
                var str = Convert.ToBase64String(bytes);

                return str;
            }
        }

        private Bitmap ResizeBitmap(Bitmap originalImage)
        {
            var desiredWidth = 20;
            var scale = (float) desiredWidth / (float)originalImage.Width;

            var newWidth = (int) (originalImage.Width * scale);
            var newHeight = (int) (originalImage.Height * scale);

            var smallerBitmap = Bitmap.CreateScaledBitmap(originalImage, newWidth, newHeight, false);

            return smallerBitmap;
        }

        

    }
}