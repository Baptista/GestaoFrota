using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Interfaces
{
    public interface IRepositoryBrand
    {
        Task<int> Insert(Brand brand);

        Task<int> InsertAll(List<Brand> brands);

        Task<int> Delete(Brand brand);

        Task<int> DeleteAll(List<Brand> brands);

        Task<int> Update(Brand brand);

        Task<int> Update(List<Brand> brands);

        Task<int> Insert(BrandPersistence brandPersistence);

        Task<int> InsertAll(List<BrandPersistence> brandsPersistence);

        Task<int> Delete(BrandPersistence brandPersistence);

        Task<int> DeleteAll(List<BrandPersistence> brandsPersistence);

        Task<int> Update(BrandPersistence brandPersistence);

        Task<int> Update(List<BrandPersistence> brandsPersistence);

        Task<Brand> Get(int id);

        Task<List<Brand>> GetAll();
    }
}
