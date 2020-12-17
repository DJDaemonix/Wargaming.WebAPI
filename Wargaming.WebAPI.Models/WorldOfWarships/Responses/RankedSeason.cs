using System;



namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public class RankedSeason
	{
		public int Id { get; set; }

		public long StartAtSeconds { get; set; }

		public string Name { get; set; }

		public DateTime StartAt => DateTime.UnixEpoch.AddSeconds(StartAtSeconds);
	}
}