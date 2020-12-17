namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public record Clan
	{
		public long Id { get; init; }

		public string Tag { get; init; }

		public string Name { get; init; }

		public int Color { get; init; }

		public int? MembersCount { get; init; }
	}

	public enum ClanRole
	{
		Commander,
		ExecutiveOfficer,
		Recruiter,
		CommissionedOfficer,
		LineOfficer,
		Midshipman
	}
}