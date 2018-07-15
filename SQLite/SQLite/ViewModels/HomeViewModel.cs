/// Mohamed Ali NOUIRA
/// http://www.sweetmit.com
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using Xamarin.Forms;
using SQLite.Models;
using SQLite.IViewModels;
using SQLite.Repositories;
using System.Windows.Input;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Navigation;
using System.Collections.ObjectModel;

namespace SQLite.ViewModels
{
    public class HomeViewModel : BaseViewModel, IHomeViewModel
    {
        private IRepository<TodoItem> _iTodoItemRepository;

        private ObservableCollection<TodoItem> _todoItems;
        public ObservableCollection<TodoItem> TodoItems
        {
            get { return _todoItems; }
            set
            {
                _todoItems = value;
                OnPropertyChanged(nameof(TodoItems));
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand SelectedItemCommand { get; set; }

        [Preserve]
        public HomeViewModel(IRepository<TodoItem> _iTodoItemRepository,
            INavigationService _iNavigationService)
        {
            this._iNavigationService = _iNavigationService;
            this._iTodoItemRepository = _iTodoItemRepository;

            AddCommand = new Command(Add);
            SelectedItemCommand = new Command<TodoItem>(SelectedItem);
            
            MessagingCenter.Subscribe<string>(this, "HomeViewLoadedMessage", InitData);
        }

        private async void InitData(string message)
        {
            var result = await _iTodoItemRepository.Get();
            if (result != null && result.Count > 0)
            {
                TodoItems = new ObservableCollection<TodoItem>(result);
            }
            else
            {
                TodoItems = new ObservableCollection<TodoItem>();
            }
        }

        private async void Add()
        {
            await _iNavigationService.NavigateTo("DetailsView", null);
        }

        private async void SelectedItem(TodoItem param)
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add(nameof(TodoItem), param);
            await _iNavigationService.NavigateTo("DetailsView", navigationParams);
        }
    }
}
