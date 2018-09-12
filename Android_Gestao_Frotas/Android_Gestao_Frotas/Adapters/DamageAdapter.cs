using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Core_Gestao_Frotas.Business.Models;

namespace Android_Gestao_Frotas.Adapters
{

    public delegate void OnRemoveDamageClick(int position);
    public delegate void OnUpdateDescription(List<DamageVehicle> DamageVehicles);
    public delegate void OnPhotoClick(int position);
    public delegate void OnFolderClick(int position);

    class DamageAdapter : BaseAdapter
    {

        public event OnRemoveDamageClick OnRemoveDamageClick;
        public event OnUpdateDescription OnUpdateDescription;
        public event OnPhotoClick OnPhotoClick;
        public event OnFolderClick OnFolderClick;

        private Context _context;

        private List<DamageVehicle> _damagevehicles;
        private List<DamageVehicleDocument> _damagevehiclesDocuments;

        public DamageAdapter(Context context, IEnumerable<DamageVehicle> damagevehicles, IEnumerable<DamageVehicleDocument> damagevehiclesDocuments)
        {
            _context = context;
            _damagevehicles = damagevehicles.ToList();
            _damagevehiclesDocuments = damagevehiclesDocuments.ToList();
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return _damagevehicles[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            DamageAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as DamageAdapterViewHolder;

            if (holder == null)
            {
                holder = new DamageAdapterViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.item_damage, parent, false);
                holder.ivImage = view.FindViewById<ImageView>(Resource.Id.ivImage);
                holder.editText1 = view.FindViewById<EditText>(Resource.Id.editText1);
                holder.myButtonCamera = view.FindViewById<ImageButton>(Resource.Id.myButtonCamera);
                holder.myButtonFolder = view.FindViewById<ImageButton>(Resource.Id.myButtonFolder);
                holder.ButtonRemove = view.FindViewById<ImageButton>(Resource.Id.ButtonRemove);

                view.Tag = holder;

                if (!holder.HasDeleteButton)
                {

                    holder.ButtonRemove.Click += delegate
                    {
                        OnRemoveDamageClick?.Invoke(holder.Position);
                    };

                    holder.HasDeleteButton = true;
                }

                if (!holder.HasRefreshText)
                {

                    holder.editText1.TextChanged += delegate
                    {
                        _damagevehicles[holder.Position].Description = holder.editText1.Text;
                        OnUpdateDescription?.Invoke(_damagevehicles);
                    };

                    holder.HasRefreshText = true;
                }

                if (!holder.HasCameraMenu)
                {

                    holder.myButtonCamera.Click += delegate
                    {
                        OnPhotoClick?.Invoke(holder.Position);
                    };

                    holder.HasCameraMenu = true;
                }

                if (!holder.HasFolderMenu)
                {

                    holder.myButtonFolder.Click += delegate
                    {
                        OnFolderClick?.Invoke(holder.Position);
                    };

                    holder.HasFolderMenu = true;
                }

            }

            holder.Position = position;

            holder.editText1.Text = _damagevehicles[holder.Position].Description;

            if (_damagevehiclesDocuments[holder.Position].Document != null)
            {
                holder.ivImage.SetImageBitmap(StringToBitMap(_damagevehiclesDocuments[holder.Position].Document.ToString()));
            }

            return view;
        }

        public override int Count
        {
            get { return _damagevehicles.Count; }
        }

        public Bitmap StringToBitMap(String encodedString)
        {
            try
            {
                byte[] encodeByte = Base64.Decode(encodedString, Base64Flags.Default);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(encodeByte, 0, encodeByte.Length);
                return bitmap;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }

    class DamageAdapterViewHolder : Java.Lang.Object
    {

        public DamageAdapterViewHolder()
        {
            HasFolderMenu = false;
            HasCameraMenu = false;
            HasDeleteButton = false;
            HasRefreshText = false;
        }

        public ImageView ivImage { get; set; }

        public EditText editText1 { get; set; }

        public ImageButton myButtonFolder { get; set; }

        public ImageButton myButtonCamera { get; set; }

        public ImageButton ButtonRemove { get; set; }

        public bool HasFolderMenu { get; set; }
        public bool HasRefreshText { get; set; }
        public bool HasCameraMenu { get; set; }
        public bool HasDeleteButton { get; set; }

        public int Position { get; set; }

    }
}