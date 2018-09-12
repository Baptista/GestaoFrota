using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Interfaces
{
    interface IRepositoryRequestHistory
    {
        Task<int> Insert(RequestHistory RequestHistory);

        Task<int> InsertAll(List<RequestHistory> RequestHistorys);

        Task<int> Delete(RequestHistory RequestHistory);

        Task<int> DeleteAll(List<RequestHistory> RequestHistorys);

        Task<int> Update(RequestHistory RequestHistory);

        Task<int> Update(List<RequestHistory> RequestHistorys);

        Task<int> Insert(RequestHistoryPersistence RequestHistoryPersistence);

        Task<int> InsertAll(List<RequestHistoryPersistence> RequestHistorysPersistence);

        Task<int> Delete(RequestHistoryPersistence RequestHistoryPersistence);

        Task<int> DeleteAll(List<RequestHistoryPersistence> RequestHistorysPersistence);

        Task<int> Update(RequestHistoryPersistence RequestHistoryPersistence);

        Task<int> Update(List<RequestHistoryPersistence> RequestHistorysPersistence);

        Task<RequestHistory> Get(int id);

        Task<List<RequestHistory>> GetAll();

        Task<List<RequestHistory>> GetTopThreeRequestHistoriesForApproval();

        Task<List<RequestHistory>> GetTopThreeRequestHistoriesForApproval(int userId);

        Task<List<RequestHistory>> GetTopThreeRequestHistoriesUnavailable();

        Task<List<RequestHistory>> GetTopThreeRequestHistoriesUnavailable(int userId);

        Task<List<RequestHistory>> GetTopThreeRequestHistoriesEncourse();

        Task<List<RequestHistory>> GetTopThreeRequestHistoriesEncourse(int userId);

        Task<List<RequestHistory>> GetRequestHistoriesBetween(DateTime startDate, DateTime endDate);
    }
}
