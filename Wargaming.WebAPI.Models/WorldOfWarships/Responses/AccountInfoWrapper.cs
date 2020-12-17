namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public record AccountInfoWrapper
	{
		public bool HiddenProfile { get; init; }
		public AccountStats[] Stats { get; init; }
	}
}