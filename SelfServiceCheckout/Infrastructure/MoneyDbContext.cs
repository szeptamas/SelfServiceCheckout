using Microsoft.EntityFrameworkCore;

namespace SelfServiceCheckout.Infrastructure
{
	public class MoneyDbContext : DbContext
	{
		public DbSet<Money> Money { get; set; }

		public MoneyDbContext(DbContextOptions<MoneyDbContext> options) : base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			CreateMoney(modelBuilder);
		}

		private void CreateMoney(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Money>().ToTable(nameof(Money));
			modelBuilder.Entity<Money>().HasKey(x => x.Id);

			modelBuilder.Entity<Money>()
			 .Property(x => x.Id)
			 .HasDefaultValueSql("newsequentialid()")
			 .IsRequired();

			modelBuilder.Entity<Money>()
		   .Property(x => x.Key)
		   .HasColumnType("nvarchar(20)");

			modelBuilder.Entity<Money>()
			.Property(x => x.Value)
			.HasColumnType("int")
			.IsRequired(false);

			modelBuilder.Entity<Money>()
			.Property(x => x.InStock)
			.HasColumnType("bit");
		}
	}
}
