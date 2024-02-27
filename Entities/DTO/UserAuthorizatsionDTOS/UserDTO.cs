using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.UserAuthorizatsionDTOS
{
    public class UserDTO
    {
        public int Id { get; set; }
        public required string Login { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
    }
}
