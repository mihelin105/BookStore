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
