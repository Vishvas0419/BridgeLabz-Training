using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Reviews
{
    //Week 3 coding question 

    //Problem Statement 1 - Pyramid Arrangement

    //Given to you is an unordered / unsorted integer array of size n.Reorder the array in such a way that the largest number of the array is in the middle index of the array and the remaining numbers which are lesser than or equal to the previous element should be arranged in descending order as we move to the edges of the array ((0, n-1) index).
    //Note that as we move to the edges of the array, you will need to arrange the elements in the descending order starting from the middle index.You have to place the next largest after the largest element (the middle element) on either side of the middle element.
    //If n is even, you can consider either of the n / 2 - 1'^ or n/2t^ index as your middle element and place the largest element in either of those indexes and move towards edges from there.
    //Example:
    //Input:
    //1, 4, 3, 6, 8, 7, 9, 2, 5, 0, 12, 23, -1
    //Output:
    //-1, 1, 3, 5, 7, 9, 23, 12, 8, 6, 4, 2, 0
    //int[] pyramid(int arr[], int n) {
    //……………..your code
    //……………
    //return arr[ ]
    //}

    internal static class Week3
    {
        public static int[] pyramid(int[] arr, int n)
        {
            Array.Sort(arr);
            int[] result = new int[n];
            int middle = n / 2;
            int left = middle - 1;
            int right = middle + 1;
            result[middle] = arr[n - 1];

            for (int i = n - 2; i >= 0; i--)
            {
                if ((n - 2 - i) % 2 != 0)
                    result[left--] = arr[i];
                else
                    result[right++] = arr[i];
            }
            return result;
        }
    }

    //=========================================================

    //project 2 - moview streaming platform
    public class ViewingSession
    {
        private string username;

        private string title;
        private int year;
        private List<string> genreList;
        private double watchedPercentage;
        private DateTime timestamp;   // change int -> DateTime
        public DateTime Timestamp { get { return timestamp; } set { timestamp = value; } }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public List<string> GenreList
        {
            get { return genreList; }
            set { genreList = value; }
        }

        public double WatchedPercentage
        {
            get { return watchedPercentage; }
            set { watchedPercentage = value; }
        }

        public void display()
        {
            Console.WriteLine($"TITLE:{Title} ({Year})");
        }

    }

    public class ProfileStore<T> where T : ViewingSession
    {
        private Dictionary<string, Dictionary<string, double>> userProfiles;
        private List<T> sessions;

        public ProfileStore()
        {
            userProfiles = new Dictionary<string, Dictionary<string, double>>();
            sessions = new List<T>();   
        }

        //store session in a list and then update the userProfile (weight)
        public void AddSession(T session)
        {
            sessions.Add(session);

            if (!userProfiles.ContainsKey(session.Username))
                userProfiles[session.Username] = new Dictionary<string, double>();

            Dictionary<string, double> profile = userProfiles[session.Username];
            double weight = session.WatchedPercentage / 100.0;

            //int i = 0;
            for (int i = 0; i < session.GenreList.Count; i++)
            {
                string genre = session.GenreList[i];
                if (!profile.ContainsKey(genre))
                {
                    profile[genre] = 0;
                }
                profile[genre] = profile[genre] + weight;
            }
        }

        public Dictionary<string, double> GetProfile(string username)
        {
            if (userProfiles.ContainsKey(username))
                return userProfiles[username];
            return new Dictionary<string, double>();
        }

        public List<T> GetAllSessions()
        {
            return sessions;
        }
        //LINQ method to filter highly watched sessions
        public List<T> GetHighlyWatchedSessions(double percentage)
        {
            return sessions.Where(session => session.WatchedPercentage >= percentage)
                .ToList();
        }
    }

    //main kaam of this regex Parse class Parse() method is to convert raw string to a object and store it in a object of Viewing session (session object here) and return it
    public class RegexParse //contains Parse() method
    {
        private string pattern = @"USER:(.*?)\|TITLE:(.*?)\s*\((\d{4})\)\|GENRES:(.*?)\|WATCHED:(\d+)%\|TS:(.*)";
        public ViewingSession Parse(string input)
        {
            Match match = Regex.Match(input, pattern);
            ViewingSession session = new ViewingSession();

            if (match.Success)
            {
                session.Username = match.Groups[1].Value;
                session.Title = match.Groups[2].Value.Trim();
                session.Year = int.Parse(match.Groups[3].Value);

                List<string> genres = new List<string>();
                string[] genreParts = match.Groups[4].Value.Split(',');
                for (int i = 0; i < genreParts.Length; i++)
                {
                    genres.Add(genreParts[i].Trim());
                }
                session.GenreList = genres;

                session.WatchedPercentage = double.Parse(match.Groups[5].Value);
                session.Timestamp = DateTime.Parse(match.Groups[6].Value.Trim());
            }

            return session;
        }
    }



    //============================================================


    
    

}


