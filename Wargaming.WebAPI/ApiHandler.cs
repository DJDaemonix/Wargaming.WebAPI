using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Wargaming.WebAPI.Models;
using Wargaming.WebAPI.Models.Api;
using Wargaming.WebAPI.Utilities;
using static Wargaming.WebAPI.ApiProperties;



namespace Wargaming.WebAPI
{
	public class ApiHandler
	{
		public const int MaxResultsInRequest = 100;

		protected HttpClient Client { get; init; }

		protected string AppId { get; init; }

		protected static JsonSerializerOptions SerializerOptions { get; } = new()
		{
			PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance,
			PropertyNameCaseInsensitive = true,
			NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals | JsonNumberHandling.AllowReadingFromString,
			
		};


		public ApiHandler(IHttpClientFactory factory, string host, string appId)
		{
			Client = factory.CreateClient();
			Client.BaseAddress = new(host);
			AppId = appId;
		}
		protected ApiHandler(HttpClient client)
		{
			Client = client ?? throw new ArgumentNullException(nameof(client));
		}

		~ApiHandler()
		{
			Client.Dispose();
		}

		public async Task<HttpResponseMessage> GetRequestAsync(string endpoint, params ApiArgument[] arguments)
		{
			string path = BuildPath(endpoint, arguments);
			return await Client.GetAsync(path);
		}

		public static async Task<TData> ParseResponseDataAsync<TData>(HttpResponseMessage response) => (await ParseResponseFullAsync<TData>(response)).Data;

		internal static async Task<ApiResponse<TData>> ParseResponseFullAsync<TData>(HttpResponseMessage response)
		{
			try
			{
				string json = await response.Content.ReadAsStringAsync();
				ApiResponse<TData> parsedResponse = JsonSerializer.Deserialize<ApiResponse<TData>>(json, SerializerOptions);

				return parsedResponse;
			}
			catch
			{
#if RELEASE				
				return null;
#else
				throw;
#endif
			}
		}


		protected string BuildPath(string endpoint, params ApiArgument[] arguments)
		{
			StringBuilder path = new(endpoint);

			if (AppId is not null)
			{
				path.AppendFormat("?{0}={1}", "application_id", AppId);
			}

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
