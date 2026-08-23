using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    internal class Song
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public int Duration { get; set; }

        public Song(string name, string artist, int duration)
        {
            Name = name;
            Artist = artist;
            Duration = duration;
        }
    }
}
