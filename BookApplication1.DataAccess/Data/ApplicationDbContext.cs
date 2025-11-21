using BookApplication1.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookApplication1.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Seed Categories (Expanded to cover all book types)
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Thriller", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Sci-fi", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Fantasy", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Technology", DisplayOrder = 5 },
                new Category { Id = 6, Name = "Nature", DisplayOrder = 6 },
                new Category { Id = 7, Name = "History", DisplayOrder = 7 },
                new Category { Id = 8, Name = "Cooking", DisplayOrder = 8 },
                new Category { Id = 9, Name = "Self-Help", DisplayOrder = 9 }
            );


            // 2. Seed Products with CategoryId mappings
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "The Time Traveler",
                    Description = "A thrilling sci-fi adventure across space and time.",
                    Author = "A. Reynolds",
                    Price = 499.99f,
                    Quantity = 50,
                    PublishedDate = new DateOnly(2023, 5, 12),
                    EditionNum = 2,
                    Rating = 4,
                    ISBN = "978-1-23456-789-7",
                    CreatedAt = new DateOnly(2023, 5, 1),
                    UpdatedAt = new DateOnly(2023, 5, 12),
                    CategoryId = 3 // Sci-fi,
                },
                new Product
                {
                    Id = 2,
                    Name = "Mystery of the Lost Manor",
                    Description = "A gripping thriller filled with suspense and twists.",
                    Author = "Sarah Blake",
                    Price = 299.50f,
                    Quantity = 80,
                    PublishedDate = new DateOnly(2022, 11, 20),
                    EditionNum = 1,
                    Rating = 5,
                    ISBN = "978-1-98765-432-1",
                    CreatedAt = new DateOnly(2022, 11, 1),
                    UpdatedAt = new DateOnly(2022, 11, 20),
                    CategoryId = 2 // Thriller
                },
                new Product
                {
                    Id = 3,
                    Name = "Galactic Frontiers",
                    Description = "An epic sci-fi saga exploring distant galaxies.",
                    Author = "James Carter",
                    Price = 599.00f,
                    Quantity = 40,
                    PublishedDate = new DateOnly(2024, 1, 10),
                    EditionNum = 3,
                    Rating = 4,
                    ISBN = "978-0-12345-678-9",
                    CreatedAt = new DateOnly(2024, 1, 1),
                    UpdatedAt = new DateOnly(2024, 1, 10),
                    CategoryId = 3 // Sci-fi
                },
                new Product
                {
                    Id = 4,
                    Name = "Shadows of the Forgotten Realm",
                    Description = "A dark fantasy adventure blending magic, mythology, and mystery.",
                    Author = "Evelyn Hart",
                    Price = 450.00f,
                    Quantity = 120,
                    PublishedDate = new DateOnly(2021, 8, 17),
                    EditionNum = 1,
                    Rating = 5,
                    ISBN = "978-1-54321-987-6",
                    CreatedAt = new DateOnly(2021, 8, 1),
                    UpdatedAt = new DateOnly(2021, 8, 17),
                    CategoryId = 4 // Fantasy
                },
                new Product
                {
                    Id = 5,
                    Name = "The Quantum Paradox",
                    Description = "A mind-bending story about alternate timelines and cosmic secrets.",
                    Author = "Dr. Neil Harmon",
                    Price = 650.00f,
                    Quantity = 35,
                    PublishedDate = new DateOnly(2023, 3, 2),
                    EditionNum = 2,
                    Rating = 4,
                    ISBN = "978-0-24680-135-7",
                    CreatedAt = new DateOnly(2023, 3, 1),
                    UpdatedAt = new DateOnly(2023, 3, 2),
                    CategoryId = 3 // Sci-fi
                },
                new Product
                {
                    Id = 6,
                    Name = "Echoes of the Crimson Blade",
                    Description = "A samurai-inspired action novel full of honor, conflict, and redemption.",
                    Author = "Kenji Morita",
                    Price = 520.50f,
                    Quantity = 60,
                    PublishedDate = new DateOnly(2020, 12, 5),
                    EditionNum = 3,
                    Rating = 4,
                    ISBN = "978-1-67890-555-3",
                    CreatedAt = new DateOnly(2020, 12, 1),
                    UpdatedAt = new DateOnly(2020, 12, 5),
                    CategoryId = 1 // Action
                },
                new Product
                {
                    Id = 7,
                    Name = "Beneath the Silver Lake",
                    Description = "A slow-burn mystery unraveling eerie clues in a quiet lakeside town.",
                    Author = "Maya Collins",
                    Price = 310.00f,
                    Quantity = 95,
                    PublishedDate = new DateOnly(2022, 4, 14),
                    EditionNum = 1,
                    Rating = 3,
                    ISBN = "978-0-11223-445-8",
                    CreatedAt = new DateOnly(2022, 4, 1),
                    UpdatedAt = new DateOnly(2022, 4, 14),
                    CategoryId = 2 // Thriller
                },
                new Product
                {
                    Id = 8,
                    Name = "Rise of the Cyber Dominion",
                    Description = "A futuristic action thriller set in a war-torn cyberpunk world.",
                    Author = "L. Vargas",
                    Price = 799.00f,
                    Quantity = 20,
                    PublishedDate = new DateOnly(2024, 2, 1),
                    EditionNum = 2,
                    Rating = 5,
                    ISBN = "978-9-87654-320-4",
                    CreatedAt = new DateOnly(2024, 2, 1),
                    UpdatedAt = new DateOnly(2024, 2, 1),
                    CategoryId = 3 // Sci-fi
                },
                new Product
                {
                    Id = 9,
                    Name = "The Alchemist’s Secret Grimoire",
                    Description = "A historical mystery following the hunt for a forbidden ancient manuscript.",
                    Author = "Isabella Grant",
                    Price = 560.75f,
                    Quantity = 70,
                    PublishedDate = new DateOnly(2023, 7, 22),
                    EditionNum = 1,
                    Rating = 4,
                    ISBN = "978-1-22468-975-3",
                    CreatedAt = new DateOnly(2023, 7, 1),
                    UpdatedAt = new DateOnly(2023, 7, 22),
                    CategoryId = 7 // History
                },
                new Product
                {
                    Id = 10,
                    Name = "Voyage to the Edge of Nowhere",
                    Description = "A philosophical sci-fi novel exploring the human condition through space travel.",
                    Author = "Theo Marquez",
                    Price = 480.00f,
                    Quantity = 55,
                    PublishedDate = new DateOnly(2021, 9, 29),
                    EditionNum = 4,
                    Rating = 5,
                    ISBN = "978-1-30987-642-2",
                    CreatedAt = new DateOnly(2021, 9, 1),
                    UpdatedAt = new DateOnly(2021, 9, 29),
                    CategoryId = 3 // Sci-fi
                },
                new Product
                {
                    Id = 11,
                    Name = "The Silent Ward",
                    Description = "A chilling psychological thriller set in an abandoned hospital.",
                    Author = "Jordan Pierce",
                    Price = 350.00f,
                    Quantity = 110,
                    PublishedDate = new DateOnly(2022, 2, 10),
                    EditionNum = 1,
                    Rating = 3,
                    ISBN = "978-0-33445-221-7",
                    CreatedAt = new DateOnly(2022, 2, 1),
                    UpdatedAt = new DateOnly(2022, 2, 10),
                    CategoryId = 2 // Thriller
                },
                new Product
                {
                    Id = 12,
                    Name = "Chronicles of the Forgotten Empire",
                    Description = "An epic fantasy journey through a fallen kingdom full of secrets.",
                    Author = "Ariana Vale",
                    Price = 899.00f,
                    Quantity = 25,
                    PublishedDate = new DateOnly(2023, 10, 4),
                    EditionNum = 2,
                    Rating = 5,
                    ISBN = "978-1-44444-222-9",
                    CreatedAt = new DateOnly(2023, 10, 1),
                    UpdatedAt = new DateOnly(2023, 10, 4),
                    CategoryId = 4 // Fantasy
                },
                new Product
                {
                    Id = 13,
                    Name = "Fragments of the Neon Sky",
                    Description = "A cyber-noir story exploring technology, identity, and rebellion.",
                    Author = "Cyrus Lee",
                    Price = 420.00f,
                    Quantity = 75,
                    PublishedDate = new DateOnly(2024, 3, 12),
                    EditionNum = 1,
                    Rating = 4,
                    ISBN = "978-2-54321-111-6",
                    CreatedAt = new DateOnly(2024, 3, 1),
                    UpdatedAt = new DateOnly(2024, 3, 12),
                    CategoryId = 3 // Sci-fi
                },
                new Product
                {
                    Id = 14,
                    Name = "The Silent Observer",
                    Description = "A psychological thriller exploring the human mind.",
                    Author = "Adrian Wells",
                    Price = 499,
                    Quantity = 0,
                    PublishedDate = new DateOnly(2018, 5, 12),
                    EditionNum = 1,
                    Rating = 4,
                    ISBN = "978-1-54321-765-4-2",
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    UpdatedAt = DateOnly.FromDateTime(DateTime.Now),
                    CategoryId = 2 // Thriller
                },
                new Product
                {
                    Id = 15,
                    Name = "Modern Web Development",
                    Description = "A complete guide to mastering full-stack web frameworks and tools.",
                    Author = "Laura Kim",
                    Price = 899,
                    Quantity = 0,
                    PublishedDate = new DateOnly(2021, 3, 1),
                    EditionNum = 2,
                    Rating = 5,
                    ISBN = "978-1-98765-123-6-1",
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    UpdatedAt = DateOnly.FromDateTime(DateTime.Now),
                    CategoryId = 5 // Technology
                },
                new Product
                {
                    Id = 16,
                    Name = "Into the Deep Blue",
                    Description = "A journey into marine mysteries and ocean life.",
                    Author = "Caleb Morgan",
                    Price = 350,
                    Quantity = 0,
                    PublishedDate = new DateOnly(2015, 11, 20),
                    EditionNum = 1,
                    Rating = 3,
                    ISBN = "978-1-33445-667-8-9",
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    UpdatedAt = DateOnly.FromDateTime(DateTime.Now),
                    CategoryId = 6 // Nature
                },
                new Product
                {
                    Id = 17,
                    Name = "AI for Everyone",
                    Description = "Understanding artificial intelligence in everyday life.",
                    Author = "Meera Patel",
                    Price = 750,
                    Quantity = 0,
                    PublishedDate = new DateOnly(2022, 7, 10),
                    EditionNum = 1,
                    Rating = 5,
                    ISBN = "978-1-22334-998-7-6",
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    UpdatedAt = DateOnly.FromDateTime(DateTime.Now),
                    CategoryId = 5 // Technology
                },
                new Product
                {
                    Id = 18,
                    Name = "The Forgotten Tales",
                    Description = "A collection of ancient stories retold for modern readers.",
                    Author = "Rohan Khanna",
                    Price = 420,
                    Quantity = 0,
                    PublishedDate = new DateOnly(2010, 1, 5),
                    EditionNum = 3,
                    Rating = 4,
                    ISBN = "978-1-55678-224-3-4",
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    UpdatedAt = DateOnly.FromDateTime(DateTime.Now),
                    CategoryId = 4 // Fantasy (or History/Folklore)
                },
                new Product
                {
                    Id = 19,
                    Name = "Cooking with Passion",
                    Description = "Easy and delicious recipes for everyday cooking.",
                    Author = "Sofia Bennett",
                    Price = 650,
                    Quantity = 0,
                    PublishedDate = new DateOnly(2019, 8, 18),
                    EditionNum = 1,
                    Rating = 5,
                    ISBN = "978-1-44223-556-5-3",
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    UpdatedAt = DateOnly.FromDateTime(DateTime.Now),
                    CategoryId = 8 // Cooking
                },
                new Product
                {
                    Id = 20,
                    Name = "The Stars Beyond",
                    Description = "A sci-fi adventure exploring distant galaxies.",
                    Author = "Neil Carver",
                    Price = 580,
                    Quantity = 0,
                    PublishedDate = new DateOnly(2017, 6, 9),
                    EditionNum = 2,
                    Rating = 4,
                    ISBN = "978-1-99887-332-1-8",
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    UpdatedAt = DateOnly.FromDateTime(DateTime.Now),
                    CategoryId = 3 // Sci-fi
                },
                new Product
                {
                    Id = 21,
                    Name = "Mastering C# and .NET",
                    Description = "A deep dive into backend development with C# and .NET Core.",
                    Author = "James Holloway",
                    Price = 999,
                    Quantity = 0,
                    PublishedDate = new DateOnly(2023, 2, 15),
                    EditionNum = 1,
                    Rating = 5,
                    ISBN = "978-1-11223-456-7-4",
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    UpdatedAt = DateOnly.FromDateTime(DateTime.Now),
                    CategoryId = 5 // Technology
                },
                new Product
                {
                    Id = 22,
                    Name = "The Art of Minimalism",
                    Description = "How minimalism transforms lifestyle, productivity, and mindset.",
                    Author = "Elena Rivers",
                    Price = 320,
                    Quantity = 0,
                    PublishedDate = new DateOnly(2016, 9, 27),
                    EditionNum = 1,
                    Rating = 4,
                    ISBN = "978-1-77889-554-3-7",
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    UpdatedAt = DateOnly.FromDateTime(DateTime.Now),
                    CategoryId = 9 // Self-Help
                },
                new Product
                {
                    Id = 23,
                    Name = "History of Ancient Civilizations",
                    Description = "From Mesopotamia to Rome – a detailed historical exploration.",
                    Author = "Dr. Nathan Clarke",
                    Price = 850,
                    Quantity = 0,
                    PublishedDate = new DateOnly(2012, 4, 30),
                    EditionNum = 2,
                    Rating = 5,
                    ISBN = "978-1-66554-778-2-9",
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    UpdatedAt = DateOnly.FromDateTime(DateTime.Now),
                    CategoryId = 7 // History
                }
            );

        }
    }
}