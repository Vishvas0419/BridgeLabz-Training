using System;
using System.Collections.Generic;
using System.IO;
namespace Collections_Streams
{
    public class CSV_DataHandling
    {
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

        public void WriteCsv(string filePath, List<Dictionary<string, string>> records, string[] headers)
        {
            List<string> lines = new List<string>();
            lines.Add(string.Join(",", headers));

            for (int i = 0; i < records.Count; i++)
            {
                Dictionary<string, string> record = records[i];
                List<string> values = new List<string>();

                for (int j = 0; j < headers.Length; j++)
                {
                    values.Add(record[headers[j]]);
                }

                lines.Add(string.Join(",", values));
            }

            File.WriteAllLines(filePath, lines);
        }

        public List<Dictionary<string, string>> IncreaseSalaryForDepartment(List<Dictionary<string, string>> records, string department, decimal percentage)
        {
            List<Dictionary<string, string>> updated = new List<Dictionary<string, string>>();

            for (int i = 0; i < records.Count; i++)
            {
                Dictionary<string, string> record = records[i];
                Dictionary<string, string> updatedRecord = new Dictionary<string, string>(record);

                if (record["department"] == department)
                {
                    decimal currentSalary = decimal.Parse(record["salary"]);
                    decimal newSalary = currentSalary + (currentSalary * percentage / 100m);
                    updatedRecord["salary"] = newSalary.ToString();
                }

                updated.Add(updatedRecord);
            }

            return updated;
        }
    }
}
