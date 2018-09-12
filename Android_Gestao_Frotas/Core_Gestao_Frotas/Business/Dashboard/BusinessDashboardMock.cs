using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Dashboard
{
    public class BusinessDashboardMock : BaseBusiness, IBusinessDashboard
    {
        public Task<bool> AddJustification(RequestJustification requestJustification, int conflitID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ApproveRequest(RequestHistory requesthistory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CancelRequest(RequestHistory request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeUserPassword(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Configuration>> GetConfigurations()
        {
            throw new NotImplementedException();
        }

        public User GetCurrentUser()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetNewUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<RequestHistory> GetRequestHistory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RequestHistory>> GetRequestsActive()
        {
            await Task.Delay(2000);

            var requests = new List<RequestHistory>();

            for (var count = 0; count < 3; count++)
                requests.Add(new RequestHistory()
                {
                    Id = count,
                    User = new User()
                    {
                        Id = 1,
                        Name = "André Reis",
                        Profile = new Profile()
                        {
                            Id = 2,
                            Description = "Utilizador"
                        }
                    }
                });

            return requests;
        }

        public Task<IEnumerable<RequestHistory>> GetRequestsActiveAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RequestHistory>> GetRequestsActiveUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RequestHistory>> GetRequestsActiveUserVehicle(User user, Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RequestHistory>> GetRequestsCurso(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RequestHistory>> GetRequestsEncourse()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Request>> GetRequestsForApproval()
        {
            await Task.Delay(2000);

            var requests = new List<Request>();

            for (var count = 0; count < 3; count++)
                requests.Add(new Request()
                {
                    Id = count,
                    RequestDate = DateTime.Now,
                    User = new User() {
                        Id = 1,
                        Name = "André Reis",
                        Profile = new Profile() {
                            Id = 2,
                            Description = "Utilizador"
                        }
                    }
                });

            return requests;
        }

        public async Task<IEnumerable<Request>> GetRequestsUnavailable()
        {
            await Task.Delay(2000);

            var requests = new List<Request>();

            for (var count = 0; count < 3; count++)
                requests.Add(new Request()
                {
                    Id = count,
                    RequestDate = DateTime.Now,
                    User = new User()
                    {
                        Id = 1,
                        Name = "André Reis",
                        Profile = new Profile()
                        {
                            Id = 2,
                            Description = "Utilizador"
                        }
                    }
                });

            return requests;
        }

        public Task<IEnumerable<User>> GetUsersRepository()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VehicleHistory>> GetVehicleHistory()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vehicle>> GetVehiclesRepository()
        {
            throw new NotImplementedException();
        }

        public Task<bool> LoadRequests()
        {
            throw new NotImplementedException();
        }

        public Task<bool> LoadVehicles()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<RequestHistory>> IBusinessDashboard.GetRequestsForApproval()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<RequestHistory>> IBusinessDashboard.GetRequestsUnavailable()
        {
            throw new NotImplementedException();
        }
    }
}
