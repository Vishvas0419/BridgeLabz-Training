using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
//@"USER:(?<Username>[^|]+)\|TITLE:(?<Title>.+?)\s*\((?<Year>\d{4})\)\|GENRES:(?<Genres>[^|]+)\|WATCHED:(?<Watched>\d+)%\|TS:(?<Timestamp>[^|]+)"

namespace Reviews
{
    internal class Week3
    {

    }

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
    }

    public class RegexParse
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
}


