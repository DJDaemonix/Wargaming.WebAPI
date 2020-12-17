using System;



namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public record ClanLadder : ClanRating
	{
		public ClanRating[] Ratings { get; init; }

		public int? PrimeTime { get; init; }

		public int? PlannedPrimeTime { get; init; }

		public string RatingRealm { get; init; }

		public int LeadingTeam { get; init; }
	}
}