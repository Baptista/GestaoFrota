using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Mappers
{
    class MapperBrand
    {

        public static BrandPersistence ToPersistence(Brand brand)
        {
            var brandPersistence = new BrandPersistence()
            {
                Id = brand.Id,
                Description = brand.Description,
                Active = (byte)(brand.Active == true ? 1 : 0)
            };

            return brandPersistence;
        }

        public static List<BrandPersistence> ToPersistence(List<Brand> brands)
        {
            var brandsPersistence = new List<BrandPersistence>();

            foreach (var brand in brands)
            {
                brandsPersistence.Add(new BrandPersistence()
                {
                    Id = brand.Id,
                    Description = brand.Description,
                    Active = (byte)(brand.Active == true ? 1 : 0)
                });
            }

            return brandsPersistence;
        }

        public static Brand ToModel(BrandPersistence brandsPersistence)
        {
            var brand = new Brand()
            {
                Id = brandsPersistence.Id,
                Description = brandsPersistence.Description,
                Active = brandsPersistence.Active == 1 ? true : false
            };

            return brand;
        }

        public static List<Brand> ToModel(List<BrandPersistence> brandsPersistence)
        {
            var brands = new List<Brand>();

            foreach (var brandPersistence in brandsPersistence)
            {
                brands.Add(new Brand()
                {
                    Id = brandPersistence.Id,
                    Active = brandPersistence.Active == 1 ? true : false,
                    Description = brandPersistence.Description
                });
            }

            return brands;
        }

    }
}
