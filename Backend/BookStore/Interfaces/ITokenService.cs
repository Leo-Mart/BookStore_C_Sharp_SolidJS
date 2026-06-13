using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models.Users;

namespace BookStore.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}