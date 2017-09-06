using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HiddenMessage.Service.ServerRequests
{
    public class HttpRequest
    {
        public HttpRequest(){}

		public async static Task MakeGetRequest(String url, Func<String, String> onResult)
		{
			HttpClient client = HttpRequest.BuildClient();

			HttpResponseMessage response = await client.GetAsync(url);
			HttpContent rawContent = response.Content;

            HttpRequest.HandleResponseContent(response, onResult);

            response.Dispose();
            client.Dispose();
		}

		public async static Task MakePostRequest(String url, String jsonString, Func<String, String> onResult)
		{
            HttpClient client = HttpRequest.BuildClient();

            StringContent toPost = new StringContent(jsonString, Encoding.UTF8, "application/json");
			HttpResponseMessage response = await client.PostAsync(url, toPost);

			HttpRequest.HandleResponseContent(response, onResult);

			response.Dispose();
			client.Dispose();
		}

		public async static Task MakePutRequest(String url, String jsonString, Func<String, String> onResult)
		{
			HttpClient client = HttpRequest.BuildClient();

			StringContent toPut = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(url, toPut);

			HttpRequest.HandleResponseContent(response, onResult);

			response.Dispose();
			client.Dispose();
		}

        private static HttpClient BuildClient()
        {
			HttpClient client = new HttpClient();

			var header = client.DefaultRequestHeaders;
			header.Add(ServerVariables.AUTH_HEADER, ServerVariables.AUTH_KEY);
            return client;
        }

        private async static void HandleResponseContent(HttpResponseMessage response, Func<String, String> onResult)
        {
			HttpContent rawContent = response.Content;
			String content = await rawContent.ReadAsStringAsync();

			if (onResult != null) onResult(content);
            rawContent.Dispose();
        }
    }
}
