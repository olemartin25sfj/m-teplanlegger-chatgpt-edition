using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        MeetingManager meetingManager = new MeetingManager();

        while (true)
        {
            Console.WriteLine("\nMøteplanlegger");
            Console.WriteLine("1. Planlegg nytt møte");
            Console.WriteLine("2. Vis planlagte møter");
            Console.WriteLine("3. Slett møte");
            Console.WriteLine("4. Avslutt");
            Console.Write("Velg et alternativ: ");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    Console.Write("Skriv inn møtetittel: ");
                    string title = Console.ReadLine() ?? "Ukjent møte";

                    Console.Write("Skriv inn deltakere (kommaseparert): ");
                    string participantsInput = Console.ReadLine() ?? "";
                    List<string> participants = new List<string>(participantsInput.Split(',', StringSplitOptions.RemoveEmptyEntries));

                    Console.Write("Skriv inn møtetidspunkt (YYYY-MM-DD HH:MM): ");
                    DateTime meetingTime;
                    while (!DateTime.TryParse(Console.ReadLine(), out meetingTime))
                    {
                        Console.Write("Feil format. Prøv igjen (YYYY-MM-DD HH:MM): ");
                    }

                    meetingManager.ScheduleMeeting(title, participants, meetingTime);
                    break;

                case "2":
                    meetingManager.ShowScheduledMeetings();
                    break;

                case "3":
                    Console.Write("Skriv inn tittelen på møtet du vil slette: ");
                    string deleteTitle = Console.ReadLine() ?? "";
                    meetingManager.DeleteMeeting(deleteTitle);
                    break;

                case "4":
                    Console.WriteLine("Avslutter...");
                    return;

                default:
                    Console.WriteLine("Ugyldig valg, prøv igjen.");
                    break;
            }
        }
    }
}