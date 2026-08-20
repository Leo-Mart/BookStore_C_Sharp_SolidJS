using System.Collections.Generic;

namespace BookStore.Exceptions
{
    public class UnauthorizedRequestException(string message, int statusCode) : Exception(message)
    {
        public int StatusCode = statusCode;
    }

    public class UserRegistrationException(
        string message,
        IEnumerable<Microsoft.AspNetCore.Identity.IdentityError>? errors,
        int statusCode
    ) : Exception(message)
    {
        public int StatusCode = statusCode;
        public IEnumerable<Microsoft.AspNetCore.Identity.IdentityError> Errors = errors;
    }
}
