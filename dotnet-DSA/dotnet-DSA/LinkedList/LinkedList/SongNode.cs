using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    internal class SongNode
    {
        public Song Data { get; set; }
        public SongNode Next { get; set; }
        public SongNode Prev { get; set; }

        public SongNode(Song data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }
}
