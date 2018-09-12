using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Models
{
    public class Permission : BaseModel
    {
        public const string ConfigDefaultPassword = "config_default_password";
        public const string ViewProfiles = "view_profiles";
        public const string ManageProfiles = "manage_profiles";
        public const string ViewUsers = "view_users";
        public const string ManageUsers = "manage_users";
        public const string ResetUserPassword = "reset_users_password";
        public const string ViewBrands = "view_brands";
        public const string ManageBrands = "manage_brands";
        public const string ViewTypologies = "view_typologies";
        public const string ManageTypologies = "manage_typologies";
        public const string ViewModels = "view_models";
        public const string ManageModels = "manage_models";
        public const string ViewVehicles = "view_vehicles";
        public const string ManageVehicles = "manage_vehicles";
        public const string CancelUserRequests = "cancel_users_request";
        public const string ApproveUserRequests = "approve_users_request";
        public const string EditUserRequests = "edit_users_request";
        public const string MakeVehicleAvailable = "make_vehicle_available";
        public const string ViewUserRequests = "view_user_requests";
        public const string ViewUserRequestDetails = "view_users_request_detail";
        public const string ViewUserRequestsEncourse = "view_users_request_encourse";
        public const string ViewUserRequestsEncourseDetails = "view_users_request_encourse_detail";
        public const string GenerateUserReport = "generate_users_report";

        public int Id { get; set; }

        public string Description { get; set; }

        public Permission()
        {

        }

        public override string ToString()
        {
            return Description;
        }

    }
}
