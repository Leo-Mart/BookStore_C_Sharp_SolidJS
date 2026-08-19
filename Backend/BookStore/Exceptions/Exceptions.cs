namespace BookStore.Exceptions
{
    public class UnAuthorizedRequestException(string message, int statusCode) : Exception(message)
    {
        public int StatusCode = statusCode;
    }
}
