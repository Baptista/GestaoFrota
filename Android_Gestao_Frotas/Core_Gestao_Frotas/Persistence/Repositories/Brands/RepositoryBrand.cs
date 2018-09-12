using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Mappers;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Repositories.Brands
{
    public class RepositoryBrand : BaseRepository, IRepositoryBrand
    {
        public async Task<int> Insert(Brand Brand)
        {
            var persistence = MapperBrand.ToPersistence(Brand);
            var result = await DBConnection.InsertOrReplaceAsync(persistence);
            return result;
        }

        public async Task<int> InsertAll(List<Brand> Brands)
        {
            var persistences = MapperBrand.ToPersistence(Brands);
            var result = await DBConnection.InsertOrReplaceAllAsync(persistences);
            return result;
        }

        public async Task<int> Delete(Brand Brand)
        {
            var persistence = MapperBrand.ToPersistence(Brand);
            var result = await DBConnection.DeleteAsync(persistence);
            return result;
        }

        public async Task<int> DeleteAll(List<Brand> Brands)
        {
            var persistences = MapperBrand.ToPersistence(Brands);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<int> Update(Brand Brand)
        {
            var persistence = MapperBrand.ToPersistence(Brand);
            var result = await DBConnection.UpdateAsync(persistence);
            return result;
        }

        public async Task<int> Update(List<Brand> Brands)
        {
            var persistences = MapperBrand.ToPersistence(Brands);
            var result = await DBConnection.DeleteAsync(persistences);
            return result;
        }

        public async Task<Brand> Get(int id)
        {
            var persistence = await DBConnection.GetAsync<BrandPersistence>(conf => conf.Id == id);
            var Brand = MapperBrand.ToModel(persistence);
            return Brand;
        }

        public async Task<List<Brand>> GetAll()
        {
            var persistences = await DBConnection.Table<BrandPersistence>().OrderBy(m => m.Id).ToListAsync();
            var Brands = MapperBrand.ToModel(persistences);
            return Brands;
        }

        public async Task<int> Insert(BrandPersistence BrandPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAsync(BrandPersistence);
            return result;
        }

        public async Task<int> InsertAll(List<BrandPersistence> BrandsPersistence)
        {
            var result = await DBConnection.InsertOrReplaceAllAsync(BrandsPersistence);
            return result;
        }

        public async Task<int> Delete(BrandPersistence BrandPersistence)
        {
            var result = await DBConnection.DeleteAsync(BrandPersistence);
            return result;
        }

        public async Task<int> DeleteAll(List<BrandPersistence> BrandsPersistence)
        {
            var result = await DBConnection.DeleteAsync(BrandsPersistence);
            return result;
        }

        public async Task<int> Update(BrandPersistence BrandPersistence)
        {
            var result = await DBConnection.UpdateAsync(BrandPersistence);
            return result;
        }

        public async Task<int> Update(List<BrandPersistence> BrandsPersistence)
        {
            var result = await DBConnection.UpdateAsync(BrandsPersistence);
            return result;
        }
    }
}