using DSAReview;
using System;
using System.Collections.Generic;

namespace DSAReview
{
    public class FlightSystem
    {
        private FlightNode head;
        public void AddFlight(Flight flight)
        {
            FlightNode newNode = new FlightNode(flight);
            if (head == null)
            {
                head = newNode;
                return;
            }
            FlightNode temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
            newNode.Prev = temp; //ading flights at tail
        }
        public void RunwayAllocation() //using CLL to alot runway to flight
        {
            if (head == null)
            {
                Console.WriteLine("No flights available");
                return;
            }
            FlightNode temp = head;
            while (temp.Next != head)
            {
                Console.WriteLine(
                    $"Flight {temp.Data.Code} allocated to runway"
                );
                temp = temp.Next;
            }

            // Process the last node
            Console.WriteLine(
                $"Flight {temp.Data.Code} allocated to runway"
            );
        }
        public void RunwayBoarding()
        {
            FlightNode temp = head;
            Queue<Flight> boardingQueue = new Queue<Flight>();
            while (temp != null)
            {
                boardingQueue.Enqueue(temp.Data);
                temp = temp.Next;
            }
            while (boardingQueue.Count > 0) //FIFO
            {
                Flight flight = boardingQueue.Dequeue();
                Console.WriteLine($"Flight {flight.Code} is boarding");
            }
        }
        public void FlightCancellation(int flightCode)
        {
            FlightNode temp = head;
            Stack<int> st = new Stack<int>();

            while (temp != null)
            {
                if (temp.Data.Code == flightCode)
                {
                    st.Push(temp.Data.Code);
                    break;
                }
                temp = temp.Next;
            }
            if (st.Count > 0)
            {
                Console.WriteLine($"Flight {st.Pop()} cancelled");
            }
        }
        public FlightNode NavigateFlightForward(TimeOnly time)
        {
            FlightNode temp = head;

            while (temp != null)
            {
                if (temp.Data.BoardingTime == time)
                {
                    return temp.Next; 
                }

                temp = temp.Next;
            }

            return null;
        }

        public FlightNode NavigateFlightBackward(TimeOnly time)
        {
            FlightNode temp = head;

            while (temp != null)
            {
                if (temp.Data.BoardingTime == time)
                {
                    return temp.Prev;
                }

                temp = temp.Next;
            }

            return null;
        }

        public void FlightLookup(int flightCode)
        {
            Dictionary<int, Flight> flights =
                new Dictionary<int, Flight>();

            FlightNode temp = head;
            while (temp != null)
            {
                flights.Add(temp.Data.Code, temp.Data);
                temp = temp.Next;
            }

            if (flights.ContainsKey(flightCode))
            {
                DisplayFlightDetails(flights[flightCode]);
            }
        }
        public void SortFlights() //acc to flight code
        {
            FlightNode temp = head;

            while (temp != null)
            {
                FlightNode next = temp.Next;

                while (next != null)
                {
                    if (temp.Data.Code > next.Data.Code)
                    {
                        Flight temporary = temp.Data;
                        temp.Data = next.Data;
                        next.Data = temporary;
                    }

                    next = next.Next;
                }

                temp = temp.Next;
            }
        }
        //bs acc to flight code
        public void BinarySearch(Flight flight)
        {
            List<Flight> flights = new List<Flight>();

            FlightNode temp = head;

            while (temp != null)
            {
                flights.Add(temp.Data);
                temp = temp.Next;
            }

            int low = 0;
            int high = flights.Count - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (flights[mid].Code == flight.Code)
                {
                    DisplayFlightDetails(flights[mid]);
                    return;
                }
                else if (flights[mid].Code < flight.Code)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
        }

        public void DisplayFlightDetails(Flight flight)
        {
            Console.WriteLine("Flight Details : ");
            Console.WriteLine($"Flight Code : {flight.Code}, " +$"\nFlight Name : {flight.Name}" + $"\nFlight Boarding Time : {flight.BoardingTime}"
            );
        }
    }
}