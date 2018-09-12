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
using Android_Gestao_Frotas.Activities.PermissionSelect;
using Android_Gestao_Frotas.Helpers;
using Core_Gestao_Frotas;
using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Business.Profiles;
using Newtonsoft.Json;

namespace Android_Gestao_Frotas.Activities.ProfileInfo
{

    [Activity(Label = "Adicionar Perfil", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivityProfileInfoController : ActivityBaseController
    {
        ActivityProfileInfoView MainView;
        Android.Support.V7.Widget.Toolbar Toolbar;
        IBusinessProfile BusinessProfile = new BusinessProfile();
        private List<Permission> _permissionsloaded;
        private List<Permission> _permissions;
        private List<KeyValuePair<Permission, bool>> _permissionsparaeditar;
        private Dictionary<Permission, bool> permissionsinfo = new Dictionary<Permission, bool>();
        private string profilename;
        private Profile _profileget;
        private int _profilegetID;
        private int _typeget;
        private bool estado; 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            LoadView();
            _typeget = Intent.GetIntExtra("tipo", 0);
            if (_typeget == 0)
            {
                LoadDataAsync();
                MainView.ChangeLayoutState(false);
            }
            else
            {
                LoadProfile();
                Title = "Editar Perfil";
                MainView.ChangeLayoutState(true);
            }
        }

        private async void LoadProfile()
        {
            SetLoadingView(true);
            _profilegetID = Intent.GetIntExtra("profile", 0);
            _profileget = await BusinessProfile.GetProfile(_profilegetID);

            MainView.Changeprofiletext(_profileget.Description);
            profilename = _profileget.Description;
            permissionsinfo = _profileget.Permissions;
            estado = _profileget.Active;
            MainView.ChangeProfileStateStart(estado);
            _permissionsparaeditar = permissionsinfo.ToList();
            MainView.UpdatePermissionsProfile(permissionsinfo, _typeget);

            _permissionsloaded = (await BusinessProfile.GetPermissions()).ToList();
            _permissions = _permissionsloaded;

            for (int i = 0; i < _permissionsparaeditar.Count; i++)
            {
                var itemToRemove = _permissions.SingleOrDefault(r => r.Id == _permissionsparaeditar[i].Key.Id);
                _permissions.Remove(itemToRemove);
            }

            SetLoadingView(false);
        }

        private async void LoadDataAsync()
        {
            SetLoadingView(true);
            _permissionsloaded = (await BusinessProfile.GetPermissions()).ToList();
            _permissions = _permissionsloaded;
            SetLoadingView(false);
        }

        private void LoadView()
        {
            MainView = new ActivityProfileInfoView(this);
            SetContentView(MainView);

            Toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(Toolbar);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar?.SetHomeButtonEnabled(true);
            Toolbar.NavigationClick += (o, a) => { OnBackPressed(); };

            MainView.AddPermissao -= MainView_AddPermissao;
            MainView.AddPermissao += MainView_AddPermissao;

            MainView.OnProfileNameChange -= MainView_OnProfileNameChange;
            MainView.OnProfileNameChange += MainView_OnProfileNameChange;

            MainView.OnDeletePermissionController -= MainView_OnDeletePermissionController;
            MainView.OnDeletePermissionController += MainView_OnDeletePermissionController;

            MainView.OnChangePermissionStateController -= MainView_OnChangePermissionStateController;
            MainView.OnChangePermissionStateController += MainView_OnChangePermissionStateController;

            MainView.OnStateChangeProfile -= MainView_OnStateChangeProfile;
            MainView.OnStateChangeProfile += MainView_OnStateChangeProfile;

        }

        private void MainView_OnStateChangeProfile(bool state)
        {
            estado = state;
        }

        private async void MainView_OnDeletePermissionController(int pos)
        {

            if (_typeget == 0)
            {
                List<KeyValuePair<Permission, bool>> _permissionsadd = permissionsinfo.ToList();
                var response = await new DialogHelper(this).Question("Tem a certeza que pretende Eliminar a permissão " + _permissionsadd[pos].Key.Description + "?");
                if (response == DialogHelper.DialogResponse.Yes)
                {
                    _permissions.Add(_permissionsadd[pos].Key);
                    _permissionsadd.RemoveAt(pos);
                    permissionsinfo = _permissionsadd.ToDictionary(x => x.Key, x => x.Value);
                    MainView.UpdatePermissionsProfile(permissionsinfo, _typeget);
                }
            }
            else
            {
                var response = await new DialogHelper(this).Question("Tem a certeza que pretende Eliminar a permissão " + _permissionsparaeditar[pos].Key.Description + "?");
                if (response == DialogHelper.DialogResponse.Yes)
                {
                    _permissions.Add(_permissionsparaeditar[pos].Key);
                    _permissionsparaeditar.RemoveAt(pos);
                    permissionsinfo = _permissionsparaeditar.ToDictionary(x => x.Key, x => x.Value);
                    MainView.UpdatePermissionsProfile(permissionsinfo, _typeget);
                }
            }

        }

        private void MainView_OnChangePermissionStateController(int pos)
        {
            if (_permissionsparaeditar[pos].Value == true)
            {
                var newValue = new KeyValuePair<Permission, bool>(_permissionsparaeditar[pos].Key, false);
                _permissionsparaeditar[pos] = newValue;
                permissionsinfo = _permissionsparaeditar.ToDictionary(x => x.Key, x => x.Value);
                MainView.UpdatePermissionsProfile(permissionsinfo, _typeget);
            }
            else
            {
                var newValue = new KeyValuePair<Permission, bool>(_permissionsparaeditar[pos].Key, true);
                _permissionsparaeditar[pos] = newValue;
                permissionsinfo = _permissionsparaeditar.ToDictionary(x => x.Key, x => x.Value);
                MainView.UpdatePermissionsProfile(permissionsinfo, _typeget);
            }
        }

        private void MainView_OnProfileNameChange(string name)
        {
            profilename = name;
        }

        private void MainView_AddPermissao()
        {
            //var addpermissaoselected = await new DialogHelper(this).Pick(_permissions);
            //permissionsinfo.Add(addpermissaoselected, true);
            //_permissions.Remove(addpermissaoselected);
            //MainView.UpdatePermissionsProfile(permissionsinfo, _typeget);
            var intent = new Intent(this, typeof(ActivityPermissionSelectController));
            AllYouCanGet.editprofile = new EditProfile();
            AllYouCanGet.editprofile.CurrentPermissions = new Dictionary<Permission, bool>(permissionsinfo);
            //AllYouCanGet.editprofile.CurrentPermissions = permissionsinfo;
            StartActivityForResult(intent, SelectPermissions);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == SelectPermissions)
            {
                if (resultCode == Result.Ok)
                {
                    SetLoadingView(true);
                    permissionsinfo = new Dictionary<Permission, bool>(AllYouCanGet.editprofile.CurrentPermissions);
                    _permissionsparaeditar = permissionsinfo.ToList();
                    MainView.UpdatePermissionsProfile(permissionsinfo, _typeget);
                    SetLoadingView(false);
                }
            }
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
                    if (profilename != string.Empty)
                    {
                        if (_typeget == 0)
                        {
                            Sendprofile();
                        }
                        else
                        {
                            EditProfile();
                        }

                    }
                    else
                    {
                        Erro();
                    }
                    //Toast.MakeText(this, "It Works!", ToastLength.Short).Show();
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }

        private async void EditProfile()
        {
            SetLoadingView(true);
            var editprofile = new Profile()
            {
                Id = _profileget.Id,
                Description = profilename,
                IsIncomplete = true,
                Active = !estado,
                Permissions = _profileget.Permissions
            };


            //LOL
            var ready = 0;
            if (editprofile.Active == true)
            {
                ready = await BusinessProfile.CheckUserStatusProfile(editprofile);
            }

            var result4 = false;
            if (ready == 0)
            {
                result4 = await BusinessProfile.UpdateProfileState(editprofile);
            }
            else
            {
                var dialogResult = await new DialogHelper(this).Message("Não é possível inativar o perfil. Existem utilizadores, ativos com o perfil associado.");
            }

            if (result4 == true)
            {

                var result = await BusinessProfile.UpdateProfile(editprofile);
                var result2 = await BusinessProfile.DeletePermissions(editprofile);

                if (permissionsinfo.Count > 0)
                {

                    foreach (var item in permissionsinfo)
                    {
                        var result3 = await BusinessProfile.AddProfilePermission(_profileget.Id, item.Key.Id, item.Value == true ? 1 : 0);
                    }

                }

                SetLoadingView(false);
                SetResult(Result.Ok);
                Finish();

            }


            //LEL

        }

        private async void Erro()
        {
            var dialogResult = await new DialogHelper(this).Message($"Campos não Preenchidos.");
        }

        private async void Sendprofile()
        {
            SetLoadingView(true);
            var novoprofile = new Profile()
            {
                Id = -1,
                Description = profilename,
                IsIncomplete = true
            };
            var result = await BusinessProfile.AddProfile(novoprofile);

            if (permissionsinfo.Count > 0)
            {

                foreach (var item in permissionsinfo)
                {
                    var result2 = await BusinessProfile.AddProfilePermission(result.Id, item.Key.Id, 1);
                }

            }
            SetLoadingView(false);

            SetResult(Result.Ok);
            Finish();

        }

    }
}