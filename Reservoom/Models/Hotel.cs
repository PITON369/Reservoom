﻿using System;
using Reservoom.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class Hotel
    {
        private readonly ReservationBook _reservationBook;

        public string Name { get; }

        public Hotel(string name, ReservationBook reservationBook)
        {
            Name = name;
            _reservationBook = reservationBook;
        }

        /// <summary>
        /// Get the reservations for a user.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>The reservations for the user.</returns>
        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _reservationBook.GetAllReservations();
        }

        /// <summary>
        ///  Make a reservation.
        /// </summary>
        /// <param name="reservation">The incoming reservation.</param>
        public async Task MakeReservation(Reservation reservation)
        {
            _reservationBook.AddReservation(reservation);
        }
    }
}