using System.Runtime.Serialization;



namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public record Ship
	{
		public string Name { get; init; }

		public int Tier { get; init; }

		public long Id { get; init; }

		public ShipType Type { get; init; }

		public bool Testship { get; init; }
	}


	public enum ShipType
	{
		[EnumMember(Value = nameof(Unknown))]
		Unknown = -1,

		[EnumMember(Value = nameof(AirCarrier))]
		AirCarrier = 0,

		[EnumMember(Value = nameof(Battleship))]
		Battleship = 1,

		[EnumMember(Value = nameof(Cruiser))]
		Cruiser = 2,

		[EnumMember(Value = nameof(Destroyer))]
		Destroyer = 3,

		[EnumMember(Value = nameof(Submarine))]
		Submarine = 4
	}
}