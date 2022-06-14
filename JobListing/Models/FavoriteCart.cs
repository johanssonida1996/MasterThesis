using JobListing.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Models
{
    public class FavoriteCart
    {
        
        private readonly AppDbContext _appDbContext;

        public string FavoriteCartId { get; set; }

        public List<FavoriteCartItem> FavoriteCartItems { get; set; }

        private FavoriteCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public static FavoriteCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();


            session.SetString("CartId", cartId);

            return new FavoriteCart(context) { FavoriteCartId = cartId };
        }

        public void AddToCart(Worker worker)
        {
            var favoriteCartItem =
                    _appDbContext.FavoriteCartItems.SingleOrDefault(
                        s => s.Worker.Id == worker.Id && s.FavoriteCartId == FavoriteCartId);

            if (favoriteCartItem == null)
            {
                favoriteCartItem = new FavoriteCartItem
                {
                    FavoriteCartId = FavoriteCartId,
                    Worker = worker,
                    
                };

                _appDbContext.FavoriteCartItems.Add(favoriteCartItem);
            }
            else
            {
                //shoppingCartItem.Amount++;
            }
            _appDbContext.SaveChanges();
        }

        public void RemoveFromCart(Worker worker)
        {
            var favoriteCartItem =
                          _appDbContext.FavoriteCartItems.SingleOrDefault(
                              s => s.Worker.Id == worker.Id);

            if (favoriteCartItem != null)
            {
                    _appDbContext.FavoriteCartItems.Remove(favoriteCartItem);
            }

            _appDbContext.SaveChanges();

            //return localAmount;
        }

        public List<FavoriteCartItem> GetFavoriteCartItems()
        {
            return FavoriteCartItems ??
                   (FavoriteCartItems =
                       _appDbContext.FavoriteCartItems.Where(c => c.FavoriteCartId == FavoriteCartId)
                           .Include(s => s.Worker)
                            .Include(s => s.Worker.Category)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _appDbContext
                .FavoriteCartItems
                .Where(cart => cart.FavoriteCartId == FavoriteCartId);

            _appDbContext.FavoriteCartItems.RemoveRange(cartItems);

            _appDbContext.SaveChanges();
        }

        //public decimal GetShoppingCartTotal()
        //{
        //    var total = _appDbContext.FavoriteCartItems.Where(c => c.FavoriteCartId == FavoriteCartId)
        //        .Select(c => c.Pie.Price * c.Amount).Sum();
        //    return total;
        //}
    }
}
