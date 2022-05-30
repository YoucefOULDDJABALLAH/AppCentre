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
            var RoleId = Guid.NewGuid().ToString();
            var UserID = Guid.NewGuid().ToString();

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
                    Id = RoleId,
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
                    Id= UserID,
                    PasswordHash= getHashedPassword("Dgsn_2020")


                });
        }
        private string getHashedPassword(string password) 
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            
            return hashed;
        }
        public DbSet<Applications> AspNetApplications { get; set; }
    }
}
