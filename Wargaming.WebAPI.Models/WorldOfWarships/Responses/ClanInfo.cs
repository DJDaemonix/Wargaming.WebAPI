using System.Linq;

namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public class ClanInfo
	{
		public long Id { get; set; }

		public string Tag { get; set; }

		public string Name { get; set; }

		public string Color { get; set; }

		public int Rank { get; set; } = -1;

		public ClanLadder Ladder { get; set; }

//		public Region Region => LeadingRating.Realm.RealmStringToRegion();

//		public Region CurrentRealm => !string.IsNullOrEmpty(Ladder.RatingRealm)
//		  ? Ladder.RatingRealm.RealmStringToRegion()
//		  : Ladder.Realm.RealmStringToRegion();

		public int CurrentSeasonId { get; set; }

		public ClanRating AlphaRating => Ladder.Ratings.SingleOrDefault(r => r.SeasonId == CurrentSeasonId && r.Team == 1);

		public ClanRating BravoRating => Ladder.Ratings.SingleOrDefault(r => r.SeasonId == CurrentSeasonId && r.Team == 2);

		public ClanRating LeadingRating => AlphaRating is not null && AlphaRating.BestSeasonRating ? AlphaRating : BravoRating;
	}
}