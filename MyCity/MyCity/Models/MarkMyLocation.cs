using System;
namespace MyCity
{
	public class MarkMyLocation
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public int PinId { get; set; }
		public string PinActivatedTime { get; set; }
		public string PinningAttempts { get; set; }
		public int IsPinActive { get; set; }
		public string IsValidUser { get; set; }
		public string Weather { get; set; }
		public string PinExpiredTime { get; set; }
	}
}
