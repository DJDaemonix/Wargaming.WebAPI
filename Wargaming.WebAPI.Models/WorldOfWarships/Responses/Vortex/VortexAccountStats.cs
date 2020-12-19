namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public record VortexAccountStats
	{
//		public object Clan { get; init; }
//		public object Pvp { get; init; }
//		public object Pve { get; init; }

		public VortexAccountBasic Basic { get; init; }
	}

	public record VortexAccountBasic
	{
		public object LevelingTier { get; init; }
		public long CreatedAt { get; init; }
		public int LevelingPoints { get; init; }
		public int Karma { get; init; }
		public long LastBattleTime { get; init; }
	}
}
