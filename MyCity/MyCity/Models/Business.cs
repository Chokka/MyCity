using System;
namespace MyCity
{
	public class Business
	{
		public int id { get; set; }
		public int categoryid { get; set; }
		public int AddressId { get; set; }
		public string BusinessName { get; set; }
		public string BusinessOwner { get; set; }
		public string BusinessManager { get; set; }
		public string Phone_Number1 { get; set; }
		public string Extension1 { get; set; }
		public string Phone_Number2 { get; set; }
		public string Extension2 { get; set; }
		public string Mobile_Number { get; set; }
		public string Fax { get; set; }
		public string Email_Id { get; set; }
		public string Website { get; set; }
		public int IsActive { get; set; }
		public string CreatedDate { get; set; }
		public string ModifiedDate { get; set; }
	}
}
