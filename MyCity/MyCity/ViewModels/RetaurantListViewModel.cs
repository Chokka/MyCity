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
                await FetchAcquaintances();

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

            await FetchAcquaintances();

            RefreshRetaurantsCommand.ChangeCanExecute();
        }

        async Task FetchAcquaintances()
        {
            IsBusy = true;
			var list = new ObservableRangeCollection<Restaurant>();
			var item = new Restaurant { Name = "Name", Address = "Address" };
			var item1 = new Restaurant { Name = "Name1", Address = "Address" };
			var item2 = new Restaurant { Name = "Name2", Address = "Address" };
			var item3 = new Restaurant { Name = "Name3", Address = "Address"};

			//Retaurants = new ObservableRangeCollection<Retaurant>(await _DataSource.GetItems());
			list.Add(item);
			list.Add(item1);
			list.Add(item2);
			list.Add(item3);
			Retaurants = list;
            IsBusy = false;
        }
    }
}

