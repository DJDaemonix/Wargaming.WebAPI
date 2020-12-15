using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public record PlayerListing
	{
		public string Nickname { get; init; }

		public uint AccountId { get; init; }
	}
}
