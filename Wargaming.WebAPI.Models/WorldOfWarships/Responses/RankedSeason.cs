using System;



namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public record RankedSeason
	{
		public int Id { get; init; }

		public long StartAtSeconds { get; init; }

		public string Name { get; init; }

		public DateTime StartAt => DateTime.UnixEpoch.AddSeconds(StartAtSeconds);
	}
}