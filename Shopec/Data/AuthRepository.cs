using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Threading.Tasks;

using Shopec.Data;
using Shopec.Models;

namespace Shopec.Controllers
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context = new DataContext();
        const int iterations = 350000;

        //public AuthRepository(DataContext context)
        //{
        //	_context = context;
        //}
        //public void Login(string username, string password)
        //{

        //}

        //private bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash, string userPassword)
        //{

        //}

        //public async Task<bool> UserExists(string username)
        //{

        //}
        //private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        //{


        //}

        //   public async Task<Orders> placeOrder(ShoppingCartDto SpcDto)
        //{






        //}
        public async Task<User> Login(string username, string password)
        {
            bool User = await UserExists(username);
            if (User)
            {
                var logedInUser = await _context.User.FirstOrDefaultAsync(e => e.username == username);
                var passwordHash = new byte[20];
                var passwordSalt = new byte[16];
                string allocateHash = CreatePasswordHash(logedInUser.password, out passwordHash, out passwordSalt);
                bool verifiedHash = VerifyPasswordHash(allocateHash, passwordSalt, passwordHash, password);

                if (verifiedHash)
                    return logedInUser;
            }
            return null;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash, string userPassword)
        {
            var resultHash = new byte[36];
            passwordHash = new Rfc2898DeriveBytes(
                userPassword,
                passwordSalt,
                iterations).GetBytes(20);
            Array.Copy(passwordSalt, 0, resultHash, 0, 16);
            Array.Copy(passwordHash, 0, resultHash, 16, 20);
            string resultBase64 = Convert.ToBase64String(resultHash);
            if (!password.Equals(resultBase64))
            {
                return false;

            }
            return true;
        }

        public async Task<bool> UserExists(string username)
        {
            var res = await _context.User.AnyAsync(e => (e.username).Equals(username));
            return res;
        }

        private string CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            var bytes = new byte[16];

            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            passwordSalt = bytes;
            passwordHash = new Rfc2898DeriveBytes(
                password,
                passwordSalt,
                iterations).GetBytes(20);
            byte[] hash = new byte[36];
            Array.Copy(passwordSalt, 0, hash, 0, 16);
            Array.Copy(passwordHash, 0, hash, 16, 20);
            string passwordString = Convert.ToBase64String(hash);
            return passwordString;



        }



        public async Task<Orders> placeOrder(ShoppingCartDto SpcDto)
        {
            var validUser = await _context.User.FirstOrDefaultAsync(e => e.id == SpcDto.userId);
            if (validUser != null)
            {
                var totalQuantity = 0;
                totalQuantity = await changeProductQuantity(SpcDto.items);
                var shoppinCart = await _context.ShoppingCart.FirstOrDefaultAsync(e => e.userId == SpcDto.userId);
                int shoppinCartId = shoppinCart.id;


                var order = _context.Orders.Add(new Orders()
                {
                    deliveryType = SpcDto.deliveryOptionCode,
                    totalPrice = SpcDto.grossTotal,
                    productsPurchased = totalQuantity,
                    orderdate = DateTime.Now,
                    shoppingCartId = shoppinCartId
                });
                _context.SaveChanges();
                return order;

               
            }

            return null;

        }


        private async Task<int> changeProductQuantity( IEnumerable<CartItem> items)
        {
            int totalQuantity = 0;
            foreach (var item in items)
            {
                totalQuantity += item.quantity;

                var productChangedDetail = _context.Products.FirstAsync(e => e.id == item.productId).Result;

                if (productChangedDetail != null)
                {
                    productChangedDetail.quantity = Convert.ToString(Convert.ToInt32(productChangedDetail.quantity) - item.quantity);
                    _context.SaveChanges();
                }
            }
            return totalQuantity;
        }
    }
}