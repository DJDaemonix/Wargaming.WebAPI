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
		public const int MaxResultsInRequest = 100;

		protected IHttpClientFactory ClientFactory { get; init; }

		protected string Host { get; init; }
		protected string AppId { get; init; }

		protected static JsonSerializerOptions SerializerOptions { get; } = new()
		{
			PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance,
			PropertyNameCaseInsensitive = true
		};


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

		public static async Task<TData> ParseResponseDataAsync<TData>(HttpResponseMessage response)
		{
			return (await ParseResponseFullAsync<TData>(response)).Data;
		}

		internal static async Task<ApiResponse<TData>> ParseResponseFullAsync<TData>(HttpResponseMessage response)
		{
			try
			{
				ApiResponse<TData> parsedResponse = JsonSerializer.Deserialize<ApiResponse<TData>>(await response.Content.ReadAsStringAsync(), SerializerOptions);

				return parsedResponse;
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
