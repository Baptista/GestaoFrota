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
using Android_Gestao_Frotas.CustomControls;
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Models;

namespace Android_Gestao_Frotas.Adapters
{

    public delegate void OnUpdateBrand(Brand brand);
    public delegate void OnUpdateBrandState(Brand brand);

    class FragmentBrandsAdapter : BaseAdapter
    {

        public event OnUpdateBrand OnUpdateBrand;
        public event OnUpdateBrandState OnUpdateBrandState;

        private Context _context;

        private List<Brand> _brands;

        public FragmentBrandsAdapter(Context context, IEnumerable<Brand> brands)
        {
            _context = context;
            _brands = brands.ToList();
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return _brands[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            BrandsAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as BrandsAdapterViewHolder;

            if (holder == null)
            {
                holder = new BrandsAdapterViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.item_fragment_vehicles_brand, parent, false);
                holder.ibtnOptions = view.FindViewById<ImageButton>(Resource.Id.imgbtnOptions);
                holder.tvState = view.FindViewById<ActiveTextView>(Resource.Id.tvState);
                holder.tvBrand = view.FindViewById<TextView>(Resource.Id.tvBrand);

                holder.Position = position;

                if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ManageBrands))
                {
                    if (!holder.HasOptionMenu)
                    {
                        holder.ibtnOptions.Click += delegate { OnOptionsClick(holder); };
                        holder.HasOptionMenu = true;
                    }
                }
                else
                {
                    holder.ibtnOptions.Visibility = ViewStates.Gone;
                }

                view.Tag = holder;
            }

            holder.Position = position;

            holder.tvBrand.Text = $"Marca: {_brands[position].Description}";
            holder.tvState.Text = $"Estado: " + (_brands[position].Active ? $"Ativo" : $"Inativo");
            holder.tvState.IsActive = _brands[position].Active;

            return view;
        }

        public override int Count
        {
            get { return _brands.Count; }
        }

        private void OnOptionsClick(BrandsAdapterViewHolder holder)
        {
            var popupMenu = new PopupMenu(_context, holder.ibtnOptions, GravityFlags.AxisClip);
            popupMenu.MenuInflater.Inflate(Resource.Menu.options_menu, popupMenu.Menu);
            popupMenu.MenuItemClick += async (sender, args) =>
            {
                switch (args.Item.ItemId)
                {
                    case Resource.Id.nav_change:
                        var userInput = await new DialogHelper(_context).UserInput("Altere o nome da marca a baixo e para guardar clique 'Ok'.", _brands[holder.Position].Description, "Marca...");
                        if (!string.IsNullOrEmpty(userInput))
                        {
                            var brandForEdit = _brands[holder.Position];
                            brandForEdit.Description = userInput;
                            OnUpdateBrand?.Invoke(brandForEdit);
                        }
                        else if (userInput != null)
                        {
                            await new DialogHelper(_context).Message("Nome de marca inválido, tente outro.");
                        }
                        break;
                    case Resource.Id.nav_active:
                        var brandForStateChange = _brands[holder.Position];
                        OnUpdateBrandState?.Invoke(brandForStateChange);
                        break;
                }
            };
            popupMenu.Show();
        }
    }

    class BrandsAdapterViewHolder : Java.Lang.Object
    {
        public BrandsAdapterViewHolder()
        {
            HasOptionMenu = false;
        }

        public TextView tvBrand { get; set; }

        public ActiveTextView tvState { get; set; }

        public ImageButton ibtnOptions { get; set; }

        public bool HasOptionMenu { get; set; }

        public int Position { get; set; }
    }

}