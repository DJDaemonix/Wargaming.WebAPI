using System;



namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public partial record AccountInfo
	{
		public uint AccountId { get; init; }

		public string Nickname { get; init; }

		public string Name { get => Nickname; init => Nickname = value; }

		public float CreatedAt { get; init; }
		public DateTime CreatedAtTime => DateTime.UnixEpoch.AddSeconds(CreatedAt);

		public VortexAccountStats Statistics { get; init; }

		public AccountInfo(AccountInfo input)
		{
			AccountId = input.AccountId;
			Nickname = input.Nickname;
			CreatedAt = input.CreatedAt;
			Statistics = input.Statistics;
		}
	}
}
