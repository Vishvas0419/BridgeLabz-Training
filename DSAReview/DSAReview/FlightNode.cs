using System;
using System.Collections.Generic;
using System.Text;

namespace DSAReview
{
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
}
