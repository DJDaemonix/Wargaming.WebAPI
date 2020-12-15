namespace Wargaming.WebAPI.Models.Api
{
	/// <summary>
	/// Parameter name and value to pass on to an API request <br />
	/// <i>(Used internally within the <see cref="Wargaming.WebAPI"/> Assembly)</i>
	/// </summary>
	public record ApiArgument(string Name, string Value);
}
