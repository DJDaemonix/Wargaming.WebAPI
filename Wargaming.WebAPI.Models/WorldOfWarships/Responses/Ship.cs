using System.Runtime.Serialization;



namespace Wargaming.WebAPI.Models.WorldOfWarships.Responses
{
	public class Ship
	{
		public string Name { get; set; }

		public int Tier { get; set; }

		public long Id { get; set; }

		public ShipType Type { get; set; }

		public bool Testship { get; set; }
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