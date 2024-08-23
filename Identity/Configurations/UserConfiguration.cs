using Identity.Models;
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
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                     new ApplicationUser
                     {
                         Id= "0b2544ccddb5fa43",
                         Email="Admin@localhost.com",
                         NormalizedEmail="ADMIN@LOCALHOST.COM",
                         FirstName="Admin",
                         LastName="Sha",
                         UserName="admin@localhost.com",
                         NormalizedUserName= "ADMIN@LOCALHOST.COM",
                         PasswordHash=hasher.HashPassword(null,"p@ssword1"),
                         EmailConfirmed=true,
                     },

                     new ApplicationUser
                     {
                         Id = "f752b721688d256580",
                         Email = "user@localhost.com",
                         NormalizedEmail = "USER@LOCALHOST.COM",
                         FirstName = "System",
                         LastName = "Usr",
                         UserName = "User@localhost.com",
                         NormalizedUserName = "USER@LOCALHOST.COM",
                         PasswordHash = hasher.HashPassword(null, "p@ssword1"),
                         EmailConfirmed = true,
                     }


                );
        }
    }
}
