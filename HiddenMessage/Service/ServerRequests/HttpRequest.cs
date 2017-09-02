using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HiddenMessage.Service.ServerRequests
{
    public class HttpRequest
    {
        public HttpRequest(){}

		public async static Task MakeGetRequest(String url, Func<String, String> onResult)
		{
			HttpClient client = new HttpClient();

			var header = client.DefaultRequestHeaders;
			header.Add(ServerVariables.AUTH_HEADER, ServerVariables.AUTH_KEY);

			HttpResponseMessage response = await client.GetAsync(url);
			HttpContent rawContent = response.Content;
            String content = await rawContent.ReadAsStringAsync();

            onResult(content);

            rawContent.Dispose();
            response.Dispose();
            client.Dispose();
		}

		public async static Task MakePostRequest(String url, String jsonString, Func<HttpContent, String> onResult)
		{
			HttpClient client = new HttpClient();

			var header = client.DefaultRequestHeaders;
			header.Add(ServerVariables.AUTH_HEADER, ServerVariables.AUTH_KEY);
			header.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            StringContent toPost = null;
			HttpResponseMessage response = await client.PostAsync(ServerVariables.SERVER_URL + "/users", toPost);
			HttpContent content = response.Content;

			onResult(content);

			content.Dispose();
			response.Dispose();
			client.Dispose();
		}
    }
}
