using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Reservoom.Commands;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reservoom.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private string _userName;
        public string UserName
        {
            get 
            { 
                return _userName; 
            }
            set 
            { 
                _userName = value; 
                OnPropertyChanged(nameof(UserName));
            }
        }

        private int _floorNumber;
        public int FloorNumber
        {
            get
            {
                return _floorNumber;
            }
            set
            {
                _floorNumber = value;
                OnPropertyChanged(nameof(FloorNumber));
            }
        }

        private int _roomNumber;
        public int RoomNumber
        {
            get
            {
                return _roomNumber;
            }
            set
            {
                _roomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }
        
        private DateTime _startdate = new DateTime(2022, 2, 2);
        public DateTime StartDate
        {
            get 
            { 
                return _startdate; 
            }
            set 
            { 
                _startdate = value; 
                OnPropertyChanged(nameof(StartDate));

                ClearErrors(nameof(EndDate));

                if (EndDate < StartDate)
                {
                    AddError("The start date cannot be after the end date.", nameof(StartDate));
                }
            }
        }

        private DateTime _endDate = new DateTime(2022, 2, 4);
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));

                ClearErrors(nameof(StartDate));
                ClearErrors(nameof(EndDate));

                if (EndDate < StartDate)
                {
                    AddError("The end date cannot be before the start date.", nameof(EndDate));
                }
            }
        }

        private void AddError(string errorMessage, string propertyName)
        {
            if (!_propertyNameToErrorsDictionary.ContainsKey(propertyName))
            {
                _propertyNameToErrorsDictionary.Add(propertyName, new List<string>());
            }

            _propertyNameToErrorsDictionary[propertyName].Add(errorMessage);

            OnErrorsChanged(propertyName);
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        private readonly Dictionary<string, List<string>> _propertyNameToErrorsDictionary;

        public bool HasErrors => _propertyNameToErrorsDictionary.Any();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged; 

        public MakeReservationViewModel(HotelStore hotelStore, NavigationService reservationViewNavigationService)
        {
            SubmitCommand = new MakeReservationCommand(this, hotelStore, reservationViewNavigationService);
            CancelCommand = new NavigateCommand(reservationViewNavigationService);

            _propertyNameToErrorsDictionary = new Dictionary<string, List<string>>();
        }

        public IEnumerable GetErrors(string? propertyName)
        {
            return _propertyNameToErrorsDictionary.GetValueOrDefault(propertyName, new List<string>());
        }

        private void ClearErrors(string propertyName)
        {
            _propertyNameToErrorsDictionary.Remove(nameof(propertyName));
            OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}