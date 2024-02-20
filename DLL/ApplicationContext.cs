using BeautyTrackSystem.DLL.Models.Entities;
using Insurance.DLL.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;


namespace DLL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserEntityModel> Users { get; set; }
        public DbSet<BranchModel> Branches { get; set; }
        public DbSet<AgentModel> Agents { get; set; }
        public DbSet<ContractModel> Contracts { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContractModel>()
                      .HasOne(c => c.Branch)
                      .WithMany(b => b.Contracts)
                      .HasForeignKey(c => c.Id)
                      .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
