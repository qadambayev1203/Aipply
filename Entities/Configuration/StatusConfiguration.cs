using Entities.Model.AuthorizationModel;
using Entities.Model.StatusesModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasData(
                new Status { id = 1, status = "active" },
                new Status { id = 2, status = "talked" },
                new Status { id = 3, status = "rejected" },
                new Status { id = 4, status = "consent" }
                );

        }
    }
}
