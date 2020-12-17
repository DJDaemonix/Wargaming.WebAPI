using System;



namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public record ClanRating
	{
		public bool BestSeasonRating { get; init; }

		public int Division { get; init; }

		public int DivisionRating { get; init; }

		public int PublicRating { get; init; }

		public int InitialPublicRating { get; init; }

		public ClanLeague League { get; init; }

		public int Team { get; init; }

		public int Wins { get; init; }

		public int Battles { get; init; }

		public int SeasonId { get; init; }

		public int LongestWinningStreak { get; init; }

		public int CurrentWinningStreak { get; init; }

		public DateTime? LastBattleAt { get; init; }

		public DateTime? LastWinAt { get; init; }

		public ClanStage Stage { get; init; }

		public int? Rank { get; init; }

		public int? GlobalRank { get; init; }

		public string Realm { get; init; }
	}
}