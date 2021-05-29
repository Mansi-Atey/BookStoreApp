using BookStoreManagerLayer.InterfaceManager;
using BookStoreModelLayer;
using BookStoreRepositoryLayer;
using BookStoreRepositoryLayer.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.Manager
{
    public class UserManagerLayer:IUserManager
    {
        private readonly IUserRepository userRepository = new UserRepositoryLayer();
        public object AddUserDetails(User users)
        {
            return this.userRepository.AddUserDetails(users);
        }
        public Login Login(Login login)
        {
            return this.userRepository.Login(login);
        }
    }
}
