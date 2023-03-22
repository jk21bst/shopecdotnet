using System.Threading.Tasks;

using Shopec.Models;

namespace Shopec.Data
{
	public interface IAuthRepository
    {
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
        Task<Orders> placeOrder(ShoppingCartDto SpcDto);
    }
}