using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Interfaces
{
    interface IRepositoryRequestJustification
    {

        Task<int> Insert(RequestJustification RequestJustification);

        Task<int> InsertAll(List<RequestJustification> RequestJustifications);

        Task<int> Delete(RequestJustification RequestJustification);

        Task<int> DeleteAll(List<RequestJustification> RequestJustifications);

        Task<int> Update(RequestJustification RequestJustification);

        Task<int> Update(List<RequestJustification> RequestJustifications);

        Task<int> Insert(RequestJustificationPersistence RequestJustificationPersistence);

        Task<int> InsertAll(List<RequestJustificationPersistence> RequestJustificationsPersistence);

        Task<int> Delete(RequestJustificationPersistence RequestJustificationPersistence);

        Task<int> DeleteAll(List<RequestJustificationPersistence> RequestJustificationsPersistence);

        Task<int> Update(RequestJustificationPersistence RequestJustificationPersistence);

        Task<int> Update(List<RequestJustificationPersistence> RequestJustificationsPersistence);

        Task<RequestJustification> Get(int id);

        Task<List<RequestJustification>> GetAll();

    }
}
