using KASSS.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KASSS.Data
{
    public class AppDbContext : IdentityDbContext<Customer, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)

        {
        }

        public DbSet<RefreshToken> UserRefreshTokens { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Button> Buttons { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
    }
}
