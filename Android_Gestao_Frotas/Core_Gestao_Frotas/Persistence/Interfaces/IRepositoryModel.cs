using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Interfaces
{
    interface IRepositoryModel
    {

        Task<int> Insert(Model Model);

        Task<int> InsertAll(List<Model> Models);

        Task<int> Delete(Model Model);

        Task<int> DeleteAll(List<Model> Models);

        Task<int> Update(Model Model);

        Task<int> Update(List<Model> Models);

        Task<int> Insert(ModelPersistence ModelPersistence);

        Task<int> InsertAll(List<ModelPersistence> ModelsPersistence);

        Task<int> Delete(ModelPersistence ModelPersistence);

        Task<int> DeleteAll(List<ModelPersistence> ModelsPersistence);

        Task<int> Update(ModelPersistence ModelPersistence);

        Task<int> Update(List<ModelPersistence> ModelsPersistence);

        Task<Model> Get(int id);

        Task<List<Model>> GetAll();

    }
}
