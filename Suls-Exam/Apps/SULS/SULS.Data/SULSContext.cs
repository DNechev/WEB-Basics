namespace SULS.Data
{
    using Microsoft.EntityFrameworkCore;
    using SULS.Models;

    public class SULSContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Problem> Problems { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SulsDbSettings.connectionString);

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);

            modelBuilder.Entity<Problem>().HasKey(p => p.Id);

            modelBuilder.Entity<Submission>().HasKey(s => s.Id);

            modelBuilder.Entity<Submission>().Property(s => s.Code).HasColumnType("text").HasMaxLength(800);

            modelBuilder.Entity<Submission>().HasOne<User>(s => s.User)
                 .WithMany(u => u.Submissions)
                 .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Submission>().HasOne<Problem>(s => s.Problem)
                 .WithMany(p => p.Submissions)
                 .HasForeignKey(s => s.ProblemId);

            base.OnModelCreating(modelBuilder);
        }
    }
}