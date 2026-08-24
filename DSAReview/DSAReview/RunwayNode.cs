using System;
using System.Collections.Generic;
using System.Text;

namespace DSAReview
{
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
}
