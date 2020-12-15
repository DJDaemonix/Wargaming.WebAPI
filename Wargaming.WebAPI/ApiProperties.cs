namespace Wargaming.WebAPI
{
	public static class ApiProperties
	{
		public enum Region { EU, NA, CIS, ASIA }
		public enum Game { WG, WOT, WOWS, WOWP }

		public static string GetApiHost(Game game, Region region) => apiHosts[(int)game][(int)region];

		private static readonly string[][] apiHosts = new string[][] // [game][region]
		{
			// Wargaming.net
			new string[]
			{
				"https://api.worldoftanks.eu/wgn/",
				"https://api.worldoftanks.com/wgn/",
				"https://api.worldoftanks.ru/wgn/",
				"https://api.worldoftanks.asia/wgn/"
			},

			// World Of Tanks
			new string[]
			{
				"https://api.worldoftanks.eu/wot/",
				"https://api.worldoftanks.com/wot/",
				"https://api.worldoftanks.ru/wot/",
				"https://api.worldoftanks.asia/wot/"
			},

			// World Of Warships
			new string[]
			{
				"https://api.worldofwarships.eu/wows/",
				"https://api.worldofwarships.com/wows/",
				"https://api.worldofwarships.ru/wows/",
				"https://api.worldofwarships.asia/wows/"
			},

			// World Of Warplanes
			new string[]
			{
				"https://api.worldofwarplanes.eu/wowp/",
				"https://api.worldofwarplanes.com/wowp/",
				"https://api.worldofwarplanes.ru/wowp/",
				"https://api.worldofwarplanes.asia/wowp/"
			},
		};
	}
}