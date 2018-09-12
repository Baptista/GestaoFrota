using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Models
{
    public class BaseModel
    {
        public const int Null = -111;

        public bool IsIncomplete { get; set; }

        public BaseModel()
        {
            IsIncomplete = false;
        }
    }
}
