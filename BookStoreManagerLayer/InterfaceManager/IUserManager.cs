using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.InterfaceManager
{
   public interface IUserManager
    {
        object AddUserDetails(UserModel user);
        LoginModel Login(LoginModel login);

    }
}
