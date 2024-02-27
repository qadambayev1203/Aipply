using Entities.Model.UsersModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Model.AuthorizationModel;
using System.Net;

namespace Entities.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    id = 1,
                    login = "admin",
                    password = PasswordManager.EncryptPassword(("admin" + "admin123").ToString()),
                    email = "aippy@gmail.com",
                    user_type_id = 1
                });

        }
    }
}
