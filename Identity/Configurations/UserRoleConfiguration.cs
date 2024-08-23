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
                    UserId= "ad7fa1aa-3bd2-4d49-a854-39c8b51e85aa",
                    RoleId= "620288e5-ac30-4751-a24c-29d3f432a666"
                },

                new IdentityUserRole<string>
                {
                    UserId = "e770632f-31b4-4ec6-8871-92bf0a26c1e9",
                    RoleId = "9c95a9ce-059c-4ace-b1e0-500c24d0e859"
                }
                );
        }
    }
}
