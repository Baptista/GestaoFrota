using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Mappers
{
    public static class MapperWeb
    {

        public static List<BrandPersistence> WebBrandListToPersistence(List<WebBrand> webBrands)
        {
            var brandsPersistence = new List<BrandPersistence>();
            for (int i = 0; i < webBrands.Count; i++)
            {
                brandsPersistence.Add(new BrandPersistence
                {
                    Id = webBrands[i].IdMarca,
                    Description = webBrands[i].Descricao,
                    Active = Convert.ToByte(webBrands[i].Ativo)
                });
            }

            return brandsPersistence;
        }

        public static BrandPersistence WebBrandToPersistence(WebBrand webBrands)
        {
            var brandsPersistence = new BrandPersistence();
                brandsPersistence = new BrandPersistence
                {
                    Id = webBrands.IdMarca,
                    Description = webBrands.Descricao,
                    Active = Convert.ToByte(webBrands.Ativo)
                };

            return brandsPersistence;
        }

        public static List<ConfigurationPersistence> WebConfigurationToPersistence(List<WebConfiguration> webConfigurations)
        {
            var configurationPersistence = new List<ConfigurationPersistence>();
            for (int i = 0; i < webConfigurations.Count; i++)
            {
                configurationPersistence.Add(new ConfigurationPersistence
                {
                    Id = webConfigurations[i].IdConfiguracao,
                    Parameter = webConfigurations[i].Parametro,
                    Description = webConfigurations[i].Descricao,
                });
            }

            return configurationPersistence;
        }

        public static List<ProfilePersistence> WebProfileToPersistence(List<WebProfile> webProfiles)
        {
            var ProfilePersistence = new List<ProfilePersistence>();
            for (int i = 0; i < webProfiles.Count; i++)
            {
                ProfilePersistence.Add(new ProfilePersistence
                {
                    Id = webProfiles[i].IdPerfil,
                    Description = webProfiles[i].Descricao,
                    Active = (byte)(webProfiles[i].Ativo == true ? 1 : 0)
                });
            }

            return ProfilePersistence;
        }

        public static List<ProfilePermissionPersistence> WebProfilePermissionToPersistence(List<WebProfilePermission> webProfilePermissions)
        {
            var ProfilePermissionPersistence = new List<ProfilePermissionPersistence>();
            for (int i = 0; i < webProfilePermissions.Count; i++)
            {
                ProfilePermissionPersistence.Add(new ProfilePermissionPersistence
                {
                    Id = webProfilePermissions[i].IdPerfilPermissao,
                    IdPermission = webProfilePermissions[i].IdPermissao,
                    IdProfile = webProfilePermissions[i].IdPerfil,
                    Active = (byte)(webProfilePermissions[i].Ativo == true ? 1 : 0)
                });
            }

            return ProfilePermissionPersistence;
        }

        public static List<PermissionPersistence> WebPermissionToPersistence(List<WebPermission> webPermissions)
        {
            var PermissionPersistence = new List<PermissionPersistence>();
            for (int i = 0; i < webPermissions.Count; i++)
            {
                PermissionPersistence.Add(new PermissionPersistence
                {
                    Id = webPermissions[i].IdPermissao,
                    Description = webPermissions[i].Descricao
                });
            }

            return PermissionPersistence;
        }

        public static List<UserPersistence> WebUserListToPersistence(List<WebUser> webUsers)
        {
            var UserPersistence = new List<UserPersistence>();
            for (int i = 0; i < webUsers.Count; i++)
            {
                UserPersistence.Add(new UserPersistence
                {
                    Id = webUsers[i].IdUtilizador,
                    Username = webUsers[i].Username,
                    Password = webUsers[i].Password,
                    Name = webUsers[i].Nome,
                    Active = (byte)(webUsers[i].Ativo == true ? 1 : 0),
                    IdProfile = webUsers[i].IdPerfil,
                });
            }

            return UserPersistence;
        }

        public static UserPersistence WebUserToPersistence(WebUser webUser)
        {
            var UserPersistence = new UserPersistence();
                UserPersistence = new UserPersistence
                {
                    Id = webUser.IdUtilizador,
                    Username = webUser.Username,
                    Password = webUser.Password,
                    Name = webUser.Nome,
                    Active = (byte)(webUser.Ativo == true ? 1 : 0),
                    IdProfile = webUser.IdPerfil,
                };

            return UserPersistence;
        }

        public static List<VehiclePersistence> WebVehicleListToPersistence(List<WebVehicle> webVehicles)
        {
            var VehiclePersistence = new List<VehiclePersistence>();
            for (int i = 0; i < webVehicles.Count; i++)
            {
                VehiclePersistence.Add(new VehiclePersistence
                {
                    Id = webVehicles[i].IdVeiculo,
                    IdModel = webVehicles[i].IdModelo,
                    IdTypology = webVehicles[i].IdTipologia,
                    StartKms = float.Parse(webVehicles[i].KmsIniciais.ToString()),
                    ContractKms = float.Parse(webVehicles[i].KmsContrato.ToString()),
                    LicensePlate = webVehicles[i].Matricula,
                    IdUser = webVehicles[i].IdUtilizador.ToString(),
                    Available = (byte)(webVehicles[i].Disponivel == true ? 1 : 0),
                    Active = (byte)(webVehicles[i].Ativo == true ? 1 : 0)
                });
            }

            return VehiclePersistence;
        }

        public static VehiclePersistence WebVehicleToPersistence(WebVehicle webVehicle)
        {
            var VehiclePersistence = new VehiclePersistence() {
                Id = webVehicle.IdVeiculo,
                IdModel = webVehicle.IdModelo,
                IdTypology = webVehicle.IdTipologia,
                StartKms = float.Parse(webVehicle.KmsIniciais.ToString()),
                ContractKms = float.Parse(webVehicle.KmsContrato.ToString()),
                LicensePlate = webVehicle.Matricula,
                IdUser = webVehicle.IdUtilizador.ToString(),
                Available = (byte)(webVehicle.Disponivel == true ? 1 : 0),
                Active = (byte)(webVehicle.Ativo == true ? 1 : 0)
            };

            return VehiclePersistence;
        }

        public static List<ModelPersistence> WebModelListToPersistence(List<WebModel> webModels)
        {
            var ModelPersistence = new List<ModelPersistence>();
            for (int i = 0; i < webModels.Count; i++)
            {
                ModelPersistence.Add(new ModelPersistence
                {
                    Id = webModels[i].IdModelo,
                    IdBrand = webModels[i].IdMarca,
                    IdFuel = webModels[i].IdCombustivel,
                    Description = webModels[i].Descricao,
                    Active = (byte)(webModels[i].Ativo == true ? 1 : 0)
                });
            }

            return ModelPersistence;
        }

        public static ModelPersistence WebModelToPersistence(WebModel webModel)
        {
            var ModelPersistence = new ModelPersistence()
                {
                Id = webModel.IdModelo,
                IdBrand = webModel.IdMarca,
                IdFuel = webModel.IdCombustivel,
                Description = webModel.Descricao,
                Active = (byte)(webModel.Ativo == true ? 1 : 0)
            };

            return ModelPersistence;
        }

        public static List<TypologyPersistence> WebTypologyListToPersistence(List<WebTypology> webTypologys)
        {
            var TypologyPersistence = new List<TypologyPersistence>();
            for (int i = 0; i < webTypologys.Count; i++)
            {
                TypologyPersistence.Add(new TypologyPersistence
                {
                    Id = webTypologys[i].IdTipologia,
                    Description = webTypologys[i].Descricao,
                    Active = (byte)(webTypologys[i].Ativo == true ? 1 : 0)
                });
            }

            return TypologyPersistence;
        }

        public static TypologyPersistence WebTypologyToPersistence(WebTypology webTypology)
        {
            var TypologyPersistence = new TypologyPersistence()
            {
                Id = webTypology.IdTipologia,
                Description = webTypology.Descricao,
                Active = (byte)(webTypology.Ativo == true ? 1 : 0)
            };

            return TypologyPersistence;
        }

        public static List<FuelPersistence> WebFuelToPersistence(List<WebFuel> webFuels)
        {
            var FuelPersistence = new List<FuelPersistence>();
            for (int i = 0; i < webFuels.Count; i++)
            {
                FuelPersistence.Add(new FuelPersistence
                {
                    Id = webFuels[i].IdCombustivel,
                    Description = webFuels[i].Descricao
                });
            }

            return FuelPersistence;
        }

        public static List<VehicleDeliveryPersistence> WebVehicleDeliveryToPersistence(List<WebVehicleDelivery> webVehicleDeliverys)
        {
            var VehicleDeliveryPersistence = new List<VehicleDeliveryPersistence>();
            for (int i = 0; i < webVehicleDeliverys.Count; i++)
            {
                VehicleDeliveryPersistence.Add(new VehicleDeliveryPersistence
                {
                    Id = webVehicleDeliverys[i].IdVeiculoEntrega,
                    IdRequestHistory = webVehicleDeliverys[i].IdPedidoMarcacaoHistorico,
                    Kms = decimal.Parse(webVehicleDeliverys[i].Kms.ToString()),
                    Date = webVehicleDeliverys[i].Data
                });
            }

            return VehicleDeliveryPersistence;
        }

        public static List<DamageVehiclePersistence> WebDamageVehicleToPersistence(List<WebDamageVehicle> webDamageVehicles)
        {
            var DamageVehiclePersistence = new List<DamageVehiclePersistence>();
            for (int i = 0; i < webDamageVehicles.Count; i++)
            {
                DamageVehiclePersistence.Add(new DamageVehiclePersistence
                {
                    Id = webDamageVehicles[i].IdDanosVeiculo,
                    IdRequestHistory = webDamageVehicles[i].IdPedidoMarcacaoHistorico.ToString(),
                    IdVehicle = webDamageVehicles[i].IdVeiculo,
                    Description = webDamageVehicles[i].Descricao,
                    Date = webDamageVehicles[i].Data,
                    Active = (byte)(webDamageVehicles[i].Ativo == true ? 1 : 0)
                });
            }

            return DamageVehiclePersistence;
        }

        public static List<DamageVehicleDocumentPersistence> WebDamageVehicleDocumentToPersistence(List<WebDamageVehicleDocument> webDamageVehicleDocuments)
        {
            var DamageVehicleDocumentPersistence = new List<DamageVehicleDocumentPersistence>();
            for (int i = 0; i < webDamageVehicleDocuments.Count; i++)
            {
                DamageVehicleDocumentPersistence.Add(new DamageVehicleDocumentPersistence
                {
                    Id = webDamageVehicleDocuments[i].IdDanosVeiculoComprovativo,
                    //Document = webDamageVehicleDocuments[i].Documento,
                    DocumentFormat = webDamageVehicleDocuments[i].FormatoDocumento,
                    DocumentName = webDamageVehicleDocuments[i].NomeDocumento,
                    IdDamageVehicle = webDamageVehicleDocuments[i].IdDanosVeiculo,
                    Date = webDamageVehicleDocuments[i].Data,
                    Active = (byte)(webDamageVehicleDocuments[i].Ativo == true ? 1 : 0)
                });
            }

            return DamageVehicleDocumentPersistence;
        }

        public static List<RequestJustificationTypePersistence> WebRequestJustificationTypeToPersistence(List<WebRequestJustificationType> webRequestJustificationTypes)
        {
            var RequestJustificationTypePersistence = new List<RequestJustificationTypePersistence>();
            for (int i = 0; i < webRequestJustificationTypes.Count; i++)
            {
                RequestJustificationTypePersistence.Add(new RequestJustificationTypePersistence
                {
                    Id = webRequestJustificationTypes[i].IdTipoJustificacaoPedido,
                    Description = webRequestJustificationTypes[i].Descricao
                });
            }

            return RequestJustificationTypePersistence;
        }

        public static List<RequestStatePersistence> WebRequestStateToPersistence(List<WebRequestState> webRequestStates)
        {
            var RequestStatePersistence = new List<RequestStatePersistence>();
            for (int i = 0; i < webRequestStates.Count; i++)
            {
                RequestStatePersistence.Add(new RequestStatePersistence
                {
                    Id = webRequestStates[i].IdEstadoPedidoMarcacao,
                    Description = webRequestStates[i].Descricao
                });
            }

            return RequestStatePersistence;
        }

        public static List<RequestPersistence> WebRequestToPersistence(List<WebRequest> webRequests)
        {
            var RequestPersistence = new List<RequestPersistence>();
            for (int i = 0; i < webRequests.Count; i++)
            {
                RequestPersistence.Add(new RequestPersistence
                {
                    Id = webRequests[i].IdPedidoMarcacao,
                    Date = webRequests[i].DataPedido,
                    IdUser = webRequests[i].IdUtilizador
                });
            }

            return RequestPersistence;
        }

        public static List<RequestJustificationPersistence> WebRequestJustificationToPersistence(List<WebRequestJustification> webRequestJustifications)
        {
            var RequestJustificationPersistence = new List<RequestJustificationPersistence>();
            for (int i = 0; i < webRequestJustifications.Count; i++)
            {
                RequestJustificationPersistence.Add(new RequestJustificationPersistence
                {
                    Id = webRequestJustifications[i].IdJustificacaoPedidoMarcacao,
                    IdRequest = webRequestJustifications[i].IdPedidoMarcacao,
                    IdRequestConflict = webRequestJustifications[i].IdPedidoMarcacaoConflito,
                    IdRequestJustificationType = webRequestJustifications[i].IdTipoJustificacaoPedido,
                    Justification = webRequestJustifications[i].Justificacao
                });
            }

            return RequestJustificationPersistence;
        }

        public static List<RequestHistoryPersistence> WebRequestHistoriesToPersistence(List<WebRequestHistory> webRequestHistories)
        {
            var RequestHistoriesPersistence = new List<RequestHistoryPersistence>();
            for (int i = 0; i < webRequestHistories.Count; i++)
            {
                RequestHistoriesPersistence.Add(new RequestHistoryPersistence
                {
                    Id = webRequestHistories[i].IdPedidoMarcacaoHistorico,
                    IdRequest = webRequestHistories[i].IdPedidoMarcacao,
                    IdVehicle = webRequestHistories[i].IdVeiculo,
                    IdUser = webRequestHistories[i].IdUtilizador,
                    IdRequestState = webRequestHistories[i].IdEstadoPedidoMarcacao,
                    StartDate = webRequestHistories[i].DataInicio,
                    EndDate = webRequestHistories[i].DataFim,
                    Active = (byte)(webRequestHistories[i].Ativo == true ? 1 : 0)
                });
            }

            return RequestHistoriesPersistence;
        }

        public static string ToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
        }

        public static T FromJson<T>(this string str)
               where T : class
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

    }

}
