using System;

namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public record PlayerClanData
	{
		public long? ClanId { get; init; }
		public Clan Clan { get; init; }

		public DateTime JoinedAt { get; init; }
		
		public string Role { get; init; }
		public ClanRole ClanRole => Role.ParseClanRole();
	}
}