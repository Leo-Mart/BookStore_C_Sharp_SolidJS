using someboeoeks.Models.Authors;

namespace someboeoeks.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorDto ToAuthorDto(this Author author)
        {
            return new AuthorDto
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            };
        }
    }
}