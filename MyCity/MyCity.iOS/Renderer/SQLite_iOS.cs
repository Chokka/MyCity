using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using MyCity;

[assembly: Dependency(typeof(SQLite_iOS))]

namespace MyCity
{
	public class SQLite_iOS : ISQLite
	{
		#region ISQLite implementation

		public SQLite.Net.SQLiteConnection GetConnection()
		{
			string path = FileAccessHelper.GetFilePath("mycity_db.db");
			var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
			var connection = new SQLite.Net.SQLiteConnection(platform, path);

			return connection;
		}
		#endregion
	}
}