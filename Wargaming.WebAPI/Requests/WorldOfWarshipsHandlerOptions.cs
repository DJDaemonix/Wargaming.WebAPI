using Wargaming.WebAPI.Models;



namespace Wargaming.WebAPI.Requests
{
	public sealed class WorldOfWarshipsHandlerOptions
	{
		internal Region Region { get; init; }
		internal string AppId { get; init; }

		public WorldOfWarshipsHandlerOptions(Region region, string appId)
		{
			Region = region;
			AppId = appId;
		}
	}
}
