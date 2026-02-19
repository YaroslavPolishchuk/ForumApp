using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Net;

namespace Forum.Infrastructure.MiddleWare
{
    public class DummyMiddleWare
    {
        private readonly RequestDelegate _next;

        public DummyMiddleWare(RequestDelegate next)
        {
            _next=next;
        }

        public async Task Invoke(HttpContext context)
        {
            Debug.WriteLine("This is DummyMiddleWare");
            await _next.Invoke(context);
        }
    }
}
