using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


public class Meeting
{
    public string Title { get; set; }
    public List<string> Participants { get; set; }
    public DateTime MeetingTime { get; set; }

    public Meeting(string title, List<string> participants, DateTime meetingTime)
    {
        Title = title;
        Participants = participants;
        MeetingTime = meetingTime;
    }

    public void SaveToFile()
    {
        List<Meeting> meetings = new List<Meeting>();

        if (File.Exists("meetings.json"))
        {
            string existingData = File.ReadAllText("meetings.json");

            if (!string.IsNullOrWhiteSpace(existingData))
            {
                try
                {
                    meetings = JsonConvert.DeserializeObject<List<Meeting>>(existingData) ?? new List<Meeting>();
                }
                catch
                {
                    Console.WriteLine("Feil ved lesing av eksisterende møter. Filen kan være korrupt.");
                }
            }
        }

        meetings.Add(this);

        File.WriteAllText("meetings.json", JsonConvert.SerializeObject(meetings, Formatting.Indented));
    }

}
