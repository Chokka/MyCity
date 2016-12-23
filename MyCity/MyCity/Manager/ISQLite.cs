using System;
using SQLite.Net;
namespace MyCity
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}
