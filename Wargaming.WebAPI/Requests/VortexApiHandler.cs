using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Wargaming.WebAPI.Models;
using Wargaming.WebAPI.Models.Api;
using Wargaming.WebAPI.Models.WorldOfWarships.Responses;



namespace Wargaming.WebAPI.Requests
{
	public class VortexApiHandler : ApiHandler
	{
		public VortexApiHandler(IHttpClientFactory factory, Region region) : base(factory, GetApiHost(region), null) { }
		public VortexApiHandler(IHttpClientFactory factory, WorldOfWarshipsHandlerOptions options) : base(factory, GetApiHost(options.Region), null) { }
		public VortexApiHandler(IHttpClientFactory factory) : base(factory.CreateClient(nameof(VortexApiHandler))) { }


		public static string GetApiHost(Region region) => region switch
		{
			Region.EU => "https://vortex.worldofwarships.eu/api/",
			Region.NA => "https://vortex.worldofwarships.com/api/",
			Region.CIS => "https://vortex.worldofwarships.ru/api/",
			Region.ASIA => "https://vortex.worldofwarships.asia/api/",
			_ => throw new NotImplementedException(),
		};

		// Api : accounts/{id}
		public async Task<AccountInfo> FetchAccountAsync(uint accountId)
		{
			using HttpResponseMessage response = await GetRequestAsync($"accounts/{accountId}/");
			ApiResponse<Dictionary<uint, AccountInfo>> parsedRequest = await ParseResponseFullAsync<Dictionary<uint, AccountInfo>>(response);

			return parsedRequest.Data.Select(obj => obj.Value).First() with { AccountId = accountId };
		}
		public Task<AccountInfo[]> FetchAccountsAsync(uint[] accountIds)
		{
			Task<AccountInfo>[] fetches = new Task<AccountInfo>[accountIds.Length];
			for (int i = 0; i < accountIds.Length; i++)
			{
				Task<AccountInfo> t = FetchAccountAsync(accountIds[i]);
				t.Start();
				fetches[i] = t;
			}

			return Task.WhenAll(fetches);
		}

		// Api : accounts/{id}
		public async Task<PlayerClanData> FetchAccountClanAsync(uint accountId)
		{
			using HttpResponseMessage response = await GetRequestAsync($"accounts/{accountId}/clans/");
			ApiResponse<PlayerClanData> parsedRequest = await ParseResponseFullAsync<PlayerClanData>(response);

			return parsedRequest.Data;
		}
	}
}
