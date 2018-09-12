using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services
{
    public class BaseService
    {
        public const string ApiURL = "http://213.32.71.49/";

        public const string GetConfigurationsURL = "frota/example/getconfiguracao";
        public const string GetProfilesURL = "frota/example/getperfil";
        public const string GetProfilePermissionsURL = "frota/example/getperfilpermisao";
        public const string GetPermissionsURL = "frota/example/getpermissao";
        public const string GetLoginIdURL = "frota/example/loginID";
        public const string GetUsersURL = "frota/example/getutilizadores";
        public const string GetVehiclesURL = "frota/example/getveiculo";
        public const string GetBrandsURL = "frota/example/getmarcas";
        public const string GetModelsURL = "frota/example/getmodelos";
        public const string GetTypologysURL = "frota/example/gettipologia";
        public const string GetFuelsURL = "frota/example/getcombustivel";
        public const string GetVehicleHistoryURL = "frota/example/getveiculohistorico";
        public const string GetDamageVehicleURL = "frota/example/getdanosveiculos";
        public const string GetDamageVehicleDocumentURL = "frota/example/getdanosveiculocomprovativo";
        public const string GetRequestJustificationTypesURL = "frota/example/getrequestjustificationtype";
        public const string GetRequestStatesURL = "frota/example/getrequeststates";
        public const string GetRequestsURL = "frota/example/getrequests";
        public const string GetRequestJustificationsURL = "frota/example/getrequestjustification";
        public const string GetRequestHistoriesURL = "frota/example/getpedidomarcacaohistorico";
        public const string AddJustificationURL = "frota/example/addjustification";

        public const string ResetUserPasswordURL = "frota/example/passwordresetutilizador";
        public const string ChangeUserStateURL = "frota/example/ativoutilizador";
        public const string ChangeUserPasswordURL = "frota/example/mudarpasswordutilizador";
        public const string ChangeDefaultPasswordURL = "frota/example/updatedefaultpassword";

        public const string InsertBrandURL = "frota/example/addmarca";
        public const string InsertModelURL = "frota/example/addmodelo";
        public const string InsertTypologyURL = "frota/example/addtipologia";

        public const string UpdateBrandURL = "frota/example/updatemarca";
        public const string UpdateModelURL = "frota/example/updatemodelo";
        public const string UpdateTypologyURL = "frota/example/updatetipologia";

        public const string ChangeBrandStateURL = "frota/example/ativomarca";
        public const string ChangeModelStateURL = "frota/example/ativomodelo";
        public const string ChangeTypologyStateURL = "frota/example/ativotipologia";
        public const string ChangeAllModelsStateURL = "frota/example/ativomodelosuper";

        public const string ChangeVehicleStateURL = "frota/example/ativoveiculo";

        public const string AddUserURL = "frota/example/addutilizador";
        public const string UpdateUserURL = "frota/example/updateutilizador";

        public const string GetRequestsForApprovalURL = "frota/example/getpedidomarcacaopendente";
        public const string GetRequestsUnavailableURL = "frota/example/getpedidosdisponibilizar";
        public const string GetRequestsActiveURL = "frota/example/getpedidomarcacaoaprovado";
        public const string GetRequestsCursoURL = "frota/example/getpedidomarcacaoemcurso";

        public const string GetAvailableVehiclesURL = "frota/example/getveiculosdisponiveis";
        public const string existesobreposicaoURL = "frota/example/existesobreposicao";
        public const string addpedidoURL = "frota/example/addpedido";
        public const string addpedidohistoricoURL = "frota/example/addpedidohistorico";
        public const string AprovaPedidoURL = "frota/example/aprovapedido";
        public const string CancelRequestURL = "frota/example/cancelapedido";

        public const string addveiculohistoricoURL = "frota/example/addveiculohistorico";
        public const string terminapedidoURL = "frota/example/terminapedido";
        public const string adddanoURL = "frota/example/adddano";
        public const string adddanocomprovativoURL = "frota/example/adddanocomprovativo";

        public const string addprofileURL = "frota/example/addprofile";
        public const string addprofilepermissionURL = "frota/example/addpermisaoprofile";
        public const string updateprofileURL = "frota/example/updateprofile";
        public const string deletepermissionsURL = "frota/example/deletepermissions";
        public const string stateprofileURL = "frota/example/ativoprofile";
        public const string userprofilexistsURL = "frota/example/existeuserprofile";

        public const string AddVehicleURL = "frota/example/addveiculo";

        public const string GetMethod = "GET";
        public const string PostMethod = "POST";

        public const string ContentTypeApplicationJson = "application/json";

        public enum UrlMethodType
        {
            Base = 0,
            GetConfigurations = 1,
            GetProfiles = 2,
            GetPermissions = 3,
            GetProfilePermissions = 4,
            GetLoginID = 5,
            GetUsers = 6,
            GetVehicles = 7,
            GetBrands = 8,
            GetModels = 9,
            GetTypologies = 10,
            GetFuels = 11,
            ResetUserPassword = 12,
            ChangeUserState = 13,
            InsertBrand = 14,
            InsertModel = 15,
            InsertTypology = 16,
            AddUser = 17,
            UpdateUser = 18,
            UpdateBrand = 19,
            UpdateModel = 20,
            UpdateTypology = 21,
            ChangeBrandState = 22,
            ChangeModelState = 23,
            ChangeTypologyState = 24,
            ChangeAllModelsState = 25,
            ChangeVehicleState = 26,
            GetRequestsForApproval = 27,
            GetRequestsUnavailable = 28,
            GetRequestsActive = 29,
            GetVehicleHistory = 30,
            GetDamageVehicle = 31,
            GetDamageVehicleDocument = 32,
            GetAvailableVehicles = 33,
            addpedido = 34,
            addpedidohistorico = 35,
            AddVehicle = 36,
            AprovaPedido = 37,
            addveiculohistorico = 38,
            terminapedido = 39,
            adddano = 40,
            adddanocomprovativo = 41,
            GetRequestsCurso = 42,
            ChangeUserPassword = 43,
            addprofile = 44,
            addprofilepermission = 45,
            updateprofile = 46,
            deletepermissions = 47,
            stateprofile = 48,
            userprofilexists = 49,
            GetRequestJustificationTypes = 50,
            GetRequestStates = 51,
            GetRequests = 52,
            GetRequestJustifications = 53,
            GetRequestHistories = 54,
            CancelRequest = 55,
            ChangeDefaultPassword = 56,
            AddJustification = 57,
            ExisteSobreposicao = 58
        }

        public string GetUrl(UrlMethodType method = UrlMethodType.Base)
        {
            var url = string.Empty;

            switch(method)
            {
                case UrlMethodType.Base:
                    url = ApiURL;
                    break;
                case UrlMethodType.GetConfigurations:
                    url = ApiURL + GetConfigurationsURL;
                    break;
                case UrlMethodType.GetProfiles:
                    url = ApiURL + GetProfilesURL;
                    break;
                case UrlMethodType.GetPermissions:
                    url = ApiURL + GetPermissionsURL;
                    break;
                case UrlMethodType.GetProfilePermissions:
                    url = ApiURL + GetProfilePermissionsURL;
                    break;
                case UrlMethodType.GetLoginID:
                    url = ApiURL + GetLoginIdURL;
                    break;
                case UrlMethodType.GetUsers:
                    url = ApiURL + GetUsersURL;
                    break;
                case UrlMethodType.GetVehicles:
                    url = ApiURL + GetVehiclesURL;
                    break;
                case UrlMethodType.GetBrands:
                    url = ApiURL + GetBrandsURL;
                    break;
                case UrlMethodType.GetModels:
                    url = ApiURL + GetModelsURL;
                    break;
                case UrlMethodType.GetTypologies:
                    url = ApiURL + GetTypologysURL;
                    break;
                case UrlMethodType.GetFuels:
                    url = ApiURL + GetFuelsURL;
                    break;
                case UrlMethodType.ResetUserPassword:
                    url = ApiURL + ResetUserPasswordURL;
                    break;
                case UrlMethodType.ChangeUserState:
                    url = ApiURL + ChangeUserStateURL;
                    break;
                case UrlMethodType.InsertBrand:
                    url = ApiURL + InsertBrandURL;
                    break;
                case UrlMethodType.InsertModel:
                    url = ApiURL + InsertModelURL;
                    break;
                case UrlMethodType.InsertTypology:
                    url = ApiURL + InsertTypologyURL;
                    break;
                case UrlMethodType.AddUser:
                    url = ApiURL + AddUserURL;
                    break;
                case UrlMethodType.UpdateUser:
                    url = ApiURL + UpdateUserURL;
                    break;
                case UrlMethodType.UpdateBrand:
                    url = ApiURL + UpdateBrandURL;
                    break;
                case UrlMethodType.UpdateModel:
                    url = ApiURL + UpdateModelURL;
                    break;
                case UrlMethodType.UpdateTypology:
                    url = ApiURL + UpdateTypologyURL;
                    break;
                case UrlMethodType.ChangeBrandState:
                    url = ApiURL + ChangeBrandStateURL;
                    break;
                case UrlMethodType.ChangeModelState:
                    url = ApiURL + ChangeModelStateURL;
                    break;
                case UrlMethodType.ChangeTypologyState:
                    url = ApiURL + ChangeTypologyStateURL;
                    break;
                case UrlMethodType.ChangeAllModelsState:
                    url = ApiURL + ChangeAllModelsStateURL;
                    break;
                case UrlMethodType.ChangeVehicleState:
                    url = ApiURL + ChangeVehicleStateURL;
                    break;
                case UrlMethodType.GetRequestsForApproval:
                    url = ApiURL + GetRequestsForApprovalURL;
                    break;
                case UrlMethodType.GetRequestsUnavailable:
                    url = ApiURL + GetRequestsUnavailableURL;
                    break;
                case UrlMethodType.GetRequestsActive:
                    url = ApiURL + GetRequestsActiveURL;
                    break;
                case UrlMethodType.GetVehicleHistory:
                    url = ApiURL + GetVehicleHistoryURL;
                    break;
                case UrlMethodType.GetDamageVehicle:
                    url = ApiURL + GetDamageVehicleURL;
                    break;
                case UrlMethodType.GetDamageVehicleDocument:
                    url = ApiURL + GetDamageVehicleDocumentURL;
                    break;
                case UrlMethodType.GetAvailableVehicles:
                    url = ApiURL + GetAvailableVehiclesURL;
                    break;
                case UrlMethodType.addpedido:
                    url = ApiURL + addpedidoURL;
                    break;
                case UrlMethodType.addpedidohistorico:
                    url = ApiURL + addpedidohistoricoURL;
                    break;
                case UrlMethodType.AddVehicle:
                    url = ApiURL + AddVehicleURL;
                    break;
                case UrlMethodType.AprovaPedido:
                    url = ApiURL + AprovaPedidoURL;
                    break;
                case UrlMethodType.addveiculohistorico:
                    url = ApiURL + addveiculohistoricoURL;
                    break;
                case UrlMethodType.terminapedido:
                    url = ApiURL + terminapedidoURL;
                    break;
                case UrlMethodType.adddano:
                    url = ApiURL + adddanoURL;
                    break;
                case UrlMethodType.adddanocomprovativo:
                    url = ApiURL + adddanocomprovativoURL;
                    break;
                case UrlMethodType.GetRequestsCurso:
                    url = ApiURL + GetRequestsCursoURL;
                    break;
                case UrlMethodType.ChangeUserPassword:
                    url = ApiURL + ChangeUserPasswordURL;
                    break;
                case UrlMethodType.addprofile:
                    url = ApiURL + addprofileURL;
                    break;
                case UrlMethodType.addprofilepermission:
                    url = ApiURL + addprofilepermissionURL;
                    break;
                case UrlMethodType.updateprofile:
                    url = ApiURL + updateprofileURL;
                    break;
                case UrlMethodType.deletepermissions:
                    url = ApiURL + deletepermissionsURL;
                    break;
                case UrlMethodType.stateprofile:
                    url = ApiURL + stateprofileURL;
                    break;
                case UrlMethodType.userprofilexists:
                    url = ApiURL + userprofilexistsURL;
                    break;
                case UrlMethodType.GetRequestJustificationTypes:
                    url = ApiURL + GetRequestJustificationTypesURL;
                    break;
                case UrlMethodType.GetRequestStates:
                    url = ApiURL + GetRequestStatesURL;
                    break;
                case UrlMethodType.GetRequests:
                    url = ApiURL + GetRequestsURL;
                    break;
                case UrlMethodType.GetRequestJustifications:
                    url = ApiURL + GetRequestJustificationsURL;
                    break;
                case UrlMethodType.GetRequestHistories:
                    url = ApiURL + GetRequestHistoriesURL;
                    break;
                case UrlMethodType.CancelRequest:
                    url = ApiURL + CancelRequestURL;
                    break;
                case UrlMethodType.ChangeDefaultPassword:
                    url = ApiURL + ChangeDefaultPasswordURL;
                    break;
                case UrlMethodType.AddJustification:
                    url = ApiURL + AddJustificationURL;
                    break;
                case UrlMethodType.ExisteSobreposicao:
                    url = ApiURL + existesobreposicaoURL;
                    break;
            }

            return url;
        }

        public async Task<string> GetAsync(string url)
        {
            var client = new HttpClient();

            var result = await client.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<string> PostAsync(string url, List<KeyValuePair<string, string>> data)
        {
            var encodedContent = new FormUrlEncodedContent(data);

            var client = new HttpClient();

            var result = await client.PostAsync(url, encodedContent);
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }
    }
}
