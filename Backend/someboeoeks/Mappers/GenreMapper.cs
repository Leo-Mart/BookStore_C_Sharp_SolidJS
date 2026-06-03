using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using someboeoeks.Models.Genres;

namespace someboeoeks.Mappers
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