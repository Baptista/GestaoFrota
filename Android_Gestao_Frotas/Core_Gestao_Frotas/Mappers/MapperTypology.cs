using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Mappers
{
    class MapperTypology
    {

        public static TypologyPersistence ToPersistence(Typology Typology)
        {
            var TypologyPersistence = new TypologyPersistence()
            {
                Id = Typology.Id,
                Description = Typology.Description,
                Active = (byte)(Typology.Active == true ? 1 : 0)
            };

            return TypologyPersistence;
        }

        public static List<TypologyPersistence> ToPersistence(List<Typology> Typologys)
        {
            var TypologysPersistence = new List<TypologyPersistence>();

            foreach (var Typology in Typologys)
            {
                TypologysPersistence.Add(new TypologyPersistence()
                {
                    Id = Typology.Id,
                    Description = Typology.Description,
                    Active = (byte)(Typology.Active == true ? 1 : 0)
                });
            }

            return TypologysPersistence;
        }

        public static Typology ToModel(TypologyPersistence TypologyPersistence)
        {
            var Typology = new Typology()
            {
                Id = TypologyPersistence.Id,
                Description = TypologyPersistence.Description,
                Active = TypologyPersistence.Active == 1 ? true : false
            };

            return Typology;
        }

        public static List<Typology> ToModel(List<TypologyPersistence> TypologysPersistence)
        {
            var Typologys = new List<Typology>();

            foreach (var TypologyPersistence in TypologysPersistence)
            {
                Typologys.Add(new Typology()
                {
                    Id = TypologyPersistence.Id,
                    Description = TypologyPersistence.Description,
                    Active = TypologyPersistence.Active == 1 ? true : false
                });
            }

            return Typologys;
        }

    }
}