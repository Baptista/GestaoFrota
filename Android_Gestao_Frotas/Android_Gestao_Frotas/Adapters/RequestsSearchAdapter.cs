using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Models;
using Square.Picasso;

namespace Android_Gestao_Frotas.Adapters
{

    public delegate void AcceptRequest(RequestHistory request);
    public delegate void CancelRequest(RequestHistory request,string justification);
    public delegate void RequestAvailableVehicle(RequestHistory request);

    class RequestsSearchAdapter : BaseAdapter
    {

        public event AcceptRequest AcceptRequest;
        public event CancelRequest CancelRequest;
        public event RequestAvailableVehicle RequestAvailableVehicle;
        private Context _context;
        private List<RequestHistory> _requests;

        public RequestsSearchAdapter(Context context, IEnumerable<RequestHistory> requests)
        {
            _context = context;
            _requests = requests.ToList();
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return _requests[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var view = convertView;
            RequestsSearchAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as RequestsSearchAdapterViewHolder;

            if (holder == null)
            {
                holder = new RequestsSearchAdapterViewHolder();
                var inflater = _context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.item_requests, parent, false);

                holder.ivUserImage = view.FindViewById<ImageView>(Resource.Id.ivUserImage);
                holder.tvName = view.FindViewById<TextView>(Resource.Id.tvName);
                holder.tvAddress = view.FindViewById<TextView>(Resource.Id.tvAddress);
                holder.tvDate = view.FindViewById<TextView>(Resource.Id.tvDate);
                holder.tvState = view.FindViewById<TextView>(Resource.Id.tvState);
                holder.MyButtonOptionRequest = view.FindViewById<ImageButton>(Resource.Id.MyButtonOptionRequest);

                view.Tag = holder;
            }

            holder.tvName.Text = _requests[position].Vehicle.ToString();
            holder.tvAddress.Text = "Owner: " + _requests[position].User.Name;
            holder.tvDate.Text = "De: " + _requests[position].StartDate.ToString("dd-MM-yyyy") + " até " + _requests[position].EndDate.ToString("dd-MM-yyyy");

            Picasso.With(_context)
            .Load(Resource.Drawable.car_picture_test)
            .Placeholder(Resource.Drawable.ic_car_image)
            .Error(Resource.Drawable.ic_car_image)
            .Resize(111, 111)
            .CenterInside()
            .Transform(new CircleTransform(Color.Red, 2f))
            .Into(holder.ivUserImage);

            if (_requests[position].RequestState.Id == 1)
            {
                if (_requests[position].EndDate > DateTime.Now)
                {
                    holder.tvState.Text = "Estado: Aprovado";
                    holder.tvState.SetTextColor(Color.ParseColor("#04B404"));
                    holder.MyButtonOptionRequest.Visibility = ViewStates.Visible;
                }
                else
                {
                    holder.tvState.Text = "Estado: Aprovado (para Disponibilizar)";
                    holder.tvState.SetTextColor(Color.ParseColor("#04B404"));
                    holder.MyButtonOptionRequest.Visibility = ViewStates.Visible;
                }
            }
            else if (_requests[position].RequestState.Id == 2)
            {
                holder.tvState.Text = "Estado: Pendente";
                holder.tvState.SetTextColor(Color.ParseColor("#868A08"));
                holder.MyButtonOptionRequest.Visibility = ViewStates.Visible;
            }
            else if (_requests[position].RequestState.Id == 3)
            {
                holder.tvState.Text = "Estado: Cancelado";
                holder.tvState.SetTextColor(new Color(ContextCompat.GetColor(_context, Resource.Color.edge_red)));
                holder.MyButtonOptionRequest.Visibility = ViewStates.Gone;
            }
            else if (_requests[position].RequestState.Id == 4)
            {
                holder.tvState.Text = "Estado: Terminado";
                holder.tvState.SetTextColor(Color.ParseColor("#B40431"));
                holder.MyButtonOptionRequest.Visibility = ViewStates.Gone;
            }

            if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ViewUserRequestDetails) && _requests[position].RequestState.Id != 1)
            {
                if (!holder.HasOptionMenu)
                {
                    holder.MyButtonOptionRequest.Click += delegate { OnOptionsClick(holder, _requests[position]); };
                    holder.HasOptionMenu = true;
                }
            }else if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ViewUserRequestsEncourseDetails) && _requests[position].RequestState.Id == 1)
            {
                if (!holder.HasOptionMenu)
                {
                    holder.MyButtonOptionRequest.Click += delegate { OnOptionsClick(holder, _requests[position]); };
                    holder.HasOptionMenu = true;
                }
            }else if (_requests[position].User.Id == AllYouCanGet.CurrentUser.Id)
            {
                if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ApproveUserRequests) || AllYouCanGet.CurrentUser.Profile.IsActive(Permission.CancelUserRequests) || AllYouCanGet.CurrentUser.Profile.IsActive(Permission.MakeVehicleAvailable))
                {
                    if (!holder.HasOptionMenu)
                    {
                        holder.MyButtonOptionRequest.Click += delegate { OnOptionsClick(holder, _requests[position]); };
                        holder.HasOptionMenu = true;
                    }
                }else if (_requests[position].RequestState.Id == 1 && _requests[position].EndDate > DateTime.Now)
                {
                    if (!holder.HasOptionMenu)
                    {
                        holder.MyButtonOptionRequest.Click += delegate { OnOptionsClick(holder, _requests[position]); };
                        holder.HasOptionMenu = true;
                    }
                }
            }

            holder.Position = position;

            return view;

        }

        private void OnOptionsClick(RequestsSearchAdapterViewHolder holder, RequestHistory requestHistory)
        {
            var popupMenu = new PopupMenu(_context, holder.MyButtonOptionRequest, GravityFlags.AxisClip);
            if (_requests[holder.Position].RequestState.Id == 2)
            {
                popupMenu.MenuInflater.Inflate(Resource.Menu.options_requests_menu, popupMenu.Menu);

                popupMenu.MenuItemClick += async (sender, args) =>
                {
                    switch (args.Item.ItemId)
                    {
                        case Resource.Id.nav_approve:
                            if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.ApproveUserRequests))
                            {
                                var result = await new DialogHelper(_context).Question($"Pretende aprovar o pedido de marcação?");
                                if (result == DialogHelper.DialogResponse.Yes)
                                {
                                    AcceptRequest?.Invoke(_requests[holder.Position]);
                                }
                            }
                            else
                            {
                                var errorresult = await new DialogHelper(_context).Message("Não tem permissão para realizar esta tarefa!");
                            }
                            break;
                        case Resource.Id.nav_change:
                            //TODO
                            break;
                        case Resource.Id.nav_cancel:
                            if (requestHistory.User.Id == AllYouCanGet.CurrentUser.Id)
                            {
                                var result2 = await new DialogHelper(_context).Question($"Pretende cancelar o pedido de marcação?");
                                if (result2 == DialogHelper.DialogResponse.Yes)
                                {
                                    var result3 = await new DialogHelper(_context).UserInput($"Justificação para cancelar o pedido:");
                                    if (result3 != string.Empty && result3 != "")
                                    {
                                        CancelRequest?.Invoke(_requests[holder.Position], result3);
                                    }
                                }
                            }else if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.CancelUserRequests))
                            {
                                var result2 = await new DialogHelper(_context).Question($"Pretende cancelar o pedido de marcação?");
                                if (result2 == DialogHelper.DialogResponse.Yes)
                                {
                                    var result3 = await new DialogHelper(_context).UserInput($"Justificação para cancelar o pedido:");
                                    if (result3 != string.Empty && result3 != "")
                                    {
                                        CancelRequest?.Invoke(_requests[holder.Position], result3);
                                    }
                                }
                            }
                            else
                            {
                                var errorresult = await new DialogHelper(_context).Message("Não tem permissão para realizar esta tarefa!");
                            }
                            break;
                    }
                };

                 popupMenu.Show();
            }else if (_requests[holder.Position].RequestState.Id == 1)
            {
                if (requestHistory.EndDate > DateTime.Now)
                {
                    popupMenu.MenuInflater.Inflate(Resource.Menu.options2_requests_menu, popupMenu.Menu);

                    popupMenu.MenuItemClick += async (sender, args) =>
                    {
                        switch (args.Item.ItemId)
                        {
                            case Resource.Id.nav_cancel:
                                if (requestHistory.User.Id == AllYouCanGet.CurrentUser.Id)
                                {
                                    var result2 = await new DialogHelper(_context).Question($"Pretende cancelar o pedido de marcação?");
                                    if (result2 == DialogHelper.DialogResponse.Yes)
                                    {
                                        var result3 = await new DialogHelper(_context).UserInput($"Justificação para cancelar o pedido:");
                                        if (result3 != string.Empty)
                                        {
                                            CancelRequest?.Invoke(_requests[holder.Position], result3);
                                        }
                                    }
                                }
                                else if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.CancelUserRequests))
                                {
                                    var result2 = await new DialogHelper(_context).Question($"Pretende cancelar o pedido de marcação?");
                                    if (result2 == DialogHelper.DialogResponse.Yes)
                                    {
                                        var result3 = await new DialogHelper(_context).UserInput($"Justificação para cancelar o pedido:");
                                        if (result3 != string.Empty)
                                        {
                                            CancelRequest?.Invoke(_requests[holder.Position], result3);
                                        }
                                    }
                                }
                                else
                                {
                                    var errorresult = await new DialogHelper(_context).Message("Não tem permissão para realizar esta tarefa!");
                                }
                                break;
                        }
                    };

                    popupMenu.Show();
                }
                else
                {
                    popupMenu.MenuInflater.Inflate(Resource.Menu.options3_requests_menu, popupMenu.Menu);

                    popupMenu.MenuItemClick += async (sender, args) =>
                    {
                        switch (args.Item.ItemId)
                        {
                            case Resource.Id.nav_acceptcar:
                                if (AllYouCanGet.CurrentUser.Profile.IsActive(Permission.MakeVehicleAvailable))
                                {
                                    var result2 = await new DialogHelper(_context).Question($"Pretende Disponibilizar o Veiculo " + requestHistory.Vehicle.ToString() + " ?");
                                    if (result2 == DialogHelper.DialogResponse.Yes)
                                    {
                                        RequestAvailableVehicle?.Invoke(requestHistory);
                                    }
                                }
                                break;
                        }
                    };

                    popupMenu.Show();
                }
            }
        }

        public override int Count
        {
            get { return _requests.Count; }
        }

    }

    class RequestsSearchAdapterViewHolder : Java.Lang.Object
    {

        public RequestsSearchAdapterViewHolder()
        {
            HasOptionMenu = false;
        }

        public ImageView ivUserImage { get; set; }

        public TextView tvName { get; set; }

        public TextView tvAddress { get; set; }

        public TextView tvDate { get; set; }

        public TextView tvState { get; set; }

        public ImageButton MyButtonOptionRequest { get; set; }

        public bool HasOptionMenu { get; set; }

        public int Position { get; set; }

    }
}