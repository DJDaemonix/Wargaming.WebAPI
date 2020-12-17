namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public record AccountListing
	{
		public string Nickname { get; init; }

		public uint AccountId { get; init; }
	}
}
