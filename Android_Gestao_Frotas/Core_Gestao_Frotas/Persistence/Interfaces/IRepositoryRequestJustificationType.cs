using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Interfaces
{
    interface IRepositoryRequestJustificationType
    {

        Task<int> Insert(RequestJustificationType RequestJustificationType);

        Task<int> InsertAll(List<RequestJustificationType> RequestJustificationTypes);

        Task<int> Delete(RequestJustificationType RequestJustificationType);

        Task<int> DeleteAll(List<RequestJustificationType> RequestJustificationTypes);

        Task<int> Update(RequestJustificationType RequestJustificationType);

        Task<int> Update(List<RequestJustificationType> RequestJustificationTypes);

        Task<int> Insert(RequestJustificationTypePersistence RequestJustificationTypePersistence);

        Task<int> InsertAll(List<RequestJustificationTypePersistence> RequestJustificationTypesPersistence);

        Task<int> Delete(RequestJustificationTypePersistence RequestJustificationTypePersistence);

        Task<int> DeleteAll(List<RequestJustificationTypePersistence> RequestJustificationTypesPersistence);

        Task<int> Update(RequestJustificationTypePersistence RequestJustificationTypePersistence);

        Task<int> Update(List<RequestJustificationTypePersistence> RequestJustificationTypesPersistence);

        Task<RequestJustificationType> Get(int id);

        Task<List<RequestJustificationType>> GetAll();

    }
}
