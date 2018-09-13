using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFDataGridPaging
{
    public class MainViewModel : ViewModel
    {
        private ICommand _firstPageCommand;

        public ICommand FirstPageCommand
        {
            get
            {
                return _firstPageCommand;
            }

            set
            {
                _firstPageCommand = value;
            }
        }

        private ICommand _previousPageCommand;

        public ICommand PreviousPageCommand
        {
            get
            {
                return _previousPageCommand;
            }

            set
            {
                _previousPageCommand = value;
            }
        }

        private ICommand _nextPageCommand;

        public ICommand NextPageCommand
        {
            get
            {
                return _nextPageCommand;
            }

            set
            {
                _nextPageCommand = value;
            }
        }

        private ICommand _lastPageCommand;

        public ICommand LastPageCommand
        {
            get
            {
                return _lastPageCommand;
            }

            set
            {
                _lastPageCommand = value;
            }
        }

        private int _pageSize;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                if(_pageSize != value)
                {
                    _pageSize = value;
                    OnPropertyChanged("PageSize");
                }
            }
        }

        private int _currentPage;

        public int CurrentPage
        {
            get
            {
                return _currentPage;
            }

            set
            {
                if(_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged("CurrentPage");
                }
            }
        }

        private int _totalPage;

        public int TotalPage
        {
            get
            {
                return _totalPage;
            }

            set
            {
                if(_totalPage != value)
                {
                    _totalPage = value;
                    OnPropertyChanged("TotalPage");
                }
            }
        }

        private ObservableCollection<FakeDatabase> _fakeSoruce;

        public ObservableCollection<FakeDatabase> FakeSource
        {
            get
            {
                return _fakeSoruce;
            }
            set
            {
                if(_fakeSoruce != value)
                {
                    _fakeSoruce = value;
                    OnPropertyChanged("FakeSource");
                }
            }
        }

        private List<FakeDatabase> _source;

        public MainViewModel()
        {
            _currentPage = 1;

            _pageSize = 10;

            FakeDatabase fake = new FakeDatabase();

            _source = fake.GenerateFakeSource();

            _totalPage = _source.Count / _pageSize;

            _fakeSoruce = new ObservableCollection<FakeDatabase>();

            List<FakeDatabase> result = _source.Take(_pageSize).ToList();

            _fakeSoruce.Clear();

            _fakeSoruce.AddRange(result);

            _firstPageCommand = new DelegateCommand(FirstPageAction);

            _previousPageCommand = new DelegateCommand(PreviousPageAction);

            _nextPageCommand = new DelegateCommand(NextPageAction);

            _lastPageCommand = new DelegateCommand(LastPageAction);
        }

        private void FirstPageAction()
        {
            CurrentPage = 1;

            var result = _source.Take(_pageSize).ToList();

            _fakeSoruce.Clear();

            _fakeSoruce.AddRange(result);
        }

        private void PreviousPageAction()
        {
            if(CurrentPage == 1)
            {
                return;
            }

            List<FakeDatabase> result = new List<FakeDatabase>();

            if(CurrentPage == 2)
            {
                result = _source.Take(_pageSize).ToList();
            }
            else
            {
                result = _source.Skip((CurrentPage - 2) * _pageSize).Take(_pageSize).ToList();
            }

            _fakeSoruce.Clear();

            _fakeSoruce.AddRange(result);

            CurrentPage--;
        }

        private void NextPageAction()
        {
            if(CurrentPage == _totalPage)
            {
                return;
            }

            List<FakeDatabase> result = new List<FakeDatabase>();

            result = _source.Skip(CurrentPage * _pageSize).Take(_pageSize).ToList();

            _fakeSoruce.Clear();

            _fakeSoruce.AddRange(result);

            CurrentPage++;
        }

        private void LastPageAction()
        {
            CurrentPage = TotalPage;

            int skipCount = (_totalPage - 1) * _pageSize;
            int takeCount = _source.Count - skipCount;

            var result = _source.Skip(skipCount).Take(takeCount).ToList();

            _fakeSoruce.Clear();

            _fakeSoruce.AddRange(result);
        }
    }
}
