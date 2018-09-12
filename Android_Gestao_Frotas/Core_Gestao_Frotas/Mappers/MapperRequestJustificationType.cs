using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Mappers
{
    class MapperRequestJustificationType
    {

        public static RequestJustificationTypePersistence ToPersistence(RequestJustificationType RequestJustificationType)
        {
            var RequestJustificationTypePersistence = new RequestJustificationTypePersistence()
            {
                Id = RequestJustificationType.Id,
                Description = RequestJustificationType.Description
            };

            return RequestJustificationTypePersistence;
        }

        public static List<RequestJustificationTypePersistence> ToPersistence(List<RequestJustificationType> RequestJustificationTypes)
        {
            var RequestJustificationTypesPersistence = new List<RequestJustificationTypePersistence>();

            foreach (var RequestJustificationType in RequestJustificationTypes)
            {
                RequestJustificationTypesPersistence.Add(new RequestJustificationTypePersistence()
                {
                    Id = RequestJustificationType.Id,
                    Description = RequestJustificationType.Description
                });
            }

            return RequestJustificationTypesPersistence;
        }

        public static RequestJustificationType ToModel(RequestJustificationTypePersistence RequestJustificationTypePersistence)
        {
            var RequestJustificationType = new RequestJustificationType()
            {
                Id = RequestJustificationTypePersistence.Id,
                Description = RequestJustificationTypePersistence.Description
            };

            return RequestJustificationType;
        }

        public static List<RequestJustificationType> ToModel(List<RequestJustificationTypePersistence> RequestJustificationTypesPersistence)
        {
            var RequestJustificationTypes = new List<RequestJustificationType>();

            foreach (var RequestJustificationTypePersistence in RequestJustificationTypesPersistence)
            {
                RequestJustificationTypes.Add(new RequestJustificationType()
                {
                    Id = RequestJustificationTypePersistence.Id,
                    Description = RequestJustificationTypePersistence.Description
                });
            }

            return RequestJustificationTypes;
        }

    }
}