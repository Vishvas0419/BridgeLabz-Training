using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Reviews
{
    //problem statement 1 - Flight Management System
    internal class Week4DSA
    {
        
    }

    //problem statement 1 - Flight Management System

    public class Flight
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public TimeOnly BoardingTime { get; set; }
        //public bool IsCancel {  get; set; }
        //public bool IsDelayed {  get; set; }
        public Flight(int code, string name, TimeOnly boardingTime /*,bool isCancel,bool isDelayed*/)
        {
            Code = code;
            Name = name;
            BoardingTime = boardingTime;
            //IsCancel = isCancel;
            //IsDelayed = isDelayed;
        }
    }

    public class FlightNode
    {
        public Flight Data { get; set; }
        public FlightNode Next { get; set; }
        public FlightNode Prev { get; set; }
        public FlightNode(Flight data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }


    public class FlightSystem
    {
        private FlightNode head;
        private RunwayNode runwayHead;
        private RunwayNode currentRunway;

        private Dictionary<int, Queue<Passenger>> boardingQueues = new Dictionary<int, Queue<Passenger>>();
        private Dictionary<int, PriorityQueue<Passenger, int>> priorityQueues = new Dictionary<int, PriorityQueue<Passenger, int>>();
        private Stack<int> cancellationStack = new Stack<int>();
        private Dictionary<int, Flight> flights = new Dictionary<int, Flight>();

        public void AddFlight(Flight flight) //fl ight nodes added to dll acc to boarding time
        {

            flights.Add(flight.Code, flight); //adding also to dictionary which will br further used for flights lookup

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

        public void AddRunway(int runwayNumber)// creates and add runway nodes to CLL
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
            while (temp.Next != runwayHead) //check for CLL
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
            newNode.Next = runwayHead;
        }

        public void RunwayAllocation() //uses CLL to allocate runways in a round-robin manner
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
                Console.WriteLine($"Flight {temp.Data.Code} allocated to Runway {currentRunway.RunwayNumber}");

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

        public void AddPassenger(int flightCode, Passenger passenger) //runway boarding of passengers to flights acc to priority of passengers
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
                        boardingQueues[flightCode] = new Queue<Passenger>();
                    }
                    if (passenger.IsPriority)
                    {
                        if (!priorityQueues.ContainsKey(flightCode))
                        {
                            priorityQueues[flightCode] = new PriorityQueue<Passenger, int>();
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
                PriorityQueue<Passenger, int> priorityQueue = priorityQueues[flightCode];

                while (priorityQueue.Count > 0)
                {
                    Passenger passenger = priorityQueue.Dequeue();

                    Console.WriteLine(
                        $"Priority passenger {passenger.Name} is boarding Flight {flightCode}"
                    );

                    hasPassengers = true;
                }
            }

            if (boardingQueues.ContainsKey(flightCode))
            {
                Queue<Passenger> queue = boardingQueues[flightCode];

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
        public void FlightCancellation(int flightCode) //uses stack to do undo trail and keep track of recently cancelled flight
        {
            FlightNode temp = head;

            while (temp != null)
            {
                if (temp.Data.Code == flightCode)
                {
                    cancellationStack.Push(temp.Data.Code);
                    Console.WriteLine($"Flight {temp.Data.Code} cancelled");
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
            else
            {
                Console.WriteLine("Invalid Flight Code");
            }
        }
        public void SortFlightsByCode() //acc to flight code
        {
            FlightNode temp = head;

            while (temp != null)
            {
                FlightNode next = temp.Next;

                while (next != null) //bubble sort
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
            Console.WriteLine($"Flight Code : {flight.Code}, " + $"\nFlight Name : {flight.Name}" + $"\nFlight Boarding Time : {flight.BoardingTime}"
            );
        }
    }


    public class Passenger
    {
        public int PassengerId { get; set; }
        public string Name { get; set; }
        public bool IsPriority { get; set; }
        public Passenger(int passengerId, string name, bool isPriority)
        {
            PassengerId = passengerId;
            Name = name;
            IsPriority = isPriority;
        }
    }

    public class RunwayNode
    {
        public int RunwayNumber { get; set; }
        public RunwayNode Next { get; set; }

        public RunwayNode(int runwayNumber)
        {
            RunwayNumber = runwayNumber;
            Next = null;
        }
    }

    //problem statement 2 - Product of Array Except Self

    //Return array answer where answer[i] is the product of all elements except nums[i] without using division.  
    //Constraints: n ≤ 1e5; values |nums[i]| ≤ 30; O(n), O(1) extra(excluding output).
    //Examples: Input: [1, 2, 3, 4] → [24, 12, 8, 6] Input: [-1,1,0,-3,3] → [0, 0, 9, 0, 0]
    //Hints: Prefix and suffix product passes; handle zeros


    public static class ProductExceptSelf
    {
        public static int[] productExceptSelf(int[] arr)
        {
            int[] result = new int[arr.Length];
            int zeroes = 0;
            int prod = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0) zeroes++;
                else prod *= arr[i];
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (zeroes == 1)
                {
                    if (arr[i] == 0) result[i] = prod;
                }
                else if (zeroes > 1)
                {
                    result[i] = 0;
                }
                else result[i] = prod / arr[i];
            }
            return result;
        }
    }









}
