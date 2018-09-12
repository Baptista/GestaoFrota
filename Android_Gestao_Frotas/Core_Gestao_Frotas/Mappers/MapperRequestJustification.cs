using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Mappers
{
    class MapperRequestJustification
    {

        public static RequestJustificationPersistence ToPersistence(RequestJustification RequestJustification)
        {
            var RequestJustificationPersistence = new RequestJustificationPersistence()
            {
                Id = RequestJustification.Id,
                Justification = RequestJustification.Justification,
                //TODO
                //RequestJustificationType = RequestJustification.IdRequestJustificationType
                //Request = RequestJustification.IdRequest
            };

            return RequestJustificationPersistence;
        }

        public static List<RequestJustificationPersistence> ToPersistence(List<RequestJustification> RequestJustifications)
        {
            var RequestJustificationsPersistence = new List<RequestJustificationPersistence>();

            foreach (var RequestJustification in RequestJustifications)
            {
                RequestJustificationsPersistence.Add(new RequestJustificationPersistence()
                {
                    Id = RequestJustification.Id,
                    Justification = RequestJustification.Justification,
                    //TODO
                    //RequestJustificationType = RequestJustification.IdRequestJustificationType
                    //Request = RequestJustification.IdRequest
                });
            }

            return RequestJustificationsPersistence;
        }

        public static RequestJustification ToModel(RequestJustificationPersistence RequestJustificationPersistence)
        {
            var RequestJustification = new RequestJustification()
            {
                Id = RequestJustificationPersistence.Id,
                Justification = RequestJustificationPersistence.Justification,
                //TODO
                //RequestJustificationType = RequestJustificationPersistence.IdRequestJustificationType
                //Request = RequestJustificationPersistence.IdRequest
            };

            return RequestJustification;
        }

        public static List<RequestJustification> ToModel(List<RequestJustificationPersistence> RequestJustificationsPersistence)
        {
            var RequestJustifications = new List<RequestJustification>();

            foreach (var RequestJustificationPersistence in RequestJustificationsPersistence)
            {
                RequestJustifications.Add(new RequestJustification()
                {
                    Id = RequestJustificationPersistence.Id,
                    Justification = RequestJustificationPersistence.Justification,
                    //TODO
                    //RequestJustificationType = RequestJustificationPersistence.IdRequestJustificationType
                    //Request = RequestJustificationPersistence.IdRequest
                });
            }

            return RequestJustifications;
        }

    }
}