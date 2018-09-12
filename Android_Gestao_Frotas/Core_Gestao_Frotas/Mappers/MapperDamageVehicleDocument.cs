using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Mappers
{
    public class MapperDamageVehicleDocument
    {
        public static DamageVehicleDocumentPersistence ToPersistence(DamageVehicleDocument DamageVehicleDocument)
        {
            var DamageVehicleDocumentPersistence = new DamageVehicleDocumentPersistence()
            {
                Id = DamageVehicleDocument.Id,
                Active = (byte) (DamageVehicleDocument.Active ? 1 : 0),
                Date = DamageVehicleDocument.Date,
                Document = DamageVehicleDocument.Document,
                DocumentFormat = DamageVehicleDocument.DocumentFormat,
                DocumentName = DamageVehicleDocument.DocumentName,
                //TODO:
                //DamageVehicle = DamageVehicleDocument.IdDamageVehicle
            };

            return DamageVehicleDocumentPersistence;
        }

        public static List<DamageVehicleDocumentPersistence> ToPersistence(List<DamageVehicleDocument> DamageVehicleDocuments)
        {
            var DamageVehicleDocumentsPersistence = new List<DamageVehicleDocumentPersistence>();

            foreach (var DamageVehicleDocument in DamageVehicleDocuments)
            {
                DamageVehicleDocumentsPersistence.Add(new DamageVehicleDocumentPersistence()
                {
                    Id = DamageVehicleDocument.Id,
                    Active = (byte) (DamageVehicleDocument.Active ? 1 : 0),
                    Date = DamageVehicleDocument.Date,
                    Document = DamageVehicleDocument.Document,
                    DocumentFormat = DamageVehicleDocument.DocumentFormat,
                    DocumentName = DamageVehicleDocument.DocumentName,
                    //TODO:
                    //DamageVehicle = DamageVehicleDocument.IdDamageVehicle
                });
            }

            return DamageVehicleDocumentsPersistence;
        }

        public static DamageVehicleDocument ToModel(DamageVehicleDocumentPersistence DamageVehicleDocumentPersistence)
        {
            var DamageVehicleDocument = new DamageVehicleDocument()
            {
                Id = DamageVehicleDocumentPersistence.Id,
                Active = DamageVehicleDocumentPersistence.Active == 1 ? true : false,
                Date = DamageVehicleDocumentPersistence.Date,
                Document = DamageVehicleDocumentPersistence.Document,
                DocumentFormat = DamageVehicleDocumentPersistence.DocumentFormat,
                DocumentName = DamageVehicleDocumentPersistence.DocumentName,
                //TODO:
                //DamageVehicle = DamageVehicleDocumentPersistence.IdDamageVehicle
            };

            return DamageVehicleDocument;
        }

        public static List<DamageVehicleDocument> ToModel(List<DamageVehicleDocumentPersistence> DamageVehicleDocumentsPersistence)
        {
            var DamageVehicleDocuments = new List<DamageVehicleDocument>();

            foreach (var DamageVehicleDocumentPersistence in DamageVehicleDocumentsPersistence)
            {
                DamageVehicleDocuments.Add(new DamageVehicleDocument()
                {
                    Id = DamageVehicleDocumentPersistence.Id,
                    Active = DamageVehicleDocumentPersistence.Active == 1 ? true : false,
                    Date = DamageVehicleDocumentPersistence.Date,
                    Document = DamageVehicleDocumentPersistence.Document,
                    DocumentFormat = DamageVehicleDocumentPersistence.DocumentFormat,
                    DocumentName = DamageVehicleDocumentPersistence.DocumentName,
                    //TODO:
                    //DamageVehicle = DamageVehicleDocumentPersistence.IdDamageVehicle
                });
            }

            return DamageVehicleDocuments;
        }
    }
}