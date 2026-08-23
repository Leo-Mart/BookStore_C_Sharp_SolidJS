using BookStore.Exceptions;

namespace BookStore.Middleware
{
    public class ErrorMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext ctx, RequestDelegate next)
        {
            try
            {
                await next(ctx);
            }
            catch (BadHttpRequestException exc)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = exc.Message,
                    StatusCode = exc.StatusCode,
                };

                var response = ctx.Response;
                if (!response.HasStarted)
                {
                    response.StatusCode = (int)errorResponse.StatusCode;
                    await response.WriteAsJsonAsync(errorResponse);
                }
            }
            catch (UnauthorizedRequestException exc)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = exc.Message,
                    StatusCode = exc.StatusCode,
                };
                var response = ctx.Response;
                if (!response.HasStarted)
                {
                    response.StatusCode = (int)errorResponse.StatusCode;
                    await response.WriteAsJsonAsync(errorResponse);
                }
            }
            catch (UserRegistrationException exc)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = exc.Message,
                    StatusCode = exc.StatusCode,
                };
                var response = ctx.Response;
                if (!response.HasStarted)
                {
                    response.StatusCode = (int)errorResponse.StatusCode;
                    await response.WriteAsJsonAsync(errorResponse);
                }
            }
            catch (Exception exc)
            {
                var errorResponse = new ErrorResponse { Message = exc.Message, StatusCode = 500 };

                var response = ctx.Response;
                if (!response.HasStarted)
                {
                    response.StatusCode = (int)errorResponse.StatusCode;
                    await response.WriteAsJsonAsync(errorResponse);
                }
            }
        }
    }
}
