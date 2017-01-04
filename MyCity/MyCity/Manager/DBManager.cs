using Xamarin.Forms;
using SQLite.Net;
using System.Linq;
using System.Collections.Generic;

namespace MyCity
{
	public class DBManager
	{

		private static DBManager instance = null;
		public static DBManager sharedInstance() {
			if (instance == null)
			{
				instance = new DBManager();
			}
			return instance;
		}

		SQLiteConnection _db;

		private DBManager()
		{
			_db = DependencyService.Get<ISQLite>().GetConnection();
		}

		/*----- Address Manage -----*/
		public void AddAddress(Address item)
		{
			_db.Execute("insert into Address values(null,'" + item.Address1 + "','" + item.Address2 + "'," + item.Address3 + ",'" + item.City
			            + "','" + item.Zipcode + "', '"+item.State+"','"+item.CreatedBy
			            +"','" + item.Modified+"',"+item.IsActive+");");
		
		}

		public void DeleteAddress(int Id)
		{
			_db.Execute("delete from Address where Id=?", Id);
		}
		public void UpdateAddress(Address item)
		{
			_db.Execute("update Address set Address1='" + item.Address1 + "', Address2='" + item.Address2
			            + "', Address3='" + item.Address3 +"', City='"+item.City+"', Zipcode='"+item.Zipcode
			            + "', State='" + item.State +"', CreatedBy='"+item.CreatedBy+"', Modified='"+item.Modified
			            + "', IsActive='" + item.IsActive + "' where Id=" + item.Id);
		}

		public IEnumerable<Address> GetAllAddress()
		{
			return _db.Query<Address>("select * from Address where 1");
		}

		public Address GetAddress(string id)
		{
			var result = _db.Query<Address>("select * from Address where flightId=?", id);
			if (result.Count > 0)
				return result.First();
			else
				return null;
		}

		/*----- Business Manage -----*/
		public void AddBusiness(Business item)
		{
			_db.Execute("insert into Business values(null," + item.categoryid + "," + item.AddressId + ",'" + item.BusinessName + "','" + item.BusinessOwner
			            + "','" + item.BusinessManager + "', '" + item.Phone_Number1 + "','" + item.Extension1
			            + "','" + item.Phone_Number2 + "','" + item.Extension2 + "','" + item.Mobile_Number
			            + "','" + item.Fax + "','" + item.Email_Id + "','" + item.Website + "'," + item.IsActive + ",'" + item.CreatedDate + "','" + item.ModifiedDate + "');");

		}

		public void DeleteBusiness(int Id)
		{
			_db.Execute("delete from Business where id=?", Id);
		}
		public void UpdateBusiness(Business item)
		{
			_db.Execute("update Business set categoryid=" + item.categoryid + ", AddressId=" + item.AddressId
			            + ", BusinessName='" + item.BusinessName + "', BusinessOwner='" + item.BusinessOwner + "', BusinessManager='" + item.BusinessManager
			            + "', Phone_Number1='" + item.Phone_Number1 + "', Extension1='" + item.Extension1 + "', Phone_Number2='" + item.Phone_Number2
			            + "', Extension2='" + item.Extension2 + "',Mobile_Number='" + item.Mobile_Number + "', Fax=" + item.Fax + ", Email_Id='" + item.Email_Id
			            + "', Website='" + item.Website + "', IsActive=" + item.IsActive + ",CreatedDate='" + item.CreatedDate + "',ModifiedDate='" + item.ModifiedDate + "' where id=" + item.id);
		}

		public IEnumerable<Business> GetAllBusiness()
		{
			return _db.Query<Business>("select * from Business where 1");
		}

		public Business GetBusiness(string id)
		{
			var result = _db.Query<Business>("select * from Business where id=?", id);
			if (result.Count > 0)
				return result.First();
			else
				return null;
		}

		/*----- Address Manage -----*/
		public void AddCategory(Category item)
		{
			_db.Execute("insert into Category values(null,'" + item.category_name + "');");

		}

		public void DeleteCategory(int Id)
		{
			_db.Execute("delete from Category where id=?", Id);
		}
		public void UpdateCategory(Category item)
		{
			_db.Execute("update Category set category_name='" + item.category_name + "' where id=" + item.id);
		}

		public IEnumerable<Category> GetAllCategory()
		{
			return _db.Query<Category>("select * from Category where 1");
		}

		public Category GetCategory(string id)
		{
			var result = _db.Query<Category>("select * from Category where flightId=?", id);
			if (result.Count > 0)
				return result.First();
			else
				return null;
		}

		/*----- Location Manage -----*/
		public void AddLocation(MarkMyLocation item)
		{
			string sql = "insert into MarkMyLocation values(null," + item.UserId + "," + item.Latitude + "," + item.Longitude + "," + item.PinId
						+ ",'" + item.PinActivatedTime + "', " + item.PinningAttempts + "," + item.IsPinActive
																		 + "," + item.IsValidUser + ",'" + item.Weather + "','null','" + item.PinExpiredTime + "');";
			_db.Execute(sql);

		}

		public void DeleteLocation(int Id)
		{
			_db.Execute("delete from MarkMyLocation where Id=?", Id);
		}

		public void UpdateLocation(MarkMyLocation item)
		{
			_db.Execute("update MarkMyLocation set UserId=" + item.UserId + ", Latitude=" + item.Latitude
			            + ", Longitude=" + item.Longitude + ", PinId=" + item.PinId + ", PinActivatedTime='" + item.PinActivatedTime
			            + "', PinningAttempts='" + item.PinningAttempts + "', IsPinActive=" + item.IsPinActive + ", IsValidUser=" + item.IsValidUser
			            + ", Weather='" + item.Weather + "',PinExpiredTime='" + item.PinExpiredTime + "' where Id=" + item.Id);
		}

		public IEnumerable<MarkMyLocation> GetAllLocation()
		{
			return _db.Query<MarkMyLocation>("select * from MarkMyLocation where 1");
		}

		public MarkMyLocation GetLocation(string id)
		{
			var result = _db.Query<MarkMyLocation>("select * from MarkMyLocation where Id=?", id);
			if (result.Count > 0)
				return result.First();
			else
				return null;
		}

		public MarkMyLocation GetLastLocation() { 
			var result = _db.Query<MarkMyLocation>("select * from MarkMyLocation order by Id desc");
			if (result.Count > 0)
				return result.First();
			else
				return null;
		}

		/*----- Pin Manage -----*/
		public void AddPin(CustomPin item)
		{
			string sql = "insert into Pin values("+item.Id+",'" + item.PinName + "','" + item.CreatedDate + "','" + item.ModifiedDate + "'," + item.IsActive + ");";
			_db.Execute(sql);
		}

		public void DeletePin(int flightId)
		{
			_db.Execute("delete from Pin where flightId=?", flightId);
		}
		public void UpdatePin(CustomPin item)
		{
			_db.Execute("update Pin set airlineName='" + item.PinName + "', airlineImageURL='" + item.CreatedDate
			            + "', departureTime='" + item.ModifiedDate + "' where Id=" + item.Id);
		}

		public IEnumerable<CustomPin> GetPins()
		{
			return _db.Query<CustomPin>("select * from Pin where 1");
		}

		public CustomPin GetPin(string id)
		{
			var result = _db.Query<CustomPin>("select * from Pin where flightId=?", id);
			if (result.Count > 0)
				return result.First();
			else
				return null;
		}

		public CustomPin GetPinByName(string name) { 
			var result = _db.Query<CustomPin>("select * from Pin where PinName=?", name);
			if (result.Count > 0)
				return result.First();
			else
				return null;
		}

		/*----- Restaurant Manage -----*/
		public void AddRestaurant(Restaurant item)
		{
			_db.Execute("insert into RestaurantList values(null,'" + item.categoryName + "','" + item.BusinessName + "'," + item.Address1 + ",'" + item.Address2
			            + "','" + item.City + "', '" + item.State + "','" + item.Mobile_Number
			            + "','" + item.Phone_Number1 + "','" + item.Fax + "','" + item.Email_Id
			            + "','" + item.WebSite + "','" + item.BusinessOwner + "','" + item.BusinessManager + "'," + item.IsFlag + ");");

		}

		public void DeleteRestaurant(int flightId)
		{
			_db.Execute("delete from RestaurantList where flightId=?", flightId);
		}
		public void UpdateRestaurant(Restaurant item)
		{
			_db.Execute("update RestaurantList set airlineName='" + item.categoryName + "', airlineImageURL='" + item.BusinessName
			            + "', departureTime='" + item.Address1 + "', departureSTime='" + item.Address2 + "', departureETime='" + item.City
			            + "', arrivalTime='" + item.State + "', arrivalSTime='" + item.Mobile_Number + "', arrivalETime='" + item.Phone_Number1
			            + "', trackedTime='" + item.Fax + "',status='" + item.Email_Id + "', isActive=" + item.WebSite + ", isArrival=" + item.BusinessOwner
			            + ", lat='" + item.BusinessManager + "', lon=" + item.IsFlag + " where id=" + item.id);
		}

		public IEnumerable<Restaurant> GetRestaurants()
		{
			return _db.Query<Restaurant>("select * from RestaurantList where 1");
		}

		public Restaurant GetRestaurant(string id)
		{
			var result = _db.Query<Restaurant>("select * from RestaurantList where id=?", id);
			if (result.Count > 0)
				return result.First();
			else
				return null;
		} 

		/*----- User Manage -----*/
		public int AddUser(UserRegistration item)
		{
			string sql = "insert into UserRegistration values(" + item.Id + ",'" + item.UserName + "','"+item.FirstName+"','"+item.LastName+"'," + item.PhoneNumber + ",'" + item.EmailId
			              + "','" + item.Password + "',"+item.IsActive+", '" + item.CreatedDate + "','" + item.ModifiedDate + "');";
			return _db.Execute(sql);

		}

		public void DeleteUser(int flightId)
		{
			_db.Execute("delete from UserRegistration where flightId=?", flightId);
		}

		public void UpdateUser(UserRegistration item)
		{
			_db.Execute("update UserRegistration set UserName='" + item.UserName + "',FirstName='"+item.FirstName+"',LastName='"+item.LastName
			            + "', PhoneNumber='" + item.PhoneNumber + "', EmailId='" + item.EmailId + "', Password='" + item.Password
			            + "', CreatedDate='" + item.CreatedDate + "', ModifiedDate='" + item.ModifiedDate + "' where UserId=" + item.Id);
		}

		public IEnumerable<UserRegistration> GetUsers()
		{
			return _db.Query<UserRegistration>("select * from UserRegistration where 1");
		}

		public UserRegistration GetUser(string id)
		{
			var result = _db.Query<UserRegistration>("select * from UserRegistration where flightId=?", id);
			if (result.Count > 0)
				return result.First();
			else
				return null;
		}

		public UserRegistration GetUser(string email, string pass)
		{
			var result = _db.Query<UserRegistration>("select * from UserRegistration where EmailId='"+email+"' and Password='"+pass+"'");
			if (result.Count > 0)
				return result.First();
			else
				return null;
		}
	}
}

