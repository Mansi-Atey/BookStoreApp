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
        User AddUserDetails(User user);
        Login Login(Login login);

    }
}
