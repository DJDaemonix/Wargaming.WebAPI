using System;



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

	public static class ClanRoleUtils
	{
		public static ClanRole ParseClanRole(this string role) => role switch
		{
			"commander" => ClanRole.Commander,
			"executive_officer" => ClanRole.ExecutiveOfficer,
			"recruiter" or "recruitment_officer" => ClanRole.Recruiter,
			"commissioned_officer" => ClanRole.CommissionedOfficer,
			"line_officer" or "officer" => ClanRole.LineOfficer,
			"midshipman" or "private" => ClanRole.Midshipman,

			_ => throw new NotImplementedException()
		};
	}
}