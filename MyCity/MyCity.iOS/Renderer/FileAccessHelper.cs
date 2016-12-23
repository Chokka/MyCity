using System;
using System.IO;
using Foundation;

namespace MyCity
{
	public class FileAccessHelper
	{
		public static string GetFilePath(string filename)
		{
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

			if (!Directory.Exists(libFolder))
			{
				Directory.CreateDirectory(libFolder);
			}

			string dbPath = Path.Combine(libFolder, filename);

			CopyDBIfNotExists(dbPath);

			return dbPath;
		}

		private static void CopyDBIfNotExists(string dbPath)
		{
			if (!File.Exists(dbPath))
			{
				var existingDb = NSBundle.MainBundle.PathForResource("mycity_db", "db");
				File.Copy(existingDb, dbPath);
			}
		}
	}
}