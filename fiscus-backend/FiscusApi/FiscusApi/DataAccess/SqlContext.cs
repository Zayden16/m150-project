using FiscusApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FiscusApi.DataAccess
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        #region Properties

        public DbSet<Category> Category { get; set; }

        public DbSet<Cost> Cost { get; set; }

        public DbSet<Payment> Payment { get; set; }

        public DbSet<Group> Group { get; set; }

        public DbSet<Item> Item { get; set; }

        public DbSet<ShoppingList> ShoppingList { get; set; }

        public DbSet<User> User { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Group>()
                .HasKey(x => x.GroupId);

            builder.Entity<User>()
                .HasKey(x => x.UserId);

            builder.Entity<User>()
                .HasOne<Group>()
                .WithMany()
                .HasForeignKey(x => x.GroupId);

            builder.Entity<Category>()
                .HasKey(x => x.CategoryId);

            builder.Entity<Cost>()
                .HasKey(x => x.CostId);

            builder.Entity<Cost>()
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(x => x.CategoryId);

            builder.Entity<Payment>()
                .HasNoKey();

            builder.Entity<Payment>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.UserId);

            builder.Entity<Payment>()
                .HasOne<Cost>()
                .WithMany()
                .HasForeignKey(x => x.CostId);

           
            builder.Entity<ShoppingList>()
                .HasKey(x => x.ShoppingListId);

            builder.Entity<ShoppingList>()
                .HasOne<Group>()
                .WithMany()
                .HasForeignKey(x => x.GroupId);

            builder.Entity<Item>()
                .HasKey(x => x.ItemId);

            builder.Entity<Item>()
                .HasOne<ShoppingList>()
                .WithMany()
                .HasForeignKey(x => x.ShoppingListId);

            builder.Entity<Item>()
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(x => x.CategoryId);

            builder.Entity<Item>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.UserId);

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
