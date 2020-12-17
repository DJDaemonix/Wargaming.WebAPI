using System;



namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public record ClanSeason
	{
		public int Id { get; init; }

		public string Name { get; init; }

		public long StartTimeSeconds { get; init; }

		public ClanLeague[] Leagues { get; init; }

		public DateTime StartTime => DateTime.UnixEpoch.AddSeconds(StartTimeSeconds);
	}
}