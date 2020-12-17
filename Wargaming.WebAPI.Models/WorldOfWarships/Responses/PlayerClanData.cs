namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public class PlayerClanData
	{
		public long? ClanId { get; set; }

		public Clan Clan { get; set; }
	}
}