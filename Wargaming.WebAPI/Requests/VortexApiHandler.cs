using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wargaming.WebAPI.Models.Api;
using Wargaming.WebAPI.Models.WorldOfWarships.Responses;
using static Wargaming.WebAPI.ApiProperties;

namespace Wargaming.WebAPI.Requests
{
	public class VortexApiHandler : WorldOfWarshipsHandler
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
		public async Task<IEnumerable<PlayerData>> FetchPlayerAsync(uint accountId)
		{
			using HttpResponseMessage response = await GetRequestAsync($"accounts/{accountId}/");
			ApiResponse<Dictionary<uint, PlayerData>> parsedRequest = await ParseResponseFullAsync<Dictionary<uint, PlayerData>>(response);

			return new List<PlayerData>(parsedRequest.Data.Select(obj => obj.Value));
		}
	}
}
