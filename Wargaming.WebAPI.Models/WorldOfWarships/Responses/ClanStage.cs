namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public record ClanStage
	{
		public string Type { get; init; }

		public string Target { get; init; }

		public int? TargetPublicRating { get; init; }

		public int? TargetDivision { get; init; }

		public int? TargetDivisionRating { get; init; }

		public int? TargetLeague { get; init; }

		public string[] Progress { get; init; }
	}
}