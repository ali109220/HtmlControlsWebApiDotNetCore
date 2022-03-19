using HtmlControlsWebApiDotNetCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlControlsWebApiDotNetCore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>  
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<HtmlDocument> HtmlDocuments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HtmlDocument>()
                .HasOne(p => p.User);
            modelBuilder.Entity<HtmlControl>()
                .HasOne(p => p.HtmlDocument)
                .WithMany(x=> x.HtmlControls);
        }
    }
}
