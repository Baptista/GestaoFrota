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

    public delegate void OnUpdateTypology(Typology typology);

    public delegate void OnUpdateTypologyState(Typology typology);

    public class FragmentTypologiesAdapter : BaseAdapter
    {
        public event OnUpdateTypology OnUpdateTypology;

        public event OnUpdateTypologyState OnUpdateTypologyState;

        private Context _context;
        private List<Typology> _typologys;

        public FragmentTypologiesAdapter(Context context, IEnumerable<Typology> typologys)
        {
            _context = context;
            _typologys = typologys.ToList();
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return _typologys[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            TypologysAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as TypologysAdapterViewHolder;

            if (holder == null)
            {
                holder = new TypologysAdapterViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.item_fragment_vehicles_typology, parent, false);
                holder.tvTypology = view.FindViewById<TextView>(Resource.Id.tvTypology);
                holder.ibtnOptions = view.FindViewById<ImageButton>(Resource.Id.imgbtnOptions);
                holder.tvState = view.FindViewById<ActiveTextView>(Resource.Id.tvState);
                
                holder.Position = position;

                if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ManageTypologies))
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
                                        OnUpdateTypology?.Invoke(_typologys[holder.Position]);
                                        break;
                                    case Resource.Id.nav_active:
                                        OnUpdateTypologyState?.Invoke(_typologys[holder.Position]);
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

            holder.Position = position;

            holder.tvTypology.Text = $"Tipologia: {_typologys[position].Description}";
            holder.tvState.Text = $"Estado: " + (_typologys[position].Active ? $"Ativo" : $"Inativo");
            holder.tvState.IsActive = _typologys[position].Active;

            return view;
        }

        public override int Count
        {
            get { return _typologys.Count; }
        }
    }

    class TypologysAdapterViewHolder : Java.Lang.Object
    {
        public TypologysAdapterViewHolder()
        {
            HasOptionMenu = false;
        }

        public TextView tvTypology { get; set; }

        public ActiveTextView tvState { get; set; }

        public ImageButton ibtnOptions { get; set; }

        public bool HasOptionMenu { get; set; }

        public int Position { get; set; }
    }

}