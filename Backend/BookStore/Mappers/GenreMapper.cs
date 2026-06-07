using BookStore.Models.Genres;

namespace BookStore.Mappers
{
    public static class GenreMapper
    {
        public static GenreDto ToGenreDto(this Genre genre)
        {
            return new GenreDto
            {
                Name = genre.Name
            };
        }
    }
}