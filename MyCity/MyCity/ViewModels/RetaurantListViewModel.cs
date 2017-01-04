using System.Linq;
using System.Threading.Tasks;
using MvvmHelpers;
using Xamarin.Forms;

namespace MyCity
{
    public class RetaurantListViewModel : BaseNavigationViewModel
    {
		public RetaurantListViewModel()
        {
        }

		ObservableRangeCollection<Restaurant> _Retaurants;
        Command _LoadRetaurantsCommand;
        Command _RefreshRetaurantsCommand;


        public ObservableRangeCollection<Restaurant> Retaurants
        {
            get { return _Retaurants ?? (_Retaurants = new ObservableRangeCollection<Restaurant>()); }
            set
            {
                _Retaurants = value;
                OnPropertyChanged("Retaurants");
            }
        }

        public Command LoadRetaurantsCommand
        {
            get { return _LoadRetaurantsCommand ?? (_LoadRetaurantsCommand = new Command(async () => await ExecuteLoadAcquaintancesCommand())); }
        }

        public async Task ExecuteLoadAcquaintancesCommand()
        {
            LoadRetaurantsCommand.ChangeCanExecute();
            _Retaurants.Clear();
            if (Retaurants.Count < 1)
                FetchAcquaintances();

            LoadRetaurantsCommand.ChangeCanExecute();
        }

        public Command RefreshRetaurantsCommand
        {
            get
            {
                return _RefreshRetaurantsCommand ?? (_RefreshRetaurantsCommand = new Command(async () => await ExecuteRefreshAcquaintancesCommandCommand()));
            }
        }

        async Task ExecuteRefreshAcquaintancesCommandCommand()
        {
            RefreshRetaurantsCommand.ChangeCanExecute();

            FetchAcquaintances();

            RefreshRetaurantsCommand.ChangeCanExecute();
        }

		void FetchAcquaintances()
        {
            IsBusy = true;
			Retaurants = GetRestaruantsFromDB();
            IsBusy = false;
        }

		ObservableRangeCollection<Restaurant> GetRestaruantsFromDB() { 
			var list = DBManager.sharedInstance().GetRestaurants();
			ObservableRangeCollection<Restaurant> result = new ObservableRangeCollection<Restaurant>();
			foreach (Restaurant item in list) {
				result.Add(item);
			}
			return result;
		}
    }
}

