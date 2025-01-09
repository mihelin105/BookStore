using BookStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class Cart
    {
        private readonly BookStoreContext _context;

        public Cart(BookStoreContext context)
        {
            _context = context;
        }

        public String Id { get; set; }
        public List<CartItem> CartItems { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            /* HTTP kontekst sadrži informacije o trenutnom HTTP zahtjevu, uključujući korisničku sesiju
             
             Iz trenutnog HTTP konteksta dohvaća objekat ISession, koji se koristi za čuvanje i dohvaćanje podataka u
             okviru korisničke sesije

            ISession omogućava rad s privremenim podacima specifičnim za korisnika
             
             */
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            /*
             services.GetService<>() da bi iz DI kontejnera dobili instancu BookStoreContext
            sto omogucava interakciju s bazom podataka
             */
            var context = services.GetService<BookStoreContext>();

            /*ako kljuc ne postoji korisnik nema cart i generira novi GUID*/
            string cartId = session.GetString("Id") ?? Guid.NewGuid().ToString();

            session.SetString("Id", cartId);
            return new Cart(context) { Id = cartId };


        }

        public CartItem GetCartItem(Book book)
        {
            /*
             koristenje LINQ za kreiranje upita prema CartItem u _context.CartItem kao izvor podataka

            SingleOrDefault LINQ metoda koja trazi jedan element u kolekciji , ako postoji vise od 1 onda baca ERROR, ako nema onda null
            ono se izvrsava nad bazom podataka 
            --
            SELECT TOP 1 *
            FROM CartItems
            WHERE BookId = @bookId AND CartId = @cartId
            --

            ci.Book.Id == book.Id && ci.CartId == Id je filter : provjerava je li ID knjige isti onome koji se prosljeduje metodi, 
            a CardID provjerava sesiju korisnika
             */
            return _context.CartItems.SingleOrDefault(ci =>
            ci.Book.Id == book.Id && ci.CartId == Id);
        }
        public void AddToCart(Book book, int quantity)
        {
            // gleda je li knjiga vec u kosarici
            var cartItem = GetCartItem(book);

            if(cartItem == null) // ako jos nije u kosarici
            {
                cartItem = new CartItem
                {
                    Book = book,
                    Quantity = quantity,
                    CartId = Id

                };

                _context.CartItems.Add(cartItem);
            }
            else // ako vec je u kosarici dodaj na existing 
            {
                cartItem.Quantity += quantity;
            }
            _context.SaveChanges();
        }

        public List<CartItem> GetAllCartItems()
        {
            return CartItems ?? 
                (CartItems = _context.CartItems.Where(ci => ci.CartId == Id)
                .Include(ci => ci.Book)
                .ToList());
        }
        public int GetCartTotal()
        {
            return _context.CartItems
                .Where(ci => ci.CartId == Id)
                .Select(ci => ci.Book.Price * ci.Quantity).Sum();
        }
    }
}
