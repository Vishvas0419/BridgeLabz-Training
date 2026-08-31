using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Collections_Streams
{
    public class JSON_DataHandling
    {
        public JArray ReadJson(string filePath)
        {
            string content = File.ReadAllText(filePath);
            return JArray.Parse(content);
        }

        public void WriteJson(string filePath, JArray data)
        {
            File.WriteAllText(filePath, data.ToString());
        }

        public List<Dictionary<string, string>> ReadCsv(string filePath)
        {
            List<Dictionary<string, string>> records = new List<Dictionary<string, string>>();
            string[] lines = File.ReadAllLines(filePath);
            string[] headers = lines[0].Split(',');

            for (int i = 1; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');
                Dictionary<string, string> record = new Dictionary<string, string>();

                for (int j = 0; j < headers.Length; j++)
                {
                    record[headers[j]] = fields[j];
                }

                records.Add(record);
            }

            return records;
        }

        public void WriteCsv(string filePath, List<Dictionary<string, string>> records)
        {
            List<string> lines = new List<string>();
            lines.Add("match_id,team1,team2,score_team1,score_team2,winner,player_of_match");

            for (int i = 0; i < records.Count; i++)
            {
                Dictionary<string, string> record = records[i];
                string line = record["match_id"] + "," + record["team1"] + "," + record["team2"] + "," + record["score_team1"] + "," + record["score_team2"] + "," + record["winner"] + "," + record["player_of_match"];
                lines.Add(line);
            }

            File.WriteAllLines(filePath, lines);
        }

        public string MaskTeamName(string teamName)
        {
            string[] parts = teamName.Split(' ');
            if (parts.Length <= 1)
            {
                return teamName;
            }
            return parts[0] + " ***";
        }

        public string RedactPlayer(string playerName)
        {
            return "REDACTED";
        }

        public JArray CensorJson(JArray matches)
        {
            JArray censored = new JArray();

            for (int i = 0; i < matches.Count; i++)
            {
                JObject match = (JObject)matches[i];
                JObject score = (JObject)match["score"];
                JObject maskedScore = new JObject();

                foreach (JProperty entry in score.Properties())
                {
                    maskedScore[MaskTeamName(entry.Name)] = entry.Value;
                }

                JObject censoredMatch = new JObject();
                censoredMatch["match_id"] = match["match_id"];
                censoredMatch["team1"] = MaskTeamName((string)match["team1"]);
                censoredMatch["team2"] = MaskTeamName((string)match["team2"]);
                censoredMatch["score"] = maskedScore;
                censoredMatch["winner"] = MaskTeamName((string)match["winner"]);
                censoredMatch["player_of_match"] = RedactPlayer((string)match["player_of_match"]);

                censored.Add(censoredMatch);
            }

            return censored;
        }

        public List<Dictionary<string, string>> CensorCsv(List<Dictionary<string, string>> records)
        {
            List<Dictionary<string, string>> censored = new List<Dictionary<string, string>>();

            for (int i = 0; i < records.Count; i++)
            {
                Dictionary<string, string> record = records[i];
                Dictionary<string, string> censoredRecord = new Dictionary<string, string>();

                censoredRecord["match_id"] = record["match_id"];
                censoredRecord["team1"] = MaskTeamName(record["team1"]);
                censoredRecord["team2"] = MaskTeamName(record["team2"]);
                censoredRecord["score_team1"] = record["score_team1"];
                censoredRecord["score_team2"] = record["score_team2"];
                censoredRecord["winner"] = MaskTeamName(record["winner"]);
                censoredRecord["player_of_match"] = RedactPlayer(record["player_of_match"]);

                censored.Add(censoredRecord);
            }

            return censored;
        }
    }
}
