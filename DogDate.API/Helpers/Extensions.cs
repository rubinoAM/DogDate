using Microsoft.AspNetCore.Http;

namespace DogDate.API.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse resp, string msg)
        {
            resp.Headers.Add("Application-Error", msg);
            resp.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            resp.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}