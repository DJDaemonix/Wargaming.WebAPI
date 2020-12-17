using System;



namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public class ClanRating
	{
		public bool BestSeasonRating { get; set; }

		public int Division { get; set; }

		public int DivisionRating { get; set; }

		public int PublicRating { get; set; }

		public int InitialPublicRating { get; set; }

		public ClanLeague League { get; set; }

		public int Team { get; set; }

		public int Wins { get; set; }

		public int Battles { get; set; }

		public int SeasonId { get; set; }

		public int LongestWinningStreak { get; set; }

		public int CurrentWinningStreak { get; set; }

		public DateTime? LastBattleAt { get; set; }

		public DateTime? LastWinAt { get; set; }

		public ClanStage Stage { get; set; }

		public int? Rank { get; set; }

		public int? GlobalRank { get; set; }

		public string Realm { get; set; }
	}
}