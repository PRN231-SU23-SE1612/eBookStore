using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();

            optionsBuilder
                .UseSqlServer(configuration.GetConnectionString("eBookStore"))
                //.UseSnakeCaseNamingConvention()
                ;
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            optionsBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleDesc = "Admin" },
                new Role { RoleId = 2, RoleDesc = "User" }
                );            
            optionsBuilder.Entity<Book>()
                .HasOne(x => x.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(u => u.PubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book_Publisher");
            optionsBuilder.Entity<Publisher>().HasData(
                new Publisher
                {
                    PubId = 1,
                    PublisherName = "",
                    City = "",
                    State = "",
                    Country = ""
                });
            optionsBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    EmailAddress = "admin@ebookstore.com",
                    Password = "admin@@123",
                    Name = "Admin",
                    RoleId = 1,
                    HireDate = DateTime.Now
                }
                );
            optionsBuilder.Entity<BookAuthor>().HasKey(e => new { e.AuthorId, e.BookId });
            base.OnModelCreating(optionsBuilder);
        }
    }
}
