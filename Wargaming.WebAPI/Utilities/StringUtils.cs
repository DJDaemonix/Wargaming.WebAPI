using System.Linq;



namespace Wargaming.WebAPI.Utilities
{
	internal static class StringUtils
	{
		public static string ToSnakeCase(this string str) => string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
	}
}