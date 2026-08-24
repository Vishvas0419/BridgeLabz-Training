using DSAReview;
using System;
using System.Collections.Generic;

namespace DSAReview
{
    public class FlightSystem
    {
        private FlightNode head;
        private RunwayNode runwayHead;
        private RunwayNode currentRunway;

        private Dictionary<int, Queue<Passenger>> boardingQueues
    = new Dictionary<int, Queue<Passenger>>();

        private Dictionary<int, PriorityQueue<Passenger, int>> priorityQueues
    = new Dictionary<int, PriorityQueue<Passenger, int>>();

        private Stack<int> cancellationStack = new Stack<int>();

        private Dictionary<int, Flight> flights =
    new Dictionary<int, Flight>();

        public void AddFlight(Flight flight) //flight nodes added acc to boarding time
        {

            flights.Add(flight.Code, flight); //adding also to dictionary

            FlightNode newNode = new FlightNode(flight);

            if (head == null)
            {
                head = newNode;
                return;
            }

            FlightNode temp = head;

            while (temp.Next != null &&
                   temp.Data.BoardingTime < flight.BoardingTime)
            {
                temp = temp.Next;
            }

            // Add at beginning
            if (temp == head &&
                temp.Data.BoardingTime > flight.BoardingTime)
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
                return;
            }

            // Add at end
            if (temp.Next == null &&
                temp.Data.BoardingTime < flight.BoardingTime)
            {
                temp.Next = newNode;
                newNode.Prev = temp;
                return;
            }

            // Add in the middle
            newNode.Next = temp;
            newNode.Prev = temp.Prev;
            temp.Prev.Next = newNode;
            temp.Prev = newNode;
        }

        public void AddRunway(int runwayNumber)
        {
            RunwayNode newNode = new RunwayNode(runwayNumber);

            if (runwayHead == null)
            {
                runwayHead = newNode;
                newNode.Next = runwayHead;
                currentRunway = runwayHead;
                return;
            }

            RunwayNode temp = runwayHead;

            while (temp.Next != runwayHead)
            {
                temp = temp.Next;
            }

            temp.Next = newNode;
            newNode.Next = runwayHead;
        }

        //changed RUnway Allocation
        public void RunwayAllocation()
        {
            if (head == null)
            {
                Console.WriteLine("No flights available");
                return;
            }

            if (runwayHead == null)
            {
                Console.WriteLine("No runway available");
                return;
            }

            FlightNode temp = head;

            while (temp != null)
            {
                Console.WriteLine(
                    $"Flight {temp.Data.Code} allocated to Runway {currentRunway.RunwayNumber}"
                );

                currentRunway = currentRunway.Next;
                temp = temp.Next;
            }
        }

        //public void RunwayAllocation() //using CLL to alot runway to flight
        //{
        //    if (head == null)
        //    {
        //        Console.WriteLine("No flights available");
        //        return;
        //    }
        //    FlightNode temp = head;
        //    while (temp.Next != head)
        //    {
        //        Console.WriteLine(
        //            $"Flight {temp.Data.Code} allocated to runway"
        //        );
        //        temp = temp.Next;
        //    }

        //    // Process the last node
        //    Console.WriteLine(
        //        $"Flight {temp.Data.Code} allocated to runway"
        //    );
        //}

        public void AddPassenger(int flightCode, Passenger passenger)
        {
            if (head == null)
            {
                Console.WriteLine("No flights available");
                return;
            }

            FlightNode temp = head;

            while (temp != null)
            {
                if (temp.Data.Code == flightCode)
                {
                    if (!boardingQueues.ContainsKey(flightCode))
                    {
                        boardingQueues[flightCode] =
                            new Queue<Passenger>();
                    }

                    if (passenger.IsPriority)
                    {
                        if (!priorityQueues.ContainsKey(flightCode))
                        {
                            priorityQueues[flightCode] =
                                new PriorityQueue<Passenger, int>();
                        }

                        priorityQueues[flightCode].Enqueue(passenger, 1);
                    }
                    else
                    {
                        if (!boardingQueues.ContainsKey(flightCode))
                        {
                            boardingQueues[flightCode] =
                                new Queue<Passenger>();
                        }

                        boardingQueues[flightCode].Enqueue(passenger);
                    }

                    Console.WriteLine(
                        $"Passenger {passenger.Name} added to Flight {flightCode} boarding queue"
                    );
                    //boardingQueues[flightCode].Enqueue(passenger);

                    //Console.WriteLine(
                    //    $"Passenger {passenger.Name} added to Flight {flightCode} boarding queue"
                    //);

                    return;
                }

                temp = temp.Next;
            }

            Console.WriteLine("Invalid Flight Code");
        }

        public void RunwayBoarding(int flightCode) //boarding passengers to a specific flight  acc to their priority
        {
            bool hasPassengers = false;

            if (priorityQueues.ContainsKey(flightCode))
            {
                PriorityQueue<Passenger, int> priorityQueue =
                    priorityQueues[flightCode];

                while (priorityQueue.Count > 0)
                {
                    Passenger passenger =
                        priorityQueue.Dequeue();

                    Console.WriteLine(
                        $"Priority passenger {passenger.Name} is boarding Flight {flightCode}"
                    );

                    hasPassengers = true;
                }
            }

            if (boardingQueues.ContainsKey(flightCode))
            {
                Queue<Passenger> queue =
                    boardingQueues[flightCode];

                while (queue.Count > 0)
                {
                    Passenger passenger = queue.Dequeue();

                    Console.WriteLine(
                        $"Passenger {passenger.Name} is boarding Flight {flightCode}"
                    );

                    hasPassengers = true;
                }
            }

            if (!hasPassengers)
            {
                Console.WriteLine("Boarding queue is empty");
            }
        }

        //public void RunwayBoarding(int flightCode)
        //{
        //    if (!boardingQueues.ContainsKey(flightCode)) //edge case handled
        //    {
        //        Console.WriteLine("Boarding queue is empty");
        //        return;
        //    }

        //    Queue<Passenger> queue = boardingQueues[flightCode];

        //    if (queue.Count == 0)
        //    {
        //        Console.WriteLine("Boarding queue is empty");
        //        return;
        //    }

        //    while (queue.Count > 0)
        //    {
        //        Passenger passenger = queue.Dequeue();

        //        Console.WriteLine(
        //            $"Passenger {passenger.Name} is boarding Flight {flightCode}"
        //        );
        //    }
        //}

        //public void RunwayBoarding()
        //{
        //    FlightNode temp = head;
        //    Queue<Flight> boardingQueue = new Queue<Flight>();
        //    while (temp != null)
        //    {
        //        boardingQueue.Enqueue(temp.Data);
        //        temp = temp.Next;
        //    }
        //    while (boardingQueue.Count > 0) //FIFO
        //    {
        //        Flight flight = boardingQueue.Dequeue();
        //        Console.WriteLine($"Flight {flight.Code} is boarding");
        //    }
        //}
        public void FlightCancellation(int flightCode)
        {
            FlightNode temp = head;

            while (temp != null)
            {
                if (temp.Data.Code == flightCode)
                {
                    cancellationStack.Push(temp.Data.Code);

                    Console.WriteLine(
                        $"Flight {temp.Data.Code} cancelled"
                    );

                    return;
                }

                temp = temp.Next;
            }

            Console.WriteLine("Invalid Flight Code");
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

        public void FlightLookup(int flightCode) //using dictionary
        {
            if (flights.ContainsKey(flightCode))
            {
                DisplayFlightDetails(flights[flightCode]);
            }
            else{
                Console.WriteLine("Invalid Flight Code");
            }
        }
        public void SortFlightsByCode() //acc to flight code
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

        public void SortFlightsByTime()
        {
            FlightNode temp = head;

            while (temp != null)
            {
                FlightNode next = temp.Next;

                while (next != null)
                {
                    if (temp.Data.BoardingTime > next.Data.BoardingTime)
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
        public void BinarySearch(int flightCode)
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

                if (flights[mid].Code == flightCode)
                {
                    DisplayFlightDetails(flights[mid]);
                    return;
                }
                else if (flights[mid].Code < flightCode)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            Console.WriteLine("Invalid Flight Code");
        }

        public void DisplayFlightDetails(Flight flight)
        {
            Console.WriteLine("Flight Details : ");
            Console.WriteLine($"Flight Code : {flight.Code}, " +$"\nFlight Name : {flight.Name}" + $"\nFlight Boarding Time : {flight.BoardingTime}"
            );
        }
    }
}