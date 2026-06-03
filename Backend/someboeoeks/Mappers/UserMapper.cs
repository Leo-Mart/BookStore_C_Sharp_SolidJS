using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using someboeoeks.Models.Users;

namespace someboeoeks.Mappers
{
    public static class UserMapper
    {
        public static ResponseUserDto ToResponseUserDtoFromUser(this User user)
        {
            return new ResponseUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Reviews = user.Reviews
            };
        }

        public static ReviewUserInfoDto ToReviewInfoFromUserDto(this User user)
        {
            return new ReviewUserInfoDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }
    }
}