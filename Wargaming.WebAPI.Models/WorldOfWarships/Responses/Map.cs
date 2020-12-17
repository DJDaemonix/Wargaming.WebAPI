namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public record Map
	{
		public string Name { get; init; }

		public string Description { get; init; }

		public string Icon { get; init; }

		public int MapId { get; init; }
	}
}