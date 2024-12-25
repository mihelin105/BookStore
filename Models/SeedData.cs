using BookStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class SeedData
    {

        public static void Initialize (IServiceProvider serviceProvider) { 
        
            using (var context = new BookStoreContext (serviceProvider.GetRequiredService<DbContextOptions<BookStoreContext>>())) 
            { 
            
                if(context.Books.Any()) // checks if the database has any books
                {
                    return; // it does contain books
                }

                context.Books.AddRange(
                    new Book
                    {
                        Title = "The Bell Jar",
                        Description = "The Bell Jar chronicles the crack-up of Esther Greenwood: young, brilliant, " +
                        "beautiful, and enormously talented, but slowly going under--maybe for the last time. Sylvia Plath" +
                        " masterfully draws the reader into Esther`s breakdown with such intensity that Esther`s neurosis " +
                        "becomes completely understandable and even rational, as probable and accessible an experience as " +
                        "going to the movies. Such thorough exploration of the dark and harrowing corners of the psyche - and " +
                        "the profound collective loneliness that modern society has yet to find a solution for - is an extraordinary accomplishment," +
                        " and has made The Bell Jar a haunting American classic.",
                        Language = "English",
                        ISBN = "9780060837020",
                        DatePublished = DateTime.Parse("1963-1-14"),
                        Price = 18,
                        Author = "Sylvia Plath",
                        imageUrl = "https://znanje.hr/product-images/c8a3fb03-e191-4bdb-81f3-66f4bd1d2ad2.jpg"
                    },

                    new Book {
                        Title = "All the Lovers in the Night",
                        Description = "Fuyuko Irie is a freelance proofreader in her thirties. Living alone in an overwhelming " +
                        "city and unable to form meaningful relationships, she has little contact with anyone other than her colleague, " +
                        "Hijiri. But a chance encounter with a man named Mitsutsuka awakens something new in her. Through their weekly" +
                        " meetings, Fuyuko starts to see the world in a different light and still, painful memories from her past begin to " +
                        "resurface. As Fuyuko realizes she exists in a small world of her own making she begins to push at her own boundaries. " +
                        "But will she find the strength to bring down the walls that surround her?",
                        Language = "English",
                        ISBN = "9781509898299",
                        DatePublished = DateTime.Parse("2011-10-13"),
                        Price = 14,
                        Author = "Mieko Kawakami",
                        imageUrl = "https://znanje.hr/product-images/2f70d0c8-e682-4d45-aadd-004044fc02ee.jpg"
                    },

                    new Book
                    {
                        Title = "On Earth We're Briefly Gorgeous",
                        Description = "\"A lyrical work of self-discovery that`s shockingly intimate and insistently " +
                        "universal...Not so much briefly gorgeous as permanently stunning.\" --Ron Charles, The Washington " +
                        "Post Poet Ocean Vuong`s debut novel is a shattering portrait of a family, a first love, and the redemptive " +
                        "power of storytelling On Earth We`re Briefly Gorgeous is a letter from a son to a mother who cannot read.",
                        Language = "English",
                        ISBN = "9780525562023",
                        DatePublished = DateTime.Parse(""),
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
