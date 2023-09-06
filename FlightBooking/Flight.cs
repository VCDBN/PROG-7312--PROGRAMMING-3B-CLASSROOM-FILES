using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Flight
    {
        public string FlightNumber { get; }
        public string Destination { get; }
        public DateTime DepartureTime { get; }

        private List<Ticket> passengerList;

        public Flight(string flightNumber, string destination, DateTime departureTime)
        {
            FlightNumber = flightNumber;
            Destination = destination;
            DepartureTime = departureTime;
            passengerList = new List<Ticket>();
        }

        public void ReserveTicket(Ticket ticket)
        {
            passengerList.Add(ticket);
        }

        public bool CheckInPassenger(string passengerName)
        {
            foreach (Ticket ticket in passengerList)
            {
                if (ticket.PassengerName == passengerName && !ticket.IsCheckedIn)
                {
                    ticket.IsCheckedIn = true;
                    return true;
                }
            }
            return false;
        }
    }

