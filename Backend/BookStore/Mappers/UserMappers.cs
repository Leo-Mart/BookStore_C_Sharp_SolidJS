using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models.Users;

namespace BookStore.Mappers
{
    public static class UserMappers
    {
        public static ReviewUserInfoDto ToReviewUserInfoFromAppUser(this AppUser user)
        {
            return new ReviewUserInfoDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                // possibly email?
            };
        }
    }
}