using System;
namespace src
{
    public class ServiceAGateway
    {
        private string baseUrl;

        public ServiceAGateway(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        public async Task<HttpResponseMessage> CallApi(int userId)
        {
            using (var client = new HttpClient { BaseAddress = new Uri(baseUrl) })
            {
                try
                {
                    var response = await client.GetAsync($"/api/user/{userId}");
                    return response;
                }
                catch (System.Exception e)
                {
                    throw new Exception("There was a problem connecting to service A.", e);
                }
            }
        }
    }
}

