using System;



namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public record ClanListing
	{
		public uint ClanId { get; init; }

		public string Name { get; init; }

		public string Tag { get; init; }

		public float CreatedAt { get; init; }
		public DateTime CreatedAtTime => DateTime.UnixEpoch.AddSeconds(CreatedAt);

		public int MembersCount { get; init; }
	}
}
