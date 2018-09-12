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
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Models;

namespace Android_Gestao_Frotas.Adapters
{
    public delegate void OnUpdateModelState(Model model);

    public delegate void OnUpdateModel(Model model);

    public class FragmentModelsAdapter : BaseAdapter
    {
        public event OnUpdateModel OnUpdateModel;

        public event OnUpdateModelState OnUpdateModelState;

        private Context _context;
        private List<Model> _models;

        public FragmentModelsAdapter(Context context, IEnumerable<Model> models)
        {
            _context = context;
            _models = models.ToList();
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return _models[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            ModelsAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as ModelsAdapterViewHolder;

            if (holder == null)
            {
                holder = new ModelsAdapterViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.item_fragment_vehicles_model, parent, false);
                holder.tvModelo = view.FindViewById<TextView>(Resource.Id.tvModelo);
                holder.tvCombustivel = view.FindViewById<TextView>(Resource.Id.tvCombustivel);
                view.Tag = holder;
                holder.ibtnOptions = view.FindViewById<ImageButton>(Resource.Id.imgbtnOptions);
                holder.tvState = view.FindViewById<ActiveTextView>(Resource.Id.tvState);

                if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ManageModels))
                {
                if (!holder.HasOptionMenu)
                {
                    holder.ibtnOptions.Click += delegate
                    {
                        var popupMenu = new PopupMenu(_context, holder.ibtnOptions, GravityFlags.AxisClip);
                        popupMenu.MenuInflater.Inflate(Resource.Menu.options_menu, popupMenu.Menu);
                        popupMenu.MenuItemClick += (sender, args) =>
                        {
                            switch (args.Item.ItemId)
                            {
                                case Resource.Id.nav_change:
                                    OnUpdateModel?.Invoke(_models[holder.Position]);
                                    break;
                                case Resource.Id.nav_active:
                                    OnUpdateModelState?.Invoke(_models[holder.Position]);
                                    break;
                            }
                        };
                        popupMenu.Show();
                    };
                    holder.HasOptionMenu = true;
                }
                }
                else
                {
                    holder.ibtnOptions.Visibility = ViewStates.Gone;
                }

                view.Tag = holder;

            }

            holder.tvModelo.Text = $"Modelo: {_models[position].Description} ({_models[position].Brand.Description})";
            holder.tvCombustivel.Text = $"Combustível: {_models[position].Fuel.Description}";
            holder.tvState.Text = $"Estado: " + (_models[position].Active ? $"Ativo" : $"Inativo");
            holder.tvState.IsActive = _models[position].Active;

            holder.Position = position;

            return view;
        }

        public override int Count
        {
            get { return _models.Count; }
        }

    }

    public class ModelsAdapterViewHolder : Java.Lang.Object
    {
        public ModelsAdapterViewHolder()
        {
            HasOptionMenu = false;
        }

        public TextView tvModelo { get; set; }

        public TextView tvCombustivel { get; set; }

        public ActiveTextView tvState { get; set; }

        public ImageButton ibtnOptions { get; set; }

        public bool HasOptionMenu { get; set; }

        public int Position { get; set; }
    }

}