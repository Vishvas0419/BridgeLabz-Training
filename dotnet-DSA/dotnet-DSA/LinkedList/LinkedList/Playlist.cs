using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    internal class Playlist
    {
        private SongNode head;
        private SongNode current;

        public void AddAtBegin(Song song)
        {
            SongNode newNode = new SongNode(song);

            if (head == null)
            {
                head = newNode;
                head.Next = head;
                head.Prev = head;
                current = head;
                return;
            }

            SongNode tail = head.Prev;

            newNode.Next = head;
            newNode.Prev = tail;
            tail.Next = newNode;
            head.Prev = newNode;
            head = newNode;
        }

        public void AddAtEnd(Song song)
        {
            if (head == null)
            {
                AddAtBegin(song);
                return;
            }

            SongNode newNode = new SongNode(song);
            SongNode tail = head.Prev;

            tail.Next = newNode;
            newNode.Prev = tail;
            newNode.Next = head;
            head.Prev = newNode;
        }

        public void AddAtPosition(Song song, int pos)
        {
            if (pos == 1 || head == null)
            {
                AddAtBegin(song);
                return;
            }

            SongNode temp = head;
            int cnt = 1;

            while (cnt < pos - 1 && temp.Next != head)
            {
                temp = temp.Next;
                cnt++;
            }

            SongNode newNode = new SongNode(song);
            newNode.Next = temp.Next;
            newNode.Prev = temp;
            temp.Next.Prev = newNode;
            temp.Next = newNode;
        }

        public void DeleteByName(string name)
        {
            if (head == null) return;

            SongNode temp = head;

            do
            {
                if (temp.Data.Name == name)
                {
                    if (temp.Next == temp)
                    {
                        head = null;
                        current = null;
                        return;
                    }

                    temp.Prev.Next = temp.Next;
                    temp.Next.Prev = temp.Prev;

                    if (temp == head)
                    {
                        head = temp.Next;
                    }
                    if (temp == current)
                    {
                        current = temp.Next;
                    }
                    return;
                }
                temp = temp.Next;
            } while (temp != head);

            Console.WriteLine("Song not found!");
        }

        public void PlayNext()
        {
            if (current == null) return;
            current = current.Next;
            Console.WriteLine($"Now playing: {current.Data.Name} - {current.Data.Artist}");
        }

        public void PlayPrevious()
        {
            if (current == null) return;
            current = current.Prev;
            Console.WriteLine($"Now playing: {current.Data.Name} - {current.Data.Artist}");
        }

        public void Display()
        {
            if (head == null)
            {
                Console.WriteLine("Playlist is empty");
                return;
            }

            SongNode temp = head;
            do
            {
                Console.WriteLine($"{temp.Data.Name} - {temp.Data.Artist} ({temp.Data.Duration}s)");
                temp = temp.Next;
            } while (temp != head);
        }
    }
}
