namespace Wargaming.WebAPI.Models.Api
{
	/// <summary>
	/// Loosely-typed / Generic API Response template.
	/// Use <see cref="ApiResponse{TData}"/> for strong-typing.
	/// </summary>
	public record ApiResponse
	{
		public string Status { get; init; }

		public ResponseMeta Meta { get; init; }

		public object Data { get; init; }
	}

	/// <summary>
	/// Strongly-typed / Defined API Response template.
	/// Use <see cref="ApiResponse"/> for generic-typing.
	/// </summary>
	/// <typeparam name="TData">Model type of the Response's Data</typeparam>
	public record ApiResponse<TData>
	{
		public string Status { get; init; }

		public ResponseMeta Meta { get; init; }

		public TData Data { get; init; }
	}
}
