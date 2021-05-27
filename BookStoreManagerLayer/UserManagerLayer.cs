using BookStoreManagerLayer.InterfaceManager;
using BookStoreModelLayer;
using BookStoreRepositoryLayer.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer
{
    public class UserManagerLayer:IUserManager
    {
        private readonly IUserRepository userRepository;

        public UserManagerLayer(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public object AddUserDetails(UserModel user)
        {
            return this.userRepository.AddUserDetails(user);
        }
        public LoginModel Login(LoginModel login)
        {
            return this.userRepository.Login(login);
        }
    }
}
