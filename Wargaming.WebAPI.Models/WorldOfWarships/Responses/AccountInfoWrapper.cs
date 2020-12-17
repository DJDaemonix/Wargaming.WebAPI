namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public class AccountInfoWrapper
	{
		public bool HiddenProfile { get; set; }
		public AccountStats[] Stats { get; set; }
	}
}