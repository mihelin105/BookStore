using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }

        // add genre and connect it to css for revealing books genre
        [Required]
        public string Genre { get; set; }

        [Required]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public string Author { get; set; }

        public string Language { get; set; }

        [Required,
            MaxLength(13)]
        public string ISBN { get; set; }

        [Required, 
            DataType(DataType.Date),
            Display(Name = "Date Published")]
        public DateTime DatePublished { get; set; }

        [Required,
            DataType(DataType.Currency)]
        public int Price { get; set; }

        [Display(Name = "Image URL")]
        public string imageUrl { get; set; }


    }
}
