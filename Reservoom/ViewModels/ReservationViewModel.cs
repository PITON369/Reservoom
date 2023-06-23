using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.ViewModels
{
    public class ReservationViewModel : ViewModelBase
    {
        private readonly Reservation _reservation;

        public string RoomID        { get { return _reservation.RoomID?.ToString(); } }
        public string UserName      { get { return _reservation.UserName; } }
        public string StartDate   { get { return _reservation.StartTime.ToString("d"); } }
        public string EndDate     { get { return _reservation.EndTime.ToString("d"); } }

        public ReservationViewModel(Reservation reservation)
        {
            _reservation = reservation;
        }
    }
}