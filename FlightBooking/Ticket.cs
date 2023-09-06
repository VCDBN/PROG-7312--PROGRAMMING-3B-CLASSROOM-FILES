
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Ticket
{
    public string PassengerName { get; }
    public Flight Flight { get; }
    public bool IsCheckedIn { get; set; }

    public Ticket(string passengerName, Flight flight)
    {
        PassengerName = passengerName;
        Flight = flight;
        IsCheckedIn = false;
    }
}
