using BookStore.Models.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BookStore.Tests
{
    public class BookControllerTests :IClassFixture<WebApplicationFactory<Program>>
    {
        readonly HttpClient _client;

        public BookControllerTests(WebApplicationFactory<Program> app)
        {
            _client = app.CreateClient();
        }
        [Fact]
        public async Task POST_Returns_JWT()
        {
            var response = await _client.GetAsync("api/books");
            response.EnsureSuccessStatusCode();

            Assert.IsType<List<BookWithoutReviewsDto>>(response.Content.Headers.ContentType.ToString());
        }
    }
}