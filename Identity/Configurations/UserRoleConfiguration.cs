using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId= "d9101822-1bb1-4e65-adf9-d9451b65c635",
                    RoleId= "620288e5-ac30-4751-a24c-29d3f432a666"
                },

                new IdentityUserRole<string>
                {
                    UserId = "83dba700-a83b-44fd-b97e-7b5942ef1d83",
                    RoleId = "9c95a9ce-059c-4ace-b1e0-500c24d0e859"
                }
                );
        }
    }
}
