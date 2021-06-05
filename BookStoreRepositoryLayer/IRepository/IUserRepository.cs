﻿using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.RepositoryInterface
{
    public interface IUserRepository
    {
        User AddUserDetails(User user);
        Login Login(Login login);

    }
}
