using Ecommerce.Shared;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Edition> Editions { get; set; }


        public DbSet<ProductVariant> ProductVariant { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductVariant>().HasKey(p => new
            {
                p.ProductId,
                p.EditionId
            });

            modelBuilder.Entity<Category>().HasData(
                  new Category { Id = 1, Name = "Libros", Url = "books", Icon = "book" },
                  new Category { Id = 2, Name = "Electronica", Url = "electronics", Icon = "camera-slr" },
                  new Category { Id = 3, Name = "Video Juegos", Url = "video-games", Icon = "aperture" }
                );

            modelBuilder.Entity<Product>().HasData(
                 new Product
                 {
                     Id = 1,
                     CategoryId = 1,
                     Title = "Galax 1",
                     Description = "Celular Sansung",
                     Image = "https://i.pinimg.com/236x/76/d9/80/76d98054151d08ac8c1e625deff00874.jpg",
                     IsPublic = true,
                     IsDeleted = true
                 },
                 new Product
                 {
                     Id = 2,
                     CategoryId = 2,
                     Title = "Iphone 1",
                     Description = "Iphone 12",
                     Image = "https://i.pinimg.com/236x/76/d9/80/76d98054151d08ac8c1e625deff00874.jpg",
                     IsPublic = true,
                     IsDeleted = true
                 },
                      new Product
                      {
                          Id = 3,
                          CategoryId = 2,
                          Title = "Iphone 3",
                          Description = "Iphone 12",
                          Image = "https://i.pinimg.com/236x/76/d9/80/76d98054151d08ac8c1e625deff00874.jpg",
                          IsPublic = true,
                          IsDeleted = true
                      }
              );

            modelBuilder.Entity<Edition>().HasData(
              new Edition { Id = 1, Name = "Default" },
              new Edition { Id = 2, Name = "AudioBook" },
              new Edition { Id = 3, Name = "PlayStation" },
              new Edition { Id = 4, Name = "Xbol" }
             );



            modelBuilder.Entity<ProductVariant>().HasData(
                 new ProductVariant
                 {
                     ProductId = 1,
                     EditionId = 1,
                     Price = 20000,
                     OriginalPrice = 10000
                 },
                 new ProductVariant
                 {
                     ProductId = 1,
                     EditionId = 2,
                     Price = 30000,
                     OriginalPrice = 20000
                 },
                    new ProductVariant
                    {
                        ProductId = 2,
                        EditionId = 1,
                        Price = 20000,
                        OriginalPrice = 10000
                    },
                 new ProductVariant
                 {
                     ProductId = 2,
                     EditionId = 2,
                     Price = 30000,
                     OriginalPrice = 20000
                 }
              );


        }
    }
}
