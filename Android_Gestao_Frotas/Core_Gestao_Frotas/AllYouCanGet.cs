using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas
{
    public class AllYouCanGet
    {
        public static User CurrentUser;

        public static RequestHistory CurrentRequest;

        public static ReportProcessData ReportProcess;

        public static EditProfile editprofile;
    }

    public class ReportProcessData
    {
        public DateTime StartDateTime;

        public DateTime EndDateTime;

        public List<Vehicle> SelectedVehicles;

        public List<User> SelectedUsers;

        public int TypeConsult;

        public List<VehicleHistory> ListaFiltrada;

        public VehicleHistory selectedtarget;
    }

    public class EditProfile
    {

        public Dictionary<Permission, bool> CurrentPermissions;

    }

}
