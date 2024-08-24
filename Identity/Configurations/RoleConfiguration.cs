using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    //Id = "9c95a9ce-059c-4ace-b1e0-500c24d0e859",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE",
                },

                new IdentityRole
                {
                    //Id = "620288e5-ac30-4751-a24c-29d3f432a666",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                }


                );
        }
    }
}
