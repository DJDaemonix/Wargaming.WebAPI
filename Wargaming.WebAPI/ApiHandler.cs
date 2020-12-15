using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Wargaming.WebAPI.Models.Api;
using Wargaming.WebAPI.Utilities;
using static Wargaming.WebAPI.ApiProperties;



namespace Wargaming.WebAPI
{
	public class ApiHandler
	{
		protected IHttpClientFactory ClientFactory { get; init; }

		protected string Host { get; init; }
		protected string AppId { get; init; }

		public ApiHandler(IHttpClientFactory factory, Game game, Region region, string appId)
		{
			ClientFactory = factory ?? throw new ArgumentNullException(nameof(factory));
			Host = GetApiHost(game, region);
			AppId = appId ?? throw new ArgumentNullException(nameof(appId));
		}

		public async Task<HttpResponseMessage> GetRequestAsync(string endpoint, params ApiArgument[] arguments)
		{
			using HttpClient client = ClientFactory.CreateClient();
			string path = BuildPath(endpoint, arguments);


			return await client.GetAsync(path);
		}

		public static async Task<TData> ParseResponseAsync<TData>(HttpResponseMessage response) where TData : class, new()
		{
			try
			{
				ApiResponse parsedResponse = JsonSerializer.Deserialize<ApiResponse>(await response.Content.ReadAsStringAsync(), new() 
					{	
						PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance, 
						PropertyNameCaseInsensitive = true 
					});

				return parsedResponse.Data as TData;
			}
			catch
			{
				return null; 
			}
		}


		protected string BuildPath(string endpoint, params ApiArgument[] arguments)
		{
			StringBuilder path = new(Host);
			path.Append(endpoint);
			path.AppendFormat("?{0}={1}", "application_id", AppId);

			if (arguments is not null)
			{
				foreach (ApiArgument arg in arguments)
				{
					path.AppendFormat("&{0}={1}", arg.Name, arg.Value);
				}
			}

			return path.ToString();
		}
	}
}
