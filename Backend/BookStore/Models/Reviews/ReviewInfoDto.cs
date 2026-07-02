namespace BookStore.Models.Reviews
{
    public record ReviewInfoDto
    {
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public int Score { get; set; }
    }
}