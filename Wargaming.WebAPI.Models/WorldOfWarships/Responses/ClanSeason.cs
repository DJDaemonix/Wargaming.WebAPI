using System;



namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public class ClanSeason
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public long StartTimeSeconds { get; set; }

		public ClanLeague[] Leagues { get; set; }

		public DateTime StartTime => DateTime.UnixEpoch.AddSeconds(StartTimeSeconds);
	}
}