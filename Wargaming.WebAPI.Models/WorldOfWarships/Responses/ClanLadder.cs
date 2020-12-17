using System;



namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public class ClanLadder : ClanRating
	{
		public ClanRating[] Ratings { get; set; }

		public int? PrimeTime { get; set; }

		public int? PlannedPrimeTime { get; set; }

		public string RatingRealm { get; set; }

		public int LeadingTeam { get; set; }
	}
}