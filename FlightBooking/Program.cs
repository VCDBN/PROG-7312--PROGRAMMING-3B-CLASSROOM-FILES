using System;
using System.Collections.Generic;

    class Program
    {
    //
        static Dictionary<string, Flight> flightSchedule = new Dictionary<string, Flight>();

        static void Main(string[] args)
        {//Setup your menu
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Flight Booking and Scheduling System");
                Console.WriteLine("1. Add a Flight");
                Console.WriteLine("2. Reserve a Ticket");
                Console.WriteLine("3. Check-In Passenger");
                Console.WriteLine("4. Exit");
            Console.WriteLine("5. Display");

            Console.Write("Select an option: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddFlight();
                            break;
                        case 2:
                            ReserveTicket();
                            break;
                        case 3:
                            CheckInPassenger();
                            break;
                        case 4:
                            isRunning = false;
                            break;
                        case 5:
                            //Display
                        default:
                            Console.WriteLine("Watch what you typing...");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Sorry my friend... Invalid input");
                }

                Console.WriteLine();
            }
        }

        static void AddFlight()
        {
            Console.Write("Enter Flight Number: ");
            string flightNumber = Console.ReadLine();

            if (!flightSchedule.ContainsKey(flightNumber))
            {
                Console.Write("Enter your Destination: ");
                string destination = Console.ReadLine();

                Console.Write("Enter Departure Date and Time (yyyy-MM-dd HH:mm): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime departureTime))
                {
                    Flight newFlight = new Flight(flightNumber, destination, departureTime);

                    flightSchedule.Add(flightNumber, newFlight);

                    Console.WriteLine("Flight added successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid date and time format.");
                }
            }
            else
            {
                Console.WriteLine("Flight with this number already exists.");
            }
        }

        static void ReserveTicket()
        {
            Console.Write("Enter Flight Number: ");
            string flightNumber = Console.ReadLine();

            if (flightSchedule.ContainsKey(flightNumber))
            {
                Flight flight = flightSchedule[flightNumber];

                Console.Write("Enter Passenger Name: ");
                string passengerName = Console.ReadLine();

                Ticket newTicket = new Ticket(passengerName, flight);
                flight.ReserveTicket(newTicket);

                Console.WriteLine("Ticket reserved successfully.");
            }
            else
            {
                Console.WriteLine("Flight not found.");
            }
        }

        static void CheckInPassenger()
        {
            Console.Write("Enter Flight Number: ");
            string flightNumber = Console.ReadLine();

            if (flightSchedule.ContainsKey(flightNumber))
            {
                Flight flight = flightSchedule[flightNumber];

                Console.Write("Enter Passenger Name: ");
                string passengerName = Console.ReadLine();

                bool checkedIn = flight.CheckInPassenger(passengerName);

                if (checkedIn)
                {
                    Console.WriteLine("Passenger checked in successfully.");
                }
                else
                {
                    Console.WriteLine("Passenger not found or already checked in.");
                }
            }
            else
            {
                Console.WriteLine("Flight not found.");
            }
        }
    }

    

  
