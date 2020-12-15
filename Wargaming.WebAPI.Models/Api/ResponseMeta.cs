using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wargaming.WebAPI.Models.Api
{
	public record ResponseMeta
	{
		public int? Count { get; init; }
	}
}
