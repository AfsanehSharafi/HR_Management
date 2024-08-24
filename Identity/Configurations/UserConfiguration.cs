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
                         //Id= "d9101822-1bb1-4e65-adf9-d9451b65c635",
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
                         //Id = "83dba700-a83b-44fd-b97e-7b5942ef1d83",
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
