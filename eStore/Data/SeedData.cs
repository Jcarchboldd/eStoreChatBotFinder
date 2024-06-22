using eStore.Models;
using Microsoft.EntityFrameworkCore;
namespace eStore.Data
{
    public static class SeedData
    {
        public static void EnsurePopulate(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<StoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Products.Any())
            {
                var products = new Product[]
                {
                    new() { Id = Guid.NewGuid(), Name = "Hydrogen", Description = "Chemical element with the symbol H", Price = 1.008M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Oxygen", Description = "Chemical element with the symbol O", Price = 15.999M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Carbon", Description = "Chemical element with the symbol C", Price = 12.011M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Gold", Description = "Chemical element with the symbol Au", Price = 196.967M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Silver", Description = "Chemical element with the symbol Ag", Price = 107.87M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Platinum", Description = "Chemical element with the symbol Pt", Price = 195.084M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Iron", Description = "Chemical element with the symbol Fe", Price = 55.845M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Titanium", Description = "Chemical element with the symbol Ti", Price = 47.867M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Helium", Description = "Chemical element with the symbol He", Price = 4.0026M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Neon", Description = "Chemical element with the symbol Ne", Price = 20.180M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Mercury", Description = "Chemical element with the symbol Hg", Price = 200.592M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Sodium", Description = "Chemical element with the symbol Na", Price = 22.990M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Potassium", Description = "Chemical element with the symbol K", Price = 39.098M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Calcium", Description = "Chemical element with the symbol Ca", Price = 40.078M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Lithium", Description = "Chemical element with the symbol Li", Price = 6.94M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Chlorine", Description = "Chemical element with the symbol Cl", Price = 35.453M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Sulfur", Description = "Chemical element with the symbol S", Price = 32.06M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Nitrogen", Description = "Chemical element with the symbol N", Price = 14.007M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Phosphorus", Description = "Chemical element with the symbol P", Price = 30.974M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp"},
                    new() { Id = Guid.NewGuid(), Name = "Magnesium", Description = "Chemical element with the symbol Mg", Price = 24.305M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Copper", Description = "Chemical element with the symbol Cu", Price = 63.546M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Zinc", Description = "Chemical element with the symbol Zn", Price = 65.38M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Lead", Description = "Chemical element with the symbol Pb", Price = 207.2M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Uranium", Description = "Chemical element with the symbol U", Price = 238.028M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Hydrogen", Description = "Chemical element with the symbol H", Price = 1.008M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Oxygen", Description = "Chemical element with the symbol O", Price = 15.999M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Carbon", Description = "Chemical element with the symbol C", Price = 12.011M, Category = "Chemical", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Sun", Description = "Celestial body that is the star at the center of the Solar System", Price = 50M, Category = "Celestial Coordinates", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Moon", Description = "Celestial body that orbits around a planet", Price = 12M, Category = "Celestial Coordinates", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Mars", Description = "Celestial body that is the fourth planet from the Sun", Price = 14M, Category = "Celestial Coordinates", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Jupiter", Description = "Celestial body that is the largest planet in the Solar System", Price = 11M, Category = "Celestial Coordinates", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Saturn", Description = "Celestial body that is the sixth planet from the Sun", Price = 9M, Category = "Celestial Coordinates", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Uranus", Description = "Celestial body that is the seventh planet from the Sun", Price = 8M, Category = "Celestial Coordinates", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Neptune", Description = "Celestial body that is the eighth and farthest known planet from the Sun", Price = 9M, Category = "Celestial Coordinates", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Pluto", Description = "Celestial body that is a dwarf planet in our Solar System", Price = 3M, Category = "Celestial Coordinates", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Laptop", Description = "Portable computer with a 15-inch screen", Price = 1200M, Category = "Electronics", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Smartphone", Description = "Handheld device with a 6-inch screen and 128GB storage", Price = 800M, Category = "Electronics", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Tablet", Description = "Portable device with a 10-inch screen", Price = 500M, Category = "Electronics", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Headphones", Description = "Wireless over-ear headphones with noise cancellation", Price = 200M, Category = "Accessories", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Smartwatch", Description = "Wearable device with fitness tracking features", Price = 250M, Category = "Accessories", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Camera", Description = "Digital camera with 24MP resolution", Price = 750M, Category = "Electronics", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Gaming Console", Description = "Next-gen console with 1TB storage", Price = 500M, Category = "Gaming", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Keyboard", Description = "Mechanical keyboard with RGB backlight", Price = 100M, Category = "Accessories", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Mouse", Description = "Wireless gaming mouse with adjustable DPI", Price = 50M, Category = "Accessories", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Monitor", Description = "27-inch 4K UHD monitor", Price = 300M, Category = "Electronics", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Printer", Description = "Wireless all-in-one printer", Price = 150M, Category = "Electronics", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Router", Description = "Wi-Fi 6 router with mesh support", Price = 100M, Category = "Networking", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "External Hard Drive", Description = "1TB portable external hard drive", Price = 75M, Category = "Storage", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "USB Flash Drive", Description = "64GB USB 3.0 flash drive", Price = 20M, Category = "Storage", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Desk Lamp", Description = "Adjustable LED desk lamp with USB charging port", Price = 40M, Category = "Home Office", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Chair", Description = "Ergonomic office chair with lumbar support", Price = 150M, Category = "Furniture", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Desk", Description = "Standing desk with adjustable height", Price = 300M, Category = "Furniture", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Webcam", Description = "1080p HD webcam with built-in microphone", Price = 75M, Category = "Accessories", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Speakers", Description = "Bluetooth speakers with surround sound", Price = 120M, Category = "Audio", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                    new() { Id = Guid.NewGuid(), Name = "Microphone", Description = "USB condenser microphone for streaming", Price = 100M, Category = "Audio", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageUrl = "/img/Products/default.webp" },
                };

                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}