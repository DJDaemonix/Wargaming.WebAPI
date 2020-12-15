using System;



namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public partial record PlayerData
	{
		public uint AccountId { get; init; }

		public string Nickname { get; init; }

		public long CreatedAt { get; init; }
		public DateTime CreatedAtTime => new(CreatedAt);


	}
}
