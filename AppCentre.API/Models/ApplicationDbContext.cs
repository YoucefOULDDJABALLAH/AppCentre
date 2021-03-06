using AppCentre.API.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;

namespace AppCentre.API.Models
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var AppId = Guid.NewGuid().ToString();
            var roleId = Guid.NewGuid().ToString();
            var userID = Guid.NewGuid().ToString();

            builder.Entity<Applications>()
                .HasData(new Applications
                {
                    ApplicationsID = AppId,
                    ApplicationsName = "Applications Centre",
                    ShortName = "AppCentre"
                });

            builder.Entity<ApplicationRole>()
                .HasData(new ApplicationRole
                {
                    Name = "Developer",
                    ApplicationsID = AppId,
                    Id = roleId,
                    NormalizedName = "Developer",
                    ConcurrencyStamp= Guid.NewGuid().ToString()
                });

            builder.Entity<ApplicationUser>()
                .HasData(new ApplicationUser
                {
                    Matricule = "3K174",
                    Grade=15,
                    NN = 400123,
                    Service = $"16H\\",
                    Nom="Youcef",
                    Prenom = "OULD DJABALLAH",
                    UserName= "Youcef_OULD_DJABALLAH",
                    Email = "Youcef_OULD_DJABALLAH@AppCentre.DRH",
                    EmailConfirmed=true,
                    NormalizedEmail= "Youcef_OULD_DJABALLAH@AppCentre.DRH",
                    Id= userID,
                    PasswordHash= "AQAAAAEAACcQAAAAEFrD4XmGRepWphfE3SfRIKMGJQI2PGSyI0IAbJ5d12GVffkmOExbTP/DVnwO8n/+tg==" // Password Dgsn_2020
                });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> {RoleId=roleId,UserId=userID}); 
        }
       
        public DbSet<Applications> AspNetApplications { get; set; }
    }
}
