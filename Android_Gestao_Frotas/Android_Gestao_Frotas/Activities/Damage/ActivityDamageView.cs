using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android_Gestao_Frotas.Adapters;
using Core_Gestao_Frotas.Business.Models;

namespace Android_Gestao_Frotas.Activities.Damage
{

    public delegate void OnRemoveDamageClickController(int position);
    public delegate void OnAddDamageClickEvent();
    public delegate void OnUpdateDescriptionController(List<DamageVehicle> DamageVehicles);
    public delegate void OnPhotoClickController(int position);
    public delegate void OnFolderClickController(int position);
    public delegate void OnTextKmsChange(string kms);

    [Activity(Label = "ActivityDamageView")]
    public class ActivityDamageView : ActivityBaseView
    {

        public event OnAddDamageClickEvent OnAddDamageClickEvent;
        public event OnRemoveDamageClickController OnRemoveDamageClickController;
        public event OnUpdateDescriptionController OnUpdateDescriptionController;
        public event OnPhotoClickController OnPhotoClickController;
        public event OnFolderClickController OnFolderClickController;
        public event OnTextKmsChange OnTextKmsChange;

        EditText kms;
        ListView lvDamage;
        ImageButton AddDamage;
        DamageAdapter adapter;

        public ActivityDamageView(Context context) : base(context)
        {
            LoadView();
        }

        private void LoadView()
        {
            var view = Inflate(Context, Resource.Layout.activity_finishrequest, this);
            lvDamage = view.FindViewById<ListView>(Resource.Id.lvDamage);
            AddDamage = view.FindViewById<ImageButton>(Resource.Id.bttAddDamage);
            kms = view.FindViewById<EditText>(Resource.Id.editTextKms);

            AddDamage.Click -= AddDamage_Click;
            AddDamage.Click += AddDamage_Click;

            kms.TextChanged -= Kms_TextChanged;
            kms.TextChanged += Kms_TextChanged;

        }

        private void Kms_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            OnTextKmsChange?.Invoke(kms.Text);
        }

        private void AddDamage_Click(object sender, EventArgs e)
        {
            OnAddDamageClickEvent?.Invoke();
        }

        public void UpdateDamage(List<DamageVehicle> damagelist, List<DamageVehicleDocument> damagedocumentlist)
        {
            adapter = new DamageAdapter(Context, damagelist, damagedocumentlist);
            lvDamage.Adapter = adapter;

            adapter.OnRemoveDamageClick -= Adapter_OnRemoveDamageClick;
            adapter.OnRemoveDamageClick += Adapter_OnRemoveDamageClick;

            adapter.OnUpdateDescription -= Adapter_OnUpdateDescription;
            adapter.OnUpdateDescription += Adapter_OnUpdateDescription;

            adapter.OnPhotoClick -= Adapter_OnPhotoClick;
            adapter.OnPhotoClick += Adapter_OnPhotoClick;

            adapter.OnFolderClick -= Adapter_OnPhotoClick;
            adapter.OnFolderClick += Adapter_OnFolderClick;

        }

        private void Adapter_OnFolderClick(int position)
        {
            OnFolderClickController?.Invoke(position);
        }

        private void Adapter_OnPhotoClick(int position)
        {
            OnPhotoClickController?.Invoke(position);
        }

        private void Adapter_OnUpdateDescription(List<DamageVehicle> DamageVehicles)
        {
            OnUpdateDescriptionController?.Invoke(DamageVehicles);
        }

        private void Adapter_OnRemoveDamageClick(int position)
        {
            OnRemoveDamageClickController?.Invoke(position);
        }
    }
}