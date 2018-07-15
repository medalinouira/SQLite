/// Mohamed Ali NOUIRA
/// http://www.sweetmit.com
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using Xamarin.Forms;
using SQLite.Models;
using SQLite.IViewModels;
using SQLite.Repositories;
using Xamarin.Forms.Popups;
using System.Windows.Input;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Navigation;

namespace SQLite.ViewModels
{
    public class DetailsViewModel : BaseViewModel, IDetailsViewModel
    {
        private IRepository<TodoItem> _iTodoItemRepository;

        private TodoItem _currentTodoItem;
        public TodoItem CurrentTodoItem
        {
            get { return _currentTodoItem; }
            set
            {
                _currentTodoItem = value;
                OnPropertyChanged(nameof(CurrentTodoItem));
            }
        }

        private bool _isDeleteVisible;
        public bool IsDeleteVisible
        {
            get { return _isDeleteVisible; }
            set
            {
                _isDeleteVisible = value;
                OnPropertyChanged(nameof(IsDeleteVisible));
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        [Preserve]
        public DetailsViewModel(IRepository<TodoItem> _iTodoItemRepository,
            IPopupsService _iPopupsService,
            INavigationService _iNavigationService)
        {
            this._iPopupsService = _iPopupsService;
            this._iNavigationService = _iNavigationService;
            this._iTodoItemRepository = _iTodoItemRepository;
            
            SaveCommand = new Command(Save);
            DeleteCommand = new Command(Delete);

            MessagingCenter.Subscribe<string>(this, "DetailsViewLoadedMessage", InitData);
        }

        private void InitData(string message)
        {
            if(_iNavigationService.GetParameters() != null)
            {
                CurrentTodoItem = _iNavigationService.GetParameters().GetValue<TodoItem>(nameof(TodoItem));
                IsDeleteVisible = true;
                return;
            }

            IsDeleteVisible = false;
            CurrentTodoItem = new TodoItem();
        }

        private async void Save()
        {
            if (IsDeleteVisible)
            {
                await _iTodoItemRepository.Update(CurrentTodoItem);
            }
            else
            {
                await _iTodoItemRepository.Insert(CurrentTodoItem);
            }
            await _iNavigationService.GoBack();
        }

        private async void Delete()
        {
            await _iTodoItemRepository.Delete(CurrentTodoItem);
            await _iNavigationService.GoBack();
        }
    }
}
