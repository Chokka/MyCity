using System;
namespace MyCity
{
	public class Singleton
	{
		static Singleton instance;

		public static Singleton shareInstance() {
			if (instance == null) {
				instance = new Singleton();
			}
			return instance;
		}

		public UserRegistration user;

		private Singleton() {
			
		}

	}
}
