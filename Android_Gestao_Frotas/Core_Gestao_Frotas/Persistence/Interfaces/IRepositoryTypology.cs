using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Persistence.Interfaces
{
    interface IRepositoryTypology
    {

        Task<int> Insert(Typology Typology);

        Task<int> InsertAll(List<Typology> Typologys);

        Task<int> Delete(Typology Typology);

        Task<int> DeleteAll(List<Typology> Typologys);

        Task<int> Update(Typology Typology);

        Task<int> Update(List<Typology> Typologys);

        Task<int> Insert(TypologyPersistence TypologyPersistence);

        Task<int> InsertAll(List<TypologyPersistence> TypologysPersistence);

        Task<int> Delete(TypologyPersistence TypologyPersistence);

        Task<int> DeleteAll(List<TypologyPersistence> TypologysPersistence);

        Task<int> Update(TypologyPersistence TypologyPersistence);

        Task<int> Update(List<TypologyPersistence> TypologysPersistence);

        Task<Typology> Get(int id);

        Task<List<Typology>> GetAll();

    }
}
