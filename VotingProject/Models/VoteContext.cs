using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace VotingProject.Models
{
    public class VoteContext : DbContext
    {
        public VoteContext()
        {
            
        }
        public virtual DbSet<TbVote> TbVote { get; set; }
        public virtual DbSet<TbVoteResult> TbVoteResult { get; set; }
        public virtual DbSet<TbVoteOption> TbVoteOption { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-0VMM96V;Database=Voting_do;Trusted_Connection=True;Encrypt=False;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbVoteResult>(entity =>
            {
                entity.HasOne(e => e.Vote).WithMany(e => e.VoteResults).HasForeignKey(a => a.VoteId).OnDelete(DeleteBehavior.Restrict);
				entity.HasOne(a => a.Option)
							  .WithMany(e => e.Results)
							  .HasForeignKey(e => e.OptionId);
			    });
            modelBuilder.Entity<TbVoteOption>(entity =>
            {
				entity.HasOne(e => e.Vote)
						   .WithMany(e => e.Options)
						   .HasForeignKey(a => a.VoteId);
			});
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<String>().HaveMaxLength(200);
            configurationBuilder.Properties<decimal>().HaveColumnType("decimal(8,2)");
            configurationBuilder.Properties<DateTime>().HaveColumnType("DateTime");
        }
    }
}
