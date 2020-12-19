using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wargaming.WebAPI.Models;
using Wargaming.WebAPI.Models.Api;
using Wargaming.WebAPI.Models.WorldOfWarships.Responses;
using Wargaming.WebAPI.Models.WorldOfWarships.Responses.Vortex;

namespace Wargaming.WebAPI.Requests
{
	public class VortexApiHandler : ApiHandler
	{
		public VortexApiHandler(IHttpClientFactory factory, Region region) : base(factory)
		{
			ClientFactory = factory ?? throw new ArgumentNullException(nameof(factory));
			Host = GetApiHost(region);
		}

		private static string GetApiHost(Region region) => region switch
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

			return new List<AccountInfo>(parsedRequest.Data.Select(obj => obj.Value)).First();
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
