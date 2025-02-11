using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class MeetingManager
{
    public List<Meeting> Meetings { get; set; } = new List<Meeting>();

    public void ScheduleMeeting(string title, List<string> participants, DateTime time)
    {
        Meeting meeting = new Meeting(title, participants, time);
        Meetings.Add(meeting);
        meeting.SaveToFile();  // Lagre møte i fil
        Console.WriteLine("Møte lagret!");
    }

    public void ShowScheduledMeetings()
    {
        if (File.Exists("meetings.json"))
        {
            string json = File.ReadAllText("meetings.json");

            // Prøv å deserialisere JSON som en liste
            List<Meeting>? meetings = JsonConvert.DeserializeObject<List<Meeting>>(json);

            if (meetings == null || meetings.Count == 0)
            {
                Console.WriteLine("Ingen planlagte møter.");
                return;
            }

            foreach (var meeting in meetings)
            {
                Console.WriteLine($"Tittel: {meeting.Title}");
                Console.WriteLine($"Deltakere: {string.Join(", ", meeting.Participants)}");
                Console.WriteLine($"Tidspunkt: {meeting.MeetingTime:yyyy-MM-dd HH:mm}");
                Console.WriteLine("------------------------------------");
            }
        }
        else
        {
            Console.WriteLine("Ingen planlagte møter.");
        }
    }

    public void DeleteMeeting(string title)
    {
        if (!File.Exists("meetings.json"))
        {
            Console.WriteLine("Ingen møter funnet.");
            return;
        }

        string json = File.ReadAllText("meetings.json");
        List<Meeting>? meetings = JsonConvert.DeserializeObject<List<Meeting>>(json) ?? new List<Meeting>();

        // Filtrer ut møtet som skal slettes
        int beforeCount = meetings.Count;
        meetings.RemoveAll(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (meetings.Count == beforeCount)
        {
            Console.WriteLine($"Fant ikke noe møte med tittelen \"{title}\".");
        }
        else
        {
            File.WriteAllText("meetings.json", JsonConvert.SerializeObject(meetings, Formatting.Indented));
            Console.WriteLine($"Møte \"{title}\" er slettet.");
        }
    }

}

