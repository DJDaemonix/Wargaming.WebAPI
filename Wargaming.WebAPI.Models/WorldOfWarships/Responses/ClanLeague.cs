namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public record ClanLeague
	{
		public string Name { get; init; }

		public string Color { get; init; }
	}
}