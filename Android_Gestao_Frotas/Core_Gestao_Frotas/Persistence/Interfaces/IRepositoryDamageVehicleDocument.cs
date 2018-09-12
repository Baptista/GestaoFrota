using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Interfaces
{
    interface IRepositoryDamageVehicleDocument
    {

        Task<int> Insert(DamageVehicleDocument DamageVehicleDocument);

        Task<int> InsertAll(List<DamageVehicleDocument> DamageVehicleDocuments);

        Task<int> Delete(DamageVehicleDocument DamageVehicleDocument);

        Task<int> DeleteAll(List<DamageVehicleDocument> DamageVehicleDocuments);

        Task<int> Update(DamageVehicleDocument DamageVehicleDocument);

        Task<int> Update(List<DamageVehicleDocument> DamageVehicleDocuments);

        Task<int> Insert(DamageVehicleDocumentPersistence DamageVehicleDocumentPersistence);

        Task<int> InsertAll(List<DamageVehicleDocumentPersistence> DamageVehicleDocumentsPersistence);

        Task<int> Delete(DamageVehicleDocumentPersistence DamageVehicleDocumentPersistence);

        Task<int> DeleteAll(List<DamageVehicleDocumentPersistence> DamageVehicleDocumentsPersistence);

        Task<int> Update(DamageVehicleDocumentPersistence DamageVehicleDocumentPersistence);

        Task<int> Update(List<DamageVehicleDocumentPersistence> DamageVehicleDocumentsPersistence);

        Task<DamageVehicleDocument> Get(int id);

        Task<List<DamageVehicleDocument>> GetAll();

    }
}
