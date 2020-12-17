using System;

namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public record PlayerClanData
	{
		public long? ClanId { get; init; }
		public Clan Clan { get; init; }

		public DateTime JoinedAt { get; init; }
		
		public string Role { get; init; }
		public ClanRole ClanRole => Role switch
		{
			"commander"				=> ClanRole.Commander,
			"executive_officer"		=> ClanRole.ExecutiveOfficer,
			"recruiter"				=> ClanRole.Recruiter,
			"commissioned_officer"	=> ClanRole.CommissionedOfficer,
			"line_officer"			=> ClanRole.LineOfficer,
			"midshipman"			=> ClanRole.Midshipman,

			_						=> throw new NotImplementedException()
		};
	}
}