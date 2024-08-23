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
                         Id= "ad7fa1aa-3bd2-4d49-a854-39c8b51e85aa",
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
                         Id = "e770632f-31b4-4ec6-8871-92bf0a26c1e9",
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
