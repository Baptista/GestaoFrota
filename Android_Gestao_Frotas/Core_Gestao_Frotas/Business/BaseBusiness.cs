using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence.Interfaces;
using Core_Gestao_Frotas.Persistence.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business
{
    public class BaseBusiness
    {
        protected static User _user;

        protected static string _appVersion;

        public static ProfileType UserProfileType
        {
            get
            {
                if (_user != null && _user.Profile != null && _user.Profile.IsIncomplete == false)
                {
                    if (_user.Profile.Description.Equals("Administrador"))
                        return ProfileType.Admin;
                    else if (_user.Profile.Description.Equals("Visualizador"))
                        return ProfileType.Validator;
                    else
                        return ProfileType.User;
                }
                else
                {
                    return ProfileType.User;
                }
            }
        }

        private IRepositoryUser _repositoryUser;
        public IRepositoryUser RepositoryUser
        {
            get
            {
                if (_repositoryUser == null)
                    _repositoryUser = new RepositoryUser();

                return _repositoryUser;
            }
            private set
            {
                _repositoryUser = value;
            }
        }
    }
}
