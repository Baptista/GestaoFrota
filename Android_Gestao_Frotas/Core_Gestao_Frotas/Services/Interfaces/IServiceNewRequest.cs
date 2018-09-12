using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Services.Interfaces
{
    public interface IServiceNewRequest
    {
        Task<string> NewRequest(Request request);

        Task<string> NewRequestHistory(RequestHistory requesthistory);

        Task<string> ExisteSobreposicao(int IdUtilizador, DateTime startDate, DateTime endDate);
    }
}
