using BookStore.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BookStore.Models
{
    public class SeedData
    {

        public static void Initialize (IServiceProvider serviceProvider) { 
        
            using (var context = new BookStoreContext (serviceProvider.GetRequiredService<DbContextOptions<BookStoreContext>>())) 
            {
                context.Database.EnsureCreated();

                if (context.Books.Any()) // checks if the database has any books
                {
                    return; // it does contain books
                }

                context.Books.AddRange(
                    new Book
                    {
                        Title = "The Bell Jar",
                        Description = "test",
                        Language = "English",
                        ISBN = "9780060837020",
                        DatePublished = DateTime.ParseExact("1963-1-14", "yyyy-M-d", CultureInfo.InvariantCulture),
                        Price = 18,
                        Author = "Sylvia Plath",
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
                        imageUrl = "https://znanje.hr/product-images/8c86657b-4880-4715-96be-acf7209d1217.jpg"
                    }
                    );

                context.SaveChanges();
            }
        }

    }
}
