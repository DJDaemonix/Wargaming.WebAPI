using System.Linq;

namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public record ClanInfo
	{
		public long Id { get; init; }

		public string Tag { get; init; }

		public string Name { get; init; }

		public string Color { get; init; }

		public int Rank { get; init; } = -1;

		public ClanLadder Ladder { get; init; }

//		public Region Region => LeadingRating.Realm.RealmStringToRegion();

//		public Region CurrentRealm => !string.IsNullOrEmpty(Ladder.RatingRealm)
//		  ? Ladder.RatingRealm.RealmStringToRegion()
//		  : Ladder.Realm.RealmStringToRegion();

		public int CurrentSeasonId { get; init; }

		public ClanRating AlphaRating => Ladder.Ratings.SingleOrDefault(r => r.SeasonId == CurrentSeasonId && r.Team == 1);

		public ClanRating BravoRating => Ladder.Ratings.SingleOrDefault(r => r.SeasonId == CurrentSeasonId && r.Team == 2);

		public ClanRating LeadingRating => AlphaRating is not null && AlphaRating.BestSeasonRating ? AlphaRating : BravoRating;
	}
}