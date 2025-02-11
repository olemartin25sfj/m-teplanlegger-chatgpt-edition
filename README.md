Møteplanlegger laget av ChatGPT.
Lager møter med tittel, deltakere, tid og dato.

+-------------------+
|    Program       |
+-------------------+
| - Main()         |
+-------------------+
| - Håndterer brukerinput og menyvalg |
+-------------------+

+-------------------+
| MeetingManager   |
+-------------------+
| + Meetings: List<Meeting> |
+-------------------+
| + ScheduleMeeting(title: string, participants: List<string>, time: DateTime) |
| + ShowScheduledMeetings() |
| + DeleteMeeting(title: string) |
+-------------------+

+-------------------+
|      Meeting      |
+-------------------+
| + Title: string   |
| + Participants: List<string> |
| + MeetingTime: DateTime |
+-------------------+
| + SaveToFile()    |
+-------------------+
