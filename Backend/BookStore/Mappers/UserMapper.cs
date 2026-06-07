using BookStore.Models.Users;

namespace BookStore.Mappers
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