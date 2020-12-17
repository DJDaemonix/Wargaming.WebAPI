namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public class ClanStage
	{
		public string Type { get; set; }

		public string Target { get; set; }

		public int? TargetPublicRating { get; set; }

		public int? TargetDivision { get; set; }

		public int? TargetDivisionRating { get; set; }

		public int? TargetLeague { get; set; }

		public string[] Progress { get; set; }
	}
}