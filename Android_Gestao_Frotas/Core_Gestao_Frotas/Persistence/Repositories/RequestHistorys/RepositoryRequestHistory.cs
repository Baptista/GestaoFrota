using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;

namespace Core_Gestao_Frotas.Persistence.Repositories.RequestHistorys
{
    class RepositoryRequestHistory: BaseRepository, IRepositoryRequestHistory
    {
        public async Task<int> Insert(RequestHistory RequestHistory)
        {
            var persistence = MapperRequestHistory.ToPersistence(RequestHistory);
            var result = await DBConnection.InsertOrReplaceAsync(persistence);
            return result;
        }

        public async Task<int> InsertAll(List<RequestHistory> RequestHistorys)
        {
            var persistences = MapperRequestHistory.ToPersistence(RequestHistorys);
            var result = await DBConnection.InsertOrReplaceAllAsync(persistences);
            return result;
        }

        public async Task<int> Delete(RequestHistory RequestHistory)
        {
            var persistence = MapperRequestHistory.ToPersistence(RequestHistory);
            var result = await DBConnection.DeleteAsync(persistence);
            return result;
        }

        public async Task<int> DeleteAll(List<RequestHistory> RequestHistorys)
        {
            var persistences = MapperRequestHistory.ToPersistence(RequestHistorys);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<int> Update(RequestHistory RequestHistory)
        {
            var persistence = MapperRequestHistory.ToPersistence(RequestHistory);
            var result = await DBConnection.UpdateAsync(persistence);
            return result;
        }

        public async Task<int> Update(List<RequestHistory> RequestHistorys)
        {
            var persistences = MapperRequestHistory.ToPersistence(RequestHistorys);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<RequestHistory> Get(int id)
        {
            var persistence = await DBConnection.GetAsync<RequestHistoryPersistence>(conf => conf.Id == id);
            var RequestHistory = MapperRequestHistory.ToModel(persistence);
            return RequestHistory;
        }

        public async Task<List<RequestHistory>> GetAll()
        {
            var persistences = await DBConnection.Table<RequestHistoryPersistence>().OrderBy(m => m.Id).ToListAsync();
            var RequestHistorys = MapperRequestHistory.ToModel(persistences);
            return RequestHistorys;
        }

        public async Task<int> Insert(RequestHistoryPersistence RequestHistoryPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAsync(RequestHistoryPersistence);
            return result;
        }

        public async Task<int> InsertAll(List<RequestHistoryPersistence> RequestHistorysPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAllAsync(RequestHistorysPersistence);
            return result;
        }

        public async Task<int> Delete(RequestHistoryPersistence RequestHistoryPersistence)
        {
            var result = await DBConnection.DeleteAsync(RequestHistoryPersistence);
            return result;
        }

        public async Task<int> DeleteAll(List<RequestHistoryPersistence> RequestHistorysPersistence)
        {
            var result = await DBConnection.DeleteAsync(RequestHistorysPersistence);
            return result;
        }

        public async Task<int> Update(RequestHistoryPersistence RequestHistoryPersistence)
        {
            var result = await DBConnection.UpdateAsync(RequestHistoryPersistence);
            return result;
        }

        public async Task<int> Update(List<RequestHistoryPersistence> RequestHistorysPersistence)
        {
            var result = await DBConnection.UpdateAsync(RequestHistorysPersistence);
            return result;
        }

        public async Task<List<RequestHistory>> GetTopThreeRequestHistoriesForApproval()
        {
            var result = await DBConnection.Table<RequestHistoryPersistence>().Where(rh => rh.IdRequestState == 2 && rh.Active == 1).Take(3).ToListAsync();
            var requestHistoriesToApprove = MapperRequestHistory.ToModel(result);
            return requestHistoriesToApprove;
        }

        public async Task<List<RequestHistory>> GetTopThreeRequestHistoriesForApproval(int userId)
        {
            var result = await DBConnection.Table<RequestHistoryPersistence>().Where(rh => rh.IdRequestState == 2 && rh.IdUser == userId && rh.Active == 1).Take(3).ToListAsync();
            var requestHistoriesToApprove = MapperRequestHistory.ToModel(result);
            return requestHistoriesToApprove;
        }

        public async Task<List<RequestHistory>> GetTopThreeRequestHistoriesUnavailable()
        {
            var result = await DBConnection.Table<RequestHistoryPersistence>().Where(rh => rh.IdRequestState == 1 && rh.EndDate < DateTime.Now && rh.Active == 1).Take(3).ToListAsync();
            var requestHistoriesUnavailable = MapperRequestHistory.ToModel(result);
            return requestHistoriesUnavailable;
        }

        public async Task<List<RequestHistory>> GetTopThreeRequestHistoriesUnavailable(int userId)
        {
            var result = await DBConnection.Table<RequestHistoryPersistence>().Where(rh => rh.IdRequestState == 1 && rh.IdUser == userId && rh.EndDate < DateTime.Now && rh.Active == 1).Take(3).ToListAsync();
            var requestHistoriesUnavailable = MapperRequestHistory.ToModel(result);
            return requestHistoriesUnavailable;
        }

        public async Task<List<RequestHistory>> GetTopThreeRequestHistoriesEncourse()
        {
            var result = await DBConnection.Table<RequestHistoryPersistence>().Where(rh => rh.IdRequestState == 1 && rh.Active == 1).Take(3).ToListAsync();
            var requestHistoriesEncourse = MapperRequestHistory.ToModel(result);
            return requestHistoriesEncourse;
        }

        public async Task<List<RequestHistory>> GetTopThreeRequestHistoriesEncourse(int userId)
        {
            var result = await DBConnection.Table<RequestHistoryPersistence>().Where(rh => rh.IdRequestState == 1 && rh.IdUser == userId && rh.Active == 1).Take(3).ToListAsync();
            var requestHistoriesEncourse = MapperRequestHistory.ToModel(result);
            return requestHistoriesEncourse;
        }

        public async Task<List<RequestHistory>> GetRequestHistoriesBetween(DateTime startDate, DateTime endDate)
        {
            var result = await DBConnection.Table<RequestHistoryPersistence>().Where(rh => endDate >= rh.StartDate && startDate <= rh.EndDate && rh.IdRequestState > 0 && rh.IdRequestState < 3).ToListAsync();
            var requestHistoriesBetweenDates = MapperRequestHistory.ToModel(result);
            return requestHistoriesBetweenDates;
        }
    }
}
