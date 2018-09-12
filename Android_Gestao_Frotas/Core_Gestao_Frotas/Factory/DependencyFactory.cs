using Core_Gestao_Frotas.Services.Interfaces;
using Core_Gestao_Frotas.Services.Splash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Factory
{
    public class DependencyFactory<T>
    {
        public static object Instantiate<T>()
        {
            if (typeof(T) is IServiceSplash)
                return new ServiceSplash();
            else
                return null;
        }
    }
}
