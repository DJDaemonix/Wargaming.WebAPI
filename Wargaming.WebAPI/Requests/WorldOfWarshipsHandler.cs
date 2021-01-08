using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Wargaming.WebAPI.Models;
using Wargaming.WebAPI.Models.Api;
using Wargaming.WebAPI.Models.WorldOfWarships.Responses;
using static Wargaming.WebAPI.ApiProperties;



namespace Wargaming.WebAPI.Requests
{
	public class WorldOfWarshipsHandler : ApiHandler
	{
		public WorldOfWarshipsHandler(IHttpClientFactory factory, WorldOfWarshipsHandlerOptions options) : base(factory, GetApiHost(Game.WOWS, options.Region), options.AppId) { }
		protected WorldOfWarshipsHandler(IHttpClientFactory factory) : base(factory.CreateClient(nameof(WorldOfWarshipsHandler))) { }


		// Api : account/list/
		public async Task<IEnumerable<AccountListing>> ListPlayersAsync(string search)
		{
			using HttpResponseMessage response = await GetRequestAsync("account/list/", new ApiArgument("search", search));
			return (await ParseResponseFullAsync<IEnumerable<AccountListing>>(response)).Data;
		}

		// Api : account/info/
		public async Task<IEnumerable<AccountInfo>> FetchPlayerAsync(params uint[] accountIds)
		{
			using HttpResponseMessage response = await GetRequestAsync("account/info/", new ApiArgument("account_id", string.Join(',', accountIds)));
			ApiResponse<Dictionary<uint, AccountInfo>> parsedRequest = await ParseResponseFullAsync<Dictionary<uint, AccountInfo>>(response);

			return new List<AccountInfo>(parsedRequest.Data.Select(obj => obj.Value));
		}
	}
}
