using Entities.Model.UserTypesModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.UsersModel
{
    public class User
    {
        public int id { get; set; }
        public required string login { get; set; }
        public required string password { get; set; }
        public string? email { get; set; }
        public string? token { get; set; }
        [ForeignKey("UserType")] public required int? user_type_id { get; set; }
        public UserType? user_type_ { get; set; }
    }
}
