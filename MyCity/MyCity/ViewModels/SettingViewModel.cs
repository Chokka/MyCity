using System;
using System.Diagnostics;
namespace MyCity
{
	public class SettingViewModel : BaseNavigationViewModel
	{
		public SettingViewModel()
		{
		}

		public bool SignIn(string email, string pass)
		{
			var result = DBManager.sharedInstance().GetUser(email, pass);
			if (result is UserRegistration) {
				Singleton.shareInstance().user = result;
				return true;
			}
			return false;
		}

		public bool SignUp(UserRegistration user)
		{
			var result = DBManager.sharedInstance().AddUser(user);
			Debug.WriteLine(result);
			if (result == 1)
				return true;
			return false;
		}
	}
}