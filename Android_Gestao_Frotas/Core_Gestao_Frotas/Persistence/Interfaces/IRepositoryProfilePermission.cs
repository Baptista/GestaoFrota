using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Interfaces
{
    public interface IRepositoryProfilePermission
    {
        //Task<int> Insert(Brand brand);

        //Task<int> InsertAll(List<Brand> brands);

        //Task<int> Delete(Brand brand);

        //Task<int> DeleteAll(List<Brand> brands);

        //Task<int> Update(Brand brand);

        //Task<int> Update(List<Brand> brands);

        Task<int> Insert(ProfilePermissionPersistence brandPersistence);

        Task<int> InsertAll(List<ProfilePermissionPersistence> brandsPersistence);

        Task<int> Delete(ProfilePermissionPersistence brandPersistence);

        Task<int> DeleteAll(List<ProfilePermissionPersistence> brandsPersistence);

        Task<int> Update(ProfilePermissionPersistence brandPersistence);

        Task<int> Update(List<ProfilePermissionPersistence> brandsPersistence);

        Task<List<ProfilePermissionPersistence>> GetAllPermissionsOfProfile(int profileId);

        //Task<Brand> Get(int id);

        //Task<List<Brand>> GetAll();
    }
}
