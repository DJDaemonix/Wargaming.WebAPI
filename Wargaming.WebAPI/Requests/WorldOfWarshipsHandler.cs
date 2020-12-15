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
	public class WorldOfWarshipsHandler : ApiHandler
	{
		public WorldOfWarshipsHandler(IHttpClientFactory factory, Region region, string appId) : base(factory, Game.WOWS, region, appId) { }

		// Api : account/list/
		public async Task<IEnumerable<PlayerListing>> ListPlayersAsync(string search)
		{
			using HttpResponseMessage response = await GetRequestAsync("account/list/", new ApiArgument("search", search));
			return (await ParseResponseFullAsync<IEnumerable<PlayerListing>>(response)).Data;
		}

		// Api : account/info/
		public async Task<IEnumerable<PlayerData>> FetchPlayerAsync(params uint[] accountIds)
		{
			using HttpResponseMessage response = await GetRequestAsync("account/info/", new ApiArgument("account_id", string.Join(',', accountIds)));
			ApiResponse<IDictionary<uint, PlayerData>> parsedRequest = await ParseResponseFullAsync<IDictionary<uint, PlayerData>>(response);

			return new List<PlayerData>(from KeyValuePair<uint, PlayerData> result in parsedRequest.Data select result.Value);
		}
	}
}
