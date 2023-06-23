using System;

namespace Reservoom.Models
{
    public class Reservation
    {
        public RoomID RoomID { get; }
        public string UserName { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public TimeSpan Length { get { return EndTime.Subtract(StartTime); } }

        public Reservation(RoomID roomID, string userName, DateTime startTime, DateTime endTime) 
        { 
            UserName = userName;
            RoomID = roomID;
            StartTime = startTime;
            EndTime = endTime;
        }

        public bool Conflicts(Reservation reservation)
        {
            if(reservation.RoomID != RoomID)
                return false; 

            return reservation.StartTime < EndTime && reservation.EndTime > StartTime;
        }
    }
}