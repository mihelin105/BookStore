using BookStore.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Models
{
    public class SeedData
    {

        public static void Initialize (IServiceProvider serviceProvider) {

            using (var context = new BookStoreContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreContext>>()))
            {
                context.Database.EnsureCreated();



                /*if (context.Books.Any()) // checks if the database has any books
                {
                    return; // it does contain books
                }*/

                var booksToAdd = new List<Book>
                {
                    new Book
                    {
                        // add genre
                        Title = "The Bell Jar",
                        Description = "test",
                        Language = "English",
                        ISBN = "9780060837020",
                        DatePublished = DateTime.ParseExact("1963-1-14", "yyyy-M-d", CultureInfo.InvariantCulture),
                        Price = 18,
                        Author = "Sylvia Plath",
                        Genre = "Novel / Autobiography",
                        imageUrl = "https://znanje.hr/product-images/c8a3fb03-e191-4bdb-81f3-66f4bd1d2ad2.jpg"
                    },

                    new Book {
                        Title = "All the Lovers in the Night",
                        Description = "test",
                        Language = "English",
                        ISBN = "9781509898299",
                        DatePublished = DateTime.ParseExact("2021-5-13", "yyyy-M-d", CultureInfo.InvariantCulture),
                        Price = 14,
                        Author = "Mieko Kawakami",
                        Genre = "Young Adult",
                        imageUrl = "https://znanje.hr/product-images/2f70d0c8-e682-4d45-aadd-004044fc02ee.jpg"
                    },

                    new Book
                    {
                        Title = "On Earth We're Briefly Gorgeous",
                        Description = "Test",
                        Language = "English",
                        ISBN = "9780525562023",
                        DatePublished = DateTime.ParseExact("2019-6-4", "yyyy-M-d", CultureInfo.InvariantCulture),
                        Price = 17,
                        Author = "Ocean Voung",
                        Genre = "Epistolary novel",
                        imageUrl = "https://znanje.hr/product-images/8c86657b-4880-4715-96be-acf7209d1217.jpg"
                    },

                    new Book
                    {
                        Title = "A Little Life",
                        Description = "Test",
                        Language = "English",
                        ISBN = "9780804172707",
                        DatePublished = DateTime.ParseExact("2015-1-1", "yyyy-M-d", CultureInfo.InvariantCulture),
                        Price = 20,
                        Author = "Hanya Yanagihara",
                        Genre = "Novel",
                        imageUrl = "https://znanje.hr/product-images/6ca430f9-06c0-47ad-b8c8-117917b6ebe8.jpg"
                    },

                    new Book
                    {
                        Title = "No Longer Human",
                        Description = "Test",
                        Language = "English",
                        ISBN = "9780811204811",
                        DatePublished = DateTime.ParseExact("1948-1-1", "yyyy-M-d", CultureInfo.InvariantCulture),
                        Price = 17,
                        Author = "Osamu Dazai",
                        Genre = "Novel",
                        imageUrl = "https://znanje.hr/product-images/36859b2b-f0ac-4251-978b-509ab891f351.jpg"
                    },

                    new Book
                    {
                        Title = "White Nights",
                        Description = "Test",
                        Language = "English",
                        ISBN = "9780241252086",
                        DatePublished = DateTime.ParseExact("1848-1-1", "yyyy-M-d", CultureInfo.InvariantCulture),
                        Price = 5,
                        Author = " Fyodor Dostoevsky",
                        Genre = "Novel",
                        imageUrl = "https://znanje.hr/product-images/db2e393a-dee8-49f4-b1df-bbaa96019a4e.jpg"
                    },

                    new Book
                    {
                        Title = "The Catcher in the Rye",
                        Description = "Test",
                        Language = "English",
                        ISBN = "9780241984758",
                        DatePublished = DateTime.ParseExact("1951-6-16", "yyyy-M-d", CultureInfo.InvariantCulture),
                        Price = 20,
                        Author = "J. D. Salinger",
                        Genre = "Novel",
                        imageUrl = "https://m.media-amazon.com/images/I/91fQEUwFMyL.jpg"
                    },

                    new Book
                    {
                        Title = "Normal People",
                        Description = "test.",
                        Language = "English",
                        ISBN = "9780571334667",
                        DatePublished = DateTime.ParseExact("2018-8-28", "yyyy-M-d", CultureInfo.InvariantCulture),
                        Price = 22,
                        Author = "Sally Rooney",
                        Genre = "Novel",
                        imageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1571423190i/41057294.jpg"
                    },

                    new Book
                    {
                        Title = "The Secret History",
                        Description = "test",
                        Language = "English",
                        ISBN = "9781470031702",
                        DatePublished = DateTime.ParseExact("2011-8-10", "yyyy-M-d", CultureInfo.InvariantCulture),
                        Price = 24,
                        Author = "Donna Tartt",
                        Genre = "Novel",
                        imageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1451554846i/29044.jpg"
                    },

                    new Book
                    {
                        Title = "Frankenstein",
                        Description = "test.",
                        Language = "English",
                        ISBN = "9789400001702",
                        DatePublished = DateTime.ParseExact("1888-1-1", "yyyy-M-d", CultureInfo.InvariantCulture),
                        Price = 24,
                        Author = "Mary Wollstonecraft Shelley",
                        Genre = "Gothic novel",
                        imageUrl = "https://m.media-amazon.com/images/I/81AuVq270jL._UF1000,1000_QL80_.jpg"
                    }



                };


                // Add only books that don't already exist (check by ISBN)
                foreach (var book in booksToAdd)
                {
                    if (!context.Books.Any(b => b.ISBN == book.ISBN)) // Check for duplicate by ISBN
                    {
                        context.Books.Add(book);
                    }
                }


                context.SaveChanges();
            }
            SeedRolesAndUsers(serviceProvider).Wait();
        }

        public static async Task SeedRolesAndUsers(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<DefaultUser>>();

            // Seed Roles
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Seed Admin User
            var adminEmail = "admin@site.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var user = new DefaultUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    FirstName = "Admin",
                    LastName = "Admission",
                    Address = "Kalverstraat",
                    City = "Amsterdam",
                    ZipCode = "1012",
                    UserCreationDate = DateTime.Now
                };

                var result = await userManager.CreateAsync(user, "Admin@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }




    }
}
