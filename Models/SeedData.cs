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
						imageUrl = "https://m.media-amazon.com/images/I/91fQEUwFMyL.jpg"
					}
					);

                context.SaveChanges();
            }
        }

    }
}
