using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.RepositoryInterface
{
    public interface IUserRepository
    {
        object AddUserDetails(UserModel user);
        LoginModel Login(LoginModel login);

    }
}
