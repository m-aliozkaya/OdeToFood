namespace OdeToFood.Middlewares
{
    public class HelloMiddleware
    {
        readonly RequestDelegate _next;

        public HelloMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("Hello başladı");
            await _next.Invoke(context);
            Console.WriteLine("Hello bitti");
        }
    }
}
