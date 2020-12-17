namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public class AccountStats
	{
		// fields=pve.battles,pve.damage_dealt,pve.frags,pve.wins,pve.xp

		public int Battles
		{
			get => WgBattles ?? VortexBattles ?? 0;
			set
			{
				if (WgBattles.HasValue)
				{
					WgBattles = value;
				}
				else
				{
					VortexBattles = value;
				}
			}
		}

		public int? VortexBattles { get; set; }
		public int? WgBattles { get; set; }

		public long Xp
		{
			get => WgXp ?? VortexXp ?? 0;
			set
			{
				if (WgXp.HasValue)
				{
					WgXp = value;
				}
				else
				{
					VortexXp = value;
				}
			}
		}

		public long? VortexXp { get; set; }
		public long? WgXp { get; set; }

		public int Wins { get; set; }

		public long Damage { get; set; }

		public int Frags { get; set; }

//		public MatchGroup StatsType { get; set; }
	}

	public class WgStatsWrapper
	{
		public AccountStats[] WgStats { get; set; }
		public bool HiddenProfile { get; set; }
	}
}